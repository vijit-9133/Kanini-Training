using ChainingIFwithIS;
using HandsOn;
internal class Program
{
    private static void Main(string[] args)
    {
        var people = new List<Employee>
        {
            new Employee { FName = "Alice", LName = "Johnson", Job = "Analyst", Salary = 45000 },
            new Manager { FName = "Bob", LName = "Williams", Job = "Manager", Salary = 65000, TeamSize = 10 },
            new Recruiter { FName = "Neha", LName = "Kumari", Job = "Recruiter", Salary = 40000, HiresThisMonth = 5 },
            new Employee { FName = "Vikas", LName = "Reddy", Job = "Engineer", Salary = 60000 }
        };

        Console.WriteLine("Processing employee records\n");

        foreach (var person in people)
        {
            // The 'is' keyword checks the type and assigns to a new variable
            if (person is Manager manager)
            {
                Console.WriteLine($"Processing Manager: {manager.FName} {manager.LName}");
                Console.WriteLine($"  Team size is: {manager.TeamSize}");
            }
            else if (person is Recruiter recruiter)
            {
                Console.WriteLine($"Processing Recruiter: {recruiter.FName} {recruiter.LName}");
                Console.WriteLine($"  Hires this month: {recruiter.HiresThisMonth}");
            }
            else if (person is Employee employee)
            {
                Console.WriteLine($"Processing generic Employee: {employee.FName} {employee.LName}");
                Console.WriteLine($"  Job title: {employee.Job}");
            }
        }
    }
}