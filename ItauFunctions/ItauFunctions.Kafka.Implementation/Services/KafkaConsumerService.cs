using Confluent.Kafka;
using ItauFunctions.Kafka.Implementation.Repositories;
using ItauFunctions.Kafka.Implementation.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace ItauFunctions.Kafka.Implementation.Services
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly IKafkaRepository _repository;

        public KafkaConsumerService(IKafkaRepository repository) => _repository = repository;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _repository.ConsumeAsync(stoppingToken);
        }
    }
}
