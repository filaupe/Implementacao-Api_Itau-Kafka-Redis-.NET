using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix
{
    public class Post_Response_Cobrancas_Imediata_Pix
    {
        [JsonProperty("id_cobranca_imediata_pix")]
        public string IdCobrancaImediataPix { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("revisao")]
        public int? Revisao { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }

        [JsonProperty("calendario")]
        public Calendario Calendario { get; set; }

        [JsonProperty("valor")]
        public Valor Valor { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; set; }
    }
}
