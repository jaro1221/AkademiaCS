using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotkanie3
{
    public class Karta
    {
        public string Symbol { get; set; }
        public string nazwa;
        public string kolor;
        public int wartosc;
        public int Rozmiar { get; set; } = 30;

        public string OpiszSiebie()
        {
            string tmp;
            tmp = "Nazwa: " + this.nazwa + ", symbol: " + this.Symbol + ", wartosc: " + this.wartosc + ", kolor: " + this.kolor + ".";
            return tmp;
        }



        //private int jakiesPole;

        //public int getJakiesPole()
        //{
        //    return this.jakiesPole;
        //}
        //public void setJakiesPole(int wartosc)
        //{
        //    this.jakiesPole = wartosc;
        //}



    }
}
