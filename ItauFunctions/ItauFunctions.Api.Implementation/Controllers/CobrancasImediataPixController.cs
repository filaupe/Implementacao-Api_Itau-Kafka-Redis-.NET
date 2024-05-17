using ItauFunctions.Api.Implementation.Domain.Models;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode;
using ItauFunctions.Api.Implementation.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItauFunctions.Api.Implementation.Controllers
{
    [Route("api/v1/cobrancas_imediata_pix")]
    [ApiController]
    public class CobrancasImediataPixController : ControllerBase
    {
        private readonly ItauCobrancasImediataPixService _itauCobrancasImediataPixService;

        public CobrancasImediataPixController(ItauCobrancasImediataPixService itauCobrancasImediataPixService)
        {
            _itauCobrancasImediataPixService = itauCobrancasImediataPixService;
        }

        [HttpGet]
        [Route("{id_cobranca_imediata_pix:required}/qrcode")]
        public ActionResult<Get_Response_Cobrancas_Imediata_Pix> Get(
            [FromHeader] string token,
            [FromRoute] string id_cobranca_imediata_pix)
        {
            var response = _itauCobrancasImediataPixService.Get(token, id_cobranca_imediata_pix);
            return Ok(response);
        }
        [HttpGet]
        [Route("async/{id_cobranca_imediata_pix:required}/qrcode")]
        public async Task<ActionResult<Get_Response_Cobrancas_Imediata_Pix>> GetAsync(
            [FromHeader] string token,
            [FromRoute] string id_cobranca_imediata_pix)
        {
            var response = await _itauCobrancasImediataPixService.GetAsync(token, id_cobranca_imediata_pix);
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Post_Response_Cobrancas_Imediata_Pix> Post(
            [FromHeader] string token,
            [FromBody] Post_Request_Cobrancas_Imediata_Pix value)
        {
            var response = _itauCobrancasImediataPixService.Post(token, value);
            return Ok(response);
        }
        [HttpPost]
        [Route("async")]
        public async Task<ActionResult<Post_Response_Cobrancas_Imediata_Pix>> PostAsync(
            [FromHeader] string token,
            [FromBody] Post_Request_Cobrancas_Imediata_Pix value)
        {
            var response = await _itauCobrancasImediataPixService.PostAsync(token, value);
            return Ok(response);
        }

        [HttpPatch("{id_cobranca_imediata_pix:required}")]
        public ActionResult<Patch_Response_Cobrancas_Imediata_Pix> Patch(
            [FromRoute] string id_cobranca_imediata_pix, 
            [FromBody] Patch_Request_Cobrancas_Imediata_Pix value)
        {
            return Ok();
        }
    }
}
