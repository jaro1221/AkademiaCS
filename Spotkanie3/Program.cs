using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotkanie3
{
    class Program
    {
        static void Main(string[] args)
        { 
            TaliaKart talia = new TaliaKart();
            TaliaKart talia2 = new TaliaKart(50, "zielony");
            talia.PokazTalieKart();
            Console.ReadKey();

            Karta karta = new Karta();
            karta.Symbol = "5";
            Console.WriteLine(karta.Symbol);
        }
    }
}
