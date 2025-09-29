using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class DivisionOut
    {
        public static void DivideWithOut(int dividend, int divisor, out int result, out int remainder)
        {
            if (divisor != 0)
            {
                result = dividend / divisor;
                remainder = dividend % divisor;
            }
            else
            {
                result = 0;
                remainder = 0;
                Console.WriteLine("Warning: Cannot divide by zero. Result and remainder set to 0.");
            }
        }
    }
}
