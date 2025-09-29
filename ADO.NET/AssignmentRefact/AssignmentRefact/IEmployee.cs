using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    internal interface IEmployee
    {
        void CalculateSalary(int hoursWorked);
        void ProcessPayment();
        void GeneratePaySlip();
    }
}
