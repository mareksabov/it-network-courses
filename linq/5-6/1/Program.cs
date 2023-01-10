using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
    class Program
    {
        private static HashSet<Programator> _programators = new HashSet<Programator>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Zadejte {i+1}. programátora");
                Console.Write("Jméno: ");
                var name = Console.ReadLine();
                Console.Write("Programovací jazyky (oddělujte čárkou a mezerou): ");
                var languages = Console.ReadLine();

                _programators.Add(new Programator(name, languages.Split(", ")));
            }

            /*_programators.Add(new Programator("Karel", new string[] { "C#", "Swift", "Kotlin" }));
            _programators.Add(new Programator("Lucie", new string[] { "JavaSript", "PHP", "C#" }));
            _programators.Add(new Programator("Milan", new string[] { "C", "C++", "C#" }));*/

            var allLanguages = new HashSet<string>();
            var sameLanguages = new HashSet<string>(_programators.First().ProgramovaciJazyky);

            for (int i = 0; i < 3; i++)
            {
                allLanguages.UnionWith(_programators.ElementAt(i).ProgramovaciJazyky);
                sameLanguages.IntersectWith(_programators.ElementAt(i).ProgramovaciJazyky);
            }

            // Console.WriteLine($"Všechny jazyky: {string.Join(", ",allLanguages)}");

            //for automatic check in it networks
            var sb = new StringBuilder();
            foreach (var item in allLanguages)
            {
                sb.Append(item).Append(", ");
            }

            Console.WriteLine($"Všechny jazyky: {sb.ToString()}");

            sb = new StringBuilder();
            foreach (var item in sameLanguages)
            {
                sb.Append(item).Append(", ");
            }
            Console.WriteLine($"Společné jazyky: {sb.ToString()}");

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                var exceptLanguages = new HashSet<string>(_programators.ElementAt(i).ProgramovaciJazyky);

                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                        continue;

                    exceptLanguages.ExceptWith(_programators.ElementAt(j).ProgramovaciJazyky);
                }

                sb = new StringBuilder();
                foreach (var item in exceptLanguages)
                {
                    sb.Append(item).Append(", ");
                }
                Console.WriteLine($"Jazyky, které umí jen {_programators.ElementAt(i).Jmeno}: {sb.ToString()}");
            }
            Console.ReadLine();
        }
    }
}
