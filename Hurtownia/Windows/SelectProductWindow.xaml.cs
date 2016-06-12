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
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for SelectProductWindow.xaml
    /// </summary>
    public partial class SelectProductWindow : Window
    {
        public int Index { get; set; }
        public SelectProductWindow()
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
            this.Index = ListViewWarehouse.SelectedIndex;
            Close();
        }
    }
}
