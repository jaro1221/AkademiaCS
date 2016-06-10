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
        private Delivery newDelivery = new Delivery();
        public DeliveryWindow()
        {
            InitializeComponent();
            ListViewDeliveryList.ItemsSource = newDelivery.DeliveryList;
            ComboBoxProducts.ItemsSource = Products.GetProductsListAsString();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = ComboBoxProducts.Text;
            Product = Products.GetProduct(name);
            Product.Price = float.Parse(TextBoxPrice.Text);
            Product.Quantity = float.Parse(TextBoxQuantity.Text);
            Product.Cost = Product.Price*Product.Quantity;

            newDelivery.AddProduct(Product);
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
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.Show();
        }
    }
}