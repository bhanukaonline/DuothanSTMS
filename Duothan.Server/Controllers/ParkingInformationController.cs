using Duothan.Server.Data;
using Duothan.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace Duothan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingInformationController : ControllerBase
    {
        private readonly ParkingInformationRepository _repository;

        public ParkingInformationController(ParkingInformationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingInformation>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingInformation>> GetById(int id)
        {
            var parking = await _repository.GetById(id);
            if (parking == null)
            {
                return NotFound();
            }
            return Ok(parking);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ParkingInformation parking)
        {
            var id = await _repository.Add(parking);
            return CreatedAtAction(nameof(GetById), new { id }, parking);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ParkingInformation parking)
        {
            if (id != parking.ParkingID)
            {
                return BadRequest();
            }

            await _repository.Update(parking);
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
