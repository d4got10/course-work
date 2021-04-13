using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Сoursework_Server
{
    public class Player : IComparable<Player>
    {
        public Client Client;
        public readonly string Name;

        public Player(string name, Client client)
        {
            Name = name;
            Client = client;
        }

        public int CompareTo(Player other) => Name.CompareTo(other.Name);
    }
}
