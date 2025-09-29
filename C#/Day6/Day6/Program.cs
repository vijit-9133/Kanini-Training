using Day6;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //TypeChecker("Kanini");
        //TypeChecker(100);
        //GenericDemo<int> spl = new GenericDemo<int>  (1 );
        //GenericDemo<string> ss = new GenericDemo<string>("Kanini");
        Console.WriteLine("--- Electronic Device Control ---");

        TV myTv = new TV();
        Laptop myLaptop = new Laptop();
        IElectronicDevice device1 = myTv;
        IElectronicDevice device2 = myLaptop;
        Console.WriteLine("\nTurning on devices:");
        device1.TurnOn();
        device2.TurnOn();
        Console.WriteLine("\nTurning off devices:");
        device1.TurnOff();
        device2.TurnOff();
    }
    static void TypeChecker<T>(T val) 
    {
        Console.WriteLine(val);
    }

}