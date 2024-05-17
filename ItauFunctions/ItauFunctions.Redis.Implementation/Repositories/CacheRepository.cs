using ItauFunctions.Redis.Implementation.Repositories.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ItauFunctions.Redis.Implementation.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDatabase _database;

        public CacheRepository()
        {
            _database = RedisConnection.Connection.GetDatabase();
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var jsonData = JsonConvert.SerializeObject(value);
            await _database.StringSetAsync(key, jsonData);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var jsonData = await _database.StringGetAsync(key);
            if (jsonData.IsNullOrEmpty)
            {
                return default!;
            }

            return JsonConvert.DeserializeObject<T>(jsonData!)!;
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }
}
