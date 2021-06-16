namespace CourseWork_Server.DataStructures.Danil
{
    public interface IHashTableFinder<TKey, TValue>
    {
        bool TryFind(TKey key, out TValue value, out int hashValue);
    }
}
