using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Loc
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("tipoCob")]
        public string TipoCob { get; set; }

        [JsonProperty("criacao")]
        public DateTime? Criacao { get; set; }
    }
}
