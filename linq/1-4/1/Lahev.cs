using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Lahev : IPolozka
    {
        public string Nazev { get; private set; }
        public double Objem { get; private set; }

        public Lahev(string nazev, double objem)
        {
            Nazev = nazev;
            Objem = objem;
        }
    }

}
