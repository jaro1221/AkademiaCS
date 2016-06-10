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

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProp(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


        public Company Company { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            StackPanelCompanyData.DataContext = Company;

        }


        private void LoadData()
        {
            Clients.LoadClients();
            Products.LoadProducts();
            Deliveries.LoadDeliveries();
            SettingsValues.LoadSettings();
            LoadCompany();
        }

        private void LoadCompany()
        {
            string name = SettingsValues.GetValue("companyname");
            string owner = SettingsValues.GetValue("companyowner");
            this.Company = new Company(name, owner);

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

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenSettingsWindow();
        }

        private static void OpenSettingsWindow()
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
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
    }
}