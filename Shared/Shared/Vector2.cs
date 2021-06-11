using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public struct Vector2 : IComparable<Vector2>
    {
        public int X;
        public int Y;

        public int CompareTo(Vector2 other)
        {
            return 10000000 * Y + X;   
        }
    }
}
