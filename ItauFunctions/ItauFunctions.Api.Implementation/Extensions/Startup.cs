using ItauFunctions.Api.Implementation.Domain.Models.Enums;
using ItauFunctions.Api.Implementation.Infrastructure.Repositories;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using ItauFunctions.Api.Implementation.Services;
using ItauFunctions.Kafka.Implementation.Extensions;
using ItauFunctions.Kafka.Implementation.Repositories.Interfaces;

namespace ItauFunctions.Api.Implementation.Extensions
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureItauClient(configuration);
            services.ConfigureInjectionServices();
            services.AddKafka(configuration);
        }

        public static void ConfigureInjectionServices(this IServiceCollection services)
        {
            services.AddSingleton<ItauClientRepository>();
            services.AddSingleton<ItauCobrancasImediataPixRepository>();
            services.AddSingleton<IKafkaRepository, KafkaRepository>();

            services.AddSingleton<ItauTokenService>();
            services.AddSingleton<ItauCobrancasImediataPixService>();
        }

        public static void ConfigureItauClient(this IServiceCollection services, IConfiguration configuration)
        {
            string? ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            string baseApiAddress = String.Empty;
            string baseTokenAddress = String.Empty;

            if (ASPNETCORE_ENVIRONMENT == "Development")
            {
                baseApiAddress = configuration["Urls:Desenvolvimento:Api"]!;
                baseTokenAddress = configuration["Urls:Desenvolvimento:Token"]!;
            }
            else
            {
                baseApiAddress = configuration["Urls:Producao:Api"]!;
                baseTokenAddress = configuration["Urls:Producao:Token"]!;
            }

            services.AddHttpClient(nameof(EClient.ItauApi), httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseApiAddress);
            });
            services.AddHttpClient(nameof(EClient.ItauToken), httpClient =>
            {
                httpClient.BaseAddress = new Uri(baseTokenAddress);
            });
        }

        public static void Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
