using CelestialOrreryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialOrreryApp.Services.Interfaces
{
    public interface ICelestialObjectService
    {
        Task<IEnumerable<CelestialObject>> GetAllAsync();
        Task<CelestialObject> GetByIdAsync(string id);
        Task AddAsync(CelestialObject celestialObject);
        Task UpdateAsync(CelestialObject celestialObject);
        Task DeleteAsync(string id);
    }
}
