internal class Program
{
    private static void Main(string[] args)
    { 
    Console.WriteLine("Generating a sequence of even numbers:");

        foreach (int number in GetEvenNumbers(10))
        {
            Console.WriteLine($"Received: {number}");

            if (number >= 6)
            {
                Console.WriteLine("Stopping the loop after 6.");
                break;
            }
        }
        
        Console.WriteLine("\nIteration complete.");
    }

    public static IEnumerable<int> GetEvenNumbers(int max)
{
    Console.WriteLine("--> Iterator started");

    for (int i = 0; i <= max; i++)
    {
        if (i % 2 == 0)
        {
            Console.WriteLine($"   Yielding {i}...");
            yield return i;
        }
    }

    Console.WriteLine("Iterator finished");
}
}
