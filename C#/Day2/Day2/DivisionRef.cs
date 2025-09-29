using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class DivisionRef
    {
        public static void DivideWithRef(int dividend, int divisor, ref double result)
        {
            if (divisor != 0)
            {
                result = (double)dividend / divisor;
            }
            else
            {
                result = double.NaN; // Not a Number for division by zero
            }
        }
    }
}
