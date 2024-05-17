using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode;
using ItauFunctions.Api.Implementation.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Infrastructure.Services
{
    public class ItauCobrancasImediataPixService
    {
        private readonly IConfiguration _configuration;
        private readonly ItauTokenService _itauTokenService;
        private readonly ItauCobrancasImediataPixRepository _itauCobrancasImediataPixRepository;
        
        public ItauCobrancasImediataPixService(IConfiguration configuration, ItauTokenService itauTokenService, ItauCobrancasImediataPixRepository itauCobrancasImediataPixRepository)
        {
            _configuration = configuration;
            _itauTokenService = itauTokenService;
            _itauCobrancasImediataPixRepository = itauCobrancasImediataPixRepository;
        }

        public Get_Response_Cobrancas_Imediata_Pix Get(string id_cobranca_imediata_pix)
        {
            var response = _itauCobrancasImediataPixRepository.Get(id_cobranca_imediata_pix);
            return response;
        }
        public Get_Response_Cobrancas_Imediata_Pix Get(string token, string id_cobranca_imediata_pix)
        {
            var response = _itauCobrancasImediataPixRepository.Get(token, id_cobranca_imediata_pix);
            return response;
        }
        public async Task<Get_Response_Cobrancas_Imediata_Pix> GetAsync(string id_cobranca_imediata_pix)
        {
            var response = await _itauCobrancasImediataPixRepository.GetAsync(id_cobranca_imediata_pix);
            return response;
        }
        public async Task<Get_Response_Cobrancas_Imediata_Pix> GetAsync(string token, string id_cobranca_imediata_pix)
        {
            var response = await _itauCobrancasImediataPixRepository.GetAsync(token, id_cobranca_imediata_pix);
            return response;
        }

        public Post_Response_Cobrancas_Imediata_Pix Post(Post_Request_Cobrancas_Imediata_Pix request)
        {
            return _itauCobrancasImediataPixRepository.Post(request);
        }
        public Post_Response_Cobrancas_Imediata_Pix Post(string token, Post_Request_Cobrancas_Imediata_Pix request)
        {
            return _itauCobrancasImediataPixRepository.Post(token, request);
        }
        public async Task<Post_Response_Cobrancas_Imediata_Pix> PostAsync(Post_Request_Cobrancas_Imediata_Pix request)
        {
            return await _itauCobrancasImediataPixRepository.PostAsync(request);
        }
        public async Task<Post_Response_Cobrancas_Imediata_Pix> PostAsync(string token, Post_Request_Cobrancas_Imediata_Pix request)
        {
            return await _itauCobrancasImediataPixRepository.PostAsync(token, request);
        }

        //public async Task<Post_Response_Cobrancas_Imediata_Pix> PatchAsync(string id_cobranca_imediata_pix,
        //    Patch_Request_Cobrancas_Imediata_Pix request)
        //{

        //}
    }
}
