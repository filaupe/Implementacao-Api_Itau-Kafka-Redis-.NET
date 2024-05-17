using Confluent.Kafka;

namespace ItauFunctions.Kafka.Implementation
{
    public class KafkaConsumer
    {
        private readonly ConsumerConfig _config;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public KafkaConsumer(string bootstrapServers)
        {
            _config = new ConsumerConfig
            {
                GroupId = Guid.NewGuid().ToString(),
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void StartConsuming(string topic)
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
            var tps = new TopicPartitionOffset(new TopicPartition("PIX", 0), Offset.Beginning);

            consumer.Assign(tps);
            consumer.Subscribe(topic);

            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(_cancellationTokenSource.Token);
                    Console.WriteLine($"Mensagem recebida: {consumeResult.Message.Value}");
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            consumer.Close();
        }

        public void StopConsuming()
        {
            _cancellationTokenSource.Cancel();
        }
    }

}
