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
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for InvoicesWindow.xaml
    /// </summary>
    public partial class InvoicesWindow : Window
    {
        public InvoicesWindow()
        {
            InitializeComponent();
            ListViewInvoicesList.ItemsSource = Invoices.InvoicesList;
            LabelAll.Content = "Liczba faktur: " + Invoices.NumberOfInvoices.ToString();

        }


        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            int index = ListViewInvoicesList.SelectedIndex;
            var result = MessageBox.Show("Czy na pewno?", "Usuwanie", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                Invoices.DeleteIncoice(index);
                MessageBox.Show("Pomyślnie usunięto fakturę.", "Sukces!");

            }
        }

        private void ListViewInvoicesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = ListViewInvoicesList.SelectedIndex;
            if (index != -1)
            {
                ShowInvoiceWindow showInvoiceWindow = new ShowInvoiceWindow(index);
                showInvoiceWindow.Show();
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListViewInvoicesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonDelete.IsEnabled = ListViewInvoicesList.SelectedIndex != -1;
        }
    }
}
