using API.Application;
using API.Data;
using API.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Repository
{
    public class PostRepo: IUserPost<Post, int>
    {
        private readonly UserPostContext _context;
        public PostRepo(UserPostContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            return await _context.Posts.
                  FirstOrDefaultAsync(u => u.PostId == id) ?? throw new Exception("Post not found");
        }
        public async Task<Post> Create(Post entity)
        {
            _context.Posts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Post?> Update(Post entity)
        {
           
            var existingPost = await _context.Set<Post>().FindAsync(entity.PostId);

            if (existingPost == null)
            {
                return null;
            }

            existingPost.Title = entity.Title;
            existingPost.Content = entity.Content;
            
            _context.Entry(existingPost).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return existingPost;
        }

        public async Task<Post?> Delete(int id)
        {
           
            var postToDelete = await _context.Set<Post>().FindAsync(id);

            if (postToDelete == null)
            {
                return null;
            }

            _context.Set<Post>().Remove(postToDelete);

            await _context.SaveChangesAsync();

            return postToDelete;
        }


    }
}
