using Duothan.Server.Data;
using Duothan.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace Duothan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicTransportScheduleController : ControllerBase
    {
        private readonly PublicTransportScheduleRepository _repository;

        public PublicTransportScheduleController(PublicTransportScheduleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicTransportSchedule>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicTransportSchedule>> GetById(int id)
        {
            var schedule = await _repository.GetById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult> Add(PublicTransportSchedule schedule)
        {
            var id = await _repository.Add(schedule);
            return CreatedAtAction(nameof(GetById), new { id }, schedule);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PublicTransportSchedule schedule)
        {
            if (id != schedule.ScheduleID)
            {
                return BadRequest();
            }

            await _repository.Update(schedule);
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
