using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest1
    {
        public static void Display()
        {
            Console.WriteLine("Enter your first name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            string lname = Console.ReadLine();
            Console.WriteLine($"Full name:{fname} {lname}");
        }
    }
}
