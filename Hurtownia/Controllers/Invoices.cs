using System.Collections.ObjectModel;
using Hurtownia.Controllers;

namespace Hurtownia.Models
{
    public static class Invoices
    {
        public static ObservableCollection<Invoice> InvoicesList { get; set; } = new ObservableCollection<Invoice>();

        public static int NumberOfInvoices
        {
            get { return InvoicesList.Count; }
            set { }
        }


        public static void AddInvoice(Invoice newInvoice)
        {
            InvoicesList.Add(newInvoice);
            NumberOfInvoices = InvoicesList.Count;
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
    }
}