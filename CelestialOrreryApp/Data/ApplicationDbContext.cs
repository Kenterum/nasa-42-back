using MongoDB.Driver;
using CelestialOrreryApp.Models;

namespace CelestialOrreryApp.Data
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionStrings:MongoConnection"]);
            Database = client.GetDatabase(configuration["MongoDatabaseName"]);
        }

        public IMongoCollection<CelestialObject> CelestialObjects => Database.GetCollection<CelestialObject>("CelestialObjects");
    }
}
