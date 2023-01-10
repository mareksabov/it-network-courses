using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Boty : IPolozka
    {
        public int Velikost { get; private set; }
        public string Nazev { get; private set; }

        public Boty(string nazev, int velikost)
        {
            Nazev = nazev;
            Velikost = velikost;
        }
    }

}
