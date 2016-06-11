using System.Windows;
using System.Windows.Input;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            ListViewSettings.ItemsSource = SettingsValues.SettingValuesList;
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SettingsValues.SaveSettings();
            Close();
        }


        private void ListViewSettings_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = ListViewSettings.SelectedIndex;
            var editSettingWindow = new EditSettingValue(index);
            editSettingWindow.Show();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}