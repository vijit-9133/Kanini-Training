using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Manager : Employee
    {
        public string DepartmentName { get; set; }
        // Manager constructor calls the base class constructor
        public Manager(string name, string employeeId, string departmentName) : base(name, employeeId)
        {
            DepartmentName = departmentName;
            Console.WriteLine($"Manager constructor called for {Name}.");
        }
        // Overriding the Display method from the base class
        public override void Display()
        {
            // Calling the base class method to reuse its logic
            base.Display();
            Console.WriteLine($"Role: Manager, Department: {DepartmentName}");
        }
    }
}
