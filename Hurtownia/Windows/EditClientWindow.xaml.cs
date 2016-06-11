using System;
using System.Windows;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public EditClientWindow(int index)
        {
            Index = index;
            InitializeComponent();
            EditedClient = Clients.GetClient(index);
            TextBoxFirstName.Text = EditedClient.FirstName;
            TextBoxLastName.Text = EditedClient.LastName;
            DatePickerDateOfBirth.Text = EditedClient.DateOfBirth.ToShortDateString();
            TextBoxNip.Text = EditedClient.Nip;
            TextBoxPhone.Text = EditedClient.Phone.ToString();
            TextBoxDiscount.Text = EditedClient.Discount.ToString();
            TextBoxNation.Text = EditedClient.Nation;
            TextBoxCity.Text = EditedClient.City;
            TextBoxStreet.Text = EditedClient.Street;
            TextBoxNumber.Text = EditedClient.Number;
        }

        public int Index { get; set; }
        public Client EditedClient { get; set; }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var firstName = TextBoxFirstName.Text;
                var lastName = TextBoxLastName.Text;
                var dateOfBirth = DatePickerDateOfBirth.DisplayDate.Date;
                var nip = TextBoxNip.Text;
                var phone = int.Parse(TextBoxPhone.Text);
                var discount = float.Parse(TextBoxDiscount.Text);
                var nation = TextBoxNation.Text;
                var city = TextBoxCity.Text;
                var street = TextBoxStreet.Text;
                var number = TextBoxNumber.Text;

                Clients.EditClient(
                    new Client(nation, city, street, number, firstName, lastName, dateOfBirth, nip, phone, discount),
                    Index);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}