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
        public ObservableCollection<Product> ProductsListOfDelivery { get; set; } = new ObservableCollection<Product>();
        public Product Product { get; set; }
        public DeliveryWindow()
        {
            InitializeComponent();
            ListViewDeliveryList.ItemsSource = Delivery.DeliveryList;
            ComboBoxProducts.ItemsSource = Products.GetProductsListAsString();
        }



        

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = ComboBoxProducts.Text;
            Product = Products.GetProduct(name);
            Product.Price = float.Parse(TextBoxPrice.Text);
            Product.Quantity = float.Parse(TextBoxQuantity.Text);
            Product.Cost = Product.Price*Product.Quantity;

            Delivery.AddProduct(Product);
            ResetFields();
            LabelCostOfProducts.Content = Delivery.CostOfProducts;
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

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();

        }
    }
}