using System.Collections.Generic;

namespace CourseWork_Server.DataStructures
{
    public interface ITreeFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out IEnumerable<TValue> value);
    }

    public interface ITreeRangeFinder<TKey, TValue>
    {
        IEnumerable<TValue> GetValuesRange(TKey min, TKey max);
    }
}
