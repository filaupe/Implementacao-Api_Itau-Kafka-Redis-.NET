using ItauFunctions.Api.Implementation.Domain.Models;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using ItauFunctions.Redis.Implementation.Services;
using ItauFunctions.Redis.Implementation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItauFunctions.Api.Implementation.Controllers
{
    [Route("api/v1/oauthd")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ItauTokenService _itauTokenService;
        private readonly ICacheService _cacheService;

        public AuthenticationController(ItauTokenService itauTokenService, ICacheService cacheService)
        {
            _itauTokenService = itauTokenService;
            _cacheService = cacheService;
        }

        [HttpPost]
        [Route("identity/connect/token")]
        public async Task<IActionResult> Post(string client_id, string client_secret)
        {
            try
            {
                await _cacheService.SetCacheValueAsync<Get_Response_Cobrancas_Imediata_Pix>("Teste123Teste", new Get_Response_Cobrancas_Imediata_Pix());
                var result = await _itauTokenService.AuthorizationToken(client_id, client_secret);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Erro
                {
                    Detail = ex.Message,
                });
            }
        }
    }
}
