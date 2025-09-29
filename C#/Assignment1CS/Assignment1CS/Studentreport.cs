using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1CS
{
    public class Studentreport
    {
        public StudentData CollectInput()
        {
            Console.WriteLine("--- Learner Information Collection ---");
            Console.Write("Enter Learner Name: ");
            string sname = Console.ReadLine();
            int age;
            while (true)
            {
                Console.Write("Enter Age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a positive whole number.");
                }
            }
            double mark1, mark2, mark3;

            while (true)
            {
                Console.Write("Enter Marks for Course 1: ");
                if (double.TryParse(Console.ReadLine(), out mark1) && mark1 >= 0 && mark1 <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter a number between 0 and 100.");
                }
            }

            while (true)
            {
                Console.Write("Enter Marks for Course 2: ");
                if (double.TryParse(Console.ReadLine(), out mark2) && mark2 >= 0 && mark2 <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter a number between 0 and 100.");
                }
            }

            while (true)
            {
                Console.Write("Enter Marks for Course 3: ");
                if (double.TryParse(Console.ReadLine(), out mark3) && mark3 >= 0 && mark3 <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid mark. Please enter a number between 0 and 100.");
                }
            }

            return new StudentData(sname, age, mark1, mark2, mark3);
        }

        public void ProcessLearnerData(StudentData data)
        {
            data.TotalMarks = data.Mark1 + data.Mark2 + data.Mark3;
            data.AverageMarks = data.TotalMarks / 3;

            if (data.AverageMarks >= 90)
            {
                data.Grade = "A";
            }
            else if (data.AverageMarks >= 75 && data.AverageMarks < 90)
            {
                data.Grade = "B";
            }
            else if (data.AverageMarks >= 50 && data.AverageMarks < 75)
            {
                data.Grade = "C";
            }
            else
            {
                data.Grade = "F";
            }
        }

        public void Display(StudentData data)
        {
            Console.WriteLine("\n--- Learner Report ---");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Name: {data.Name}");
            Console.WriteLine($"Age: {data.Age}");
            Console.WriteLine($"Total Marks: {data.TotalMarks}");
            Console.WriteLine($"Average: {data.AverageMarks:F1}");
            Console.WriteLine($"Grade: {data.Grade}");
        }
    }

    public class StudentData
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }
        public double Mark3 { get; set; }
        public double TotalMarks { get; set; }
        public double AverageMarks { get; set; }
        public string Grade { get; set; }

        public StudentData(string name, int age, double mark1, double mark2, double mark3)
        {
            Name = name;
            Age = age;
            Mark1 = mark1;
            Mark2 = mark2;
            Mark3 = mark3;
        }
    }
}

