using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Calendario
    {
        [JsonProperty("criacao")]
        public DateTime? Criacao { get; set; }

        [JsonProperty("expiracao")]
        public string Expiracao { get; set; }
    }
}
