using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp
{

    class Program
    {
        // Prostředí, ve kterém hledáme cestu (1 = překážka, 0 = volná plocha)
        static int[,] prostredi = new int[12, 12]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1 },
            { 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };
        // Zde se budou ukládat všechny procházené body
        static Bod[,] body = new Bod[prostredi.GetLength(0), prostredi.GetLength(1)];
        static Bod pocatecniBod = new Bod(4, 7, 0);
        static Bod cilovyBod = new Bod(8, 9, int.MaxValue);

        static void Main(string[] args)
        {
            // Každý bod má ve výchozím stavu maximální možnou hodnotu,
            // aby se pak dala jednodušeji porovnávat při hledání výsledné cesty
            for (int y = 0; y < body.GetLength(1); y++)
                for (int x = 0; x < body.GetLength(0); x++)
                    body[x, y] = new Bod(x, y, int.MaxValue);
            body[pocatecniBod.X, pocatecniBod.Y] = pocatecniBod;

            var queue = new Queue<Bod>();

            queue.Enqueue(pocatecniBod);


            while (true)
            {
                var workingPoint = queue.Dequeue();

                //up
                if (workingPoint.Y - 1 > 0 && prostredi[workingPoint.X, workingPoint.Y - 1] == 0 && body[workingPoint.X, workingPoint.Y - 1].Hodnota == int.MaxValue)
                {
                    body[workingPoint.X, workingPoint.Y - 1].Hodnota = workingPoint.Hodnota + 1;
                    queue.Enqueue(body[workingPoint.X, workingPoint.Y - 1]);

                    if (body[workingPoint.X, workingPoint.Y - 1].X == cilovyBod.X && body[workingPoint.X, workingPoint.Y - 1].Y == cilovyBod.Y)
                        break;
                }

                //down
                if (workingPoint.Y + 1 < prostredi.GetLength(1) && prostredi[workingPoint.X, workingPoint.Y + 1] == 0 && body[workingPoint.X, workingPoint.Y + 1].Hodnota == int.MaxValue)
                {
                    body[workingPoint.X, workingPoint.Y + 1].Hodnota = workingPoint.Hodnota + 1;
                    queue.Enqueue(body[workingPoint.X, workingPoint.Y + 1]);

                    if (body[workingPoint.X, workingPoint.Y + 1].X == cilovyBod.X && body[workingPoint.X, workingPoint.Y + 1].Y == cilovyBod.Y)
                        break;
                }

                //left
                if (workingPoint.X - 1 > 0 && prostredi[workingPoint.X - 1, workingPoint.Y] == 0 && body[workingPoint.X - 1, workingPoint.Y].Hodnota == int.MaxValue)
                {
                    body[workingPoint.X - 1, workingPoint.Y].Hodnota = workingPoint.Hodnota + 1;
                    queue.Enqueue(body[workingPoint.X - 1, workingPoint.Y]);

                    if (body[workingPoint.X - 1, workingPoint.Y].X == cilovyBod.X && body[workingPoint.X - 1, workingPoint.Y].Y == cilovyBod.Y)
                        break;
                }

                //right
                if (workingPoint.X + 1 < prostredi.GetLength(0) && prostredi[workingPoint.X + 1, workingPoint.Y] == 0 && body[workingPoint.X + 1, workingPoint.Y].Hodnota == int.MaxValue)
                {
                    body[workingPoint.X + 1, workingPoint.Y].Hodnota = workingPoint.Hodnota + 1;
                    queue.Enqueue(body[workingPoint.X + 1, workingPoint.Y]);

                    if (body[workingPoint.X, workingPoint.Y].X == cilovyBod.X && body[workingPoint.X, workingPoint.Y].Y == cilovyBod.Y)
                        break;
                }


            }
            //get path
            var workingPoint2 = body[cilovyBod.X, cilovyBod.Y];
            var stack = new Stack<Bod>();
            stack.Push(workingPoint2);

            while (true)
            {
                // Console.WriteLine($"[{workingPoint2.X};{workingPoint2.Y}] = {workingPoint2.Hodnota}");

                if (workingPoint2.X == pocatecniBod.X && workingPoint2.Y == pocatecniBod.Y)
                    break;

                //up
                if (workingPoint2.Y-1 > 0 &&  body[workingPoint2.X, workingPoint2.Y - 1].Hodnota == workingPoint2.Hodnota - 1)
                {
                    stack.Push(body[workingPoint2.X, workingPoint2.Y - 1]);
                    workingPoint2 = body[workingPoint2.X, workingPoint2.Y - 1];
                    continue;
                }
                //left
                else if (workingPoint2.X-1 > 0 && body[workingPoint2.X - 1, workingPoint2.Y].Hodnota == workingPoint2.Hodnota - 1)
                {
                    stack.Push(body[workingPoint2.X - 1, workingPoint2.Y]);
                    workingPoint2 = body[workingPoint2.X - 1, workingPoint2.Y];
                    continue;
                }
                //down
                else if (workingPoint2.Y+1 < body.GetLength(1) && body[workingPoint2.X, workingPoint2.Y + 1].Hodnota == workingPoint2.Hodnota - 1)
                {
                    stack.Push(body[workingPoint2.X, workingPoint2.Y + 1]);
                    workingPoint2 = body[workingPoint2.X, workingPoint2.Y + 1];
                    continue;
                }
                //right
                else if (workingPoint2.X+1 < body.GetLength(0) && body[workingPoint2.X + 1, workingPoint2.Y].Hodnota == workingPoint2.Hodnota - 1)
                {
                    stack.Push(body[workingPoint2.X + 1, workingPoint2.Y]);
                    workingPoint2 = body[workingPoint2.X+1, workingPoint2.Y];
                    continue;
                }

            }

            Console.Write(string.Join(' ', stack));
            Console.ReadLine();
        }
    }

}
