using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Programator
    {
        public string Jmeno { get; private set; }
        public HashSet<string> ProgramovaciJazyky { get; private set; }

        public Programator(string jmeno, string[] jazyky)
        {
            Jmeno = jmeno;
            ProgramovaciJazyky = new HashSet<string>(jazyky);
        }
    }

}
