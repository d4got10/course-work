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
        public int Health;
        public uint ActionPointsCount { get; private set; }
        public string Clan { get; private set; }

        public Vector2 Position { get; set; }

        private readonly IAttackService _attackService;
        private readonly IMoveService _moveService;
        private readonly IDeathService _deathService;

        public Player(IAttackService attackService, IMoveService moveService, IDeathService deathService,
                        string name, string passwordHash)
        {
            _attackService = attackService;
            _moveService = moveService;
            _deathService = deathService;
            Name = name;
            Password = passwordHash;

            Init();
        }

        private void Init()
        {
            ActionPointsCount = 0;
            Clan = null;
            Health = 5;
        }

        public bool Equals(Player other)
        {
            return Name == other.Name;
        }

        public void Attack(Player target)
        {
            _attackService.Attack(this, target);
        }

        public void Move(Vector2 direction)
        {
            _moveService.Move(this, direction);
        }

        public bool TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                return true;
            }
            return false;
        }

        public void Die()
        {
            _deathService.Die(this);
        }
    }
}
