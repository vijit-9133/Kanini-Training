using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Vehicle
    {
        public string Make;
        public string Model;
        public int Year;
        public Vehicle(string make,string model, int year )
        { 
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public virtual void GetInfo()
        {
            Console.WriteLine("Details of the vehicle");
            Console.WriteLine("Make: "+Make);
            Console.WriteLine("Model: "+Model);
            Console.WriteLine("Year: "+Year);
        }
    }
     class Car : Vehicle {
        public Car(string make, string model, int year) : base(make, model, year)
        {
        }

        public override void GetInfo()
        {
            Console.WriteLine("Bike");
            base.GetInfo();
            
        }
    }
     class Bike : Vehicle {
        public Bike(string make, string model, int year) : base(make, model, year)
        {
        }

        public override void GetInfo()
        {   
            Console.WriteLine("Bike");
            base.GetInfo();
        }
    }
}
