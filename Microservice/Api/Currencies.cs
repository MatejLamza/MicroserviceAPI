using Microservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Api
{
    public class Currencies
    {
        public static Currency Get()
        {
            WebRequest request = WebRequest.Create("https://api.fixer.io/latest?symbols=EUR,USD&base=HRK");
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse wr = request.GetResponseAsync().Result;
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<Currency>(content);
        }
    }
}
