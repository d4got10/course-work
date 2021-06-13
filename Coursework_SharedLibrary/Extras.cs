using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class Extras
    {
        public static int GetDigitCount(int number)
        {
            int count = 0;
            do
            {
                count++;
                number /= 10;
            } while (number > 0);
            return count;
        }
    }
}
