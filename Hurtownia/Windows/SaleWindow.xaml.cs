using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Hurtownia.Classes;
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
            TextBoxDocNumber.Text = DateTime.Now.Date.Year.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "/" +
                                    DateTime.Now.Date.Day + "/" + (Invoices.InvoicesList.Count + 1).ToString();
            ComboBoxProducts.ItemsSource = Products.GetProductsListAsString();
            //ComboBoxClients.ItemsSource = Clients.GetClientsListAsString();

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
            Product product2 = Products.GetProduct(name);
            if (product.Quantity <= product2.Quantity)
            {
               // try
               // {
                    product.Cost = product.Price * product.Quantity;

                    ////Product = Products.GetProduct(name);
                    //Product.Price = float.Parse(TextBoxPrice.Text);
                    //Product.Quantity = float.Parse(TextBoxQuantity.Text);
                    //Product.Cost = Product.Price*Product.Quantity;

                    newInvoice.AddProduct(product);
                    ResetFields();
                    UpdateLabels();
              //  }
              //  catch (Exception exception)
              //  {
             //       MessageBox.Show("Sprawdź poprawność wprowadzonych danych.\nSzczegóły: " + exception.Message, "Błąd!");
              //  }
            }
            else
            {
                MessageBox.Show("Brak wystarczającej ilości produktu na magazynie!", "Błąd");
            }

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
            try
            {
                var result = MessageBox.Show("Czy dokonano zapłaty w wysokości " + newInvoice.BruttoSum + " zł?",
                    "Płatność", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    newInvoice.DateTime = DatePickerDate.DisplayDate;
                    newInvoice.Number = TextBoxDocNumber.Text;
                    Invoices.AddInvoice(newInvoice);
                    Invoices.ExecuteInvoice(newInvoice.Number);
                    MessageBox.Show("Dziękujemy za zakupy! Zapraszamy ponownie!", "Sukces!");
                    Close();
                    ShowInvoiceWindow showInvoiceWindow = new ShowInvoiceWindow(newInvoice.Number);
                    showInvoiceWindow.Show();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sprawdź poprawność wprowadzonych danych.\nSzczegóły: " + exception.Message, "Błąd!");
            }
        }

        //private void ComboBoxClients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{
        //    newInvoice.Client = Clients.GetClient(ComboBoxClients.SelectedIndex);
        //    LabelDiscount.Content = newInvoice.Client.Discount.ToString() + "%";
        //}

        private void TextBoxQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            Product product = Products.GetProduct(ComboBoxProducts.Text);
            TextBoxQuantity.Text = "max. " + product.Quantity;
            TextBoxQuantity.SelectAll();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewClients.SelectedIndex;
            if (index != -1)
            {
                newInvoice.DeleteProduct(index);
                UpdateLabels();
            }
            
        }

        private void ListViewClients_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewClients.SelectedIndex;
            if (index == -1)
                ButtonDelete.IsEnabled = false;
            else
                ButtonDelete.IsEnabled = true;
        }

        private void ButtonClient_Click(object sender, RoutedEventArgs e)
        {
            SelectClientWindow selectClientWindow = new SelectClientWindow();
            selectClientWindow.ShowDialog();
            newInvoice.Client = Clients.GetClient(selectClientWindow.Index);
            ButtonClient.Content = newInvoice.Client.FirstName + " " + newInvoice.Client.LastName;
            LabelDiscount.Content = newInvoice.Client.Discount.ToString() + "%";

        }
    }
}