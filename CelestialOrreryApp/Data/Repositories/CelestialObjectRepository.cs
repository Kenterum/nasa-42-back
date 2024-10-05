using CelestialOrreryApp.Data.Interfaces;
using CelestialOrreryApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialOrreryApp.Data.Repositories
{
    public class CelestialObjectRepository : ICelestialObjectRepository
    {
        private readonly IMongoCollection<CelestialObject> _celestialObjects;

        public CelestialObjectRepository(MongoDbContext context)
        {
            _celestialObjects = context.CelestialObjects;
        }

        public async Task<IEnumerable<CelestialObject>> GetAllAsync()
        {
            return await _celestialObjects.Find(_ => true).ToListAsync();
        }

        public async Task<CelestialObject> GetByIdAsync(string id)
        {
            return await _celestialObjects.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(CelestialObject celestialObject)
        {
            await _celestialObjects.InsertOneAsync(celestialObject);
        }

        public async Task UpdateAsync(CelestialObject celestialObject)
        {
            await _celestialObjects.ReplaceOneAsync(x => x.Id == celestialObject.Id, celestialObject);
        }

        public async Task DeleteAsync(string id)
        {
            await _celestialObjects.DeleteOneAsync(x => x.Id == ObjectId.Parse(id));
        }
    }
}
