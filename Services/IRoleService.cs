using System.Collections;

namespace SurveyBasket.Services
{
    public interface IRoleService
    {
        Task<IEnumerable> GetAllAsync(bool? includeDisabled = false, CancellationToken cancellationToken = default);
    }
}
