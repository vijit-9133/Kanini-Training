using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Infrastructure.Services;
using API.Domain;


namespace CodeFirstManytoMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
           return Ok( await _userService.GetAllUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

    }

}