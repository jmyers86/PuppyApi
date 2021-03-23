using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PuppyApi
{
    class Program
    {
        class Puppy
        {
            public Array message { get; set; }
            public bool status { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // All dog breeds
            var responseAsStream = await client.GetStreamAsync("https://dog.ceo/api/breeds/list/all");

            var breeds = await JsonSerializer.DeserializeAsync<List<Puppy>>(responseAsStream);

            foreach (var breed in breeds)
            {
                Console.WriteLine(breed.message);
            }
            // Console.WriteLine(responseAsStream);
        }
    }
}
