using System;

namespace AVL_Tree
{
    public class Node<TKey> where TKey : IComparable
    {
        public TKey Key;
        public Node<TKey> Left;
        public Node<TKey> Right;
        public int Height;
        public Node(TKey key)
        {
            Key = key;
            Left = Right = null;
            Height = 1;
        }
        public static bool operator <(Node<TKey> nodeLeft, Node<TKey> nodeRight)
        {
            return nodeLeft.Key.CompareTo(nodeRight.Key) < 0;
        }
        public static bool operator >(Node<TKey> nodeLeft, Node<TKey> nodeRight)
        {
            return nodeLeft.Key.CompareTo(nodeRight.Key) > 0;
        }
    }
}
