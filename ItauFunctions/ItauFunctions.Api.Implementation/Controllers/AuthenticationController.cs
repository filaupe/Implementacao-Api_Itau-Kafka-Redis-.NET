using ItauFunctions.Api.Implementation.Domain.Models;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItauFunctions.Api.Implementation.Controllers
{
    [Route("api/v1/oauthd")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ItauTokenService _itauTokenService;

        public AuthenticationController(ItauTokenService itauTokenService)
        {
            _itauTokenService = itauTokenService;
        }

        [HttpPost]
        [Route("identity/connect/token")]
        public async Task<IActionResult> Post(string client_id, string client_secret)
        {
            try
            {
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
