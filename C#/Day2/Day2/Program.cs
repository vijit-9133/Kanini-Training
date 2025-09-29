using Day2;

internal class Program
{
    public static void Main(string[] args)
    {
        Developer dev = new Developer("Jane Smith", "D456", "C#");
        Console.WriteLine("\nDisplaying information for the Developer:");
        dev.Display();
        Console.WriteLine();
        Tester tester = new Tester("Mike Brown", "T789", "Selenium");
        Console.WriteLine("\nDisplaying information for the Tester:");
        tester.Display();
        Console.WriteLine();
        Console.WriteLine("=============================================================");
        Customer myCustomer = new Customer();
        myCustomer.CustomerName = "Customer1";
        Console.WriteLine($"Current customer name: {myCustomer.CustomerName ?? "Not Set"}");
        Console.WriteLine();
        myCustomer.CustomerName = "Michael";
        Console.WriteLine($"Current customer name: {myCustomer.CustomerName ?? "Not Set"}");
        Console.WriteLine("=============================================================");
        Console.WriteLine("Enter number:");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number:");
        int num2 = int.Parse(Console.ReadLine());
        double refResult = 0;
        DivisionRef.DivideWithRef(num1, num2, ref refResult);
        Console.WriteLine($"Result from ref parameter method: {refResult:F2}");
        Console.WriteLine();
        DivisionOut divisionOut = new DivisionOut();
        DivisionOut.DivideWithOut(num1, num2, out int outResult, out int outRemainder);
        Console.WriteLine($"Result from out parameter method: {outResult}");
        Console.WriteLine($"Remainder from out parameter method: {outRemainder}");

        Console.WriteLine("=============================================================");
        Console.WriteLine("Multi-Level Inheritance");
        Department it = new Department("John Doe", "E123", "IT", "Building A");
        Console.WriteLine("\nDisplaying information for the Department:");
        it.Display();
        Console.ReadKey();

    }
}