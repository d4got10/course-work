namespace CourseWork_Server.DataStructures
{
    public interface IHashTableFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out TValue value, out int hashValue);
    }
}
