using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Domain
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? NumberOfPlayers { get; set; }
        public ICollection<PlayerSport>? PlayerSports { get; set; }
    }
}
