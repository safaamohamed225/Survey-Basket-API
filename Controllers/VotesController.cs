using Microsoft.AspNetCore.Authorization;

namespace SurveyBasket.Controllers;
[Route("api/polls/{pollId}/vote")]
[ApiController]
[Authorize]
public class VotesController(IQuestionService questionService) : ControllerBase
{
    public IQuestionService _questionService { get; } = questionService;

    [HttpGet("")]

    public async Task<IActionResult> Start([FromRoute] int pollId, CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();
        var result = await _questionService.GetAvailableAsync(pollId, userId!, cancellationToken);
        if (result.IsSuccess)
            return Ok(result.Value);
        return result.Error.Equals(VoteErrors.DuplicatedVote)
            ? result.ToProblem(StatusCodes.Status409Conflict)
            : result.ToProblem(StatusCodes.Status404NotFound);
    }

}
