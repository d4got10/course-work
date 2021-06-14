using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Server.DataStructures.Danil
{
    public class HashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private class Node<UKey, UValue> where UKey : TKey where UValue : TValue
        {
            public UKey Key;
            public UValue Value;
            public bool Deleted;

            public Node(UKey key, UValue value)
            {
                Key = key;
                Value = value;
                Deleted = false;
            }
        }

        private const float UpperBound = 0.75f;
        private const float LowerBound = 0.25f;
        private const int MinSize = 100;

        public delegate int HashFunction(TKey key, int i, int size);
        public readonly HashFunction Function;

        public Action Changed;
        public Action Rehashed;
        public Action<TValue> Added;
        public Action<TValue> Removed;

        public struct ValueWithHash
        {
            public int Hash;
            public TValue Value;
        }

        public ValueWithHash[] Values
        {
            get
            {
                var values = new ValueWithHash[_currentLoad];
                int j = 0;
                for(int i = 0; i < _data.Length; i++)
                {
                    if(_data[i] != null && _data[i].Value != null && _data[i].Deleted == false)
                    {
                        values[j].Hash = i;
                        values[j].Value = _data[i].Value;
                        j++;
                    }
                }
                return values;
            }
        }

        private int _currentLoad;
        private Node<TKey, TValue>[] _data;
        private bool _isInternal;

        public HashTable(HashFunction function, int size)
        {
            Function = function;
            if (size < MinSize) size = MinSize;
            _data = new Node<TKey, TValue>[size];
            _currentLoad = 0;
        }

        public bool Add(TKey key, TValue value)
        {
            for(int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index] == null || _data[index].Deleted)
                {
                    _data[index] = new Node<TKey, TValue>(key, value);

                    _currentLoad++;
                    if (_currentLoad > _data.Length * UpperBound)
                        Resize();
                    else if(_isInternal == false)
                        Changed?.Invoke();

                    if (_isInternal == false)
                        Added?.Invoke(value);

                    return true;
                }
            }
            return false;
        }

        public bool TryFind(TKey key, out TValue value, out int hash)
        {
            hash = -1;
            value = default;
            for (int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index] != null)
                {
                    if (_data[index].Deleted == false && _data[index].Key.Equals(key))
                    {
                        hash = index;
                        value = _data[index].Value;
                        return true;
                    }
                    else if(_data[index].Deleted == false)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index] != null)
                {
                    if (_data[index].Deleted == false && _data[index].Key.Equals(key))
                    {
                        var value = _data[index].Value;

                        _data[index].Deleted = true;
                        _data[index].Key = default;
                        _data[index].Value = default;
                        _currentLoad--;

                        if (_currentLoad < _data.Length * LowerBound)
                            Resize();
                        else if(_isInternal == false)
                                Changed?.Invoke();

                        if (_isInternal == false) 
                            Removed?.Invoke(value);
                        return true;
                    }
                    else if(_data[index].Deleted == false)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void Display()
        {
            Console.WriteLine($"Hashtable [Size:{_data.Length}] [Load:{_currentLoad}/{_data.Length}]:");
            for(int i = 0; i < _data.Length; i++)
            {
                if(_data[i] != null)
                {
                    if (_data[i].Deleted == false)
                    {
                        Console.WriteLine($"Hash code [{i}]: {{Key:{_data[i].Key}; Value:{_data[i].Value}}}");
                    }
                    else
                    {
                        Console.WriteLine($"Hash code [{i}]: DELETED");
                    }
                }
            }
        }

        private void Resize()
        {
            _isInternal = true;
            Node<TKey, TValue>[] prevData = new Node<TKey, TValue>[_data.Length];
            _data.CopyTo(prevData, 0);

            if (_currentLoad > _data.Length * UpperBound)
            {
                _data = new Node<TKey, TValue>[prevData.Length * 2];
            }
            else
            {
                if (prevData.Length / 2 >= MinSize)
                    _data = new Node<TKey, TValue>[prevData.Length / 2];
                else
                    _data = new Node<TKey, TValue>[MinSize];
            }

            _currentLoad = 0;
            for (int i = 0; i < prevData.Length; i++)
            {
                if (prevData[i] != null && prevData[i].Deleted == false)
                    Add(prevData[i].Key, prevData[i].Value);
            }

            _isInternal = false;
            Changed?.Invoke();
            Rehashed?.Invoke();
        }
    }
}
