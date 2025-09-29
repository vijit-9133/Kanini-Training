using Microsoft.EntityFrameworkCore;
using PracticeOne.Application.Interface;
using PracticeOne.Data;
using PracticeOne.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Infrastructure.Repository
{
    public class PlayerRepo : IPlayer
    {
        private readonly PlayerSportDbContext _context;
        public PlayerRepo(PlayerSportDbContext context)
        {
            _context = context;
        }
        public async Task<Player> Create(Player player)
        {
            await _context.Players.AddAsync(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetById(int id)
        {
            return await _context.Players.FirstOrDefaultAsync(s=>s.PlayerId == id)?? throw new Exception("Player not found");
        }
        public async Task<Player> Update(Player player)
        {
            var existingPlayer = await _context.Players.FindAsync(player.PlayerId);
            if (existingPlayer == null)
            {
                throw new Exception("Player not found");
            }
            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;
            existingPlayer.IsCaptain = player.IsCaptain;
            _context.Players.Update(existingPlayer);
            await _context.SaveChangesAsync();
            return existingPlayer;
        }
        public async Task<bool> Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return false;
            }
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

