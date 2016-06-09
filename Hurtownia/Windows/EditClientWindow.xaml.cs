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
using Hurtownia.Models;

namespace Hurtownia.Windows
{
    /// <summary>
    /// Interaction logic for EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public int Index { get; set; }
        public Client EditedClient { get; set; }

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

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstName = TextBoxFirstName.Text;
                string lastName = TextBoxLastName.Text;
                DateTime dateOfBirth = DatePickerDateOfBirth.DisplayDate.Date;
                string nip = TextBoxNip.Text;
                int phone = int.Parse(TextBoxPhone.Text);
                float discount = float.Parse(TextBoxDiscount.Text);
                string nation = TextBoxNation.Text;
                string city = TextBoxCity.Text;
                string street = TextBoxStreet.Text;
                string number = TextBoxNumber.Text;

                Clients.EditClient(new Client(nation, city, street, number, firstName, lastName, dateOfBirth, nip, phone, discount), Index);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
