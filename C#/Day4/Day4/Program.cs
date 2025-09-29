using Day4;

internal class Program
{
    private static void Main(string[] args)
    {
        Practice p = new Practice();
        p.StringPract();
        p.StringBuildPract();
        p.MathPract();
        //Account myAccount = new Account("1234567890", "Vijit Shetty", 1000.00m);

        //string choice = "";
        //do
        //{
        //    Console.Clear();
        //    Console.WriteLine("--- Account Management System ---");
        //    Console.WriteLine("1. Deposit");
        //    Console.WriteLine("2. Withdraw");
        //    Console.WriteLine("3. Check Balance");
        //    Console.WriteLine("4. Exit");
        //    Console.WriteLine("-----------------------------------");
        //    Console.Write("Enter your choice: ");
        //    choice = Console.ReadLine();

        //    switch (choice)
        //    {
        //        case "1":
        //            Console.Write("Enter amount to deposit: ");
        //            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
        //            {
        //                myAccount.Deposit(depositAmount);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid amount entered.");
        //            }
        //            Console.WriteLine("\nPress any key to continue...");
        //            Console.ReadKey();
        //            break;

        //        case "2":
        //            Console.Write("Enter amount to withdraw: ");
        //            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
        //            {
        //                myAccount.Withdraw(withdrawAmount);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Invalid amount entered.");
        //            }
        //            Console.WriteLine("\nPress any key to continue...");
        //            Console.ReadKey();
        //            break;

        //        case "3":
        //            myAccount.DisplayAccountInfo();
        //            Console.WriteLine("\nPress any key to continue...");
        //            Console.ReadKey();
        //            break;

        //        case "4":
        //            Console.WriteLine("\nExiting program...");
        //            break;

        //        default:
        //            Console.WriteLine("\nInvalid choice. Please enter a number from 1 to 4.");
        //            Console.WriteLine("\nPress any key to continue...");
        //            Console.ReadKey();
        //            break;
        //    }

        //} while (choice != "4");
    
        // ========================================================
        //Console.WriteLine("Student information");
        //Console.WriteLine("\nEnter details for the student:");
        //Console.Write("Enter Student Name: ");
        //string sName = Console.ReadLine();
        //Console.Write("Enter Age: ");
        //string sAge= Console.ReadLine();
        //Console.Write("Enter Year: ");
        //int sGrade = int.Parse(Console.ReadLine());
        //Student s = new Student(sName,sGrade,sAge);
        //Console.WriteLine();
        //s.Display();
        // ========================================================
        //Console.WriteLine("--- Vehicle Information Program ---");
        //Console.WriteLine("Please choose a vehicle type:");
        //Console.WriteLine("1. Car");
        //Console.WriteLine("2. Bike");
        //Console.Write("Enter your choice (1 or 2): ");
        //string choice = Console.ReadLine();

        //switch (choice)
        //{
        //    case "1":
        //        Console.WriteLine("\nEnter details for a car:");
        //        Console.Write("Enter Make: ");
        //        string carMake = Console.ReadLine();
        //        Console.Write("Enter Model: ");
        //        string carModel = Console.ReadLine();
        //        Console.Write("Enter Year: ");
        //        int carYear = int.Parse(Console.ReadLine());
        //        Car myCar = new Car(carMake, carModel, carYear);
        //        Console.WriteLine();
        //        myCar.GetInfo();
        //        break;

        //    case "2":
        //        Console.WriteLine("\nEnter details for a bike:");
        //        Console.Write("Enter Make: ");
        //        string bikeMake = Console.ReadLine();
        //        Console.Write("Enter Model: ");
        //        string bikeModel = Console.ReadLine();
        //        Console.Write("Enter Year: ");
        //        int bikeYear = int.Parse(Console.ReadLine());
        //        Bike myBike = new Bike(bikeMake, bikeModel, bikeYear);
        //        Console.WriteLine();
        //        myBike.GetInfo();
        //        break;

        //    default:
        //        Console.WriteLine("\nInvalid choice. Please enter 1 or 2.");
        //        break;
        //}

        //Console.WriteLine();
        //Console.WriteLine("Press any key to exit.");
        //Console.ReadKey();
}
}
