using System;
using System.Collections.ObjectModel;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Models
{
    public class Invoice
    {
        public string Number { get; set; }
        public Client Client { get; set; }

        public string ClientString
        {
            get { return Client.LastName.ToString() + " " + Client.FirstName.ToString(); }
/*
            private set {  }
*/
        }

        public ObservableCollection<Product> ProductsList { get; set; } = new ObservableCollection<Product>();

        public double BruttoSum
        {
            get
            {
                double sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Brutto;
                }
                return Math.Round(sum*(1-(Client.Discount/100)), 2);
            }
            set { }
        }

        public double VatSum
        {
            get
            {
                double sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Cost*product.Tax/100;
                }
                return Math.Round(sum, 2);
            }
            set { }
        }

        public double NettoSum
        {
            get
            {
                double sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Cost;
                }
                return Math.Round(sum, 2);
            }
            set { }
        }

        public string DateString {
            get { return this.DateTime.ToShortDateString(); } }

        public DateTime DateTime { get; set; }

        public int NumberOfProducts
        {
            get { return ProductsList.Count; }
            set { }
        }

        public void AddProduct(Product product)
        {
            ProductsList.Add(product);
            NumberOfProducts = ProductsList.Count;
        }

        public void DeleteProduct(int index)
        {
            ProductsList.RemoveAt(index);
        }
    }
}