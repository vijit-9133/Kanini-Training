using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    public class EmailService
    {
        public void SendConfirmationEmail(Order order)
        {
            Console.WriteLine("Sending confirmation email to customer...");
        }
    }
}
