using System.Windows;
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for EditSettingValue.xaml
    /// </summary>
    public partial class EditSettingValue : Window
    {
        public EditSettingValue(int index, string key, string value)
        {
            InitializeComponent();
            Index = index;
            Key = key;
            Value = value;
            SetLabelsText();
        }

        private int Index { get; }
        private string Key { get; }
        private string Value { get; set; }

        private void SetLabelsText()
        {
            LabelKey.Content = Key;
            TextBoxValue.Text = Value;
        }


        private void SaveNewValues()
        {
            Close();
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Value = TextBoxValue.Text;
            SaveNewValues();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}