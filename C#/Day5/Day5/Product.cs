using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    internal class Product
    {
        public string pName ;
        public string serialNumber ;
        public DateTime dateofPurchase;
        public double cost;
        public Product(string pName, string serialNumber, DateTime dateofPurchase, double cost)
        {
            this.pName = pName;
            this.serialNumber = serialNumber;
            this.dateofPurchase = dateofPurchase;
            this.cost = cost;
        }

    }
}
