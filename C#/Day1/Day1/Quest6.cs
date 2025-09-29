using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest6
    {
        public void BooleanResult()
        {
            Console.WriteLine("BooleanResult");
            Console.WriteLine("Enter the value for x");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value for y");
            int y = int.Parse(Console.ReadLine());

            bool result = x < y;

            Console.WriteLine($"The result of whether x is less than y is {result.ToString().ToLower()}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
