using System;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Client : Person
    {
        public Client(string nation, string city, string street, string number, string firstName, string lastName,
            DateTime dateOfBirth, string nip, int phone, double discount)
            : base(nation, city, street, number, firstName, lastName, dateOfBirth)
        {
            Nip = nip;
            Phone = phone;
            Discount = discount;
        }

        public Client()
        {
        }

        public string NameString
        {
            get { return FirstName + " " + LastName; }
        }

        public string AddressString
        {
            get { return FullAddress; }
        }

        public string Nip { get; set; }
        public int Phone { get; set; }
        public double Discount { get; set; }
    }
}