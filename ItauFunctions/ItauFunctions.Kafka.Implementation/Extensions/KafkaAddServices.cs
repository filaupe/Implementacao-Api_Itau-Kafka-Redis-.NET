using ItauFunctions.Kafka.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Kafka.Implementation.Extensions
{
    public static class KafkaAddServices
    {
        public static void AddKafka(this IServiceCollection services)
        {
            services.AddSingleton(new KafkaConsumer("localhost:9092"));
            services.AddHostedService<KafkaBackgroundService>();
        }
    }
}
