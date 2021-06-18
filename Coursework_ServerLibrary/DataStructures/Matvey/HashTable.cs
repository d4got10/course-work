using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWork_Server.DataStructures.Matvey
{
    public class List<TKey, TValue> : IEnumerable<TValue>
        where TKey : IEquatable<TKey>
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
        private Node head;
        public int Count
        {
            get
            {
                int count = 0;
                if(head != null)
                {
                    count++;
                    for (var node = head.Next; node != head; node = node.Next)
                        count++;
                }
                return count;
            }
        }
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

        public TValue[] ToArray()
        {
            int count = 0;
            if (head != null)
            {
                count++;
                for (var i = head.Next; i != head; i = i.Next)
                {
                    count++;
                }
            }

            var arr = new TValue[count];
            var node = head;
            for (int i = 0; i < count; i++)
            {
                arr[i] = node.Value;
                node = node.Next;
            }
            return arr;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            if (head != null)
            {
                var arr = ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    yield return arr[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (head != null)
            {
                var arr = ToArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    yield return arr[i];
                }
            }
        }
    }
    public class HashTable<TKey, TValue> : IHashTableFinder<TKey, TValue>
                                            where TKey : IEquatable<TKey>
    {
        public delegate int HashFunction(TKey key, int size);
        public readonly HashFunction Function;
        public int Size { get; private set; }

        public struct ValueWithHash
        {
            public int Hash;
            public TValue Value;
        }

        public ValueWithHash[] Values
        {
            get
            {
                var count = 0;
                for(int i = 0; i < Size; i++)
                {
                    if(_table[i] != null)
                    {
                        count += _table[i].Count;
                    }
                }

                var values = new ValueWithHash[count];
                int j = 0;
                for(int i = 0; i < Size; i++)
                {
                    foreach(var value in _table[i])
                    {
                        values[j].Hash = i;
                        values[j].Value = value;
                        j++;
                    }
                }
                return values;
            }
        }

        private List<TKey, TValue>[] _table;

        public HashTable(HashFunction function, int s)
        {
            Function = function;
            if (s < 1) throw new Exception("Хеш таблица пуста");
            _table = new List<TKey, TValue>[s];
            Size = s;
            for (int i = 0; i < Size; i++)
            {
                _table[i] = new List<TKey, TValue>();
            }
        }
        public void ShowHT()
        {
            for (int i = 0; i < Size; i++)
            { 
                _table[i].ShowInfo();
                Console.WriteLine('\n');
            }
        }
        public void Add(TKey key, TValue value)
        {
            _table[Function(key, Size)].AddNode(key, value);
        }
        public void Remove(TKey key, TValue d)
        {
            _table[Function(key, Size)].DeleteNode(key);
        }
        public bool TryFind(TKey key, out TValue value, out int hash)
        {
            int n = Function(key, Size);
            if (_table[n].IsFindData(key, out value))
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