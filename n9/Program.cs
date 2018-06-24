﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n9
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Point();
            var rnd = new Random();
            Console.WriteLine("В программе построен линейный список. Написаны рекурсивный и нерекурсивный методы записи в новый список элементов исходного списка, но в обратном порядке.");
            Console.WriteLine("Создаем массив с рандомным размером и заполняем его тоже рандомно");
            var size = rnd.Next(1, 100);
            point = point.MakeList(size);
            Console.WriteLine("Список: ");
            point.Output();
            var point2 = new Point();
            point2 = point2.MakeList2(size, point);
            Console.WriteLine("\nВторой список нерекурсивным методом: ");
            point2.Output();
            var point3 = new Point(point.data);
            if (size != 1) { Point.Inversion(point.next, ref point3); }
            Console.WriteLine("\nТретий список рекурсивным методом: ");
            point3.Output();
            Console.ReadLine();
        }

        private class Point
        {
            public readonly int data; //информационное поле 
            public Point next; //адресное поле 

            public Point() //конструктор без параметров 
            {
                data = 0;
                next = null;
            }

            public Point(int d) //конструктор с параметрами 
            {
                data = d;
                next = null;
            }

            public override string ToString()
            {
                return data + " ";
            }

            //создание элемента списка 
            public static Point MakePoint(int d)
            {
                var p = new Point(d);
                return p;
            }

            public Point MakeList(int size)
            {
                var rnd = new Random();
                var info = rnd.Next(1, 100);
                var beg = MakePoint(info); //создаем первый элемент 
                for (var i = 1; i < size; i++)
                {
                    info = rnd.Next(1, 100);
                    var p = MakePoint(info);
                    p.next = beg;
                    beg = p;
                }

                return beg;
            }

            public Point MakeList2(int size, Point point)
            {
                var beg = MakePoint(point.data); //создаем первый элемент 
                var beg2 = point.next;
                for (var i = 1; i < size; i++)
                {
                    var p = MakePoint(beg2.data);
                    p.next = beg;
                    beg = p;
                    beg2 = beg2.next;
                }

                return beg;
            }

            public static void Inversion(Point beg, ref Point begReturn)
            {
                Point tmp = begReturn;
                Point _new = new Point(beg.data)
                {
                    next = begReturn
                };
                begReturn = _new;
                if (beg.next == null)
                {
                    return;
                }
                else
                {
                    Inversion(beg.next, ref begReturn);
                }
            }

            public void Output()
            {
                Console.Write(data + " ");
                next?.Output();
            }
        }
    }
}
