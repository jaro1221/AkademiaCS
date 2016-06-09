using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akademia1
{
    /* skróty klawiszowe
      *  ctrl + k + d - formatuje nam dokument
      *  ctrl + k + c - komentujemy zaznaczony fragment kodu
      *  ctrl + k + u - odkomentowujemy fragment kodu
      *  ctrl + r + r - zmieniamy nazwę zaznaczonej zmiennej w dokumencie
    */

    class Program
    {
        static void Main(string[] args)
        {
            int option;

            // tablica jednowymiarowa, jeżeli chcemy więcej wymiarów, to należy wstawić przecinki na każdy wymiar
            // czyli np. int[,,,] tablica jest tablicą 4-wymiarową
            string[] menuTab = { "- Game Menu -", "1. Play the Game!", "2. Highscores", "3. Settings", "4. Exit" };

            // tablica ma stały rozmiar, który przypisujemy w momencie deklaracji bądź inicjalizacji
            // nastomiast listę możemy dowolnie rozszerzać (.Add) bądź zwężać (np. .RemoveAt(<index>))
            string[] pplTab = { "Jarek Dziekan", "Michał", "Jan" };
            List<string> ppl = new List<string> { "Jarek Dziekan", "Michał", "Jan" };
            ppl.Add("Zenek");

            Console.WriteLine(ppl[2]);
            Console.WriteLine(pplTab[2]);


            /* foreach to pętla, która iteruje po wszystkich elementach kolekcji takich jak lista czy tablica
            w tym przypadku: bierzemy zmienną person i przypisujemy jej wartości kolejnych elementów 
            tablicy pplTab, a następnie wypisujemy to, co siedzi w ich wartości */
            foreach (string person in pplTab)
            {
                Console.WriteLine(person);
            }

            // int.Parse pozwala na zmiane typu tekstu wczytywanego z konsoli ze string na int
            option = int.Parse(Console.ReadLine());

            // Można użyć konstrukcji if(warunek), else if, else
            // default działa jak else, a słowko break jest konieczne (można zamienić na continue lub goto case x)
            switch (option)
            {
                case 1: Console.WriteLine("Wybrałeś 1 - Zaczynamy Grę!"); break;
                case 2: Console.WriteLine("Wybrałeś 2 - Pokazuje najlepsze wyniki"); break;
                case 3: Console.WriteLine("Wybrałeś 3 - Ustawienia"); break;
                case 4: System.Environment.Exit(0); break;
                default: Console.WriteLine("Nie ma takiej opcji!"); break;
            }


            // pozwalamy tutaj, aby program się zatrzymał i czekał na wciśnięcie jakiegoś klawisza
            Console.ReadKey();
        }
    }
}
