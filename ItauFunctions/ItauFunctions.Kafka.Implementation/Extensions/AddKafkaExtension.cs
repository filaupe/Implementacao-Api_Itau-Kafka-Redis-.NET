using ItauFunctions.Kafka.Implementation.Repositories;
using ItauFunctions.Kafka.Implementation.Repositories.Interfaces;
using ItauFunctions.Kafka.Implementation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItauFunctions.Kafka.Implementation.Extensions
{
    public static class AddKafkaExtension
    {
        public static void AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<KafkaConsumerService>();
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IKafkaRepository, KafkaRepository>();
            services.AddHostedService<KafkaConsumerService>();
        }
    }
}
