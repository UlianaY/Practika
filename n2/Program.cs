using System;
using System.Collections;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Требуется написать программу, которая по заданной рациональной дроби находит ее факториальное представление./n Введите числа через пробел");
            int p, q;
            string[] s1 = (Console.ReadLine()).Split(' ');
            int.TryParse(s1[0], out p);
            int.TryParse(s1[1], out q);
            ArrayList arr = new ArrayList();
            for (int i = 2; i<= q && p>0; i++)
            {

                int ai = p * i / q;
                arr.Add(ai);
                p = p * i % q;
            }
            Console.WriteLine(arr.Count + 1);
            foreach ( int i  in arr)
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
