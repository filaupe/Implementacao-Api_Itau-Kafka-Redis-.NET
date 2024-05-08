using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class InfoAdicional
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
