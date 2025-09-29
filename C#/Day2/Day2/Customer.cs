using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Customer
    {
        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                if (value == "Customer1")
                {
                    _customerName = value;
                    Console.WriteLine($"Customer name successfully set to: {_customerName}");
                }
                else
                {
                    Console.WriteLine($"Error: Cannot set name to '{value}'. Only 'Customer1' is allowed.");
                }
            }
        }
    }
}
