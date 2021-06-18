using System.Collections.Generic;

namespace CourseWork_Server.DataStructures
{
    public interface ITreeFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out IEnumerable<TValue> value);
        IEnumerable<TValue> GetValuesRange(TKey min, TKey max);
    }
}
