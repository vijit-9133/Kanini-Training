using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    public class Freelancer : Employee
    {
        public Freelancer(string name) : base(name) { }

        public override void CalculateSalary(int hoursWorked)
        {
            Console.WriteLine($"{Name} (Freelancer) Payment Per Task: {hoursWorked * 20}");
        }
    }
}
