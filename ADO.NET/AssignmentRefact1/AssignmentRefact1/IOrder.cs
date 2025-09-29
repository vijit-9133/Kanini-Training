using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentRefact1
{
    public interface IOrder
    {
        public class Order
        {
            public string ProductName { get; set; }
            public double Amount { get; set; }
        }
        public interface IPaymentProcessor
        {
            void Process(Order order);
        }
    }
}
