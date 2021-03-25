using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PuppyApi
{
    class Program
    {
        class Brewery
        {
            public string name { get; set; }
            public string brewery_type { get; set; }
            public string street { get; set; }
            public string address_2 { get; set; }
            public string address_3 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string county_province { get; set; }
            public string postal_code { get; set; }
            public string country { get; set; }
            public string longitude { get; set; }
            public string latitude { get; set; }
            public string phone { get; set; }
            public string website_url { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime created_at { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // All dog breeds
            var responseAsStream = await client.GetStreamAsync("https://api.openbrewerydb.org/breweries");

            var breweries = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            foreach (var brewery in breweries)
            {
                Console.WriteLine($"{brewery.name}, is a {brewery.brewery_type} brewery. It is located in {brewery.city}, {brewery.state}");
            }
            // Console.WriteLine(responseAsStream);
        }
    }
}
