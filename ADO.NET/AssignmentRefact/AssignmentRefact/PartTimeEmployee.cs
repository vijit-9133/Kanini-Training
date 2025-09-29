using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    public class PartTimeEmployee : Employee
    {
        public PartTimeEmployee(string name) : base(name) { }

        public override void CalculateSalary(int hoursWorked)
        {
            Console.WriteLine($"{Name} (Part-Time) Salary: {hoursWorked * 30}");
        }
    }
}
