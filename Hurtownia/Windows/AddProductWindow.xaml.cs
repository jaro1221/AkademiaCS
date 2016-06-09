using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            ComboBoxUnit.ItemsSource = Enum.GetValues(typeof(Product.Unit));
            ComboBoxUnit.SelectedIndex = 0;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxName.Text;
            var code = TextBoxCode.Text;
            var ean = TextBoxEan.Text;
            var price = float.Parse(TextBoxPrice.Text);
            var unit = (Product.Unit)Enum.Parse(typeof(Product.Unit), ComboBoxUnit.Text);
            var quantity = float.Parse(TextBoxQuantity.Text);
            Product newProduct = new Product(name, code, ean, price, quantity, unit);
            Products.AddProduct(newProduct);
            Close();
        }

    }
}