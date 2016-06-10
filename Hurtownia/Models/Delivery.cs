using System;
using System.Collections.ObjectModel;

namespace Hurtownia.Classes
{
    public class Delivery
    {
        public ObservableCollection<Product> DeliveryList { get; set; } = new ObservableCollection<Product>();
        public int NumberOfProducts { get; set; } = 0;
        public DateTime DateOfDelivery { get; set; }
        public string DeliverName { get; set; }
        public float CostOfProducts { get; set; } = 0;
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