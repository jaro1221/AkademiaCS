using System.Windows;
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for ShowInvoiceWindow.xaml
    /// </summary>
    public partial class ShowInvoiceWindow : Window
    {
        private readonly int _index;
        private readonly Invoice currInvoice;


        public ShowInvoiceWindow(int index)
        {
            _index = index;
            InitializeComponent();

            currInvoice = Invoices.InvoicesList[_index];
            Title = "Faktura nr " + currInvoice.Number + " (" + currInvoice.Client.FirstName + " " +
                    currInvoice.Client.LastName + ")";
            StackPanelClient.DataContext = currInvoice.Client;
            StackPanelInvoice.DataContext = currInvoice;
            ListViewProducts.ItemsSource = currInvoice.ProductsList;
            StackPanelSums.DataContext = currInvoice;
            StackPanelToPay.DataContext = currInvoice;
            SetLabels();
        }

        public ShowInvoiceWindow(string number)
        {
            InitializeComponent();
            currInvoice = Invoices.GetInvoice(number);
            StackPanelClient.DataContext = currInvoice.Client;
            StackPanelInvoice.DataContext = currInvoice;
            ListViewProducts.ItemsSource = currInvoice.ProductsList;
            StackPanelSums.DataContext = currInvoice;
            StackPanelToPay.DataContext = currInvoice;
            SetLabels();
        }

        private void SetLabels()
        {
            LabelCity.Content = Company.CompanyCity;
            LabelDate.Content = currInvoice.DateTime.Date.ToShortDateString();
            LabelCompanyName.Content = Company.CompanyName;
            LabelCompanyOwner.Content = Company.CompanyOwner;
            LabelCompanyAddress.Content = Company.CompanyAddress;
            LabelCompanyPhone.Content = Company.CompanyPhone;
        }
    }
}