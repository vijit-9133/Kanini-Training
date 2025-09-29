using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Domain
{
    public class PlayerSport
    {
        public int PlayerId { get; set; }
        public int SportId { get; set; }
        public Player Player { get; set; }
        public Sport Sport { get; set; }

    }
}
