using AssignmentRefact;

class Program
{
    static void Main()
    {
        IEmployee emp1 = new FullTimeEmployee("Anu");
        IEmployee emp2 = new PartTimeEmployee("Banu");
        IEmployee emp3 = new Freelancer("Charu");
        IEmployee emp4 = new Intern("Dinesh");

        PayrollProcessor processor = new PayrollProcessor();
       PayrollProcessor.ProcessPayroll(emp1, 40);
        PayrollProcessor.ProcessPayroll(emp2, 20);
        PayrollProcessor.ProcessPayroll(emp3, 10);
        PayrollProcessor.ProcessPayroll(emp4, 0);
    }
}
