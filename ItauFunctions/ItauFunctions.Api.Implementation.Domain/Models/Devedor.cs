using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Devedor
    {
        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
