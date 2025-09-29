using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Quest2
    {
         public void Reverse() {
            Console.WriteLine("Reversing a string");
            Console.WriteLine("Enter a string: ");
            string s = Console.ReadLine();
            string[] r = s.Split(' ');
            Array.Reverse(r);
            string rev = string.Join(" ", r);


            Console.WriteLine("The resversed string is : " +rev);

        }
        
    }
}
