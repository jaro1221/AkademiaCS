using System;
using System.ComponentModel;
using System.Windows;
using Hurtownia.Controllers;
using Hurtownia.Models;
using Hurtownia.Windows;

namespace Hurtownia
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            StackPanelCompanyData.DataContext = typeof(Company);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProp(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        private void LoadData()
        {
            Clients.LoadClients();
            Products.LoadProducts();
            Deliveries.LoadDeliveries();
            Invoices.LoadInvoices();
           // SettingsValues.LoadSettings();
            LoadCompany();
        }

        private void LoadCompany()
        {
            Company.LoadCompany();
            LabelCompanyName.Content = Company.CompanyName;
            LabelCompanyOwner.Content = Company.CompanyOwner;
        }


        private void SaleButton_Click(object sender, RoutedEventArgs e)
        {
            OpenSaleWindow();
        }

        private void OpenSaleWindow()
        {
            var saleWindow = new SaleWindow();
            saleWindow.Show();
        }

        

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            OpenClientsWindow();
        }

        private static void OpenClientsWindow()
        {
            var clientsWindow = new ClientsWindow();
            clientsWindow.Show();
        }

        private void ButtonWarehouse_Click(object sender, RoutedEventArgs e)
        {
            OpenWarehouseWindow();
        }

        private void OpenWarehouseWindow()
        {
            var warehouseWindow = new WarehouseWindow();
            warehouseWindow.Show();
        }

        private void ButtonDelivery_Click(object sender, RoutedEventArgs e)
        {
            OpenDeliveriesWindow();
        }

        private void OpenDeliveriesWindow()
        {
            var deliveriesWindow = new DeliveriesWindow();
            deliveriesWindow.Show();
        }

        private void ButtonInvoices_Click(object sender, RoutedEventArgs e)
        {
            OpenInvoicesWindow();
        }

        private void OpenInvoicesWindow()
        {
            InvoicesWindow invoicesWindow = new InvoicesWindow();
            invoicesWindow.Show();
        }
    }
}