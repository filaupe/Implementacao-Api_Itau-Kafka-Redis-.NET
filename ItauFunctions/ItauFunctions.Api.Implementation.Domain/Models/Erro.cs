using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Erro
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("violacoes")]
        public List<Violacao> Violacoes { get; set; }
    }
}
