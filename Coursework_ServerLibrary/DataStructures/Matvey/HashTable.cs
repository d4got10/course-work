using System;
using System.Text;

namespace CourseWork_Server.DataStructures.Matvey
{
    public class HashTable<TKey, TValue> : IHashTableFinder<TKey, TValue>, ISaveable
                                            where TKey : IEquatable<TKey>
                                            where TValue : ISaveable
    {
        public delegate int HashFunction(TKey key, int size);
        public readonly HashFunction Function;
        public int Size { get; private set; }

        private struct KeyValuePair : IEquatable<KeyValuePair>
        {
            public TKey Key;
            public TValue Value;

            public KeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public bool Equals(KeyValuePair other)
            {
                return Key.Equals(other.Key);
            }
        }

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
                    foreach(var p in _table[i])
                    {
                        values[j].Hash = i;
                        values[j].Value = p.Value;
                        j++;
                    }
                }
                return values;
            }
        }

        private List<KeyValuePair>[] _table;

        public HashTable(HashFunction function, int s)
        {
            Function = function;
            if (s < 1) throw new Exception("Хеш таблица пуста");
            _table = new List<KeyValuePair>[s];
            Size = s;
            for (int i = 0; i < Size; i++)
            {
                _table[i] = new List<KeyValuePair>();
            }
        }
        public void Add(TKey key, TValue value)
        {
            _table[Function(key, Size)].Add(new KeyValuePair(key, value));
        }
        public void Remove(TKey key, TValue value)
        {
            _table[Function(key, Size)].Remove(new KeyValuePair(key, value));
        }
        public bool TryFind(TKey key, out TValue value, out int hash)
        {
            int n = Function(key, Size);
            if (_table[n] != null)
            {
                foreach(var p in _table[n])
                {
                    if (p.Key.Equals(key)) {
                        value = p.Value;
                        hash = n;
                        return true;
                    }
                }
            }

            value = default;
            hash = -1;
            return false;
        }

        public string GetData()
        {
            var data = new StringBuilder();
            for(int i = 0; i < _table.Length; i++)
            {
                if (_table[i] != null)
                {
                    foreach (var pair in _table[i])
                    {
                        var row = $"{pair.Key}|{pair.Value.GetData()}\n";
                        data.Append(row);
                    }
                }
            }
            return data.ToString();
        }
    }
}