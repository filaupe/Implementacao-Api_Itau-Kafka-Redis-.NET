using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Saque
    {
        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("modalidadeAgente")]
        public string ModalidadeAgente { get; set; }

        [JsonProperty("prestadorDoServicoDeSaque")]
        public string PrestadorDoServicoDeSaque { get; set; }

        [JsonProperty("modalidadeAlteracao")]
        public string ModalidadeAlteracao { get; set; }
    }
}
