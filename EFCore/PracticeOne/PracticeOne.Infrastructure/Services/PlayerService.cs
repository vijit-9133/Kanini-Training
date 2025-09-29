using PracticeOne.Application.Interface;
using PracticeOne.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticeOne.Infrastructure.Services.PlayerService;

namespace PracticeOne.Infrastructure.Services
{
    public class PlayerService
    {
        private readonly IPlayer _playerRepo;
        public PlayerService(IPlayer playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _playerRepo.GetAll();
        }
        public async Task<Player> Create(Player player)
        {
            return await _playerRepo.Create(player);
        }
       
        public async Task<Player> GetById(int id)
        {
            return await _playerRepo.GetById(id);
        }
        public async Task<Player> Update(Player player)
        {
            return await _playerRepo.Update(player);
        }
        public async Task<bool> Delete(int id)
        {
            return await _playerRepo.Delete(id);
        }

    }
}
