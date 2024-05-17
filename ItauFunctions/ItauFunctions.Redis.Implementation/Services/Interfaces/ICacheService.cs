using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Redis.Implementation.Services.Interfaces
{
    public interface ICacheService
    {
        Task SetCacheValueAsync<T>(string key, T value);
        Task<T> GetCacheValueAsync<T>(string key);
        Task RemoveCacheValueAsync(string key);
    }
}
