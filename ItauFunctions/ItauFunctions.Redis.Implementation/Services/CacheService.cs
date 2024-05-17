using ItauFunctions.Redis.Implementation.Repositories.Interfaces;
using ItauFunctions.Redis.Implementation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Redis.Implementation.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public async Task SetCacheValueAsync<T>(string key, T value)
        {
            await _cacheRepository.SetAsync(key, value);
        }

        public async Task<T> GetCacheValueAsync<T>(string key)
        {
            return await _cacheRepository.GetAsync<T>(key);
        }

        public async Task RemoveCacheValueAsync(string key)
        {
            await _cacheRepository.RemoveAsync(key);
        }
    }
}
