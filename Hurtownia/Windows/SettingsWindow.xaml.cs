using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using Hurtownia.Models;

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

        }

        private void SaveSettingsValues()
        {
            var filename = Environment.CurrentDirectory + "..\\Files\\settings.xml";
            using (var sw = new StreamWriter(filename))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<SettingValue>));
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveSettingsValues();
            Close();
        }


        private void ListViewSettings_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var index = ListViewSettings.SelectedIndex;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}