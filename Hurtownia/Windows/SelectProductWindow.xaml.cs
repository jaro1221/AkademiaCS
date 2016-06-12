using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window
    {
        public SelectProductWindow()
        {
            InitializeComponent();
            ListViewWarehouse.ItemsSource = Products.ProductsList;
            LabelNumberOfProducts.Content = "Liczba produktów: " + ListViewWarehouse.Items.Count;
        }

        public int Index { get; set; }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
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
        }

        private void ListViewWarehouse_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Index = ListViewWarehouse.SelectedIndex;
            Close();
        }
    }
}