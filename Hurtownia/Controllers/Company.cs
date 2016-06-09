using Hurtownia.Classes;

namespace Hurtownia.Controllers
{
    public class Company : Address
    {
        public Company(string name, string nation, string city, string street, string number, string firstName,
            string lastName) : base(nation, city, street, number)
        {
            FirstName = firstName;
            LastName = lastName;
            Name = name;
        }

        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FilePath { get; set; }

        public static void SetLabels()
        {
        }
    }
}