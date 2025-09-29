using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Product
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public Product(string productName, decimal productPrice, int productQuantity)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }

        public void DisplayProductInfo(int number)
        {
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Product Number   : {number}");
            Console.WriteLine($"Product Name     : {ProductName}");
            Console.WriteLine($"Product Price    : {ProductPrice}");
            Console.WriteLine($"Product Quantity : {ProductQuantity}");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
