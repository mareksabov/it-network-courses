using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Kniha : IPolozka
    {
        public string Nazev { get; private set; }

        public Kniha(string nazev)
        {
            Nazev = nazev;
        }
    }

}
