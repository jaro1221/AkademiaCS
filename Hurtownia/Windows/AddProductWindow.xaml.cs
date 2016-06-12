using System;
using System.Windows;
using System.Windows.Input;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public bool Added { get; set; }
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
            try
            {
                var name = TextBoxName.Text;
                var code = TextBoxCode.Text;
                var ean = TextBoxEan.Text;
                var price = double.Parse(TextBoxPrice.Text);
                var unit = (Product.Unit) Enum.Parse(typeof(Product.Unit), ComboBoxUnit.Text);
                var quantity = double.Parse(TextBoxQuantity.Text);
                var newProduct = new Product(name, code, ean, price, quantity, unit);
                Products.AddProduct(newProduct);
                Close();
                MessageBox.Show("Produkt został dodany pomyślnie.", "Sukces!");
                Added = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sprawdź poprawność wprowadzonych danych.\nSzczegóły: " + exception.Message, "Błąd!");
            }
        }

        private void TextBoxCode_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Random rand = new Random();
            TextBoxCode.Text = rand.Next(100000, 999999).ToString();
        }
    }
}