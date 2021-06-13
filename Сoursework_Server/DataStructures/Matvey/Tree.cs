using System;

namespace AVL_Tree
{
    public class Tree<TKey> where TKey : IComparable
    {
        private int HeightElem(Node<TKey> elem)
        {
            if (elem != null)
                return elem.Height;
            else
                return 0;
        }
        private int BFactor (Node<TKey> elem)
        {
            return HeightElem(elem.Right) - HeightElem(elem.Left);
        }
        private void FixedHeight(Node<TKey> elem)
        {
            int left_h = HeightElem(elem.Left);
            int right_h = HeightElem(elem.Right);
            if (left_h > right_h)
                elem.Height = left_h + 1;
            else
                elem.Height = right_h + 1;
        }
        private Node<TKey> RotateRight(Node<TKey> elem)
        {
            Node<TKey> p_elem = elem.Left;
            elem.Left = p_elem.Right;
            p_elem.Right = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }
        private Node<TKey> RotateLeft(Node<TKey> elem)
        {
            Node<TKey> p_elem = elem.Right;
            elem.Right = p_elem.Left;
            p_elem.Left = elem;
            FixedHeight(elem);
            FixedHeight(p_elem);
            return p_elem;
        }
        private Node<TKey> Balance(Node<TKey> elem)
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
        public Node<TKey> Insert(Node<TKey> elem, TKey key)
        {
            if (elem == null)
                return new Node<TKey>(key);
            var help = new Node<TKey>(key);
            if (help < elem)
                elem.Left = Insert(elem.Left, key);
            else
                elem.Right = Insert(elem.Right, key);
            return Balance(elem);
        }
        public Node<TKey> Find(Node<TKey> elem, TKey key)
        {
            if (elem == null) return elem;
            var help = new Node<TKey>(key);
            if (elem < help)
                return Find(elem.Right, key);
            else if (elem > help)
                return Find(elem.Left, key);
            return elem;
        }
        private Node<TKey> FindMax(Node<TKey> elem)
        {
            if (elem.Right != null)
                return FindMax(elem.Right);
            else
                return elem;
        }
        private Node<TKey> RemoveMax(Node<TKey> elem)
        {
            if (elem.Right == null)
                return elem.Left;
            elem.Right = RemoveMax(elem.Right);
            return Balance(elem);
        }
        public Node<TKey> Remove(Node<TKey> elem, TKey key)
        {
            if (elem == null) return null;
            var help = new Node<TKey>(key);
            if (help < elem)
                elem.Left = Remove(elem.Left, key);
            else if (help > elem)
                elem.Right = Remove(elem.Right, key);
            else
            {
                Node<TKey> right = elem.Right;
                Node<TKey> left = elem.Left;
                elem.Right = null;
                elem.Left = null;
                if (right == null) return left;
                Node<TKey> max = FindMax(left);
                max.Left = RemoveMax(left);
                max.Right = right;
                return Balance(max);
            }
            return Balance(elem);
        }
        private void Print(Node<TKey> elem, int tabs)
        {
            if (elem == null) return;
            tabs += 5;
            Print(elem.Right, tabs);

            for (int i = 0; i < tabs; i++) Console.Write(' ');
            Console.WriteLine(elem.Key);

            Print(elem.Left, tabs);
            tabs -= 5;
            return;
        }
        public void Print(Node<TKey> elem)
        {
            int tabs = 0;
            Print(elem, tabs);
        }
    }
}
