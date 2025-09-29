using API.Domain;
using API.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstManytoMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            return Ok(await _postService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostById(int id)
        {
            return Ok(await _postService.GetPostById(id));
        }
        [HttpPost]
        public async Task<ActionResult> CreatePost(Post post)
        {
            await _postService.CreatePost(post);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(Post post)
        {
            await _postService.Update(post);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _postService.Delete(id);
            return Ok();
        }
    }
}
