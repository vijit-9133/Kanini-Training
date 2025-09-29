using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest4
    {
        public void RegistrationForm()
        {
            Console.WriteLine("Registration Form");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            string age = Console.ReadLine();
            Console.WriteLine("Enter your country:");
            string country = Console.ReadLine();

            Console.WriteLine($"Welcome {name}. Your age is {age} and you are from {country}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
