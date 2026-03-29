using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraPuzzle
{
    internal class Inventory
    {
        public static List<string> Items = new();
        public static void Add(string item)
        {
            Items.Add(item);
        }
        public static bool Has(string item)
        {
            return Items.Contains(item);
        }
    }
}