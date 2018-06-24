using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №6. \n . Введите а1, а2, а3, N. Выведется  последовательность чисел ак = ( ак–1 + ак-2 ) / 2 – ак–3.");
            double a1, a2, a3;
            int N;
            a1 = TakeNumber("Введите а1:");
            a2 = TakeNumber("Введите а2:");
            a3 = TakeNumber("Введите а3");
            N = TakeNumberI("Введите N:");
            while ( N < 1)
            {
                N = TakeNumberI("N < 1, введите еще раз N");
            }
            int count = 3;
            int k = 1;
            int maxk = 1;
            double max = 0;
            if ( a2 > a1)
            {
                k++;
                if ( k > maxk)
                {
                    maxk = k;
                    max = a2;
                }
            }
            else k = 1;
            if (a3 > a2)
            {
                k++;
                if (k > maxk)
                {
                    maxk = k;
                    max = a3;
                }
            }
            else k = 1;
            Console.WriteLine("Ваша последовательность:");
            if (N > 3)
            {
                Console.Write(a1 + " " + a2 + " " + a3 + " ");
                recur(a1, a2, a3, N, ref count, ref k, ref maxk, ref max);
                Console.WriteLine("\nДлина максимальной возрастающей подпоследовательности: {0} И ее последний элемент: {1:0.###}", maxk, max);
            }
            else
            {
                Console.Write(a1 + " " + a2 + " " + a3 + " ");
                recur(a1, a2, a3, N, ref count, ref k, ref maxk, ref max);
                Console.WriteLine("Ваша последовательность уже содержит 3 элемента \nДлина максимальной возрастающей подпоследовательности: {0} И ее последний элемент: {1:0.###}", a1);
            }
            
            Console.ReadKey();
        }

        static double TakeNumber(string st)
        {
            Console.WriteLine(st);
            double n = 0;
            bool ok = true;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }

        static int TakeNumberI(string st)
        {
            Console.WriteLine(st);
            int n = 0;
            bool ok = true;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }

        static void recur(double a1, double a2, double a3, int N, ref int count, ref int k, ref int maxk, ref double max)
        {
            double a4;
            count++;
            a4 = a3 / 2 + a2 / 2 - a1;
            if (a4 > a3)
            {
                k++;
                if (k >= maxk)
                {
                    maxk = k;
                    max = a4;
                }
            }
            else k = 1;
            Console.Write("{0:0.###} ", a4);
            if (N > count)
                recur(a2, a3, a4, N, ref count, ref k, ref maxk, ref max);
        }
    }
}
