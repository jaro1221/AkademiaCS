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
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for SelectClientWindow.xaml
    /// </summary>
    public partial class SelectClientWindow : Window
    {
        public int Index { get; set; }
        public SelectClientWindow()
        {
            InitializeComponent();
            ListViewClients.ItemsSource = Clients.ClientsList;
            LabelNumberOfClients.Content = "Liczba klientów: " + ListViewClients.Items.Count;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                var length = TextBoxSearch.Text.Length;
                var query = TextBoxSearch.Text.ToLower();
                if (length != 0)
                {
                    ListViewClients.ItemsSource = Clients.SearchClient(query);
                    LabelNumberOfClients.Content = "Znaleziono: " + ListViewClients.Items.Count;
                }
                else if (length == 0)
                {
                    ListViewClients.ItemsSource = Clients.ClientsList;
                    LabelNumberOfClients.Content = "Liczba klientów: " + ListViewClients.Items.Count;
                }
            }
        }

        private void ListViewClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Index = ListViewClients.SelectedIndex;
            Close();
        }
    }
}
