using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class ValorCompleto
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("modalidadeAlteracao")]
        public string? ModalidadeAlteracao { get; set; }

        [JsonProperty("retirada")]
        public Retirada? Retirada { get; set; }
    }
    
    public class ValorPost
    {
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}
