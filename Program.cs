using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuppyApi
{
    class Program
    {
        class Brewery
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("brewery_type")]
            public string BreweryType { get; set; }
            [JsonPropertyName("street")]
            public string Street { get; set; }
            [JsonPropertyName("address_2")]
            public string Address2 { get; set; }
            [JsonPropertyName("address_3")]
            public string Address3 { get; set; }
            [JsonPropertyName("city")]
            public string City { get; set; }
            [JsonPropertyName("state")]
            public string State { get; set; }
            [JsonPropertyName("county_province")]
            public string CountyProvince { get; set; }
            [JsonPropertyName("postal_code")]
            public string PostalCode { get; set; }
            [JsonPropertyName("country")]
            public string Country { get; set; }
            [JsonPropertyName("longitude")]
            public string Longitude { get; set; }
            [JsonPropertyName("latitude")]
            public string Latitude { get; set; }
            [JsonPropertyName("phone")]
            public string Phone { get; set; }
            [JsonPropertyName("website_url")]
            public string WebsiteUrl { get; set; }
            [JsonPropertyName("updated_at")]
            public DateTime UpdatedAt { get; set; }
            [JsonPropertyName("created_at")]
            public DateTime CreatedAt { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // First 20 breweries in list -by city.
            var responseAsStream = await client.GetStreamAsync("https://api.openbrewerydb.org/breweries");

            var breweries = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

            foreach (var brewery in breweries)
            {
                Console.WriteLine($"{brewery.Name}, is a {brewery.BreweryType} brewery. It is located in {brewery.City}, {brewery.State}.");
                Console.WriteLine($"Entry created on {brewery.CreatedAt}. Last updated on {brewery.UpdatedAt}.");

            }

        }
    }
}
