using Microsoft.Extensions.Caching.Distributed;

namespace LeadManagementApi.Caching
{
    public class CachingService : ICachingService
    {
		private readonly IDistributedCache _cache;
		private readonly DistributedCacheEntryOptions _options;
		
		public CachingService(IDistributedCache cache)
		{
			_cache = cache;
			_options = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
				SlidingExpiration = TimeSpan.FromSeconds(1200)
			};
		}
        public async Task<string?> GetAsync(string entity, int id)
        {
            string? value = await _cache.GetStringAsync(BuildKey(entity, id));
            return value;
        }

        public async Task InvalidateAsync(string entity, int id)
        {
            await _cache.RemoveAsync(BuildKey(entity, id));
        }

        public async Task SetAsync(string entity, int id, string value)
        {
            await _cache.SetStringAsync(BuildKey(entity, id), value, _options);
        }

        private static string BuildKey(string entity, int id)
        {
            return entity + "_" + id;
        }
    }
}