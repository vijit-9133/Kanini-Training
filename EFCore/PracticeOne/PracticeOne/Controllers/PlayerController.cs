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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Player), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetById(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }
        [HttpPut("{id}")] 
        [ProducesResponseType(typeof(Player), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id, [FromBody] PlayerUpdateDTO dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = new Player
            {
                PlayerId = id, 
                Name = dto.Name,
                Age = dto.Age,
                IsCaptain = dto.IsCaptain 
            };

            var updatedPlayer = await _playerService.Update(player);

            if (updatedPlayer == null)
            {
                return NotFound(); 
            }

            return Ok(updatedPlayer); 
        }

       
        [HttpDelete("{id}")] 
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _playerService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(); 
        }
    }

}

