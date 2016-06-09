using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotkanie4
{
    public class Ksztaut
    {
        public int Dlugosc { get; set; }
        public int Wysokosc { get; set; }

        public void CzymJestes()
        {
            Console.WriteLine("Ksztaut");
        }

    }

    public class Prostokat :Ksztaut
    {
        //public int Dlugosc { get; set; }
        //public int Wysokosc { get; set; }

        //public double Pole()
        //{
        //    return this.Wysokosc * this.Dlugosc;
        //}

        //public void CzymJestes()
        //{
        //    Console.WriteLine("Prostokat");
        //}

        //public void KlasaPodstawowa()
        //{
        //    Console.WriteLine("Ksztaut");
        //}

        //public void KlasaParent()
        //{
        //    Console.WriteLine("Ksztaut");
        //}
    }

    public class Kwadrat : Prostokat
    {
        private int _dlugosc;
        private int _wysokosc;
        public int Dlugosc
        {
            get
            {
                return this._dlugosc;
            }

            set
            {
                this._wysokosc = value;
                this._dlugosc = value;
            }
        }
        public int Wysokosc
        {
            get
            {
                return this._wysokosc;
            }

            set
            {
                this._wysokosc = value;
                this._dlugosc = value;
            }
        }
        public void CzymJestes()
        {
            Console.WriteLine("Kwadrat");
        }
        public void KlasaParent()
        {
            Console.WriteLine("Prostokat");
        }

    }

    static void Main(string[] args)
    {
        Prostokat p = new Prostokat();
    }

}
