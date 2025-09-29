using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Application.DTO
{
    public class SportDTO
    {
        [Required(ErrorMessage = "Sport name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Number of players must be a positive integer.")]
        public int? NumberOfPlayers { get; set; }
        //public List<int> PlayerIds { get; set; } = new List<int>();
    }
}
