namespace Hurtownia.Models
{
    public class Company
    {
        public Company(string companyName, string companyOwner)
        {
            CompanyName = companyName;
            CompanyOwner = companyOwner;
        }

        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }
    }
}