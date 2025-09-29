using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class TV : IElectronicDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Television is powering on and showing a picture.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Television is powering off.");
        }
    }
}
