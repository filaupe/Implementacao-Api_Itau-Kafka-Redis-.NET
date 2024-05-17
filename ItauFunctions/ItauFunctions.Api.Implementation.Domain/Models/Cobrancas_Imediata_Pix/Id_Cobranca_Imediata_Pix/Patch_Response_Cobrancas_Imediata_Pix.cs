using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix
{
    public class Patch_Response_Cobrancas_Imediata_Pix
    {
        [JsonProperty("id_cobranca_estatico_pix")]
        public string IdCobrancaEstaticoPix { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("calendario")]
        public CalendarioCompleto Calendario { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("revisao")]
        public int? Revisao { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("devedor")]
        public Devedor Devedor { get; set; }

        [JsonProperty("valor")]
        public ValorCompleto Valor { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; set; }

        [JsonProperty("emv")]
        public string Emv { get; set; }

        [JsonProperty("imagem_base64")]
        public string ImagemBase64 { get; set; }
    }
}
