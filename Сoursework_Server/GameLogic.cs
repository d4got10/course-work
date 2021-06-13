using CourseWork_Server.DataStructures.Danil;
using Shared;
using System;

namespace Сoursework_Server
{
    public class GameLogic : IAttackService, IMoveService, IDeathService
    {
        private GameGrid _grid;
        private HashTable<string, Player> _players;

        public GameLogic()
        {
            _players = new HashTable<string, Player>(StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            _grid = new GameGrid(AppConstants.GameGridSize);
        }

        public bool TryGetPlayer(string name, string password, out Player player)
        {
            if(_players.TryFind(name, out player, out var hash)){
                return player.Password == password;
            }

            player = null;
            return false;
        }

        public Player CreateAndAddPlayer(string name, string password)
        {
            var newPlayer = new Player(this, this, this, name, password);
            _grid.PlaceNewPlayer(newPlayer);
            _players.Add(name, newPlayer);
            return newPlayer;
        }

        public void Move(Player player, Vector2 direction)
        {
            var prevPosition = player.Position;
            if(_grid.Move(player, player.Position + direction))
            {
                Console.WriteLine($"MOVE: {player.Name} moved ({prevPosition} -> {player.Position})");
            }
        }

        public void Attack(Player source, Player target)
        {
            var direction = target.Position - source.Position;
            if (direction.SqrMagnitude == 1)
            {
                Console.Write($"MOVE: {source.Name} attacked {target.Name} ({target.Health} ->");
                bool died = target.TakeDamage(1);
                Console.WriteLine($" {target.Health})");

                if (died) target.Die();
            }
        }

        public void Die(Player target)
        {
            Console.WriteLine($"MOVE: {target.Name} died.");
            RemovePlayer(target);
        }

        public void RemovePlayer(Player target)
        {
            _players.Remove(target.Name);
            _grid.RemovePlayer(target);
        }
    }
}
