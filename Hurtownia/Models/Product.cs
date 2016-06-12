using System;
using Hurtownia.Models;

namespace Hurtownia.Classes
{
    public class Product
    {
        public enum Unit
        {
            kg,
            szt
        }

        public double Tax = 23;

        public Product()
        {
        }

        public Product(string name, string code, string ean, double price, double quantity, Unit enumUnit)
        {
            Name = name;
            Code = code;
            Ean = ean;
            Price = price;
            Quantity = quantity;
            Cost = price*quantity;
            EnumUnit = enumUnit;
        }

       

        public string Name { get; set; }
        public string Code { get; set; }
        public string Ean { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public string TaxString
        {
            get
            {
                var value = Math.Round(Quantity*Price*Tax/100, 2);
                return value + " (" + Tax + "%)";
            }
            set { }
        }

        public double Brutto
        {
            get { return Math.Round(Cost + Cost*Tax/100, 2); }
            set { }
        }

        public double Cost
        {
            get { return Math.Round(Price*Quantity, 2); }
            set { }
        }

        public Unit EnumUnit { get; set; }

        public string UnitString
        {
            get { return EnumUnit.ToString(); }
            set { }
        }
    }
}