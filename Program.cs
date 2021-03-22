using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PuppyApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // Random image
            var responseAsString = await client.GetStringAsync("https://dog.ceo/api/breeds/image/random");

            Console.WriteLine(responseAsString);
        }
    }
}
