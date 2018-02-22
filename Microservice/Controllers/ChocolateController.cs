using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microservice.Models;
using Microservice.Api;

namespace Microservice.Controllers
{
    [Produces("application/json")]
    [Route("api/Chocolate")]
    public class ChocolateController : Controller
    {
        public static List<Chocolate>   chocolateList;
        public static Currency          currency;

        public ChocolateController()
        {
            if (currency == null)
            {
                currency = Currencies.Get();
            }

            if (chocolateList == null)
            {
                chocolateList = new List<Chocolate>();

                Chocolate milkChocolate     =   new Chocolate("Milk", "Milka",8);
                Chocolate milkChocolate2    =   new Chocolate("Milk", "Lindt",15);
                Chocolate oreoChocolate     =   new Chocolate("Oreo", "Milka",10);
                Chocolate whiteChocolate    =   new Chocolate("White", "Nestle",10);

                chocolateList.Add(milkChocolate);
                chocolateList.Add(milkChocolate2);
                chocolateList.Add(oreoChocolate);
                chocolateList.Add(whiteChocolate);
            }
        }

        // GET api/Chocolate
        [HttpGet]
        public IEnumerable<Chocolate> Get()
        {
            return chocolateList;
        }

        // GET api/Chocolate/Milk
        [HttpGet("{type}", Name = "GetChocolates")]
        public List<Chocolate> Get(string type)
        {
            return chocolateList.FindAll(c => c.Type == type);
        }

        //GET api/Chocolate/Milk/USD
        [HttpGet("{type}/{strCurrency}",Name = "GetPriceOfChocolate")]
        public List<Chocolate> Get(string type, string strCurrency)
        {
            List<Chocolate> dummyListChocolate = chocolateList.FindAll(c => c.Type == type);
            double rate = 0.0;

            switch (strCurrency)
            {
                case "HRK":
                    rate = 1;
                    break;

                case "USD":
                    rate = currency.Rates.USD;
                    break;

                case "EUR":
                    rate = currency.Rates.EUR;
                    break;

                default:
                    break;
            }

            List<Chocolate> newChocoList = new List<Chocolate>();
            foreach (Chocolate item in dummyListChocolate)
            {
                newChocoList.Add(new Chocolate
                {
                    Type = item.Type,
                    Manufacturer = item.Manufacturer,
                    PriceHRK = item.PriceHRK * rate
                });
            }
            
            return newChocoList;
        }

        [HttpPost]
        public string Post(string type, string manufacturer, double priceHRK)
        {
            Chocolate dummyChocolate = new Chocolate(type,manufacturer,priceHRK);
            chocolateList.Add(dummyChocolate);
            return "Bravo!";
        }

    }
}
