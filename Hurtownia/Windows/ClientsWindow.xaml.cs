using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            LabelNumberOfClients.Content = "Liczba klientów: " + ListViewClients.Items.Count;
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

                var result = MessageBox.Show("Czy na pewno?", "Usuwanie", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    Clients.DeleteClient(index);
                    MessageBox.Show("Usunięto klienta", "Sukces!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd.\nSzczegóły: " + ex.Message, "Błąd!");
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
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

        private void ListViewClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = ListViewClients.SelectedIndex;
            var editClientWindow = new EditClientWindow(index);
            editClientWindow.Show();
        }

        private void ListViewClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ListViewClients.SelectedIndex;
            if (index == -1)
                ButtonDelete.IsEnabled = false;
            else
            {
                ButtonDelete.IsEnabled = true;
            }
        }
    }
}