using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeRest
{
     class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var cont = true;

            do
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                var ronResponse = client.GetStringAsync(ronURL).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($"--------------------");
                Console.WriteLine($"Kanye:{kanyeQuote}\n");
                Console.WriteLine($"--------------------");

                Console.WriteLine($"--------------------");
                Console.WriteLine($"Ron:{ronQuote}\n");
                Console.WriteLine($"--------------------");

                Console.WriteLine("Continue ? Y or N?");
                var response = Console.ReadLine().ToLower();
                cont = (response == "n") ? false : true;
            }while (cont);

        }
    }
}
