using System;

namespace CourseWork_Server.DataStructures.Matvey
{
    public class Node<TKey, TValue> where TKey : IComparable
    {
        public TKey Key;
        public TValue Value;
        public Node<TKey, TValue> Left;
        public Node<TKey, TValue> Right;
        public int Height;
        public Node(TKey key, TValue value)
        {
            Value = value;
            Key = key;
            Left = Right = null;
            Height = 1;
        }
        public static bool operator <(Node<TKey, TValue> nodeLeft, Node<TKey, TValue> nodeRight)
        {
            return nodeLeft.Key.CompareTo(nodeRight.Key) < 0;
        }
        public static bool operator >(Node<TKey, TValue> nodeLeft, Node<TKey, TValue> nodeRight)
        {
            return nodeLeft.Key.CompareTo(nodeRight.Key) > 0;
        }
    }
}
