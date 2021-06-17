namespace Coursework_Server.DataStructures.Matvey
{
    public static class StringHashTableExtras
    {
        public static int HashFunction(string key, int size)
        {
            int value = 0;
            for (int i = 0; i < key.Length; i++)
                value += key[i];
            return value % size;
        }
    }
}
