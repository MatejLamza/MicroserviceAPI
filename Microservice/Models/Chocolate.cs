using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Models
{
    public class Chocolate
    {
        public string   Type { get; set; }
        public string   Manufacturer { get; set; }
        public double   PriceHRK { get; set; }

        public Chocolate(string Type, string Manufacturer, double PriceHRK)
        {
            this.Type           = Type;
            this.Manufacturer   = Manufacturer;
            this.PriceHRK       = PriceHRK;
        }

        public Chocolate()
        {

        }
    }
}
