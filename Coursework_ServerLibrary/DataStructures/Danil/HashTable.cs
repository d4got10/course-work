using Coursework_ServerLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Server.DataStructures.Danil
{
    public class HashTable<TKey, TValue> : IHashTableDoubleFinder<TKey, TValue>, ISaveable, IDisplayable
                                            where TKey : IEquatable<TKey>
                                            where TValue : ISaveable
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

        public delegate int HashFunction(TKey key, int i, int size);
        public readonly HashFunction Function;

        public Action Changed;
        public Action Rehashed;
        public Action<TValue> Added;
        public Action<TValue> Removed;

        public struct ValueWithHash
        {
            public int FirstHash;
            public int SecondHash;
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
                        values[j].FirstHash = Function(_data[i].Key, 0, _data.Length);
                        values[j].SecondHash = i;
                        values[j].Value = _data[i].Value;
                        j++;
                    }
                }
                return values;
            }
        }

        private readonly int _minSize;
        private int _currentLoad;
        private Node<TKey, TValue>[] _data;
        private bool _isInternal;

        public HashTable(HashFunction function, int size)
        {
            Function = function;
            _minSize = size;
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

        public bool TryFind(TKey key, out TValue value, out int firstHash, out int secondHash)
        {
            firstHash = -1;
            secondHash = -1;
            value = default;
            for (int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);
                if (i == 0) firstHash = index;

                if (_data[index] != null)
                {
                    if (_data[index].Deleted == false && _data[index].Key.Equals(key))
                    {
                        secondHash = index;
                        value = _data[index].Value;
                        Debug.WriteLine($"[ДАННЫЕ] Поиск по хеш-таблице потребовал {i + 1} сравнений");
                        return true;
                    }
                }
                else
                {
                    Debug.WriteLine($"[ДАННЫЕ] Поиск по хеш-таблице потребовал {i + 1} сравнений");
                    return false;
                }
            }
            Debug.WriteLine($"[ДАННЫЕ] Поиск по хеш-таблице потребовал {_data.Length} сравнений");
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

                        if (_data.Length > _minSize && _currentLoad < _data.Length * LowerBound)
                            Resize();
                        else if(_isInternal == false)
                                Changed?.Invoke();

                        if (_isInternal == false) 
                            Removed?.Invoke(value);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public string GetData()
        {
            var data = new StringBuilder();
            for(int i = 0; i < _data.Length; i++)
            {
                if(_data[i] != null && _data[i].Deleted == false)
                {
                    string row = $"{_data[i].Value.GetData()}\n";
                    data.Append(row);
                }
            }
            return data.ToString();
        }

        public void Display()
        {
            Debug.WriteLine($"Hashtable [Size:{_data.Length}] [Load:{_currentLoad}/{_data.Length}]:");
            for(int i = 0; i < _data.Length; i++)
            {
                if(_data[i] != null)
                {
                    if (_data[i].Deleted == false)
                    {
                        Debug.WriteLine($"Hash code [{i}]: {{Key:{_data[i].Key}; Value:{_data[i].Value}}}");
                    }
                    else
                    {
                        Debug.WriteLine($"Hash code [{i}]: DELETED");
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
                if (prevData.Length / 2 >= _minSize)
                    _data = new Node<TKey, TValue>[prevData.Length / 2];
                else
                    _data = new Node<TKey, TValue>[_minSize];
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
