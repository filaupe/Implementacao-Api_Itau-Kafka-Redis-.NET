using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Retirada
    {
        [JsonProperty("saque")]
        public Saque Saque { get; set; }

        [JsonProperty("troco")]
        public Troco Troco { get; set; }
    }
}
