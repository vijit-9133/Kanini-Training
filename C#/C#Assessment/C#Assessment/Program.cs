using C_Assessment;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Working Days Calculator");
                Console.Write("Enter the start date: ");
                DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.Write("Enter the end date : ");
                DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.WriteLine("Enter holidays:");
                string holidayInput = Console.ReadLine();
                List<DateTime> holidays = new List<DateTime>();

                if (!string.IsNullOrWhiteSpace(holidayInput))
                {
                    holidays = holidayInput.Split(',')
                                           .Select(dateStr => DateTime.ParseExact(dateStr.Trim(), "dd-MM-yyyy", null))
                                           .ToList();
                }
                int workingDays = Work_Schedule_Calcy.Calculate(startDate, endDate, holidays);

                Console.WriteLine(" Calculation Results");
                Console.WriteLine($"Total working days: {workingDays}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use dd-MM-yyyy.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



            Console.WriteLine("=============================================");

            //        Console.WriteLine("Enter Loan ID:");
            //        string loanID = Console.ReadLine();
            //        Console.WriteLine("Enter Customer Name :");
            //        string customerName = Console.ReadLine();
            //        Console.WriteLine("Enter Loan Amount :");
            //        double loanAmount = double.Parse(Console.ReadLine());
            //        Console.WriteLine("Choose what you want to do:");
            //        Console.WriteLine("1. Home Loan");
            //        Console.WriteLine("2.Personal Loan");
            //        int choice = int.Parse(Console.ReadLine());
            //        double Interest = 0.0;
            //        switch (choice)
            //        {
            //            case 1:
            //                Console.WriteLine("Enter Property Value:");
            //                double propertyValue = Convert.ToDouble(Console.ReadLine());
            //                Console.WriteLine("Enter the interest rate :");
            //                float interestRate = (float)Convert.ToDouble(Console.ReadLine());
            //                HomeLoan homeLoan = new HomeLoan();
            //                homeLoan.LoanId = loanID;
            //                homeLoan.CustomerName = customerName;
            //                homeLoan.LoanAmount = loanAmount;
            //                homeLoan.PropertyValue = propertyValue;
            //                homeLoan.InterestRate = interestRate;
            //                Interest = processLoan(homeLoan, choice);
            //                break;
            //            case 2:
            //                Console.WriteLine("Enter Salary:");
            //                double salary = Convert.ToDouble(Console.ReadLine());
            //                Console.WriteLine("Enter Number of years : ");
            //                int noOfYears = Convert.ToInt32(Console.ReadLine());
            //                PersonalLoan personalLoan = new PersonalLoan();
            //                personalLoan.LoanId = loanID;
            //                personalLoan.CustomerName = customerName;
            //                personalLoan.LoanAmount = loanAmount;
            //                personalLoan.Salary = salary;
            //                personalLoan.NoOfYears = noOfYears;
            //                Interest = processLoan(personalLoan, choice);
            //                break;
            //            default:
            //                Console.WriteLine("Invalid option selected.");
            //                return;
            //        }
            //        Console.WriteLine($"Calculated Interest : {Interest}");



            //    }
            //}
            //    public static double processLoan(Loan loan, int opt)
            //{
            //    return loan.calculateInterest();
            //}
        }
    }
}