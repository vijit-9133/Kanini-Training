using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    public class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Saving order to database...");
        }
    }
}
