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
    public class UserService
    {
        private readonly IUserPost<User, int> _userRepo;
        public UserService(IUserPost<User, int> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepo.GetAll();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepo.GetById(id);
        }
        public async Task<User> CreateUser(User user)
        {
            return await _userRepo.Create(user);
        }
        public async Task<User> UpdateUser(User user)
        {
            return await (_userRepo as UserRepo)?.Update(user) ?? throw new Exception("Update operation not supported");
        }
       public async Task<User> DeleteUser(int id)
        {
            return await (_userRepo as UserRepo)?.Delete(id) ?? throw new Exception("Delete operation not supported");
        }

    }
}
