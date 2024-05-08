using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Api.Implementation.Domain.Models
{
    public class Data
    {
        [JsonProperty("pix_link")]
        public string PixLink { get; set; }

        [JsonProperty("emv")]
        public string Emv { get; set; }

        [JsonProperty("imagem_base64")]
        public string ImagemBase64 { get; set; }
    }
}
