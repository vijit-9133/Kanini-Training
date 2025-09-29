using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Student
    {
        public string Name;
        public int Age;
        public string Grade;
        public Student(string name, int age, string grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public void Display()
        {
            Console.WriteLine("Details of the Student");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Grade: " + Grade);
        }
    }
}
