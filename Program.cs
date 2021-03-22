using System;
using System.Net.Http;

namespace PuppyApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            // Random image
            var responseAsString = await client.GetStringAsync("https://dog.ceo/api/breeds/image/random");

            Console.WriteLine(responseAsString);
        }
    }
}
