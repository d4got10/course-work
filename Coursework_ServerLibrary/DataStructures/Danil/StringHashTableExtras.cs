using Shared;

namespace CourseWork_Server.DataStructures.Danil
{
    public static class StringHashTableExtras
    {
        public static int HashFunction(string key, int j, int size)
        {
            return ((Hash1(key, size) + (367 * j * j + 823 * j + 1861) * Hash2(key, size)) % size + size) % size;
        }

        public static int Hash1(string key, int size)
        {
            int value = 0;
            for (int i = 0; i < key.Length; i++)
                value += key[i];
            value *= value;
            int count = Extras.GetDigitCount(value);
            int sizeCount = Extras.GetDigitCount(size);
            for (int i = 0; i < (count - size) / 2; i++)
            {
                value /= 10;
            }
            int mod = 1;
            for (int i = 0; i < sizeCount; i++)
                mod *= 10;
            return value % mod;
        }

        public static int Hash2(string key, int size)
        {
            int value = 0;
            for (int i = 0; i < key.Length; i++)
                value += key[i];
            return value % size;
        }
    }
}
