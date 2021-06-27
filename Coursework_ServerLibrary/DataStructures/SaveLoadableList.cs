using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CourseWork_Server.DataStructures
{
    public class SaveLoadableList<T> : ISaveable, IReadOnlyList<T>
                                        where T : ISaveable
    {
        public readonly List<T> Data;

        public SaveLoadableList()
        {
            Data = new List<T>();
        }

        public T this[int index] => Data[index];

        public int Count => Data.Count;

        public string GetData()
        {
            var data = new StringBuilder();
            for(int i = 0; i < Data.Count; i++)
            {
                var row = $"{Data[i].GetData()}\n";
                data.Append(row);
            }
            return data.ToString();
        }

        public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
