using Coursework_ServerLibrary;
using System;
using System.Collections.Generic;


namespace CourseWork_Server.DataStructures.Matvey
{
    public partial class AVLTree<TKey, TValue> 
        where TKey : IComparable
        where TValue : IEquatable<TValue>
    {
        private class Node
        {
            public TKey Key;
            public List<TValue> Values;
            public Node Left;
            public Node Right;
            public int Height;
            public Node(TKey key, TValue value)
            {
                Values = new List<TValue>();
                Values.Add(value);

                Key = key;
                Left = Right = null;
                Height = 1;
            }
        }
    }

    public partial class AVLTree<TKey, TValue> : ITreeFinder<TKey, TValue>, IDisplayable
                                    where TKey : IComparable
                                    where TValue : IEquatable<TValue>
    {
        private Node _head;
        private string _name;
        private int _comparisons = 0;

        public AVLTree(string name)
        {
            _name = name;
        }

        public void Add(TKey key, TValue value)
        {
            if (_head == null)
            {
                _head = new Node(key, value);
                return;
            }

            Node current = null, parent = null;
            if(Find(key, out current, out parent))
            {
                current.Values.Add(value);
            }
            else
            {
                if (key.CompareTo(parent.Key) < 0)
                    parent.Left = new Node(key, value);
                else
                    parent.Right = new Node(key, value);
            }

            _head = Balance(_head);
        }

        public bool TryFind(TKey key, out IEnumerable<TValue> values)
        {
            _comparisons = 0;
            if(Find(key, out var found, out var parent))
            {
                Console.WriteLine($"ДАННЫЕ [{_name}]: поиск потребовал {_comparisons} сравнений");
                values = found.Values;
                return true;
            }
            values = null;
            return false;
        }

        public void Remove(TKey key, TValue value)
        {
            if (_head == null) return;

            if(Find(key, out var current, out var parent))
            {
                current.Values.Remove(value);
                if(current.Values.Count == 0)
                {
                    if (parent == current)
                    {
                        _head = _head.Left;
                    }
                    else
                    {
                        var right = current.Right;
                        var left = current.Left;
                        current.Left = null;
                        current.Right = null;
                        if (right == null)
                        {
                            if (parent.Left == current)
                                parent.Left = left;
                            else
                                parent.Right = left;
                            return;
                        }

                        var max = FindMax(left);
                        max.Left = RemoveMax(left);
                        max.Right = right;
                        if (parent.Left == current)
                            parent.Left = max;
                        else
                            parent.Right = max;
                        Balance(parent);
                    }
                }
            }
        }

        public void Display()
        {
            int tabs = 0;
            DisplayTree(_head, tabs);
        }

        private bool Find(TKey key, out Node found, out Node parent)
        {
            parent = _head;
            found = _head;
            while (found != null)
            {
                if (key.CompareTo(found.Key) < 0)
                {
                    parent = found;
                    found = found.Left;
                    _comparisons++;
                }
                else if (key.CompareTo(found.Key) > 0)
                {
                    parent = found;
                    found = found.Right;
                    _comparisons += 2;
                }
                else
                {
                    _comparisons += 2;
                    return true;
                }
            }
            return false;
        }

        private int HeightElem(Node elem)
        {
            if (elem != null)
                return elem.Height;
            else
                return 0;
        }

        private int BFactor (Node elem)
        {
            return HeightElem(elem.Right) - HeightElem(elem.Left);
        }

        private void FixedHeight(Node elem)
        {
            int left_h = HeightElem(elem.Left);
            int right_h = HeightElem(elem.Right);
            if (left_h > right_h)
                elem.Height = left_h + 1;
            else
                elem.Height = right_h + 1;
        }

        private Node RotateRight(Node elem)
        {
            Node p_elem = elem.Left;
            elem.Left = p_elem.Right;
            p_elem.Right = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }

        private Node RotateLeft(Node elem)
        {
            Node p_elem = elem.Right;
            elem.Right = p_elem.Left;
            p_elem.Left = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }

        private Node Balance(Node elem)
        {
            FixedHeight(elem);
            if (BFactor(elem) == 2)
            {
                if (BFactor(elem.Right) < 0)
                    elem.Right = RotateRight(elem.Right);
                return RotateLeft(elem);
            }
            if (BFactor(elem) == -2)
            {
                if (BFactor(elem.Left) > 0)
                    elem.Left = RotateLeft(elem.Left);
                return RotateRight(elem);
            }
            return elem;
        }

        private Node FindMax(Node elem)
        {
            if (elem.Right != null)
                return FindMax(elem.Right);
            else
                return elem;
        }

        private Node RemoveMax(Node elem)
        {
            if (elem.Right == null)
                return elem.Left;
            elem.Right = RemoveMax(elem.Right);
            return Balance(elem);
        }

        private void DisplayTree(Node root, int tabs)
        {
            if (root == null) return;

            DisplayTree(root.Right, tabs + 1);
            for (int i = 0; i < tabs; i++) Debug.Write("\t");
            Debug.WriteLine($"{root.Key}");
            DisplayTree(root.Left, tabs + 1);
        }
    }
}