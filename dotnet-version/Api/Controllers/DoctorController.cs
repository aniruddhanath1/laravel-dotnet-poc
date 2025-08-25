using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnet_version.Models;
using dotnet_version.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var doctor = _service.Get(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Doctor doctor)
        {
            var id = _service.Create(doctor);
            doctor.Id = id;
            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Doctor doctor)
        {
            doctor.Id = id;
            var updated = _service.Update(doctor);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
