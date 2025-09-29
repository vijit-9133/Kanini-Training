using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class Laptop : IElectronicDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Laptop is booting up and displaying the operating system.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Laptop is shutting down.");
        }

    }
}
