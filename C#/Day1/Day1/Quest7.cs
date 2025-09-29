using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Quest7
    {
        public void GenerateBillDetails()
        {
            Console.WriteLine("Generate Bill Details");
            const int pizzaPrice = 200;
            const int puffsPrice = 40;
            const int pepsiPrice = 120;

            Console.WriteLine("Enter the number of pizzas bought:");
            int numPizzas = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of puffs bought:");
            int numPuffs = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of pepsi bought:");
            int numPepsi = int.Parse(Console.ReadLine());

            double costPizzas = numPizzas * pizzaPrice;
            double costPuffs = numPuffs * puffsPrice;
            double costPepsi = numPepsi * pepsiPrice;

            double totalPrice = costPizzas + costPuffs + costPepsi;

            const double gstRate = 0.12;
            const double cessRate = 0.05;

            double gstAmount = totalPrice * gstRate;
            double cessAmount = totalPrice * cessRate;

            Console.WriteLine("Bill Details");
            Console.WriteLine($"Cost of Pizzas:{costPizzas}");
            Console.WriteLine($"Cost of Puffs :{costPuffs}");
            Console.WriteLine($"Cost of Pepsis :{costPepsi}");
            Console.WriteLine($"GST 12%: {gstAmount}");
            Console.WriteLine($"CESS 5%: {cessAmount}");
            Console.WriteLine($"Total Price: {totalPrice}");
            Console.WriteLine("--------------------------------------------------");
        }
    }
}
