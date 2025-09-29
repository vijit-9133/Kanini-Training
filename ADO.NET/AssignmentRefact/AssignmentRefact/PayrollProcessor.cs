using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact
{
    public class PayrollProcessor
    {
        public static void ProcessPayroll(IEmployee employee, int hoursWorked)
        {
            employee.CalculateSalary(hoursWorked);
            employee.ProcessPayment();
            employee.GeneratePaySlip();
        }
    }
}
