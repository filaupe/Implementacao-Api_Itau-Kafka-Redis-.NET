using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix
{
    public class Post_Request_Cobrancas_Imediata_Pix
    {
        [JsonProperty("calendario")]
        public CalendarioPost Calendario { get; set; }

        [JsonProperty("valor")]
        public ValorPost Valor { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; set; }
    }
}
