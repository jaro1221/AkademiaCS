using System;
using System.Windows;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            ListViewClients.ItemsSource = Clients.ClientsList;
            LabelNumberOfClients.Content = "Liczba klientów: " + ListViewClients.Items.Count.ToString();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = ListViewClients.SelectedIndex;
                Clients.DeleteClient(index);
                MessageBox.Show("Usunięto klienta");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBoxSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            int length = TextBoxSearch.Text.Length;
            string query = TextBoxSearch.Text.ToLower();
            if (length != 0)
            {
                ListViewClients.ItemsSource = Clients.SearchClient(query);
                LabelNumberOfClients.Content = "Znaleziono: " + ListViewClients.Items.Count.ToString();

            }
            else if (length == 0)
            {
                ListViewClients.ItemsSource = Clients.ClientsList;
                LabelNumberOfClients.Content = "Liczba klientów: " + ListViewClients.Items.Count.ToString();

            }
        }

        private void ListViewClients_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int index = ListViewClients.SelectedIndex;
            EditClientWindow editClientWindow = new EditClientWindow(index);
            editClientWindow.Show();
        }
    }
}