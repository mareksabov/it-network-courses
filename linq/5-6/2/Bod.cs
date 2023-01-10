using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    struct Bod
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Hodnota { get; set; }

        public Bod(int x, int y, int hodnota): this()
        {
            X = x;
            Y = y;
            Hodnota = hodnota;
        }

        public override string ToString()
        {
            return $"[{X};{Y}]";
        }
    }

}
