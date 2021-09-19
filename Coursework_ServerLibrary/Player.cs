using CourseWork_Server.DataStructures;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace Сoursework_Server
{

    public class Player : IEquatable<Player>, ISaveable
    {
        public readonly UserData UserData;

        public string Name => UserData.Login;
        public string Password => UserData.Password;

        public Clan Clan;
        public int Health;
        public int ActionPointsCount;

        public Vector2 Position { get; set; }

        private readonly IAttackService _attackService;
        private readonly IMoveService _moveService;
        private readonly IDeathService _deathService;

        public Player(IAttackService attackService, IMoveService moveService, IDeathService deathService,
                        UserData userData)
        {
            _attackService = attackService;
            _moveService = moveService;
            _deathService = deathService;
            UserData = userData;
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

        public string GetData()
        {
            return $"{UserData.GetData()}" +
                    $"|{Position}" +
                    $"|{((Clan != null) ? Clan.GetData() : "NULL|NULL")}" +
                    $"|{Health}" +
                    $"|{ActionPointsCount}";
        }

        public override string ToString()
        {
            return UserData.Login;
        }
    }
}
