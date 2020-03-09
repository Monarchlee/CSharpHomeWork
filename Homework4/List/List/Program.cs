using System;

namespace ListNameSpace
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> action)
        {
            Node<T> now = head;
            while (now != null)
            {
                action(now.Data);
                now = now.Next;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
                    // 整型List
                        GenericList<int> intlist = new GenericList<int>();
                        for (int x = 0; x < 10; x++)
                        {
                            intlist.Add(x);
                        }

                        // 字符串型List
                        GenericList<string> strList = new GenericList<string>();
                        for (int x = 0; x < 10; x++)
                        {
                            strList.Add("str" + x);
                        }

                        int sum = 0, min = int.MaxValue, max = int.MinValue;
                        intlist.ForEach(x =>
                        {
                            sum += x;
                            min = (x < min) ? x : min;
                            max = (x > max) ? x : max;
                            Console.Write(x + " ");
                        });
                        Console.WriteLine('\n'+"Max of it is " + max);
                        Console.WriteLine("Min of it is " + min);
                        Console.WriteLine("Sum of it is " + sum);
                        strList.ForEach(x => Console.Write(x + " "));
           


        }

    }
}
