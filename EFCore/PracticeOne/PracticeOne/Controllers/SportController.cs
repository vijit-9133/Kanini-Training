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
    }
}
