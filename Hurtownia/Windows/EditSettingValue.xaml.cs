using System.Windows;
using Hurtownia.Models;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for EditSettingValue.xaml
    /// </summary>
    public partial class EditSettingValue : Window
    {
        public SettingValue CurrentSettingValue { get; set; }
        public int CurrentIndex { get; set; }
        public EditSettingValue(int index)
        {
            InitializeComponent();
            CurrentIndex = index;
            CurrentSettingValue = SettingsValues.SettingValuesList[CurrentIndex];
            SetLabels();
        }

        

        private void SetLabels()
        {
            LabelKey.Content = CurrentSettingValue.Key;
            TextBoxValue.Text = CurrentSettingValue.Value;
        }


      

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            CurrentSettingValue.Value = TextBoxValue.Text;
            SettingsValues.EditSettingsValue(CurrentIndex, CurrentSettingValue);
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}