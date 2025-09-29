using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assessment
{
    internal class Loan
    {
        private string loanId;
        private string customerName;
        private double loanAmount;
        public string LoanId
        {
            get { return loanId; }
            set { loanId = value; }
        }
        public string CustomerName 
        { 
              get { return customerName; }
            set { customerName = value; }
        }
        public double LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; }
        }

        public virtual double calculateInterest() {
            return 0;

        }


    }
}
