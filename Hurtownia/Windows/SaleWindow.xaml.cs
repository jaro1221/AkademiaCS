using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Hurtownia.Controllers;
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window, INotifyPropertyChanged
    {
        private readonly Invoice newInvoice = new Invoice();


        public SaleWindow()
        {
            InitializeComponent();
            TextBoxDocNumber.Text = DateTime.Now.Date.Year + "/" + DateTime.Now.Date.Month + "/" +
                                    DateTime.Now.Date.Day + "/" + (Invoices.InvoicesList.Count + 1);

            StackPanelInfos1.DataContext = this;
            StackPanelInfos.DataContext = newInvoice;
            ListViewClients.ItemsSource = newInvoice.ProductsList;
        }

        public Client Client { get; set; }
        public string CurrProduct { get; set; }


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
            var name = CurrProduct;

            var product = Products.GetProduct(name);
            product.Quantity = double.Parse(TextBoxQuantity.Text);
            var product2 = Products.GetProduct(name);
            if (product.Quantity <= product2.Quantity)
            {
                product.Cost = product.Price*product.Quantity;


                newInvoice.AddProduct(product);
                ResetFields();
                UpdateLabels();
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
            ButtonProduct.Content = "Wybierz produkt...";
            TextBoxQuantity.Text = "";
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
                    var showInvoiceWindow = new ShowInvoiceWindow(newInvoice.Number);
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


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var index = ListViewClients.SelectedIndex;
            if (index != -1)
            {
                newInvoice.DeleteProduct(index);
                UpdateLabels();
            }
        }

        private void ListViewClients_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ListViewClients.SelectedIndex;
            if (index == -1)
                ButtonDelete.IsEnabled = false;
            else
                ButtonDelete.IsEnabled = true;
        }

        private void ButtonClient_Click(object sender, RoutedEventArgs e)
        {
            var selectClientWindow = new SelectClientWindow();
            selectClientWindow.ShowDialog();
            newInvoice.Client = Clients.GetClient(selectClientWindow.Index);
            ButtonClient.Content = newInvoice.Client.FirstName + " " + newInvoice.Client.LastName;
            LabelDiscount.Content = newInvoice.Client.Discount + "%";
        }

        private void ButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectProductWindow = new SelectProductWindow();
            selectProductWindow.ShowDialog();
            var currProduct = Products.GetProduct(selectProductWindow.Index);
            ButtonProduct.Content = "[" + currProduct.Code + "] " + currProduct.Name + " (stan: " + currProduct.Quantity +
                                    ")";
            CurrProduct = currProduct.Name;
        }
    }
}