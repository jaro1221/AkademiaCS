using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            LabelNumberOfProducts.Content = "Liczba produktów: " + ListViewWarehouse.Items.Count;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = ListViewWarehouse.SelectedIndex;
                var result = MessageBox.Show("Czy na pewno?", "Usuwanie", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    Products.DeleteProduct(index);
                    MessageBox.Show("Usunięto produkt.", "Sukces!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var length = TextBoxSearch.Text.Length;
            var query = TextBoxSearch.Text.ToLower();
            if (length != 0)
            {
                ListViewWarehouse.ItemsSource = Products.SearchProduct(query);
                LabelNumberOfProducts.Content = "Znaleziono: " + ListViewWarehouse.Items.Count;
            }
            else if (length == 0)
            {
                ListViewWarehouse.ItemsSource = Products.ProductsList;
                LabelNumberOfProducts.Content = "Liczba produktów: " + ListViewWarehouse.Items.Count;
            }
        }

        private void ListViewWarehouse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = ListViewWarehouse.SelectedIndex;
            var editProductWindow = new EditProductWindow(index);
            editProductWindow.Show();
        }

        private void ListViewWarehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewWarehouse.SelectedIndex;
            if (index == -1)
                ButtonDelete.IsEnabled = false;
            else
            {
                ButtonDelete.IsEnabled = true;
            }
        }
    }
}