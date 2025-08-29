using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Abstractions.Consts;
using SurveyBasket.Authentication.Filters;
using SurveyBasket.Contracts.Users;

namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("")]
        [HasPermission(Permissions.GetUsers)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var users = await _userService.GetAllAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [HasPermission(Permissions.GetUsers)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = await _userService.GetUserAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost("")]
        [HasPermission(Permissions.AddUsers)]
        public async Task<IActionResult> Add([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.AddAsync(request, cancellationToken);
            return result.IsSuccess? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProblem();
        }
    }
}
