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
        public static string Path { get; set; } = Environment.CurrentDirectory + "..\\Files\\company.conf";

        public static void LoadCompany()
        {
            string[] values = new string[2];
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

        }
    }
}