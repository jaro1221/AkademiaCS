using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for DeliveriesWindow.xaml
    /// </summary>
    public partial class DeliveriesWindow : Window
    {
        public DeliveriesWindow()
        {
            InitializeComponent();
            ListViewDeliveriesList.ItemsSource = Deliveries.DeliveriesList;
            SetLabels();
        }

        private void SetLabels()
        {
            LabelAll.Content = "Liczba dostaw (ogółem): " + Deliveries.DeliveriesList.Count;

            var unexec = 0;

            foreach (var item in Deliveries.DeliveriesList)
            {
                if (item.IsExecuted == "nie")
                {
                    unexec++;
                }
            }

            LabelUnExec.Content = " w tym niewykonanych: " + unexec;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var deliveryWindow = new DeliveryWindow();
            deliveryWindow.Show();
        }

        private void ListViewDeliveriesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = ListViewDeliveriesList.SelectedIndex;
            ButtonExecute.IsEnabled = Deliveries.IsExecutedCheck(index);
        }

        private void ButtonExecute_Click(object sender, RoutedEventArgs e)
        {
            var index = ListViewDeliveriesList.SelectedIndex;
            Deliveries.ExecuteDelivery(index);
        }

        private void ListViewDeliveriesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = ListViewDeliveriesList.SelectedIndex;
            if (index != -1)
            {
                var showDeliveryWindow = new ShowDeliveryWindow(index);
                showDeliveryWindow.Show();
            }
        }
    }
}