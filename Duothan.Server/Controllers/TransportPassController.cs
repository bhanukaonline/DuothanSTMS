using Duothan.Server.Data;
using Duothan.Server.Model;
using Microsoft.AspNetCore.Mvc;

namespace Duothan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportPassController : ControllerBase
    {
        private readonly TransportPassRepository _repository;

        public TransportPassController(TransportPassRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportPass>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransportPass>> GetById(int id)
        {
            var transportPass = await _repository.GetById(id);
            if (transportPass == null)
            {
                return NotFound();
            }
            return Ok(transportPass);
        }

        [HttpPost]
        public async Task<ActionResult> Add(TransportPass transportPass)
        {
            var id = await _repository.Add(transportPass);
            return CreatedAtAction(nameof(GetById), new { id }, transportPass);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TransportPass transportPass)
        {
            if (id != transportPass.TransportPassID)
            {
                return BadRequest();
            }

            await _repository.Update(transportPass);
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
