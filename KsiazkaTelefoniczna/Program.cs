using System;
using System.Collections.Generic;

namespace KsiazkaTelefoniczna
{
    class Program
    {
        public struct Osoba
        {
            public string FName;
            public string LName;
            public int Number;
        }

        public static void MainScreen()
        {
            Console.Clear();
            Console.WriteLine("|=======================|");
            Console.WriteLine("|Ksiazka telefoniczna   |");
            Console.WriteLine("|=======================|");      
            Console.WriteLine("|1 - przegladaj         |");
            Console.WriteLine("|2 - dodaj kontakt      |");
            Console.WriteLine("|3 - usun kontakt       |");
            Console.WriteLine("|4 - szukaj kontaktu    |");
            Console.WriteLine("|5 - sortowanie kontakt.|");
            Console.WriteLine("|                       |");
            Console.WriteLine("|9 - Wyjscie z programu |");
            Console.WriteLine("|=======================|");
            Console.Write("Opcja: ");
        }

        public static void AddRecord(ref List<Osoba> Contacts)
        {
            Console.WriteLine("==================");
            Console.WriteLine("DODAJ NOWY KONTAKT");
            Console.WriteLine("==================\n");


            Console.Write("Imie: ");
            string _FName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            string _LName = Console.ReadLine();
            Console.Write("Numer: ");
            int _Number = int.Parse(Console.ReadLine());
            Osoba rec = new Osoba();
            rec.FName = _FName;
            rec.LName = _LName;
            rec.Number = _Number;
            Contacts.Add(rec);
            Console.WriteLine("Dodano!");
            Console.WriteLine("|{0}\t|{1}\t\t|{2}\t\t|{3}\t\t|", Contacts.IndexOf(rec), rec.FName, rec.LName, rec.Number);
        }

        public static void ShowRecords(List<Osoba> Contacts)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("|ID\t|Imie\t\t|Nazwisko\t\t|Numer\t|");
            Console.WriteLine("=================================================================");
            int count = 0;
            foreach (var Osoba in Contacts)
            {
            Console.WriteLine("|{0}\t|{1}\t\t|{2}\t\t\t|{3}\t\t\t|", Contacts.IndexOf(Osoba), Osoba.FName, Osoba.LName, Osoba.Number);
                count++;
            }
            Console.WriteLine("=================================================================");
            Console.WriteLine("\nLiczba kontaktow: " + count);

        }

        public static void RemoveRecord(ref List<Osoba> Contacts)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("USUN ISTNIEJACY KONTAKT");
            Console.WriteLine("=======================\n");
            Console.Write("Podaj indeks kontaktu do usuniecia: ");

            int id = int.Parse(Console.ReadLine());

            foreach (Osoba rec in Contacts)
            {
                if (Contacts.IndexOf(rec) == id)
                {
                    Contacts.Remove(rec);
                    Console.WriteLine("\nUsunieto kontakt o id " + id);
                    break;
                }
            }

        }

        public static void SearchRecord(List<Osoba> Contacts)
        {
            Console.Write("Wpisz fraze do wyszukania: ");
            string phase = Console.ReadLine();
            int count = 0;
            foreach (Osoba rec in Contacts)
            {
                if (rec.FName.Contains(phase) || rec.LName.Contains(phase) || rec.Number.ToString().Contains(phase))
                {
                    int index = Contacts.IndexOf(rec);
                    Console.WriteLine("{0} - {1} - {2} - {3}", index, rec.LName, rec.FName, rec.Number);
                    count++;
                }
            }
            if(count == 0)
            {
                Console.WriteLine("\nNie znaleziono rekordow");
            }
            else
            {
                Console.WriteLine("\nZnaleziono {0} rekord(ow)", count);
            }

            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            var Contacts = new List<Osoba>();

            while (true)
            {
                MainScreen();
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 9:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        ShowRecords(Contacts);
                        break;
                    case 2:
                        Console.Clear();
                        AddRecord(ref Contacts);
                        break;
                    case 3:
                        Console.Clear();
                        RemoveRecord(ref Contacts);
                        break;
                    case 4:
                        Console.Clear();
                        SearchRecord(Contacts);
                        break;
                    case 5:
                        Contacts.Sort((x, y) => string.Compare(x.LName, y.LName));
                        Console.Clear();
                        Console.WriteLine("Lista posortowana zgodnie z alfabetem (wg nazwisk)");
                        break;
                    default:
                        Console.Clear();
                        option = 99;
                        Console.WriteLine("Err! Sprobuj ponownie.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
