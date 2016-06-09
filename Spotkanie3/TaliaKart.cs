using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotkanie3
{
    class TaliaKart
    {
        public TaliaKart()
        {
            this.ListaKart = new List<Karta>();
            Karta krol = new Karta();
            krol.Symbol = "K";
            krol.nazwa = "Krol";
            krol.wartosc = 13;
            krol.kolor = "pik";
            this.ListaKart.Add(krol);
            this.ListaKart.Add(new Karta() { nazwa = "Dwa", Symbol = "2", wartosc = 2, kolor = "pik" });
            this.ListaKart.Add(new Karta() { nazwa = "As", Symbol = "A", wartosc = 1, kolor = "kier" });
            this.ListaKart.Add(new Karta() { nazwa = "Walet", Symbol = "J", wartosc = 11, kolor = "kier" });
            this.ListaKart.Add(new Karta() { nazwa = "Walet", Symbol = "J", wartosc = 11, kolor = "trefl" });
            this.ListaKart.Add(new Karta() { nazwa = "Dama", Symbol = "D", wartosc = 12, kolor = "trefl" });
            this.ListaKart.Add(new Karta() { nazwa = "Osemka", Symbol = "8", wartosc = 8, kolor = "karo" });
            this.ListaKart.Add(new Karta() { nazwa = "Krol", Symbol = "K", wartosc = 13, kolor = "karo" });

            this.kolor = "czerwony";
            this.cena = 5;
        }

        public TaliaKart(int iloscKart, string kolor)
        {

        }

        public void PokazTalieKart()
        {
            foreach (var karta in this.ListaKart)
            {
                Console.WriteLine(karta.OpiszSiebie());
            }
        }


        public List<Karta> ListaKart;
        public string kolor;
        public int cena;

    }
}
