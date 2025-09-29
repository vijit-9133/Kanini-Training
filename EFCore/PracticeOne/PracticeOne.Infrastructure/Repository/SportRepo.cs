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
    public class SportRepo : ISport
    {
        private readonly PlayerSportDbContext _context;
        public SportRepo(PlayerSportDbContext context)
        {
            _context = context;
        }
        public async Task<Sport> Create(Sport sport)
        {
            await _context.Sports.AddAsync(sport);

            await _context.SaveChangesAsync();

            return sport;
        }

        public async Task<IEnumerable<Sport>> GetAll()
        {
            return await _context.Sports.ToListAsync();
        }
        public async Task<Sport> GetById(int id)
        {
            return await _context.Sports.FirstOrDefaultAsync(s => s.SportId == id) ?? throw new Exception("Sport not found");
        }
        public async Task<Sport> Update(Sport sport)
        {
            var existingSport = await _context.Sports.FindAsync(sport.SportId);
            if (existingSport == null)
            {
                throw new Exception("Sport not found");
            }
            existingSport.Name = sport.Name;
            existingSport.NumberOfPlayers = sport.NumberOfPlayers;
            _context.Sports.Update(existingSport);
            await _context.SaveChangesAsync();
            return existingSport;
        }
        public async Task<bool> Delete(int id)
        {
            var sport = await _context.Sports.FindAsync(id);
            if (sport == null)
            {
                return false;
            }
            _context.Sports.Remove(sport);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
