using Coursework_ServerLibrary;
using System;
using System.Collections.Generic;


namespace CourseWork_Server.DataStructures.Matvey
{
    public class AVLTree<TKey, TValue> : ITreeFinder<TKey, TValue>, IDisplayable
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

        private Node _head;
        private string _name;
        private int _comparisons = 0;

        public AVLTree(string name)
        {
            _name = name;
        }

        public void Add(TKey key, TValue value)
        {
            _head = Insert(_head, key, value);
        }

        private Node Insert(Node root, TKey key, TValue value)
        {
            if (root == null) return new Node(key, value);

            if (key.CompareTo(root.Key) < 0)
                root.Left = Insert(root.Left, key, value);
            else if (key.CompareTo(root.Key) > 0)
                root.Right = Insert(root.Right, key, value);
            else
                root.Values.Add(value);
            return Balance(root);
        }

        public bool TryFind(TKey key, out IEnumerable<TValue> values)
        {
            _comparisons = 0;
            if(Find(key, out var found, out var parent))
            {
                Debug.WriteLine($"ДАННЫЕ [{_name}]: поиск потребовал {_comparisons} сравнений");
                values = found.Values;
                return true;
            }
            values = null;
            return false;
        }

        public void Remove(TKey key, TValue value)
        {
            _head = Remove(_head, key, value);
        }

        private Node Remove(Node root, TKey key, TValue value)
        {
            if (root == null) return null;
            if (key.CompareTo(root.Key) < 0)
                root.Left = Remove(root.Left, key, value);
            else if (key.CompareTo(root.Key) > 0)
                root.Right = Remove(root.Right, key, value);
            else
            {
                root.Values.Remove(value);
                if(root.Values.Count == 0)
                {
                    Node right = root.Right;
                    Node left = root.Left;
                    if (left == null) return right;
                    Node max = FindMax(left);
                    max.Left = RemoveMax(left);
                    max.Right = right;
                    return Balance(max);
                }
            }

            return Balance(root);
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