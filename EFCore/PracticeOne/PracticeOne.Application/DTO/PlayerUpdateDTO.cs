using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeOne.Application.DTO
{
    public  class PlayerUpdateDTO
    {
        public string Name { get; set; } 
        public int Age { get; set; }
        public bool IsCaptain { get; set; } = false;
    }
}
