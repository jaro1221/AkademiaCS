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
    /// Interaction logic for DeliveriesWindow.xaml
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

            int unexec = 0;

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
            DeliveryWindow deliveryWindow = new DeliveryWindow();
            deliveryWindow.Show();
        }

        private void ListViewDeliveriesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewDeliveriesList.SelectedIndex;
            ButtonExecute.IsEnabled = Deliveries.IsExecutedCheck(index);
            
        }

        private void ButtonExecute_Click(object sender, RoutedEventArgs e)
        {
            int index = ListViewDeliveriesList.SelectedIndex;
            Deliveries.ExecuteDelivery(index);
            
            
        }
    }
}
