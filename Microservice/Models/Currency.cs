using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Models
{
    public class Currency
    {
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonProperty("rates")]
        public Rates Rates { get; set; }
    }
}
