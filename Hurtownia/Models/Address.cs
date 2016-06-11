namespace Hurtownia.Classes
{
    public class Address
    {
        public Address(string nation, string city, string street, string number)
        {
            Nation = nation;
            City = city;
            Street = street;
            Number = number;
            FullAddress = Nation + ", " + City + " ul. " + Street + " " + Number;
        }

        public Address()
        {
        }

        public string FullAddress { get; set; }


        public string Nation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}