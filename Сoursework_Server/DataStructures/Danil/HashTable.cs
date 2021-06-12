using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Server.DataStructures.Danil
{
    //НЕ РОБИТ СО ЗНАЧИМЫМИ ТИПАМИ, 
    //НУЖНО СДЕЛАТЬ КЛАСС-ОБЕРТКУ (ИЛИ ПОФИГ)
    public class HashTable<T> where T : IEquatable<T>
    {
        private const float UpperBound = 0.75f;
        private const float LowerBound = 0.25f;
        private const int MinSize = 100;

        public delegate int HashFunction(T key, int i, int size);
        public readonly HashFunction Function;

        private int _currentLoad;
        private T[] _data;
        private bool[] _deleted;

        public HashTable(HashFunction function, int size)
        {
            Function = function;
            if (size < MinSize) size = MinSize;
            _data = new T[size];
            _deleted = new bool[size];
            _currentLoad = 0;
        }

        public bool Add(T key)
        {
            for(int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index].Equals(default) || _deleted[index])
                {
                    _data[index] = key;
                    _deleted[index] = false;
                    _currentLoad++;

                    if (_currentLoad > _data.Length * UpperBound)
                        Resize();

                    return true;
                }
            }
            return false;
        }

        public bool TryFind(T key, out T value, out int hash)
        {
            hash = -1;
            value = default;
            for (int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index].Equals(default) == false)
                {
                    if (_data[index].Equals(key))
                    {
                        hash = index;
                        value = _data[index];
                        return true;
                    }
                }
                else if(_deleted[index] == false)
                {
                    return false;
                }
            }
            return false;
        }

        public bool Remove(T key)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                int index = Function(key, i, _data.Length);

                if (_data[index].Equals(default) == false)
                {
                    if (_data[index].Equals(key))
                    {
                        _data[index] = default;
                        _deleted[index] = true;
                        _currentLoad--;

                        if (_currentLoad < _data.Length * LowerBound)
                            Resize();

                        return true;
                    }
                }
                else if(_deleted[index] == false)
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
                    Console.WriteLine($"Hash code [{i}]: {_data[i]}");
                }
            }
        }

        private void Resize()
        {
            T[] prevData = new T[_data.Length];
            for (int i = 0; i < _data.Length; i++)
                prevData[i] = _data[i];

            if (_currentLoad > _data.Length * UpperBound)
            {
                _data = new T[prevData.Length * 2];
                _deleted = new bool[prevData.Length * 2];
                _currentLoad = 0;
                for (int i = 0; i < prevData.Length; i++)
                {
                    if(prevData[i] != null)
                        Add(prevData[i]);
                }
            }
            else
            {
                if (prevData.Length / 2 >= MinSize)
                {
                    _data = new T[prevData.Length / 2];
                    _deleted = new bool[prevData.Length / 2];
                }
                else
                {
                    _data = new T[MinSize];
                    _deleted = new bool[MinSize];
                }
                _currentLoad = 0;
                for (int i = 0; i < prevData.Length; i++)
                {
                    if (prevData[i] != null)
                        Add(prevData[i]);
                }
            }
        }
    }
}
