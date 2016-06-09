using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia1
{


    class Program
    {
        // Struktura jest typem wartościowym
        public struct Point
        {
            public int x;
            public int y;
            public int z;
        }

        // można w niej umieszczać proste metody, nie przyjmujące parametrów
        public struct Prostokat
        {
            public int a;
            public int b;
            public int Obwod()
            {
                return 2 * a + 2 * b;
            }
        }

        public struct NaszaStrukturaODlugiejNazwie
        {

        }

        static void Main(string[] args)
        {
            // która wersja jest czytelniejsza?
            //var nazwaSlownika = new SortedDictionary<int,NaszaStrukturaODlugiejNazwie>();
            //SortedDictionary<int,NaszaStrukturaODlugiejNazwie> nazwaSlownika  = new SortedDictionary<int, NaszaStrukturaODlugiejNazwie>();


            // Strukturę tworzymy w taki sam sposób jak proste zmienne
            // po kropce odnosimy do jej poszczególnych pól bądź metod/funkcji
            Point punkt;
            punkt.x = 1;
            punkt.y = 2;
            punkt.z = 3;
            
            // Są 3 sposoby na wypisywanie do konsoli
            Console.WriteLine("Punkt x: " + punkt.x + ", y: " + punkt.y + ", z: " + punkt.z);
            Console.WriteLine("Punkt x: {0}, y: {1}, z: {2}", punkt.x, punkt.y, punkt.z);
            // ostatni sposób dostępny dopiero od C# 6.0 czyli .NET 4.6
            Console.WriteLine($"Punkt x: {punkt.x}, y: {punkt.y}, z: {punkt.z}");

            Prostokat prostokatA;
            prostokatA.a = 5;
            prostokatA.b = 4;

            Console.WriteLine("Obwód prostokąta wynosi {0} j", prostokatA.Obwod());


            var lista = new SortedDictionary<int, NaszaStrukturaODlugiejNazwie>();


            int zmienna = 7;
            if (CountingLoop(ref zmienna))
            {
                Console.WriteLine("Zmienna ma wartość: " + zmienna);
            }
            else
            {
                Console.WriteLine("Nie dziala!");
            }


            int a, b;
            SetRandomNumber(out a, out b);


            // przy refie musimy wrzucać zmienną zainicjalizowaną (posiadającą już jakąś wartość)
            // aby później móc na niej działać.
            int abc = 5;
            CountingLoop(ref abc);


            // Polimorfizm Statyczny
            string costam = "aaa";
            JakiToTyp(a);
            JakiToTyp(costam);


            Console.ReadKey();
        }


        // Polimorfizm statyczny czyli przeciążanie funkcji
        // Taka sama funkcja, może dla różnych parametrów wejściowych robić różne rzeczy
        // paramety mogą być różne, różna może być też ich ilość
        public static void JakiToTyp(string zmienna)
        {
            Console.WriteLine("Zmienna {0} jest typu string.", zmienna);
        }
        public static void JakiToTyp(int zmienna)
        {
            Console.WriteLine("Zmienna {0} jest typu int.", zmienna);
        }
        public static void JakiToTyp(bool zmienna)
        {
            Console.WriteLine("Zmienna {0} jest typu bool.", zmienna);
        }


        // ref (referencja) pozwala na działanie wewnątrz funkcj na zmiennej, która istnieje poza funkcją
        // i na zmienianie jej wartości również poza funkcją, nie tylko w jej ciele
        public static bool CountingLoop(ref int zmienna)
        {
            if (zmienna == 0)
                return false;

            for (int i = 0; i < 100; i++)
            {
                zmienna = zmienna * zmienna;
                zmienna += 88;
                zmienna %= 22;
                zmienna /= 5 + zmienna;
                zmienna = zmienna - 103;
            }

            return true;
        }


        // out pozwala "wypluć" z funkcji kilka zmiennych, nie używając returna do tego
        // do środka wchodzą zmienne niezainicjalizowane, tylko zdeklarowane.
        public static void SetRandomNumber(out int zmienna, out int zmienna2)
        {
            Random rand = new Random();
            zmienna = rand.Next(100);
            zmienna2 = rand.Next(50);
        }


    }
}
