using System;

namespace CourseWork_Server.DataStructures.Matvey
{
    public class List<TKey, TValue> where TKey : IEquatable<TKey>
    {
        public class Node 
        {
            public Node Next;
            public TKey Data;
            public TValue Value;
            public Node Prev;

            public Node()
            {
                Next = this;
                Data = default;
                Value = default;
                Prev = this;
            }
            public Node(TKey key, TValue value)
            {
                Next = this;
                Data = key;
                Value = value;
                Prev = this;
            }
        }
        Node head;
        public List()
        {
            head = null;
        }
        public bool IsFindData(TKey d, out TValue value)
        {
            value = default;
            if (head != null)
            {
                Node current = head;
                if (current.Data.Equals(d))
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
                while (current != head)
                {
                    if (current.Data.Equals(d))
                    {
                        value = current.Value;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            return false;
        }
        public void AddNode(TKey key, TValue value)
        {
            if (head != null)
            {
                Node current = head;
                current = current.Next;
                while (current != head)
                    current = current.Next;
                var nodeToAdd = new Node(key, value);
                nodeToAdd.Next = current;
                nodeToAdd.Prev = current.Prev;
                current.Prev.Next = nodeToAdd;
                current.Prev = nodeToAdd;
            }
            else
            {
                Node nodeToAdd = new Node(key, value);
                head = nodeToAdd;
            }
        }
        public bool DeleteNode(TKey d)
        {
            if (head != null)
            {
                if (head.Data.Equals(d))
                {
                    if (head.Next == head)
                    {
                        head = null;
                        return true;
                    }
                    else
                    {
                        Node current = head.Next;
                        current.Prev = head.Prev;
                        head.Prev.Next = current;
                        head = current;
                        return true;
                    }
                }
                else
                {
                    var current = head.Next;
                    while (current != head)
                    {
                        if (current.Data.Equals(d))
                        {
                            Node temp = current.Next;
                            temp.Prev = current.Prev;
                            current.Prev.Next = temp;
                            return true;
                        }
                        current = current.Next;
                    }
                }

            }
            return false;
        }
        public void ShowInfo()
        {
            if (head != null)
            {
                Node current = head;
                do
                {
                    Console.Write(current.Data + " ");
                    current = current.Next;
                } while (current != head);
            }
            else Console.WriteLine("_NULL_");
        }
    }
    public class HashTable<TKey, TValue> : IHashTableFinder<TKey, TValue>
                                            where TKey : IEquatable<TKey>
    {
        public delegate int HashFunction(TKey key, int size);
        public readonly HashFunction Function;

        public int size;
        public List<TKey ,TValue>[] table;
        public HashTable(HashFunction function, int s)
        {
            Function = function;
            if (s < 1) throw new Exception("Хеш таблица пуста");
            table = new List<TKey, TValue>[s];
            size = s;
            for (int i = 0; i < size; i++)
            {
                table[i] = new List<TKey, TValue>();
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
        public void AddElem(TKey key, TValue value)
        {
            table[Function(key, size)].AddNode(key, value);
        }
        public void Remove(TKey key, TValue d)
        {
            if (table[Function(key, size)].DeleteNode(key))
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
        public bool TryFind(TKey key, out TValue value, out int hash)
        {
            int n = Function(key, size);
            if (table[n].IsFindData(key, out value))
            {
                hash = n;
                return true;
            }
            else
            {
                hash = -1;
                return false;
            }
        }
    }
}