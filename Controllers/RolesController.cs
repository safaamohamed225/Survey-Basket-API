﻿
namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;
        [HttpGet("")]
        public async Task<IActionResult> GetAll([FromQuery] bool? includeDisabled, CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllAsync(includeDisabled, cancellationToken);
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
           var result = await _roleService.GetAsync(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

    }
}
