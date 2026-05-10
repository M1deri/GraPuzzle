using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraPuzzle
{
    // Klasa odpowiedzialna za przechowywanie przedmiotów gracza
    public class Inventory
    {
        // Lista przedmiotów w ekwipunku
        public static List<string> Items = new();

        // Metoda dodająca przedmiot do ekwipunku
        public static void Add(string item)
        {
            Items.Add(item);
        }

        // Metoda sprawdzająca,
        // czy dany przedmiot znajduje się w ekwipunku
        public static bool Has(string item)
        {
            return Items.Contains(item);
        }
    }
}
