using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Employee
    {
        public string Name { get; set; }
        public string EmployeeId { get; set; }

        // Base class constructor
        public Employee(string name, string employeeId)
        {
            Name = name;
            EmployeeId = employeeId;
            Console.WriteLine($"Employee constructor called for {Name}.");
        }

        // A virtual method that can be overridden by derived classes
        public virtual void Display()
        {
            Console.WriteLine($"Name: {Name}, Employee ID: {EmployeeId}");
        }
    }
}
