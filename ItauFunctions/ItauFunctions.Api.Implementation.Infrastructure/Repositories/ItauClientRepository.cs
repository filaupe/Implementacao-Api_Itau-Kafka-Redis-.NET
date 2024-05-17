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

        private HttpClient InstanceClient(string instance)
        {
            var client = _httpClientFactory.CreateClient(instance);
            client.DefaultRequestHeaders.Add("User-Agent", "Other");
            return client;
        }
        
        private HttpClient InstanceClient(string instance, string token)
        {
            var client = InstanceClient(instance);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return client;
        }

        public async Task<Token> AuthorizationTokenAsync(string clientId, string clientSecret)
        {
            try
            {
                var client = InstanceClient(nameof(EClient.ItauToken));

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
        
        public async Task<string> GetStringAsync(string url, string token)
        {
            try
            {
                var client = InstanceClient(nameof(EClient.ItauApi), token);
                url = $"{client.BaseAddress}/{url}";
                string response = await client.GetStringAsync(url);
                return response;
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<string> PostAsync(string url, HttpContent requestBody, string token)
        {
            try
            {
                var client = InstanceClient(nameof(EClient.ItauApi), token);
                url = $"{client.BaseAddress}/{url}";
                var response = await client.PostAsync(url, requestBody);
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch
            {
                throw;
            }
        }
    }
}
