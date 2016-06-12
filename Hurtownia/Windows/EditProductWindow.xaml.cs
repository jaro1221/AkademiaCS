using System;
using System.Windows;
using System.Windows.Input;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
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

        public int Index { get; set; }
        public Product EditedProduct { get; set; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = TextBoxName.Text;
                var code = TextBoxCode.Text;
                var ean = TextBoxEan.Text;
                float quantity = int.Parse(TextBoxQuantity.Text);
                var price = float.Parse(TextBoxPrice.Text);
                var unit = (Product.Unit) Enum.Parse(typeof(Product.Unit), ComboBoxUnit.Text);

                Products.EditProduct(new Product(name, code, ean, price, quantity, unit), Index);
                Close();
                MessageBox.Show("Dane produktu zostały zmienione pomyślnie", "Sukces!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sprawdz poprawność wprowadzonych danych.\nSzczegóły: " + ex.Message, "Błąd!");
            }
        }

        private void TextBoxCode_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Random rand = new Random();
            TextBoxCode.Text = rand.Next(100000, 999999).ToString();
        }
    }
}