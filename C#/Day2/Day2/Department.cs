using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Department : Manager
    {
        public string Location { get; set; }

        // Department constructor calls the base class constructor
        public Department(string name, string employeeId, string departmentName, string location) : base(name, employeeId, departmentName)
        {
            Location = location;
            Console.WriteLine($"Department constructor called for {Name}.");
        }

        // Overriding the Display method again
        public override void Display()
        {
            // Calling the base class method to reuse its logic
            base.Display();
            Console.WriteLine($"Location: {Location}");
        }
    }
}
