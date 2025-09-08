using SurveyBasket.Abstractions.Consts;
using SurveyBasket.Contracts.Roles;
using System.Collections;

namespace SurveyBasket.Services
{
    public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
            await _roleManager.Roles
            .Where(r => !r.IsDefault && (!r.IsDeleted || includeDisabled))
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
                ConcurrencyStamp = Guid.CreateVersion7().ToString()
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

        public async Task<Result> UpdateAsync(string id, RoleRequest request)
        {
            var roleIsExists = await _roleManager.Roles.AnyAsync(r=>r.Name == request.Name && r.Id != id);

            if (roleIsExists)
                return Result.Failure<RoleDetailResponse>(RoleErrors.RoleAlreadyExists);
            if(await _roleManager.FindByIdAsync(id) is not { } role)
                return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

            var allowedPermissions = Permissions.GetAllPermissions();
            if (request.Permissions.Except(allowedPermissions).Any())
                return Result.Failure<RoleDetailResponse>(RoleErrors.InvalidPermissions);

            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);

           if(result.Succeeded)
            {
                var existingPermissions = await _context.RoleClaims
                    .Where(c => c.RoleId == role.Id && c.ClaimType == Permissions.Type)
                    .Select(c => c.ClaimValue)
                    .ToListAsync();

                var permissionsToAdd = request.Permissions.Except(existingPermissions)
                    .Select(p => new IdentityRoleClaim<string>
                    {
                        ClaimType = Permissions.Type,
                        ClaimValue = p,
                        RoleId = role.Id
                    }).ToList();

                var permissionsToRemove = existingPermissions.Except(request.Permissions);

                await _context.RoleClaims
                    .Where(c => c.RoleId == role.Id && permissionsToRemove.Contains(c.ClaimValue))
                    .ExecuteDeleteAsync();

                await _context.AddRangeAsync(permissionsToAdd);
                await _context.SaveChangesAsync();
                
                return Result.Success();

            }
            var error = result.Errors.First();
            return Result.Failure<RoleDetailResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
        }

        public async Task<Result> ToggleStatusAsync(string id)
        {
            if (await _roleManager.FindByIdAsync(id) is not { } role)
                return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);

            role.IsDeleted = !role.IsDeleted;

            await _roleManager.UpdateAsync(role);
            return Result.Success();
        }
    }
}