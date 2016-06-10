using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Deliveries
    {
        public static ObservableCollection<Delivery> DeliveriesList { get; set; } = new ObservableCollection<Delivery>();

        public static int NumberOfDeliveries
        {
            get { return DeliveriesList.Count; }
            set { }
        }

        public static string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\deliveries.xml";

        public static void AddNewDelivery(Delivery newDelivery)
        {
            DeliveriesList.Add(newDelivery);
            NumberOfDeliveries = DeliveriesList.Count;
            SaveDeliveries();
        }

        public static void ExecuteDelivery(int index)
        {
            Delivery delivery = DeliveriesList[index];

            foreach (var item in delivery.DeliveryList)
            {
                Products.AddProduct(item.Name, item.Quantity);
            }

            delivery.IsExecuted = "tak";
            EditDelivery(index, delivery);
            SaveDeliveries();
        }

        public static bool SaveDeliveries()
        {
            try
            {
                using (var sw = new StreamWriter(FilePath))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Delivery>));
                    serializer.Serialize(sw, DeliveriesList);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool LoadDeliveries()
        {
            try
            {
                DeliveriesList.Clear();
                using (var sr = new StreamReader(FilePath))
                {
                    var deSerializer = new XmlSerializer(typeof(ObservableCollection<Delivery>));
                    var tmpCollection =
                        (ObservableCollection<Delivery>)deSerializer.Deserialize(sr);
                    foreach (var item in tmpCollection)
                    {
                        DeliveriesList.Add(item);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException)
                {
                    var sw = new StreamWriter(FilePath);
                }
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static void EditDelivery(int index, Delivery delivery)
        {
            DeliveriesList.RemoveAt(index);
            DeliveriesList.Insert(index, delivery);
            
        }

        public static bool IsExecutedCheck(int index)
        {
            if (index != -1)
            {
                if (DeliveriesList[index].IsExecuted == "nie")
                {
                    return true;
                }
                else if (DeliveriesList[index].IsExecuted == "tak")
                {
                    return false;
                }
                return false;
            }
            return false;
        }
    }
}