using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest5
    {
        public  double FindSquare(double number)
        {
            return number * number;
        }

        public  double FindCube(double number)
        {
            return number * number * number;
        }

        public  void FindSquareAndCube()
        {
            Console.WriteLine("Find Square and Cube");
            Console.WriteLine("Enter a Number");
            double num = double.Parse(Console.ReadLine());

            double square = FindSquare(num);
            double cube = FindCube(num);

            Console.WriteLine($"Square of {num} is {square}");
            Console.WriteLine($"Cube of {num} is {cube}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
