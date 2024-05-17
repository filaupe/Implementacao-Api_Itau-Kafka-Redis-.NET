using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models.Cobrancas_Imediata_Pix.Id_Cobranca_Imediata_Pix
{
    public class Patch_Request_Cobrancas_Imediata_Pix
    {
        [JsonProperty("valor")]
        public ValorCompleto Valor { get; set; }

        [JsonProperty("chave")]
        public string Chave { get; set; }

        [JsonProperty("calendario")]
        public CalendarioCompleto Calendario { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("devedor")]
        public Devedor Devedor { get; set; }

        [JsonProperty("solicitacaoPagador")]
        public string SolicitacaoPagador { get; set; }

        [JsonProperty("infoAdicionais")]
        public List<InfoAdicional> InfoAdicionais { get; set; }
    }
}
