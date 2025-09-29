using PracticeOne.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Application.Interface
{
    public interface IPlayer
    {
        
        Task<Player> Create(Player player);

        
        Task<IEnumerable<Player>> GetAll();
    }
}
