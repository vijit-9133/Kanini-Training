using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    internal class CreditCardProcessor : IPaymentProcessor
    {
        public void Process(Order order)
        {
            Console.WriteLine($"Processing credit card payment for {order.ProductName}...");
        }
    }
    

 }

