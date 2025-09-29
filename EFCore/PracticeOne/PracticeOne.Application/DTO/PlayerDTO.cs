using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Application.DTO
{
    public class PlayerDTO
    {
        [Required(ErrorMessage = "Player name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Player age is required.")]
        [Range(15, 60, ErrorMessage = "Age must be between 15 and 60.")]
        public int Age { get; set; }

        public bool IsCaptain { get; set; } = false;

       
        //public List<int> SportIds { get; set; } = new List<int>();
    }
}

