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
    }
}

