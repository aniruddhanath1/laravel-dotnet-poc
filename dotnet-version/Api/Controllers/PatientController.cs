using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnet_version.Models;
using dotnet_version.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
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
            var patient = _service.Get(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            var id = _service.Create(patient);
            patient.Id = id;
            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Patient patient)
        {
            patient.Id = id;
            var updated = _service.Update(patient);
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
