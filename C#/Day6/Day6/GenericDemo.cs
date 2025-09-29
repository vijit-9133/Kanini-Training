using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class GenericDemo <T> //T is a placeholder type 
    {
        public T value { get; set; }
        public GenericDemo(T value)
        { 
         this.value = value;    
        }
    }
}
