using Duothan.Server.Data;
using Duothan.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace Duothan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleLocationController : ControllerBase
    {
        private readonly VehicleLocationRepository _repository;

        public VehicleLocationController(VehicleLocationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleLocation>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleLocation>> GetById(int id)
        {
            var location = await _repository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VehicleLocation location)
        {
            var id = await _repository.Add(location);
            return CreatedAtAction(nameof(GetById), new { id }, location);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, VehicleLocation location)
        {
            if (id != location.VehicleID)
            {
                return BadRequest();
            }

            await _repository.Update(location);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
