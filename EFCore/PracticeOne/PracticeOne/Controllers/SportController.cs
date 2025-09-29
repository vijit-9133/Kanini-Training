using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeOne.Application.DTO;
using PracticeOne.Domain;
using PracticeOne.Infrastructure.Services;

namespace PracticeOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly SportService _sportService;
        public SportController(SportService sportService)
        {
            _sportService = sportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sports = await _sportService.GetAll();
            return Ok(sports);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SportDTO sportDTO)
        {
            var sport = new Sport
            {
                Name = sportDTO.Name,
                NumberOfPlayers = sportDTO.NumberOfPlayers
            };
            var createdSport = await _sportService.Create(sport);
            return CreatedAtAction(nameof(GetAll), new { id = createdSport.SportId }, createdSport);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Sport), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var sport = await _sportService.GetById(id);

            if (sport == null)
            {
                return NotFound();
            }

            return Ok(sport);
        }
        [HttpPut("{id}")] // Added route parameter for ID
        [ProducesResponseType(typeof(Sport), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id, [FromBody] SportUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sport = new Sport
            {
                SportId = id, 
                Name = dto.Name,
                NumberOfPlayers = dto.NumberOfPlayers
            };

            var updatedSport = await _sportService.Update(sport);

            if (updatedSport == null)
            {
                return NotFound(); 
            }

            return Ok(updatedSport); 
        }

       
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sportService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(); 
        }
    }
}

