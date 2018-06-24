﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 56, 3, 0, -4, 85, 7, 10, 1, 1, 5, 14, 16, -30 };
            double[] arr2 = new double[] { 56, 3, 0, -4, 85, 7, 10, 1, 1, 5, 14, 16, -30 };
            Console.WriteLine("Сортировка слиянием:");
            MSort(arr);
            Console.WriteLine("Пирамидальная сортировка:");
            PSort(arr2);
            Console.ReadKey();
        }

        public static int countChange = 0;
        public static int countCompare = 0;

        static void MSort(int[] arr)
        {
            // сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: \n" + String.Join(", ", arr));
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortArr = MergeSort(arr);
            Console.WriteLine("\nОтсортированный неупорядоченный массив: \n" + String.Join(", ", sortArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            // сортировка упорядоченного по возрастанию массива
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortSortedUpArr = MergeSort(sortArr);
            Console.WriteLine("\nОтсортированный упорядоченный по возрастанию массив: \n" + String.Join(", ", sortSortedUpArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            Array.Reverse(sortArr);
            countChange = 0;                                    // обнуление счетчиков операций
            countCompare = 0;                                   // и времени
            int[] sortSortedDownArr = MergeSort(sortArr);
            Console.WriteLine("\nОтсортированный упорядоченный во убыванию массив: \n" + String.Join(", ", sortSortedDownArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
              countCompare, countChange);
        }

        static int[] MergeSort(int[] arr)
        {
            countCompare++;
            if (arr.Length == 1)
                return arr;
            int midPos = arr.Length / 2;
            return Merge(MergeSort(arr.Take(midPos).ToArray()), MergeSort(arr.Skip(midPos).ToArray()));
        }

        static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;                                   // позиции в массивах
            int[] merged = new int[arr1.Length + arr2.Length];  // новый массив, полученный в результате слияния arr1 и arr2
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                {
                    countCompare++;
                    countChange++;
                    if (arr1[a] > arr2[b])
                        merged[i] = arr2[b++];
                    else
                        merged[i] = arr1[a++];
                }
                else
                {
                    countCompare++;
                    countChange++;
                    if (b < arr2.Length)
                        merged[i] = arr2[b++];
                    else
                        merged[i] = arr1[a++];
                }
            }
            return merged;
        }

        static void PSort(double[] arr)
        {
            // сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: " + String.Join(", ", arr));
            countChange = 0;                               
            countCompare = 0;                                   
            double[] sortArr =PiromidSort(arr, arr.Length);
            Console.WriteLine("\nОтсортированный неупорядоченный массив: \n" + String.Join(", ", sortArr));
            Console.WriteLine("Затрачено {0} сравнений, {1} перессылок",
               countCompare, countChange);

            // сортировка упорядоченного по возрастанию массива
            countChange = 0;                              
            countCompare = 0;                            
            double[] sortSortedUpArr = PiromidSort(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по возрастанию: \n" + String.Join(", ", sortSortedUpArr));
            Console.WriteLine("{0} сравнений, {1} перессылок", countCompare, countChange);

            Array.Reverse(sortArr);
            countChange = 0;                              
            countCompare = 0;                                  
            double[] sortSortedDownArr = PiromidSort2(sortArr, arr.Length);
            Console.WriteLine("\nОтсортированный по убыванию массив: \n" + String.Join(", ", sortSortedDownArr));
            Console.WriteLine("{0} сравнений, {1} перессылок", countCompare, countChange);
        }


        static int add2pyramid(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countCompare += 2;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                countChange++;
                if (imax < N / 2) i = imax;
                countCompare += 2;
            }
            return i;
        }
        public static double[] PiromidSort(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
                countCompare ++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
            return arr;
        }

        static int add2pyramid2(double[] arr, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] > arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countCompare += 2;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] > arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
                countCompare += 2;
                countChange++;
            }
            return i;
        }
        public static double[] PiromidSort2(double[] arr, int len)
        {
            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid2(arr, i, len);
                if (prev_i != i) ++i;
                countCompare ++;
            }

            //шаг 2: сортировка
            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid2(arr, i, k);
                }
            }
            return arr;
        }


    }
}
