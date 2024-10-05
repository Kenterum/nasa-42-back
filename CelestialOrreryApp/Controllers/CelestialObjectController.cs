using Microsoft.AspNetCore.Mvc;
using CelestialOrreryApp.Services.Interfaces;
using CelestialOrreryApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CelestialOrreryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ICelestialObjectService _celestialObjectService;

        public CelestialObjectController(ICelestialObjectService celestialObjectService)
        {
            _celestialObjectService = celestialObjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CelestialObject>>> GetAll()
        {
            var celestialObjects = await _celestialObjectService.GetAllAsync();
            return Ok(celestialObjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CelestialObject>> GetById(string id)
        {
            var celestialObject = await _celestialObjectService.GetByIdAsync(id);
            if (celestialObject == null)
            {
                return NotFound();
            }
            return Ok(celestialObject);
        }

        [HttpPost]
        public async Task<ActionResult<CelestialObject>> Create([FromBody] CelestialObject celestialObject)
        {
            await _celestialObjectService.AddAsync(celestialObject);
            return CreatedAtAction(nameof(GetById), new { id = celestialObject.Id }, celestialObject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CelestialObject celestialObject)
        {
            if (id != celestialObject.Id.ToString())
            {
                return BadRequest("ID mismatch");
            }

            var existingObject = await _celestialObjectService.GetByIdAsync(id);
            if (existingObject == null)
            {
                return NotFound();
            }

            await _celestialObjectService.UpdateAsync(celestialObject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var celestialObject = await _celestialObjectService.GetByIdAsync(id);
            if (celestialObject == null)
            {
                return NotFound();
            }

            await _celestialObjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}
