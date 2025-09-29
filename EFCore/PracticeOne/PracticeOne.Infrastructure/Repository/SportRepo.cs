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
    }
}
