using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Tester : Employee
    {
        public string TestingTool { get; set; }

        public Tester(string name, string employeeId, string tool) : base(name, employeeId)
        {
            TestingTool = tool;
            Console.WriteLine($"Tester constructor called for {Name}.");
        }

        // Overrides the method to add tester-specific info
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Role: Tester, Tool: {TestingTool}");
        }
    }
}