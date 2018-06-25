using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n8
{
    class Program
    {
       // 1-white 2-black
List<string> catalogCycles;

        private void cyclesSearch()
        {
            int[] color = new int[V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int k = 0; k < V.Count; k++)
                    color[k] = 1;
                List<int> cycle = new List<int>();
                cycle.Add(i + 1);
                DFScycle(i, i, E, color, -1, cycle);
            }
        }

        private void DFScycle(int u, int endV, List<Edge> E, int[] color, int unavailableEdge, List<int> cycle)
        {
            //если u == endV, то эту вершину перекрашивать не нужно, иначе мы в нее не вернемся, а вернуться необходимо
            if (u != endV)
                color[u] = 2;
            else if (cycle.Count >= 2)
            {
                cycle.Reverse();
                string s = cycle[0].ToString();
                for (int i = 1; i < cycle.Count; i++)
                    s += "-" + cycle[i].ToString();
                bool flag = false; //есть ли палиндром для этого цикла графа в List<string> catalogCycles?
                for (int i = 0; i < catalogCycles.Count; i++)
                    if (catalogCycles[i].ToString() == s)
                    {
                        flag = true;
                        break;
                    }
                if (!flag)
                {
                    cycle.Reverse();
                    s = cycle[0].ToString();
                    for (int i = 1; i < cycle.Count; i++)
                        s += "-" + cycle[i].ToString();
                    catalogCycles.Add(s);
                }
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (w == unavailableEdge)
                    continue;
                if (color[E[w].v2] == 1 && E[w].v1 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v2 + 1);
                    DFScycle(E[w].v2, endV, E, color, w, cycleNEW);
                    color[E[w].v2] = 1;
                }
                else if (color[E[w].v1] == 1 && E[w].v2 == u)
                {
                    List<int> cycleNEW = new List<int>(cycle);
                    cycleNEW.Add(E[w].v1 + 1);
                    DFScycle(E[w].v1, endV, E, color, w, cycleNEW);
                    color[E[w].v1] = 1;
                }
            }
        }

        public class Graph
        {
            public Graph()
            {
                FillingMatrix();
            }

            public Graph(MyGraph graph)
            {
                MatrSmeznosti = graph.Matrix;
                KolVershn = graph.Size;
            }

            public int[,] MatrSmeznosti { get; set; }
            public int KolVershn { get; set; }

            public int Input(string str)
            {
                var ok = true;
                var digit = 0;
                while (ok)
                {
                    Console.Write(str);
                    ok = int.TryParse(Console.ReadLine(), out digit);
                    if (!ok)
                    {
                        Console.WriteLine("Ошибка ввода! Повторите ввод...");
                        ok = true;
                    }
                    else
                    {
                        ok = false;
                    }
                }

                return digit;
            }

            public int InputVGran(string str, int min, int max)
            {
                int digit;
                while (true)
                {
                    digit = Input(str);
                    if (digit > max || digit < min)
                        Console.WriteLine("Ошибка ввода! Повторите ввод ({0}<=<={1})", min, max);
                    else
                        break;
                }

                return digit;
            }

            public void FillingMatrix()
            {
                while (true)
                {
                    KolVershn = Input("Введите кол-во вершин в графе: ");
                    if (KolVershn == 0)
                    {
                        Console.WriteLine("Кол-во вершин графа не может равняться 0! Повторите ввод...");
                    }
                    else
                    {
                        if (KolVershn < 0)
                        {
                            Console.WriteLine("Кол-во вершин графа не может быть отрицательным числом! Повторите ввод...");
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                MatrSmeznosti = new int[KolVershn, KolVershn];
                for (var i = 0; i < KolVershn; i++)
                {
                    for (var j = 0; j < i; j++)
                        MatrSmeznosti[i, j] = MatrSmeznosti[j, i] =
                            InputVGran("Введите 1, если вершина " + (i + 1) + " и вершина " + (j + 1) + " связаны и 0 в обратном: ", 0, 1);
                }
            }
        }

        public class MyGraph
        {
            public int Size { get; set; }
            public int[,] Matrix { get; set; }

            public MyGraph()
            {
                Random rnd = new Random();
                Size = rnd.Next(1, 26);
                Matrix = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (j > i)
                            Matrix[i, j] = Matrix[j, i] = rnd.Next(0, 2);
                    }
                }
            }
        }

    }
}
