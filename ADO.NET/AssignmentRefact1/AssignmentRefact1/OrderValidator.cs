using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    public class OrderValidator
    {
        public bool IsValid(Order order)
        {
            if (string.IsNullOrEmpty(order.ProductName))
            {
                Console.WriteLine("Invalid product name.");
                return false;
            }
            return true;
        }
    }
}
