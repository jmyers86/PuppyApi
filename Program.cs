using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PuppyApi
{
    class Program
    {
        class Puppy
        {
            public string message { get; set; }
            public bool status { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // Random image
            var responseAsString = await client.GetStringAsync("https://dog.ceo/api/breeds/image/random");

            Console.WriteLine(responseAsString);
        }
    }
}
