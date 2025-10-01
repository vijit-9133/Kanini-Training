using ManytoManyWithoutJunction.DTO;
using ManytoManyWithoutJunction.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManytoManyWithoutJunction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddDoctor(CreateDocDTO doctorDTO)
        {
            var doc = await _service.Add(doctorDTO);
            return CreatedAtAction(nameof(AddDoctor), new { id = doc.Name }, doc);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var docs = await _service.GetAllDoc();
            return Ok(docs);
        }
    }
}
