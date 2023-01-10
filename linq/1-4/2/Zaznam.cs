using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    public class Zaznam
    {
        public DateTime Datum { get; set; }
        public string Text { get; set; }

        public Zaznam(DateTime datum, string text)
        {
            Datum = datum;
            Text = text;
        }
        public Zaznam()
        {

        }
    }

}
