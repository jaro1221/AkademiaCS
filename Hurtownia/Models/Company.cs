using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Hurtownia.Classes;

namespace Hurtownia.Models
{
    public static class Company
    {
        public static string CompanyName { get; set; }
        public static string CompanyOwner { get; set; }

        public static string CompanyAddress
        {
            get { return CompanyNation + ", " + CompanyCity + ", ul. " + CompanyStreet + " " + CompanyNumber; }
        }

        public static string CompanyPhone { get; set; }
        public static string Path { get; set; } = Environment.CurrentDirectory + "..\\Files\\company.conf";

        public static void LoadCompany()
        {
            string[] values = new string[7];
            using (StreamReader sr = new StreamReader(Path))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    
                    string line = sr.ReadLine();
                    string[] data = line.Split('=');
                    values[i] = data[1];
                    i++;
                }
            }
            CompanyName = values[0];
            CompanyOwner = values[1];
            CompanyNation = values[2];
            CompanyCity = values[3];
            CompanyStreet = values[4];
            CompanyNumber = values[5];
            CompanyPhone = values[6];


        }

        public static string CompanyNumber { get; set; }

        public static string CompanyStreet { get; set; }

        public static string CompanyCity { get; set; }

        public static string CompanyNation { get; set; }
    }
}