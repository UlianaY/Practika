using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №4 из книги Абрамов С.А., Гнездилова Г.Г., Капустина Е.Н., Селюн М.И. Задачи по программированию. М.: Наука, 1988.\n №588");
            Console.WriteLine("Дано натуральное число р. Получить последовательность а0, ..., аn, каждый член которой равен —1, 0 или 1, такую, что р = а0*3^0 + . . . + an*3^n");
            Console.WriteLine("\nВведите p ");
            int P = TakeNumber();
            string Not3 = ConvertionFromDecimal(3, P);
            int[] Number = new int[Not3.Length];
            int[] Answer = new int[Not3.Length];
            for (int i = 0; i < Answer.Length; i++)
            {
                Number[i] = Convert.ToInt32(Char.GetNumericValue(Not3[i]));
            }

            Array.Reverse(Number);
            for (int i = 0; i< Number.Length; i++)
            {
                int tek = Number[i];
                switch (tek)
                {
                    case 0:
                        Answer[i] = 0;
                        break;

                    case 1:
                        Answer[i] = 1;
                        break;
                    case 2:
                        Answer[i] = -1;
                        if (i >= Number.Length -1)
                        {
                            AddNumber(ref Number, ref Answer);
                        }    
                        else
                        {
                            MakeBetter(ref Number, ref Answer, i + 1);
                        }
                        break;
                }
            }
            Array.Reverse(Answer);

            for (int i = 0; i < Answer.Length; i++)
            {
                Console.Write(Answer[i] + " ");
            }
            Console.ReadLine();
        }

        public static void AddNumber (ref int[] Number, ref int[] Answer)
        {
            Array.Resize(ref Number, Number.Length + 1);
            Array.Resize(ref Answer, Answer.Length + 1);
            Number[Number.Length - 1] = 1;
        }

        public static void MakeBetter(ref int[] Number, ref int[] Answer, int i )
        {
            Number[i] += 1;
            if (Number[i] > 2)
            {
                if (i  >= Number.Length-1)
                {
                    AddNumber(ref Number, ref Answer);
                }
                else
                {
                    MakeBetter(ref Number, ref Answer, i + 1);
                }                            
            }
        }

        public static string ConvertionFromDecimal( int endNotation, int number)  // перевод из десятичной СС в любую
        {
            string res = "";
            int temp = 0;
            List<int> s = new List<int>();
            while (number > 0)
            {
                temp = number % endNotation;
                number = number / endNotation;
                s.Add(temp);
            }

            for (int j = s.Count - 1; j >= 0; j--)
                res = res + s[j].ToString();

            return res;
        }

        static int TakeNumber()
        {
            int n = 0;
            bool ok = true;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return n;
        }
    }
}
