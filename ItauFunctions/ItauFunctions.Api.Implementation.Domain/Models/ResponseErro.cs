using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class ResponseErro
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public Error Error { get; set; }
    }
}
