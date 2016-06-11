using System.Collections.ObjectModel;
using System.Windows;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for DeliveryWindow.xaml
    /// </summary>
    public partial class DeliveryWindow : Window
    {
        //public Product Product { get; set; }
        private readonly Delivery newDelivery;

        public DeliveryWindow()
        {
            InitializeComponent();
            newDelivery = new Delivery();
            ListViewDeliveryList.ItemsSource = newDelivery.DeliveryList;
            ComboBoxProducts.ItemsSource = Products.GetProductsListAsString();
        }

        public ObservableCollection<Product> ProductsListOfDelivery { get; set; } = new ObservableCollection<Product>();

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var name = ComboBoxProducts.Text;

            var product = Products.GetProduct(name);
            product.Price = float.Parse(TextBoxPrice.Text);
            product.Quantity = float.Parse(TextBoxQuantity.Text);
            product.Cost = product.Price*product.Quantity;

            ////Product = Products.GetProduct(name);
            //Product.Price = float.Parse(TextBoxPrice.Text);
            //Product.Quantity = float.Parse(TextBoxQuantity.Text);
            //Product.Cost = Product.Price*Product.Quantity;

            newDelivery.AddProduct(product);
            ResetFields();
            LabelCostOfProducts.Content = newDelivery.CostOfProducts;
        }

        private void ResetFields()
        {
            ComboBoxProducts.Text = "";
            ComboBoxProducts.Focus();
            TextBoxQuantity.Text = "";
            TextBoxPrice.Text = "";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            newDelivery.DateOfDelivery = DateOfDelivery.DisplayDate.Date;
            newDelivery.DeliverName = NameDelivery.Text;
            Deliveries.AddNewDelivery(newDelivery);
            MessageBox.Show("Dodano dostawę");
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }
    }
}