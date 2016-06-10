using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurtownia.Models
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string CompanyOwner { get; set; }

        public Company(string companyName, string companyOwner)
        {
            CompanyName = companyName;
            CompanyOwner = companyOwner;
        }
    }
}
