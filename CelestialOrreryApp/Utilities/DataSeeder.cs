using CelestialOrreryApp.Data;
using CelestialOrreryApp.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CelestialOrreryApp.Utilities
{
    public class DataSeeder
    {
        private readonly IMongoCollection<CelestialObject> _celestialObjects;

        public DataSeeder(MongoDbContext context)
        {
            _celestialObjects = context.CelestialObjects;
        }

        public async Task SeedDataAsync()
        {
            if (_celestialObjects.CountDocuments(_ => true) == 0)
            {
                var jsonData = await FetchJsonData();
                var celestialObjects = JsonConvert.DeserializeObject<List<CelestialObject>>(jsonData);

                if (celestialObjects != null)
                {
                    await _celestialObjects.InsertManyAsync(celestialObjects);
                }
            }
        }

        private async Task<string> FetchJsonData()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("https://data.nasa.gov/resource/b67r-rgxc.json");
                return response;
            }
        }
    }
}
