using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n10
{
    class Program
    {
        public static int ReadNatural()
        //ввод числа для красивых лаб
        {
            bool check = false;
            int intNum = 0;
            do
            {
                // Попытка перевести строку в число
                check = Int32.TryParse(Console.ReadLine(), out intNum);
                // Если попытка неудачная:
                if (!(check) || (intNum < 0))
                    Console.WriteLine("Некорректный ввод. Попробуйте ещё раз");
            } while (!(check) || (intNum < 0));
            // Если попытка удачная:
            return intNum;
        }
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            DoublyLinkedList<int> circleList = new DoublyLinkedList<int>();
            Console.WriteLine("Задание №10. \nДаны натуральное число n, действительные числа x_1 ... x_n. Вычислить: (x_1+ x_n)*( x_2+ x_(n-1)) *...*(x_n+ x_1)");
            Console.WriteLine("Введите количество элементов которые необходимо добавить в список");
            int n = ReadNatural();
            for (int i = 0; i < n; i++)
            {
                circleList.Add(rnd.Next(-100, 101));
            }
            int sum = 1;
            Console.WriteLine("Текущий список:");
            DoublyNode<int> point = circleList.GetHead();
            DoublyNode<int> tail = circleList.GetTail();
            for (int i = 0; i < circleList.Count; i++)
            {
                Console.Write(point.Data + " ");
                sum = sum * (point.Data + tail.Data);
                point = point.Next;
                tail = tail.Previous;
            }
            Console.WriteLine("\nИтоговый результат = {0}", sum);
            Console.ReadKey();
        }
        

        public class DoublyNode<T>// описание элемента
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }
        public class DoublyLinkedList<T>   // двусвязный список
        {
            DoublyNode<T> head; // головной/первый элемент
            DoublyNode<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);

                if (head == null)
                    head = node;
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                count++;
            }
            public void AddFirst(T data)
            {
                DoublyNode<T> node = new DoublyNode<T>(data);
                DoublyNode<T> temp = head;
                node.Next = temp;
                head = node;
                if (count == 0)
                    tail = head;
                else
                    temp.Previous = node;
                count++;
            }
            // удаление
            public bool Remove(T data)
            {
                DoublyNode<T> current = head;

                // поиск удаляемого узла
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        break;
                    }
                    current = current.Next;
                }
                if (current != null)
                {
                    // если узел не последний
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        // если последний, переустанавливаем tail
                        tail = current.Previous;
                    }

                    // если узел не первый
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        // если первый, переустанавливаем head
                        head = current.Next;
                    }
                    count--;
                    return true;
                }
                return false;
            }

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }

            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }

            public bool Contains(T data)
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public DoublyNode<T> GetHead()
            {
                return head;
            }
            public DoublyNode<T> GetTail()
            {
                return tail;
            }

        }

    }
}
