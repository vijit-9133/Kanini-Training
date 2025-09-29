using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assessment
{
    internal class PersonalLoan : Loan
    {
        private double salary;
        private int noOfYears;
        public double Salary { 
          get { return salary; } 
            set { salary = value; }
        }
        public int NoOfYears
        {
            get { return noOfYears; }
            set { noOfYears = value; }
        }
        public override double calculateInterest()
        {
            double Rate;
            if (Salary< 25000)
            {
                Rate = 12.0;
            }
            else
            {
                Rate = 10.0;
            }
            double interest = (LoanAmount * Rate * NoOfYears) / 100;
            return interest;
        }

    }
}
