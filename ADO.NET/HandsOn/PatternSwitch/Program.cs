using HandsOn;
internal class Program
{
    private static void Main(string[] args)
    {
        var employees = new List<Employee>
        {
            new Employee { FName = "Alice", LName = "Johnson", Job = "Manager", Salary = 65000 },
            new Employee { FName = "Bob", LName = "Williams", Job = "Analyst", Salary = 45000 },
            new Employee { FName = "Charlie", LName = "Brown", Job = "Developer", Salary = 55000 },
            new Employee { FName = "Neha", LName = "Kumari", Job = "Recruiter", Salary = 40000 },
            new Employee { FName = "Vikas", LName = "Reddy", Job = "Engineer", Salary = 60000 },
            new Employee { FName = "Anjali", LName = "Dewi", Job = "Associate", Salary = 38000 }
        };

        Console.WriteLine("Employee Bonus Calculation:");
        Console.WriteLine("------------------------------");

        foreach (var employee in employees)
        {
            decimal bonus = employee switch
            {
                // Property Pattern
                { Job: "Manager" } => employee.Salary * 0.10m,
                // Property and Relational Pattern
                { Job: "Engineer", Salary: > 58000 } => employee.Salary * 0.08m,
                // Logical Pattern
                { Job: "Developer" or "Analyst" } => employee.Salary * 0.05m,
                // Discard Pattern
                _ => 0m
            };

            Console.WriteLine($"{employee.FName + " " + employee.LName,-25} | {employee.Job,-15} | {bonus,-10}");
        }
    }
}