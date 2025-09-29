using Day5;
using System.Collections;
using System.Globalization;

internal class Program
{
    private static Dictionary<string, List<string>> clubGroups = new Dictionary<string, List<string>>();

    private static void Main(string[] args)
    {

        clubGroups.Add("Gold", new List<string> { "Tom", "Harry" });
        clubGroups.Add("Silver", new List<string> { "Sam", "Peter" });
        clubGroups.Add("Platinum", new List<string> { "Mary", "Jane" });

        Console.WriteLine("--- LakeView Club Member Manager ---");

        Console.Write("Group Name: ");
        string groupName = Console.ReadLine();

        Console.Write("Member Name: ");
        string memberName = Console.ReadLine();

        if (clubGroups.ContainsKey(groupName))
        {
            clubGroups[groupName].Add(memberName);

            Console.WriteLine("\nMembers in " + groupName + " group:");
            foreach (string member in clubGroups[groupName])
            {
                Console.WriteLine(member);
            }
        }
        else
        {
            Console.WriteLine("The group name entered does not exist.");
        }
        //=========================================================================
        Player player = new Player();

        Console.WriteLine("--- Cricket Ball Calculator ---");

        Console.Write("Enter the number of overs: ");

        if (int.TryParse(Console.ReadLine(), out int overs))
        {
            player.AddOversDetails(overs);

            int totalBalls = player.GetNoOfBallsBowled();

            Console.WriteLine($"Balls Bowled : {totalBalls}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a whole number.");
        }

        //====================================================================================

        ArrayList productList = new ArrayList();

        Console.WriteLine("--- Product Entry Program ---");
        Console.WriteLine("Enter product details in the format: ProductName,SerialNumber,DD-MM-YYYY,Cost");
        Console.WriteLine("Enter 'done' when you have finished.");
        Console.WriteLine("-----------------------------------------------------------------------------");

        string input;
        while (true)
        {
            Console.Write("Enter product details: ");
            input = Console.ReadLine();

            if (input.ToLower() == "done")
            {
                break;
            }

            string[] productDetails = input.Split(',');

            if (productDetails.Length == 4)
            {
                string pName = productDetails[0].Trim();
                string serialNumber = productDetails[1].Trim();
                DateTime dateofPurchase;
                double cost;


                bool dateParsed = DateTime.TryParseExact(
                    productDetails[2].Trim(),
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateofPurchase
                );
                bool costParsed = double.TryParse(productDetails[3].Trim(), out cost);

                if (dateParsed && costParsed)
                {
                    Product newProduct = new Product(pName, serialNumber, dateofPurchase, cost);
                    productList.Add(newProduct);
                    Console.WriteLine("Product added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date or cost format. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input format. Please enter four comma-separated values.");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n--- Product Report ---");
        Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Product Name", "Serial Number", "Purchase Date", "Purchase Cost"));
        Console.WriteLine("-----------------------------------------------------------------------------");

        foreach (Product p in productList)
        {
            Console.WriteLine(String.Format("{0,-15}{1,-15}{2,-15}{3,-15}",
                p.pName,
                p.serialNumber,
                p.dateofPurchase.ToString("dd-MM-yyyy"),
                p.cost.ToString("C", CultureInfo.InvariantCulture)
            ));
        }
        //Console.Write("Enter a flight number: ");
        //string flightNumber = Console.ReadLine();
        //Flight f = new Flight();
        //string statusMessage = f.flightStatus(flightNumber);
        //Console.WriteLine(statusMessage);
    }
}