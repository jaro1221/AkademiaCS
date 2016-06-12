﻿using System;
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

        public float BruttoSum
        {
            get
            {
                float sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Brutto;
                }
                return sum*(1-(Client.Discount/100));
            }
            set { }
        }

        public float VatSum
        {
            get
            {
                float sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Cost*product.Tax/100;
                }
                return sum;
            }
            set { }
        }

        public float NettoSum
        {
            get
            {
                float sum = 0;
                foreach (var product in ProductsList)
                {
                    sum = sum + product.Cost;
                }
                return sum;
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