using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeOne.Application.DTO;
using PracticeOne.Domain;
using PracticeOne.Infrastructure;
using PracticeOne.Infrastructure.Services;
namespace PracticeOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;
        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerService.GetAll();
            return Ok(players);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerDTO playerDTO)
        {
            var player = new Player
            {                 Name = playerDTO.Name,
                Age = playerDTO.Age,
                IsCaptain = playerDTO.IsCaptain
            };
            await _playerService.Create(player);
            return CreatedAtAction(nameof(GetAll), new { id = player.PlayerId }, player);
        }
    }
}
