namespace CourseWork_Server.DataStructures.Danil
{
    public interface IHashTableDoubleFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out TValue value, out int firstHashValue, out int secondHashValue);
    }
}

namespace CourseWork_Server.DataStructures.Matvey
{
    public interface IHashTableFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out TValue value, out int hashValue);
    }
}