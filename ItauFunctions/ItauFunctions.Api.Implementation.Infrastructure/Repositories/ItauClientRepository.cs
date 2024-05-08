using ItauFunctions.Api.Implementation.Domain.Models;
using ItauFunctions.Api.Implementation.Domain.Models.Enums;
using Newtonsoft.Json;

namespace ItauFunctions.Api.Implementation.Infrastructure.Repositories
{
    public class ItauClientRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ItauClientRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Token> AuthorizationToken(string clientId, string clientSecret)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(nameof(EClient.ItauToken));
                client.DefaultRequestHeaders.Add("User-Agent", "Other");

                var parameters = new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", clientId },
                    { "client_secret", clientSecret }
                };

                var fomContent = new FormUrlEncodedContent(parameters);
                var response = await client.PostAsync(client.BaseAddress, fomContent);

                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Token>(json)!;
            }
            catch
            {
                throw;
            }
        }
    }
}
