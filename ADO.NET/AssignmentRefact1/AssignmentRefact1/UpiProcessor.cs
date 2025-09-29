using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    internal class UpiProcessor : IPaymentProcessor
    {
        public void Process(Order order)
        {
            Console.WriteLine($"Processing UPI payment for {order.ProductName}...");
        }
    }
}
