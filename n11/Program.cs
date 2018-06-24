using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace n11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("")
            Console.WriteLine("Введите зашифрованный код:");
            string InputSt = TakeString();
            string OutputSt = "";
            for (int i = 0; i < InputSt.Length; i += 3)
            {
                int a1, a2, a3;
                if (InputSt[i] == '1') a1 = 1; else a1 = 0;
                if (InputSt[i + 1] == '1') a2 = 1; else a2 = 0;
                if (InputSt[i + 2] == '1') a3 = 1; else a3 = 0;
                if (a1 * a2 + a1 * a3 == 0) OutputSt += '0'; else OutputSt += '1';
            }
            Console.WriteLine("Расшифрованый код: " + OutputSt);
            Console.ReadKey();
        }
        
        static string TakeString()
        {
            Regex regex = new Regex(@"(?<!\S)\b[0,1]+\b(?!\S)");
            string st;
            bool ok = true;
            do
            {
                st = Console.ReadLine();
                if (!regex.IsMatch(st) || st.Length % 3 != 0) Console.WriteLine("Не вверный ввод данных. Введите еще раз: ");
            } while (!ok);
            return st;
        }
    }
}
