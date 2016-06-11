using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Models
{
    public static class Invoices
    {
        public static ObservableCollection<Invoice> InvoicesList { get; set; } = new ObservableCollection<Invoice>();
        public static string FilePath { get; set; } = Environment.CurrentDirectory + "..\\Files\\invoices.xml";

        public static int NumberOfInvoices
        {
            get { return InvoicesList.Count; }
            set { }
        }


        public static void AddInvoice(Invoice newInvoice)
        {
            InvoicesList.Add(newInvoice);
            NumberOfInvoices = InvoicesList.Count;
            SaveInvoices();
        }

        public static void ExecuteInvoice(string number)
        {
            var index = 0;
            foreach (var invoice in InvoicesList)
            {
                if (invoice.Number == number)
                    index = InvoicesList.IndexOf(invoice);
            }
            if (index != -1)
            {
                var currInvoice = InvoicesList[index];
                foreach (var product in currInvoice.ProductsList)
                {
                    foreach (var product1 in Products.ProductsList)
                    {
                        if (product1.Code == product.Code)
                        {
                            var currProduct = product1;
                            currProduct.Quantity = currProduct.Quantity - product.Quantity;
                        }
                    }
                }
            }

            Products.SaveProducts();
        }

        public static void DeleteIncoice(int index)
        {
            InvoicesList.RemoveAt(index);
            NumberOfInvoices = InvoicesList.Count;
            SaveInvoices();
        }

        public static bool LoadInvoices()
        {
            try
            {
                InvoicesList.Clear();
                using (var sr = new StreamReader(FilePath))
                {
                    var deSerializer = new XmlSerializer(typeof(ObservableCollection<Invoice>));
                    var tmpCollection =
                        (ObservableCollection<Invoice>)deSerializer.Deserialize(sr);
                    foreach (var item in tmpCollection)
                    {
                        InvoicesList.Add(item);
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

        public static bool SaveInvoices()
        {
            try
            {
                using (var sw = new StreamWriter(FilePath))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Invoice>));
                    serializer.Serialize(sw, InvoicesList);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}