using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleTables;

namespace PuppyApi
{
    class Program
    {
        static void MenuGreeting(string message)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to the Ultimate Brewery Directory");
            Console.WriteLine();
            Console.WriteLine(message);
        }

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
            var isRunning = true;
            while (isRunning)
            {
                MenuGreeting("``~*.*-------*.*~``");
                var selection = MenuPrompt("Choose an option below:");
                switch (selection)
                {
                    case 0:
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;

                    case 1:
                        MenuGreeting("Viewing Breweries listed by State."); // This only shows the first page (20) to a maximum of 50. I would be interested to implement 
                        await BreweriesByState();                           // a multiple page feature in the future!
                        break;

                    case 2:
                        MenuGreeting("Viewing Breweries in Tampa.");
                        await BreweriesInTampa();
                        break;

                    default:
                        Console.WriteLine("Sorry, please choose a valid option.");
                        break;

                }
            }
            static async Task BreweriesByState()
            {
                var client = new HttpClient();

                // First 20 breweries in list -by State.
                var responseAsStream = await client.GetStreamAsync("https://api.openbrewerydb.org/breweries");

                var breweries = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

                var table = new ConsoleTable("Name", "Brewery Type", "City", "State", "Country", "Created On", "Updated On");

                foreach (var brewery in breweries)
                {
                    table.AddRow(brewery.Name, brewery.BreweryType, brewery.City, brewery.State, brewery.Country, brewery.CreatedAt, brewery.UpdatedAt);
                }

                table.Write();
            }

            static async Task BreweriesInTampa()
            {
                var client = new HttpClient();

                // First 20 breweries in Tampa.
                var responseAsStream = await client.GetStreamAsync("https://api.openbrewerydb.org/breweries?by_city=tampa");

                var breweries = await JsonSerializer.DeserializeAsync<List<Brewery>>(responseAsStream);

                var table = new ConsoleTable("Name", "Brewery Type", "City", "State", "Country", "Created On", "Updated On");

                foreach (var brewery in breweries)
                {
                    table.AddRow(brewery.Name, brewery.BreweryType, brewery.City, brewery.State, brewery.Country, brewery.CreatedAt, brewery.UpdatedAt);
                }

                table.Write();
            }

            static int MenuPrompt(string prompt)
            {
                Console.WriteLine(prompt);
                Console.WriteLine("1) List Breweries by State (Ascending)");
                Console.WriteLine("2) List Breweries in Tampa (Ascending)");
                Console.WriteLine("Type '0' to exit the program");
                string input;
                int value;
                do
                {
                    Console.Write(">");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out value));
                return value;
            }
        }
    }
}
