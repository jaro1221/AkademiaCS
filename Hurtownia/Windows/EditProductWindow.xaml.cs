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
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public int Index { get; set; }
        public Product EditedProduct { get; set; }
        public EditProductWindow(int index)
        {
            InitializeComponent();

            Index = index;
            InitializeComponent();
            EditedProduct = Products.GetProduct(index);
            TextBoxName.Text = EditedProduct.Name;
            TextBoxCode.Text = EditedProduct.Code;
            TextBoxEan.Text = EditedProduct.Ean;
            TextBoxQuantity.Text = EditedProduct.Quantity.ToString();
            TextBoxPrice.Text = EditedProduct.Price.ToString();
            ComboBoxUnit.ItemsSource = Enum.GetValues(typeof(Product.Unit));
            ComboBoxUnit.SelectedIndex = 0;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = TextBoxName.Text;
                string code = TextBoxCode.Text;
                string ean = TextBoxEan.Text;
                float quantity = int.Parse(TextBoxQuantity.Text);
                float price = float.Parse(TextBoxPrice.Text);
                var unit = (Product.Unit)Enum.Parse(typeof(Product.Unit), ComboBoxUnit.Text);

                Products.EditProduct(new Product(name, code, ean, price, quantity, unit), Index);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
