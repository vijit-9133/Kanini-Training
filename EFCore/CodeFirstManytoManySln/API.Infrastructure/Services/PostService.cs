using API.Application;
using API.Domain;
using API.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Services
{
    public class PostService
    {
        private readonly IUserPost<Post, int> _postRepo;
        public PostService(IUserPost<Post, int> postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _postRepo.GetAll();
        }
        public async Task<Post> GetPostById(int id)
        {
            return await _postRepo.GetById(id);
        }
        public async Task<Post> CreatePost(Post post)
        {
            return await _postRepo.Create(post);
        }
        public async Task<Post> Update(Post post)
        {
            return await _postRepo.Update(post);
        }
        public async Task<Post> Delete(int id)
        {
            return await _postRepo.Delete(id);
        }


    }
}
