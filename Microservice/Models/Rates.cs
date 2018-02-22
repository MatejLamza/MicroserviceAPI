using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Models
{
    public class Rates
    {
        [JsonProperty("USD")]
        public double USD { get; set; }
        [JsonProperty("EUR")]
        public double EUR { get; set; }
    }
}
