using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Сoursework_Server
{
    public class Player : IEquatable<Player>
    {
        public readonly string Name;
        public readonly string Password;
        public uint ActionPointsCount { get; private set; }
        public string Clan { get; private set; }

        public Vector2 Position { get; set; }

        public Player(string name, string passwordHash)
        {
            Name = name;
            Password = passwordHash;
            ActionPointsCount = 0;
            Clan = null;
        }

        public bool Equals(Player other)
        {
            return Name == other.Name;
        }
    }
}
