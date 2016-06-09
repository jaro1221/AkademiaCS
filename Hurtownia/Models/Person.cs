using System;

namespace Hurtownia.Classes
{
    public class Person : Address
    {
        public Person(string nation, string city, string street, string number, string firstName, string lastName,
            DateTime dateOfBirth) : base(nation, city, street, number)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}