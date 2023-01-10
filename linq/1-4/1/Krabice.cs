using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Krabice<T> where T : IPolozka
    {
        public T Polozka { get; private set; }

        public Krabice(T polozka)
        {
            Polozka = polozka;
        }
    }

}
