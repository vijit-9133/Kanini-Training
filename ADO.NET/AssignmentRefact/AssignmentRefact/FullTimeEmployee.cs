using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssignmentRefact
{
    public class FullTimeEmployee : Employee
    {
    public FullTimeEmployee(string name) : base(name) { }

    public override void CalculateSalary(int hoursWorked)
    {
        Console.WriteLine($"{Name} (Full-Time) Salary: {hoursWorked * 50}");
    }
}
}
