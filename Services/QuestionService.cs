using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Caching.Hybrid;
using SurveyBasket.Contracts.Answers;
using SurveyBasket.Contracts.Common;
using SurveyBasket.Contracts.Questions;
using System.Collections.Generic;
using System.Threading;

namespace SurveyBasket.Services;

public class QuestionService(ApplicationDbContext context, HybridCache hybridCache , ILogger<QuestionService> logger) : IQuestionService
{
    private readonly ApplicationDbContext _context = context;
    private readonly HybridCache _hybridCache = hybridCache;
    private readonly ILogger<QuestionService> _logger = logger;
    private const string _cachePrefix = "availableQuestion"; 

    public async Task<Result<PaginatedList<QuestionResponse>>> GetAllAsync(int pollId, RequestFilters filters, CancellationToken cancellationToken)
    {
        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollIsExists)
            return Result.Failure<PaginatedList<QuestionResponse>>(PollErrors.PollNotFound);

        var query = _context.Questions
            .Where(x => x.PollId == pollId && (string.IsNullOrEmpty(filters.SearchTerm) || x.Content.Contains(filters.SearchTerm)))
            .Include(x => x.Answers)
            .ProjectToType<QuestionResponse>()
            .AsNoTracking();

        var questions = await PaginatedList<QuestionResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(questions);

    }

    public async Task<Result<QuestionResponse>> GetAsync(int pollId, int id, CancellationToken cancellationToken)
    {
        var question = await _context.Questions
            .Where(x => x.PollId == pollId && x.Id == id)
            .Include(x => x.Answers)
            .ProjectToType<QuestionResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
        if (question is null)
            return Result.Failure<QuestionResponse>(QuestionErrors.QuestionNotFound);

        return Result.Success(question);
    }

    public async Task<Result<IEnumerable<QuestionResponse>>> GetAvailableAsync(int pollId, string userId, CancellationToken cancellationToken)
    {
        var hasVote = await _context.Votes.AnyAsync(x => x.PollId == pollId && x.UserId == userId, cancellationToken);
        if (hasVote)
            return Result.Failure<IEnumerable<QuestionResponse>>(VoteErrors.DuplicatedVote);
        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId && x.IsPublished && x.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);

        if (!pollIsExists)
            return Result.Failure<IEnumerable<QuestionResponse>>(PollErrors.PollNotFound);


        var cacheKey = $"{_cachePrefix} - {pollId}";

        var questions = await _hybridCache.GetOrCreateAsync<IEnumerable<QuestionResponse>>(
            cacheKey,
            async cachEntry =>
                await _context.Questions
                  .Where(q => q.PollId == pollId && q.IsActive)
                  .Include(a => a.Answers)
                  .Select(q => new QuestionResponse
                  (
                      q.Id,
                      q.Content,
                      q.Answers.Where(a => a.IsActive).Select(a => new Contracts.Answers.AnswerResponse(a.Id, a.Content))
                  )).AsNoTracking().ToListAsync(cancellationToken)    
            );

        return Result.Success(questions!);
    }

    public async Task<Result<QuestionResponse>> AddAsync(int pollId, QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var pollIsExists = await _context.Polls.AnyAsync(x => x.Id == pollId, cancellationToken);

        if (!pollIsExists)
            return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

        var questionIsExists = await _context.Questions.AnyAsync(x => x.Content == request.Content && x.PollId == pollId, cancellationToken);
        if (questionIsExists)
            return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionContent);

        var question = request.Adapt<Question>();
        question.PollId = pollId;

        await _context.AddAsync(question, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        await _hybridCache.RemoveAsync($"{_cachePrefix} - {pollId}");

        return Result.Success(question.Adapt<QuestionResponse>());
    }

    public async Task<Result> UpdateAsync(int pollId, int id, QuestionRequest request, CancellationToken cancellationToken = default)
    {
        var questionIsExists = await _context.Questions
            .AnyAsync(x => x.PollId == pollId
            && x.Id != id
            && x.Content == request.Content
            , cancellationToken
            );
        if (questionIsExists)
            return Result.Failure(QuestionErrors.DuplicatedQuestionContent);
        var question = await _context.Questions
            .Include(x => x.Answers)
            .SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == id, cancellationToken);

        if (question is null)
            return Result.Failure(QuestionErrors.QuestionNotFound);

        question.Content = request.Content;

        //Current Answers (inside DB)
        var currentAnswers = question.Answers.Select(x => x.Content).ToList();

        //Add New Answers (Not inside DB)
        var newAnswers = request.Answers.Except(currentAnswers).ToList();

        newAnswers.ForEach(answer =>
        {
            question.Answers.Add(new Answer { Content = answer });
        });

        question.Answers.ToList().ForEach(answer =>
        {
            answer.IsActive = request.Answers.Contains(answer.Content);
        });

        await _context.SaveChangesAsync(cancellationToken);
        await _hybridCache.RemoveAsync($"{_cachePrefix} - {pollId}");

        return Result.Success();
    }
    public async Task<Result> ToggleStatusAsync(int pollId, int id, CancellationToken cancellationToken = default)
    {
        var question = await _context.Questions.SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == id, cancellationToken);

        if (question is null)
            return Result.Failure(QuestionErrors.QuestionNotFound);

        question.IsActive = !question.IsActive;

        await _context.SaveChangesAsync(cancellationToken);
        await _hybridCache.RemoveAsync($"{_cachePrefix} - {pollId}");

        return Result.Success();
    }
}
