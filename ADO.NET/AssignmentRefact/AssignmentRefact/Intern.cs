using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    public class Intern : Employee
    {
        public Intern(string name) : base(name) { }

        public override void CalculateSalary(int hoursWorked)
        {
            Console.WriteLine($"{Name} (Intern) has no salary.");
        }
    }
}
