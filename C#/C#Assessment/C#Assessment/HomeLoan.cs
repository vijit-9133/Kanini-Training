using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assessment
{
    internal class HomeLoan : Loan
    {
        private double propertyValue {  get; set; }
        private float interestRate {  get; set; }
        public double PropertyValue
        {
            get { return propertyValue; }
            set { propertyValue = value; }
        }

        public float InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
        public override double calculateInterest()
        {
            if (LoanAmount>0.8*PropertyValue)
            {
                interestRate +=2.0f;
            }
            double interest = (LoanAmount * interestRate) / 100;
            return interest;
        }
    }
}
