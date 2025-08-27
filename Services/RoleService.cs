using SurveyBasket.Abstractions.Consts;
using SurveyBasket.Contracts.Roles;
using System.Collections;

namespace SurveyBasket.Services
{
    public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable> GetAllAsync(bool? includeDisabled = false, CancellationToken cancellationToken = default) =>
            await _roleManager.Roles
            .Where(r => !r.IsDefault && (!r.IsDeleted || (includeDisabled.HasValue && includeDisabled.Value)))
            .ProjectToType<RoleResponse>()
            .ToListAsync(cancellationToken);

    public async Task<Result<RoleDetailResponse>> GetAsync(string id)
        {
            if(await _roleManager.FindByIdAsync(id) is not { } role)
                return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

            var permissions = await _roleManager.GetClaimsAsync(role);

            var response = new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(p => p.Value));
            return Result.Success(response);
        }

        public async Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request)
        {
            var roleIsExists = await _roleManager.RoleExistsAsync(request.Name);

            if(roleIsExists)
                return Result.Failure<RoleDetailResponse>(RoleErrors.RoleAlreadyExists);

            var allowedPermissions = Permissions.GetAllPermissions();
            if(request.Permissions.Except(allowedPermissions).Any())
                return Result.Failure<RoleDetailResponse>(RoleErrors.InvalidPermissions);

            var role = new ApplicationRole
            {
                Name = request.Name,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            var result = await _roleManager.CreateAsync(role);

            if(!result.Succeeded)
            {
                var permissions = request.Permissions
                    .Select(p => new IdentityRoleClaim<string>
                    {
                        ClaimType = Permissions.Type,
                        ClaimValue = p,
                        RoleId = role.Id

                    });
                await _context.AddRangeAsync(permissions);
                await _context.SaveChangesAsync();

                var response = new RoleDetailResponse(role.Id, role.Name, role.IsDeleted, request.Permissions);
                return Result.Success(response);
            }   
            var error = result.Errors.First();
            return Result.Failure<RoleDetailResponse>(new Error( error.Code, error.Description, StatusCodes.Status400BadRequest ));
        }
    }
}