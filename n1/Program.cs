using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Требуется вывести все различные представления натурального числа N в виде суммы натуральных чисел. Представления, отличающиеся друг от друга порядком слагаемых, не являются различными." +
                              "\nВходные данные - целое число N(2 <= N <= 40). \nВыходные данные:" +
                              "\nВ все различные представления числа N без повторов в виде суммы.");
            int.TryParse(Console.ReadLine(), out n);
            int[] arr = new int[n];
            Func(n, "", 0);
            Console.ReadKey();
        }

        static void Func(int N, string str, int pred)
        {
            if (N == 0 && str.Contains("+"))
                Console.WriteLine(str);
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    if (pred <= i)
                    {
                        if (str == "")
                        {
                            Func(N - i, String.Concat(i), i);
                        }
                        else
                        {
                            Func(N - i, String.Concat(str, " + ", i), i);
                        }
                    }
                }
            }
        }
    }
}
