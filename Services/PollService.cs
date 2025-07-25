﻿
using Azure.Core;

namespace SurveyBasket.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
   private readonly ApplicationDbContext _context=context;
    public async Task<IEnumerable<PollResponse>> GetPollsAsync(CancellationToken cancellationToken = default) =>
            await _context.Polls
            .AsNoTracking()
            .ProjectToType<PollResponse>()
            .ToListAsync(cancellationToken);
    public async Task<IEnumerable<PollResponse>> GetCurrentAsync(CancellationToken cancellationToken = default)=>
    
        await _context.Polls
           .AsNoTracking()
        .Where(x=>x.IsPublished == true && x.StartsAt <= DateOnly.FromDateTime( DateTime.UtcNow)
                                        && x.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow))
           .ProjectToType<PollResponse>()
           .ToListAsync(cancellationToken);

    
    public async Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll=await _context.Polls.FindAsync(id, cancellationToken);

        return poll is not null
            ? Result.Success(poll.Adapt<PollResponse>())
            : Result.Failure <PollResponse>(PollErrors.PollNotFound);
    }
    public async Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default)
    {
        var isExistingTitle = await _context.Polls.AnyAsync(x => x.Title == request.Title, cancellationToken: cancellationToken);
        if(isExistingTitle)
             return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

        var poll = request.Adapt<Poll>();

        await _context.AddAsync(poll, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(poll.Adapt<PollResponse>());
    }

    public async Task<Result> UpdateAsync(int id, PollRequest request, CancellationToken cancellationToken = default)
    {
        var isExistingTitle = await _context.Polls.AnyAsync(x => x.Title == request.Title && x.Id!=id, cancellationToken: cancellationToken);

        var currentPoll = await _context.Polls.FindAsync(id, cancellationToken);

        if (currentPoll is null)
            return Result.Failure(PollErrors.PollNotFound);

        currentPoll.Title = request.Title;
        currentPoll.Summary = request.Summary;
        currentPoll.StartsAt = request.StartsAt;
        currentPoll.EndsAt = request.EndsAt;

        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        if (poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        _context.Remove(poll);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var poll = await _context.Polls.FindAsync(id, cancellationToken);

        if (poll is null)
            return Result.Failure(PollErrors.PollNotFound);

        poll.IsPublished = !poll.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
