using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for WarehouseWindow.xaml
    /// </summary>
    public partial class WarehouseWindow : Window
    {
        public WarehouseWindow()
        {
            InitializeComponent();
            ListViewWarehouse.ItemsSource = Products.ProductsList;
            LabelNumberOfProducts.Content = "Liczba produktów: " + ListViewWarehouse.Items.Count.ToString();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = ListViewWarehouse.SelectedIndex;
                Products.DeleteProduct(index);
                MessageBox.Show("Usunięto produkt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            int length = TextBoxSearch.Text.Length;
            string query = TextBoxSearch.Text.ToLower();
            if (length != 0)
            {
                ListViewWarehouse.ItemsSource = Products.SearchProduct(query);
                LabelNumberOfProducts.Content = "Znaleziono: " + ListViewWarehouse.Items.Count.ToString();

            }
            else if (length == 0)
            {
                ListViewWarehouse.ItemsSource = Products.ProductsList;
                LabelNumberOfProducts.Content = "Liczba klientów: " + ListViewWarehouse.Items.Count.ToString();

            }
        }

        private void ListViewWarehouse_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = ListViewWarehouse.SelectedIndex;
            EditProductWindow editProductWindow = new EditProductWindow(index);
            editProductWindow.Show();
        }
    }
}