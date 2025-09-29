using PracticeOne.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Application.Interface
{
    public interface ISport
    {
        
        Task<Sport> Create(Sport sport);

       
        Task<IEnumerable<Sport>> GetAll();
        Task<Sport> GetById(int id);
        Task<Sport> Update(Sport sport);
        Task<bool> Delete(int id);
    }
}

