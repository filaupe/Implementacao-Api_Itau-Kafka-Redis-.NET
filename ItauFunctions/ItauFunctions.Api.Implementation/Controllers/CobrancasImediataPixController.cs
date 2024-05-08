using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix;
using ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode;
using Microsoft.AspNetCore.Mvc;

namespace ItauFunctions.Api.Implementation.Controllers
{
    [Route("api/v1/cobrancas_imediata_pix")]
    [ApiController]
    public class CobrancasImediataPixController : ControllerBase
    {
        [HttpGet]
        [Route("{id_cobranca_imediata_pix:required}/qrcode")]
        public ActionResult<Get_Response_Cobrancas_Imediata_Pix> Get(string id_cobranca_imediata_pix)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Post_Response_Cobrancas_Imediata_Pix> Post(
            [FromBody] Post_Request_Cobrancas_Imediata_Pix value)
        {
            return Ok();
        }

        [HttpPatch("{id_cobranca_imediata_pix:required}")]
        public ActionResult<Patch_Response_Cobrancas_Imediata_Pix> Patch(string id_cobranca_imediata_pix, 
            [FromBody] Patch_Request_Cobrancas_Imediata_Pix value)
        {
            return Ok();
        }
    }
}
