using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; set; }

        protected Employee(string name)
        {
            Name = name;
        }

        public abstract void CalculateSalary(int hoursWorked);

        public void ProcessPayment()
        {
            Console.WriteLine($"Processing Payment for {Name}");
        }

        public void GeneratePaySlip()
        {
            string paySlip = $"Payslip for {Name}";
            File.WriteAllText($"{Name}_Payslip.txt", paySlip);
            Console.WriteLine("Payslip Generated");
        }
    }
}
