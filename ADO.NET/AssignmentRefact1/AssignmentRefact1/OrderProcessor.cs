using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AssignmentRefact1.IOrder;

namespace AssignmentRefact1
{
    public class OrderProcessor
    {
        private readonly OrderValidator _validator;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly OrderRepository _repository;
        private readonly EmailService _emailService;

        public OrderProcessor(OrderValidator validator, IPaymentProcessor paymentProcessor, OrderRepository repository, EmailService emailService)
        {
            _validator = validator;
            _paymentProcessor = paymentProcessor;
            _repository = repository;
            _emailService = emailService;
        }

        public void ProcessOrder(Order order)
        {
            if (!_validator.IsValid(order))
            {
                return;
            }

            _paymentProcessor.Process(order);
            _repository.Save(order);
            _emailService.SendConfirmationEmail(order);
        }
    }
}
