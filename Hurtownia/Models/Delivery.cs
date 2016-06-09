using System;
using System.Collections.ObjectModel;

namespace Hurtownia.Classes
{
    public class Delivery
    {
        public static ObservableCollection<Product> DeliveryList { get; set; } = new ObservableCollection<Product>();
        public static DateTime DateOfDelivery { get; set; }
        public string DeliverName { get; set; }
        public static float CostOfProducts { get; set; }

        public static void AddProduct(Product product)
        {
            DeliveryList.Add(product);
            SetCost();
        }

        private static void SetCost()
        {
            CostOfProducts = 0;
            foreach (var product in DeliveryList)
            {
                CostOfProducts += product.Cost;
            }

        }
    }
}