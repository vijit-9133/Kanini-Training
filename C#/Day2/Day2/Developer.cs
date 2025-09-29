using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }
        public Developer(string name, string employeeId, string language) : base(name, employeeId)
        {
            ProgrammingLanguage = language;
            Console.WriteLine($"Developer constructor called for {Name}.");
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Role: Developer, Language: {ProgrammingLanguage}");
        }
    }
}