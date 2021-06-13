using System;

namespace _4._FSD__5_HT
{
    public class List<T> where T : IEquatable<T>
    {
        public class Node<U> where U : IEquatable<U>
        {
            public Node<U> next;
            public U data;
            public Node<U> prev;

            public Node()
            {
                next = this;
                data = default;
                prev = this;
            }
            public Node(U d)
            {
                next = this;
                data = d;
                prev = this;
            }
        }
        Node<T> head;
        public List()
        {
            head = null;
        }
        public bool IsFindData(T d)
        {
            if (head != null)
            {
                Node<T> current = head;
                if (current.data.Equals(d))
                    return true;
                current = current.next;
                while (current != head)
                {
                    if (current.data.Equals(d))
                        return true;
                    current = current.next;
                }
                return false;
            }
            else return false;
        }
        public void AddNode(T d)
        {
            if (head != null)
            {
                if (!IsFindData(d))
                {
                    Node<T> current = head;
                    current = current.next;
                    while (current != head)
                        current = current.next;
                    var nodeToAdd = new Node<T>(d);
                    nodeToAdd.next = current;
                    nodeToAdd.prev = current.prev;
                    current.prev.next = nodeToAdd;
                    current.prev = nodeToAdd;
                }
            }
            else
            {
                Node<T> nodeToAdd = new Node<T>(d);
                head = nodeToAdd;
            }
        }
        public bool DeleteNode(T d)
        {
            if (head != null)
            {
                if (head.data.Equals(d))
                {
                    if (head.next == head)
                    {
                        head = null;
                        return true;
                    }
                    else
                    {
                        Node<T> current = head.next;
                        current.prev = head.prev;
                        head.prev.next = current;
                        head = current;
                        return true;
                    }
                }
                else
                {
                    var current = head.next;
                    while (current != head)
                    {
                        if (current.data.Equals(d))
                        {
                            Node<T> temp = current.next;
                            temp.prev = current.prev;
                            current.prev.next = temp;
                            return true;
                        }
                        current = current.next;
                    }
                }

            }
            return false;
        }
        public void ShowInfo()
        {
            if (head != null)
            {
                Node<T> current = head;
                do
                {
                    Console.Write(current.data + " ");
                    current = current.next;
                } while (current != head);
            }
            else Console.WriteLine("_NULL_");
        }
    }
    public class HashTable<T> where T : IEquatable<T>
    {
        public delegate int HashFunction(T key, int size);
        public readonly HashFunction Function;

        public int size;
        public List<T>[] table;
        public HashTable(HashFunction function, int s)
        {
            Function = function;
            if (s < 1) throw new Exception("Хеш таблица пуста");
            table = new List<T>[s];
            size = s;
            for (int i = 0; i < size; i++)
            {
                table[i] = new List<T>();
            }
        }
        public void ShowHT()
        {
            for (int i = 0; i < size; i++)
            { 
                table[i].ShowInfo();
                Console.WriteLine('\n');
            }
        }
        public void AddElem(T d)
        {
            table[Function(d, size)].AddNode(d);
        }
        public void DeletElem(T d)
        {
            if (table[Function(d, size)].DeleteNode(d))
            {
                Console.WriteLine("Элемент удалён\n");
                ShowHT();
                Console.WriteLine('\n');
            }
            else
            {
                Console.WriteLine("Элемент не удалён, т. к. не найден\n");
                ShowHT();
                Console.WriteLine('\n');
            }
        }
        public void Search(T d)
        {
            int n = Function(d, size);
            if (table[n].IsFindData(d))
            {
                Console.WriteLine("Элемент " + d + " найден в строке " + Function(d, size) + '\n');
            }
            else
            {
                Console.WriteLine("Элемент " + d + " НЕ НАЙДЕН\n");
            }
        }
    }
}