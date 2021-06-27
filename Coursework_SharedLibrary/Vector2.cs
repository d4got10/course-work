using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public struct Vector2 : IComparable<Vector2>, IEquatable<Vector2>
    {
        public int X;
        public int Y;
        public int SqrMagnitude => X * X + Y * Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2(string rawData)
        {
            var data = rawData.Trim(new char[] { '(', ')' });
            var splitted = data.Split(';');
            X = int.Parse(splitted[0]);
            Y = int.Parse(splitted[1]);
        }

        public int CompareTo(Vector2 other)
        {
            return 10000000 * Y + X;   
        }

        public bool Equals(Vector2 other)
        {
            return other.X == X && other.Y == Y;
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator *(Vector2 lhs, float value)
        {
            return new Vector2((int)(lhs.X * value), (int)(lhs.Y * value));
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return lhs.Equals(rhs) == false;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }
}
