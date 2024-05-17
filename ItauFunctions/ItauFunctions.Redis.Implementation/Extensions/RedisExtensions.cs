using ItauFunctions.Redis.Implementation.Repositories.Interfaces;
using ItauFunctions.Redis.Implementation.Repositories;
using ItauFunctions.Redis.Implementation.Services.Interfaces;
using ItauFunctions.Redis.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ItauFunctions.Redis.Implementation.Extensions
{
    public static class RedisExtensions
    {
        public static void AddRedis(this IServiceCollection services)
        {
            services.AddSingleton<ICacheRepository, CacheRepository>();
            services.AddTransient<ICacheService, CacheService>();
        }
    }
}
