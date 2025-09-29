using API.Application;
using API.Data;
using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class UserRepo : IUserPost<User, int>
    {
        private readonly UserPostContext _context;
        public UserRepo(UserPostContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Include(u=>u.UserPosts)
                .ThenInclude(up=>up.Post).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
          return await _context.Users.Include(u => u.UserPosts)
                .ThenInclude(up => up.Post).FirstOrDefaultAsync(u=>u.UserId==id) ?? throw new Exception("User not found");
        }
        public async Task<User> Create(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<User> Update(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == entity.UserId);
            if (user == null) throw new Exception("User not found");
            user.Username = entity.Username;
            user.Email = entity.Email;
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) throw new Exception("User not found");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
