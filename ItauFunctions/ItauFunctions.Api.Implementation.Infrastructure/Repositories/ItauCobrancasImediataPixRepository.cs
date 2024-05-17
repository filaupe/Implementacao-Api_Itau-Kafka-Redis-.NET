using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using Newtonsoft.Json;
using System.Text;

namespace ItauFunctions.Api.Implementation.Infrastructure.Repositories
{
    public class ItauCobrancasImediataPixRepository
    {
        private const string BASE_PATH = "cobrancas_imediata_pix";

        private readonly ItauTokenService _itauTokenService;
        private readonly ItauClientRepository _itauClientRepository;
        public ItauCobrancasImediataPixRepository(ItauClientRepository itauClientRepository, ItauTokenService itauTokenService)
        {
            _itauClientRepository = itauClientRepository;
            _itauTokenService = itauTokenService;

        }

        public Get_Response_Cobrancas_Imediata_Pix Get(string id_cobranca_imediata_pix)
        {
            try
            {
                string token = _itauTokenService.AuthorizationTokenStringAsync().Result;
                var json = _itauClientRepository.GetStringAsync($"{BASE_PATH}/{id_cobranca_imediata_pix}/qrcode", token).Result;
                return JsonConvert.DeserializeObject<Get_Response_Cobrancas_Imediata_Pix>(json)!;
            }
            catch
            {
                throw;
            }

        }
        public Get_Response_Cobrancas_Imediata_Pix Get(string token, string id_cobranca_imediata_pix)
        {
            try
            {
                var json = _itauClientRepository.GetStringAsync($"{BASE_PATH}/{id_cobranca_imediata_pix}/qrcode", token).Result;
                return JsonConvert.DeserializeObject<Get_Response_Cobrancas_Imediata_Pix>(json)!;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Get_Response_Cobrancas_Imediata_Pix> GetAsync(string id_cobranca_imediata_pix)
        {
            try
            {
                string token = await _itauTokenService.AuthorizationTokenStringAsync();
                var json = await _itauClientRepository.GetStringAsync($"{BASE_PATH}/{id_cobranca_imediata_pix}/qrcode", token);
                return JsonConvert.DeserializeObject<Get_Response_Cobrancas_Imediata_Pix>(json)!;
            }
            catch
            {
                throw;
            }

        }
        public async Task<Get_Response_Cobrancas_Imediata_Pix> GetAsync(string token, string id_cobranca_imediata_pix)
        {
            try
            {
                var json = await _itauClientRepository.GetStringAsync($"{BASE_PATH}/{id_cobranca_imediata_pix}/qrcode", token);
                return JsonConvert.DeserializeObject<Get_Response_Cobrancas_Imediata_Pix>(json)!;
            }
            catch
            {
                throw;
            }
        }

        public Post_Response_Cobrancas_Imediata_Pix Post(Post_Request_Cobrancas_Imediata_Pix request)
        {
            try
            {
                string token = _itauTokenService.AuthorizationTokenStringAsync().Result;
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var responseJson = _itauClientRepository.PostAsync(BASE_PATH, content, token).Result;
                return JsonConvert.DeserializeObject<Post_Response_Cobrancas_Imediata_Pix>(responseJson)!;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Post_Response_Cobrancas_Imediata_Pix Post(string token, Post_Request_Cobrancas_Imediata_Pix request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var responseJson = _itauClientRepository.PostAsync(BASE_PATH, content, token).Result;
                return JsonConvert.DeserializeObject<Post_Response_Cobrancas_Imediata_Pix>(responseJson)!;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Post_Response_Cobrancas_Imediata_Pix> PostAsync(Post_Request_Cobrancas_Imediata_Pix request)
        {
            try
            {
                string token = await _itauTokenService.AuthorizationTokenStringAsync();
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var responseJson = await _itauClientRepository.PostAsync(BASE_PATH, content, token);
                return JsonConvert.DeserializeObject<Post_Response_Cobrancas_Imediata_Pix>(responseJson)!;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<Post_Response_Cobrancas_Imediata_Pix> PostAsync(string token, Post_Request_Cobrancas_Imediata_Pix request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var responseJson = await _itauClientRepository.PostAsync(BASE_PATH, content, token);
                return JsonConvert.DeserializeObject<Post_Response_Cobrancas_Imediata_Pix>(responseJson)!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
