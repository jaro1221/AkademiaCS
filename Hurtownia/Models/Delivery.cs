using System;
using System.Collections.ObjectModel;

namespace Hurtownia.Classes
{
    public class Delivery
    {
        public ObservableCollection<Product> DeliveryList { get; set; } = new ObservableCollection<Product>();
        public int NumberOfProducts { get; set; }

        public DateTime DateOfDelivery { get; set; }

        public string DateAsString
        {
            get { return DateOfDelivery.ToShortDateString(); }
            set { }
        }

        public string DeliverName { get; set; }

        public double CostOfProducts
        {
            get { return Math.Round(CostOfProducts, 2); }
            set { }
        }

        public string IsExecuted { get; set; } = "nie";

        public void AddProduct(Product product)
        {
            DeliveryList.Add(product);
            NumberOfProducts = DeliveryList.Count;
            SetCost(product);
        }

        private void SetCost(Product product)
        {
            CostOfProducts += product.Cost;
        }
    }
}