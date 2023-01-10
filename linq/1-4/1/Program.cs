using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
	class Program
	{
 		static void Main(string[] args) {
             var list = new List<Krabice<IPolozka>>();
        
        list.Add(new Krabice<IPolozka>(new Boty("tenisky",39)));
        list.Add(new Krabice<IPolozka>(new Kniha("Proměna")));
        list.Add(new Krabice<IPolozka>(new Lahev("termoska",1.5)));
        list.Add(new Krabice<IPolozka>(new Boty("zimní boty",42)));

        Console.WriteLine($"V první krabici jsou {list[0].Polozka.Nazev} velikosti {(list[0].Polozka as Boty).Velikost}");
        Console.WriteLine($"Ve druhé krabici je kniha s názvem {list[1].Polozka.Nazev}");
        Console.WriteLine($"Ve třetí krabici je {list[2].Polozka.Nazev} o objemu {(list[2].Polozka as Lahev).Objem} l");
        Console.WriteLine($"Ve čtvrté krabici jsou {list[3].Polozka.Nazev} velikosti {(list[3].Polozka as Boty).Velikost}");
		}
	}
}