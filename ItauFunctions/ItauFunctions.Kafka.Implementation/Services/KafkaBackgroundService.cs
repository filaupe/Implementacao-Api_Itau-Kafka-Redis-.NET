using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Kafka.Implementation.Services
{
    public class KafkaBackgroundService : BackgroundService
    {
        private readonly KafkaConsumer _consumer;

        public KafkaBackgroundService(KafkaConsumer consumer)
        {
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.StartConsuming("PIX");
            await Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _consumer.StopConsuming();
            await base.StopAsync(stoppingToken);
        }
    }
}
