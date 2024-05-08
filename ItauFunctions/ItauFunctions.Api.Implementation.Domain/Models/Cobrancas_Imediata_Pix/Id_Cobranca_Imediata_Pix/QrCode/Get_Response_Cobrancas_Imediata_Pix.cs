using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix.QrCode
{
    public class Get_Response_Cobrancas_Imediata_Pix
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
