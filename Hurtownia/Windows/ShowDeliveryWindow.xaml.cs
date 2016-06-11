using System.Windows;
using Hurtownia.Classes;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for ShowDeliveryWindow.xaml
    /// </summary>
    public partial class ShowDeliveryWindow : Window
    {
        public ShowDeliveryWindow(int index)
        {
            InitializeComponent();
            Index = index;
            Delivery = Deliveries.GetDelivery(index);
            ListViewDeliveryList.ItemsSource = Delivery.DeliveryList;
            StackPanelInfos.DataContext = Delivery;
            StackPanelInfos2.DataContext = Delivery;
        }

        public int Index { get; set; }
        private Delivery Delivery { get; }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Deliveries.DeleteDelivery(Index);
            MessageBox.Show("Usunięto dostawę");
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}