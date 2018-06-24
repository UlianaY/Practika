/*using System;
using System.IO;

public class Summa
{
    private static void Main()
    {
        StreamReader sr = new StreamReader("INPUT.TXT");
        StreamWriter sw = new StreamWriter("OUTPUT.TXT");

        int n;

        int.TryParse(sr.ReadLine(), out n);
        Func(n, "", 0,ref sw);

        sr.Close();
        sw.Close();
    }

    static void Func(int N, string str, int pred, ref StreamWriter sw)
    {
        if (N == 0 && str.Contains("+"))
            sw.WriteLine(str);
        else
        {
            for (int i = 1; i <= N; i++)
            {
                if (pred <= i)
                {
                    if (str == "")
                    {
                        Func(N - i, String.Concat(i), i, ref sw);
                    }
                    else
                    {
                        Func(N - i, String.Concat(str, "+", i), i, ref sw);
                    }
                }
            }
        }
    }

}*/
