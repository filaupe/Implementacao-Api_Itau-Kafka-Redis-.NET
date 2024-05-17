using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class CalendarioCompleto
    {
        [JsonProperty("criacao")]
        public DateTime? Criacao { get; set; }

        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }
    }
    
    public class CalendarioPost
    {
        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }
    }
}
