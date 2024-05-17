using Confluent.Kafka;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using ItauFunctions.Kafka.Implementation.Repositories.Interfaces;
using ItauFunctions.Redis.Implementation.Services;
using ItauFunctions.Redis.Implementation.Services.Interfaces;

namespace ItauFunctions.Api.Implementation.Services
{
    public class KafkaService : IKafkaRepository
    {
        private readonly ICacheService _cacheService;
        private readonly ItauTokenService _tokenService;
        private readonly ItauCobrancasImediataPixService _itauCobrancasImediataPixService;
        
        private readonly string _bootstrapServers;
        private readonly string _groupId;
        private readonly string _topic;

        public KafkaService(IConfiguration configuration, ItauTokenService itauTokenService, 
            ItauCobrancasImediataPixService itauCobrancasImediataPixService, ICacheService cacheService)
        {
            string? groupId = configuration["Kafka:GroupId"];

            if (String.IsNullOrEmpty(groupId))
                groupId = Guid.NewGuid().ToString();

            _bootstrapServers = configuration["Kafka:BootstrapServers"]!;
            _topic = configuration["Kafka:Topic"]!;
            _groupId = groupId;

            _tokenService = itauTokenService;
            _itauCobrancasImediataPixService = itauCobrancasImediataPixService; 
            _cacheService = cacheService;
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
                        //var response = _itauCobrancasImediataPixService.Post(new Post_Request_Cobrancas_Imediata_Pix());
                        //var img = _itauCobrancasImediataPixService.Get(response.IdCobrancaImediataPix);
                        //await _cacheService.SetCacheValueAsync("Formato", img);
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
