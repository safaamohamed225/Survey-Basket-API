using SurveyBasket.Contracts.Roles;
using System.Collections;

namespace SurveyBasket.Services
{
    public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

        public async Task<IEnumerable> GetAllAsync(bool? includeDisabled = false, CancellationToken cancellationToken= default)=>
            await _roleManager.Roles
            .Where(r=>!r.IsDefault &&(!r.IsDeleted || (includeDisabled.HasValue && includeDisabled.Value)))
            .ProjectToType<RoleResponse>()
            .ToListAsync(cancellationToken);
    }
}
