using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Violacao
    {
        [JsonProperty("propriedade")]
        public string Propriedade { get; set; }

        [JsonProperty("razao")]
        public string Razao { get; set; }
    }
}
