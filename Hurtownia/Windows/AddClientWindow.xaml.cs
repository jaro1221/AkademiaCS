using System;
using System.CodeDom;
using System.Security.Cryptography;
using System.Windows;
using Hurtownia.Controllers;

namespace Hurtownia.Windows
{
    /// <summary>
    ///     Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var lastName = TextBoxLastName.Text;
                var firstName = TextBoxFirstName.Text;
                var dateOfBirth = DatePickerDateOfBirth.DisplayDate.Date;
                var nip = TextBoxNip.Text;
                var phone = int.Parse(TextBoxPhone.Text);
                var nation = TextBoxNation.Text;
                var city = TextBoxCity.Text;
                var street = TextBoxStreet.Text;
                var number = TextBoxNumber.Text;

                var discount = int.Parse(TextBoxDiscount.Text);
                var newClient = new Client(nation, city, street, number, firstName, lastName, dateOfBirth, nip, phone,
                    discount);
                Clients.AddClient(newClient);
                Close();
                MessageBox.Show("Dodano klienta: " + firstName + " " + lastName, "Sukces!");
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Sprawdz poprawność wprowadzonych danych.\nSzczegóły: " + exception.Message, "Błąd!");
            }
        }
    }
}