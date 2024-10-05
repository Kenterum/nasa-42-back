using CelestialOrreryApp.Data.Interfaces;
using CelestialOrreryApp.Models;
using CelestialOrreryApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialOrreryApp.Services
{
    public class CelestialObjectService : ICelestialObjectService
    {
        private readonly ICelestialObjectRepository _repository;

        public CelestialObjectService(ICelestialObjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CelestialObject>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CelestialObject> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CelestialObject celestialObject)
        {
            // Add any business logic or validations here
            await _repository.AddAsync(celestialObject);
        }

        public async Task UpdateAsync(CelestialObject celestialObject)
        {
            // Add any business logic or validations here
            await _repository.UpdateAsync(celestialObject);
        }

        public async Task DeleteAsync(string id)
        {
            // Add any business logic or validations here
            await _repository.DeleteAsync(id);
        }
    }
}
