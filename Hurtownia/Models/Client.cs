using System;
using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Client : Person
    {
        public string NameString
        {
            get { return base.FirstName + " " + base.LastName; }
        }

        public string AddressString
        {
            get { return base.FullAddress; }
        }

        public Client(string nation, string city, string street, string number, string firstName, string lastName,
            DateTime dateOfBirth, string nip, int phone, float discount)
            : base(nation, city, street, number, firstName, lastName, dateOfBirth)
        {
            Nip = nip;
            Phone = phone;
            Discount = discount;
        }

        public Client()
        {
        }

        public string Nip { get; set; }
        public int Phone { get; set; }
        public float Discount { get; set; }
    }
}