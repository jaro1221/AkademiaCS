using System.Collections.ObjectModel;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Deliveries
    {
        public ObservableCollection<Delivery> DeliveriesList { get; set; } = new ObservableCollection<Delivery>();
        public int NumberOfDeliveries { get; set; }

        public void AddNewDelivery()
        {
        }

        public void AddToWarehouse()
        {
        }
    }
}