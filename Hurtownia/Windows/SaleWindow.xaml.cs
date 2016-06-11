using System;
using System.ComponentModel;
using System.Windows;
using Hurtownia.Controllers;
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window, INotifyPropertyChanged
    {
        private Invoice newInvoice = new Invoice();
        public Client Client { get; set; }


        public SaleWindow()
        {
            InitializeComponent();
            ComboBoxProducts.ItemsSource = Products.GetProductsListAsString();
            ComboBoxClients.ItemsSource = Clients.GetClientsListAsString();

            StackPanelInfos1.DataContext = this;
            StackPanelInfos.DataContext = newInvoice;
            ListViewClients.ItemsSource = newInvoice.ProductsList;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var name = ComboBoxProducts.Text;

            var product = Products.GetProduct(name);
            product.Quantity = float.Parse(TextBoxQuantity.Text);
            product.Cost = product.Price*product.Quantity;

            ////Product = Products.GetProduct(name);
            //Product.Price = float.Parse(TextBoxPrice.Text);
            //Product.Quantity = float.Parse(TextBoxQuantity.Text);
            //Product.Cost = Product.Price*Product.Quantity;
            
            newInvoice.AddProduct(product);
            ResetFields();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            LabelGrossSum.Content = newInvoice.BruttoSum.ToString();
            LabelTotalSum.Content = newInvoice.NettoSum.ToString();
            LabelVatSum.Content = newInvoice.VatSum.ToString();
        }


        private void ResetFields()
        {
            ComboBoxProducts.Text = "";
            TextBoxQuantity.Text = "";
            ComboBoxProducts.Focus();
        }


        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonExecute_OnClick(object sender, RoutedEventArgs e)
        {
            newInvoice.DateTime = DatePickerDate.DisplayDate;
            newInvoice.Number = TextBoxDocNumber.Text;
            Invoices.AddInvoice(newInvoice);
            Invoices.ExecuteInvoice(newInvoice.Number);
        }

        private void ComboBoxClients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            newInvoice.Client = Clients.GetClient(ComboBoxClients.SelectedIndex);
            LabelDiscount.Content = newInvoice.Client.Discount.ToString() + "%";
        }
    }
}