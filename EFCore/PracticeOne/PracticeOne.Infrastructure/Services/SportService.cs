using PracticeOne.Application.Interface;
using PracticeOne.Domain;
using PracticeOne.Infrastructure.Repository;
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
        public async Task<Sport> GetById(int id)
        {
            return await _sportRepo.GetById(id);
        }
        public async Task<Sport> Update(Sport sport)
        {
            return await _sportRepo.Update(sport);
        }
        public async Task<bool> Delete(int id)
        {
            return await _sportRepo.Delete(id);
        }
    }
}
