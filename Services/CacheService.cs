
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace SurveyBasket.Services
{
    public class CacheService(IDistributedCache distributedCache, ILogger<CacheService> logger) : ICacheService
    {
        private readonly IDistributedCache _distributedCache = distributedCache;
        private readonly ILogger _logger = logger;

        public async Task<T?> GetAsnc<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            _logger.LogInformation("Get cache with ley: {key}", key);
            var cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);

            return string.IsNullOrEmpty(cachedValue) ? null : JsonSerializer.Deserialize<T>(cachedValue);

        }


        public async Task SetAsnc<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            _logger.LogInformation("Set cache with ley: {key}", key);
            await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), cancellationToken);
        }

        public async Task RemoveAsnc(string key, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Remove cache with ley: {key}", key);
            await _distributedCache.RemoveAsync(key, cancellationToken);
        }
    }
}
