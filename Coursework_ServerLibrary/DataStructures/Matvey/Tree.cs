using System;


namespace CourseWork_Server.DataStructures.Matvey
{
    public class Tree<TKey, TValue> where TKey : IComparable
    {
        private int HeightElem(Node<TKey, TValue> elem)
        {
            if (elem != null)
                return elem.Height;
            else
                return 0;
        }
        private int BFactor (Node<TKey ,TValue> elem)
        {
            return HeightElem(elem.Right) - HeightElem(elem.Left);
        }
        private void FixedHeight(Node<TKey, TValue> elem)
        {
            int left_h = HeightElem(elem.Left);
            int right_h = HeightElem(elem.Right);
            if (left_h > right_h)
                elem.Height = left_h + 1;
            else
                elem.Height = right_h + 1;
        }
        private Node<TKey, TValue> RotateRight(Node<TKey, TValue> elem)
        {
            Node<TKey, TValue> p_elem = elem.Left;
            elem.Left = p_elem.Right;
            p_elem.Right = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }
        private Node<TKey, TValue> RotateLeft(Node<TKey, TValue> elem)
        {
            Node<TKey, TValue> p_elem = elem.Right;
            elem.Right = p_elem.Left;
            p_elem.Left = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }
        private Node<TKey, TValue> Balance(Node<TKey, TValue> elem)
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
        public Node<TKey, TValue> Insert(Node<TKey, TValue> elem, TKey key, TValue value)
        {
            if (elem == null)
                return new Node<TKey, TValue>(key, value);
            var help = new Node<TKey, TValue>(key, value);
            if (help < elem)
                elem.Left = Insert(elem.Left, key, value);
            else
                elem.Right = Insert(elem.Right, key, value);
            return Balance(elem);
        }
        public Node<TKey, TValue> Find(Node<TKey, TValue> elem, TKey key, TValue value)
        {
            if (elem == null) return elem;
            var help = new Node<TKey, TValue>(key, value);
            if (elem < help)
                return Find(elem.Right, key, value);
            else if (elem > help)
                return Find(elem.Left, key, value);
            return elem;
        }
        private Node<TKey, TValue> FindMax(Node<TKey, TValue> elem)
        {
            if (elem.Right != null)
                return FindMax(elem.Right);
            else
                return elem;
        }
        private Node<TKey, TValue> RemoveMax(Node<TKey, TValue> elem)
        {
            if (elem.Right == null)
                return elem.Left;
            elem.Right = RemoveMax(elem.Right);
            return Balance(elem);
        }
        public Node<TKey, TValue> Remove(Node<TKey, TValue> elem, TKey key, TValue value)
        {
            if (elem == null) return null;
            var help = new Node<TKey, TValue>(key, value);
            if (help < elem)
                elem.Left = Remove(elem.Left, key, value);
            else if (help > elem)
                elem.Right = Remove(elem.Right, key, value);
            else
            {
                Node<TKey, TValue> right = elem.Right;
                Node<TKey, TValue> left = elem.Left;
                elem.Right = null;
                elem.Left = null;
                if (right == null) return left;
                Node<TKey, TValue> max = FindMax(left);
                max.Left = RemoveMax(left);
                max.Right = right;
                return Balance(max);
            }
            return Balance(elem);
        }
    }
}