using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWork_Server.DataStructures.Matvey
{
    public class List<T> : IEnumerable<T>
        where T : IEquatable<T>
    {
        private class Node 
        {
            public Node Next;
            public T Data;
            public Node Prev;

            public Node()
            {
                Next = this;
                Data = default;
                Prev = this;
            }
            public Node(T key)
            {
                Next = this;
                Data = key;
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
        public bool TryFind(T key, out T value)
        {
            value = default;
            if (head != null)
            {
                Node current = head;
                if (current.Data.Equals(key))
                {
                    value = current.Data;
                    return true;
                }
                current = current.Next;
                while (current != head)
                {
                    if (current.Data.Equals(key))
                    {
                        value = current.Data;
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }
            return false;
        }
        public void Add(T value)
        {
            if (head != null)
            {
                Node current = head;
                current = current.Next;
                while (current != head)
                    current = current.Next;
                var nodeToAdd = new Node(value);
                nodeToAdd.Next = current;
                nodeToAdd.Prev = current.Prev;
                current.Prev.Next = nodeToAdd;
                current.Prev = nodeToAdd;
            }
            else
            {
                Node nodeToAdd = new Node(value);
                head = nodeToAdd;
            }
        }
        public bool Remove(T value)
        {
            if (head != null)
            {
                if (head.Data.Equals(value))
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
                        if (current.Data.Equals(value))
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

        public T[] ToArray()
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

            var arr = new T[count];
            var node = head;
            for (int i = 0; i < count; i++)
            {
                arr[i] = node.Data;
                node = node.Next;
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
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
}