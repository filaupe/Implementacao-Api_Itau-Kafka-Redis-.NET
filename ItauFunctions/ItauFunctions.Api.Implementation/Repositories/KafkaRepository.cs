using Confluent.Kafka;
using ItauFunctions.Kafka.Implementation.Repositories.Interfaces;

namespace ItauFunctions.Api.Implementation.Services
{
    public class KafkaRepository : IKafkaRepository
    {
        private readonly string _bootstrapServers;
        private readonly string _groupId;
        private readonly string _topic;

        public KafkaRepository(IConfiguration configuration)
        {
            string? groupId = configuration["Kafka:GroupId"];

            if (String.IsNullOrEmpty(groupId))
                groupId = Guid.NewGuid().ToString();

            _bootstrapServers = configuration["Kafka:BootstrapServers"]!;
            _topic = configuration["Kafka:Topic"]!;
            _groupId = groupId;
        }

        public async Task ConsumeAsync(CancellationToken stoppingToken)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe(_topic);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(125, stoppingToken);
                    try
                    {
                        var consumeResult = consumer.Consume(stoppingToken);
                        Console.WriteLine($"Teste: {consumeResult.Message.Value}");
                    }
                    catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                    {
                        // Ignore cancellation exception when stopping
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Erro ao consumir mensagem: {e.Error.Reason}");
                    }
                }
            }
            finally
            {
                consumer.Close();
            }
        }
    }
}
