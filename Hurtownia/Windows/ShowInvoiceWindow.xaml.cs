using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for ShowInvoiceWindow.xaml
    /// </summary>
    public partial class ShowInvoiceWindow : Window
    {
        private int _index;
        private Invoice currInvoice;


        public ShowInvoiceWindow(int index)
        {
            this._index = index;
            InitializeComponent();
            currInvoice = Invoices.InvoicesList[_index];
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
