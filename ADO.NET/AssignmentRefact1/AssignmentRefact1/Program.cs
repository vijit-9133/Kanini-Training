// Program.cs
using AssignmentRefact1;
using static AssignmentRefact1.IOrder;

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order
        {
            ProductName = "Laptop",
            Amount = 50000
        };

        IPaymentProcessor processor = new CreditCardProcessor();

        OrderProcessor orderProcessor = new OrderProcessor(
            new OrderValidator(),
            processor,
            new OrderRepository(),
            new EmailService()
        );

        orderProcessor.ProcessOrder(order);

        Console.WriteLine("\nProcessing UPI Order...");
        IPaymentProcessor upiProcessor = new UpiProcessor();
        OrderProcessor upiOrderProcessor = new OrderProcessor(
            new OrderValidator(),
            upiProcessor,
            new OrderRepository(),
            new EmailService()
        );
        upiOrderProcessor.ProcessOrder(order);
    }
}