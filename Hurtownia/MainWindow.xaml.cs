using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;
using Hurtownia.Controllers;
using Hurtownia.Models;
using Hurtownia.Windows;

namespace Hurtownia
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoadData();
            InitializeComponent();
        }

        private void LoadData()
        {
            Clients.LoadClients();
            Products.LoadProducts();
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
            OpenDeliveryWindow();
        }

        private void OpenDeliveryWindow()
        {
            var deliveryWindow = new DeliveryWindow();
            deliveryWindow.Show();
        }
    }
}