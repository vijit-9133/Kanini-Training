using PracticeOne.Application.Interface;
using PracticeOne.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Infrastructure.Services
{
    public class SportService : ISport
    {
        private readonly ISport _sportRepo;
        public SportService(ISport sportRepo)
        {
            _sportRepo = sportRepo;
        }
        public async Task<IEnumerable<Sport>> GetAll()
        {
            return await _sportRepo.GetAll();
        }
        public async Task<Sport> Create(Sport sport)
        {
            return await _sportRepo.Create(sport);
        }
    }
}
