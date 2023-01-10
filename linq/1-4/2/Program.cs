using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{
    class Program
    {
        static List<Zaznam> _list = new List<Zaznam>();
        static int _selectedIndex = 0;

        static void Main(string[] args)
        {
            Tick();
        }

        private static void Tick()
        {
            PrintBase();
            ReadCommand();
        }

        private static void PrintBase()
        {
            Console.Clear();

            PrintMenu();

            PrintRecords();
        }

        private static void ReadCommand()
        {
            Console.Write("Zadej příkaz: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "predchozi":
                Previous();
                Tick();
                    break;
                case "dalsi":
                Next();
                Tick();
                    break;
                case "novy":
                    CreateRecord();
                    break;
                case "smaz":
                    DeleteRecord();
                    break;
                case "zavri":
                    Environment.Exit(0);
                    break;
                default:
                    Tick();
                    break;
            }
        }

        private static void Next(){
            if(_selectedIndex +1 <= _list.Count-1)
                _selectedIndex++;
            else
                _selectedIndex = _list.Count-1;
        }

        private static void Previous(){
            if(_selectedIndex -1 >= 0)
                _selectedIndex--;
            else
                _selectedIndex = 0;
        }

        private static void CreateRecord()
        {
            PrintBase();
            Console.WriteLine();

            while (true)
            {
                Console.Write("Datum: ");
                var input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime dt))
                {
                    Console.Clear();
                    PrintMenu();
                    Console.WriteLine();
                    Console.WriteLine($"Datum: {dt.ToString("dd.MM.yyyy")}");
                    Console.WriteLine();
                    Console.WriteLine("Text:");

                    var sb = new StringBuilder();

                    var text = string.Empty;

                    while (true)
                    {
                        var line = Console.ReadLine();

                        if (line == "uloz")
                        {
                            text = sb.ToString();
                            break;
                        }
                        else
                        {
                            sb.AppendLine(line);
                        }
                    }

                    _list.Add(new Zaznam(dt, text));
                    _selectedIndex = _list.Count -1;
                    Tick();
                    break;
                }
            }
        }

        private static void PrintRecords()
        {
            Console.WriteLine($"Počet záznamů: {_list.Count}");
            //Console.WriteLine();
            if(_list.Count > 0){
                //Console.WriteLine();
                PrintRecord(_list[_selectedIndex]);
            }
        }

        private static void DeleteRecord(){
            if(_list.Count == 0 || (_selectedIndex < 0 || _selectedIndex >= _list.Count)){
                Tick();
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Datum: {_list[_selectedIndex].Datum.ToString("dd.MM.yyyy")}");
            Console.WriteLine();
            Console.WriteLine(_list[_selectedIndex].Text);
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------\n");
            Console.WriteLine("Pro odstranění tohoto záznamu stiskni \"a\", pro zrušení jiný znak.");
            var input = Console.ReadLine();

            if(input == "a"){
                _list.Remove(_list[_selectedIndex]);
                _selectedIndex = 0;
                DeleteRecord();
            }

            Tick();
        }

        private static void PrintRecord(Zaznam record)
        {
            Console.WriteLine();

            Console.WriteLine($"Datum: {record.Datum.ToString("dd.MM.yyyy")}");
            Console.WriteLine();

            Console.WriteLine(record.Text);

            Console.WriteLine("-------------------------------------------------------\n");
        }

        static void PrintMenu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Deník se ovládá následujícími příkazy:");
            Console.WriteLine("- predchozi: Přesunutí na předchozí záznam");
            Console.WriteLine("- dalsi: Přesunutí na další záznam");
            Console.WriteLine("- novy: Vytvoření nového záznamu");
            Console.WriteLine("- uloz: Uložení vytvořeného záznamu");
            Console.WriteLine("- smaz: Odstranění záznamu");
            Console.WriteLine("- zavri: Zavření deníku");
            Console.WriteLine("-------------------------------------------------------\n");
        }
    }
}