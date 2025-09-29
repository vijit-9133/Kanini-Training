using ADOAssignment1;
using Microsoft.Data.SqlClient;

internal  class Program
{
    private static void Main(string[] args)
    {
        string choice;
        do
        {
            Console.WriteLine("\n--- Car Database CRUD Operations Menu ---");
            Console.WriteLine("1. Create Table (Cars)");
            Console.WriteLine("2. Add Car");
            Console.WriteLine("3. Display All Cars");
            Console.WriteLine("4. Update Car Price");
            Console.WriteLine("5. Delete Car");
            Console.WriteLine("6. Exit");
            Console.WriteLine("7. Search Car");
            Console.Write("Enter your choice: ");
            try
            {
                int ch = Convert.ToInt32(Console.ReadLine());
                CRUD c = new CRUD();
                switch (ch)
                {
                    case 1:
                        CRUD.CreateTable();
                        break;
                    case 2:
                        CRUD.AddCar();
                        break;
                    case 3:
                        CRUD.DisplayCars();
                        break;
                    case 4:
                        CRUD.UpdateCar();
                        break;
                    case 5:
                        CRUD.DeleteCar();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program.");
                        return;
                    case 7:
                        CRUD.SearchCar();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nDo you want to perform another operation? (yes/no)");
            choice = Console.ReadLine();
        } while (choice != null && choice.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase));
    }
}