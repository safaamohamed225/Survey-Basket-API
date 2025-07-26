namespace SurveyBasket.Services
{
    public interface ICacheService
    {
        Task<T?> GetAsnc<T>(string key, CancellationToken cancellationToken = default) where T : class;
        Task SetAsnc<T>(string key, T value, CancellationToken cancellationToken = default) where T : class;
        Task RemoveAsnc(string key, CancellationToken cancellationToken = default);


    }
}
