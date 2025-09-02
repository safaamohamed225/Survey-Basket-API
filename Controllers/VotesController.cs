using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RateLimiting;
using SurveyBasket.Abstractions.Consts;
using SurveyBasket.Contracts.Votes;

namespace SurveyBasket.Controllers;

[Route("api/polls/{pollId}/vote")]
[ApiController]
[Authorize(DefaultRoles.Member)]
[EnableRateLimiting(Limiter.Concurrency)]
public class VotesController(IQuestionService questionService, IVoteService voteService) : ControllerBase
{
    private readonly IQuestionService _questionService = questionService;
    private readonly IVoteService _voteService = voteService;

    [HttpGet("")]
    [OutputCache(PolicyName ="Polls")]
    public async Task<IActionResult> Start([FromRoute] int pollId, CancellationToken cancellationToken)
    {
        var userId = "426fcde1-88e1-4e27-8788-dcec2acb2488"; //User.GetUserId();

        var result = await _questionService.GetAvailableAsync(pollId, userId!, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

    }

    [HttpPost("")]
    public async Task<IActionResult> Vote([FromRoute] int pollId, [FromBody] VoteRequest request, CancellationToken cancellationToken)
    {
        var result = await _voteService.AddAsync(pollId, User.GetUserId()!, request, cancellationToken);

        return result.IsSuccess ? Created() : result.ToProblem();
    }
}