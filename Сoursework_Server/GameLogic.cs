using CourseWork_Server.DataStructures.Danil;
using Shared;
using System;

namespace Сoursework_Server
{
    public class GameLogic : IAttackService, IMoveService
    {
        private GameGrid _grid;
        private HashTable<string, Player> _players;

        public GameLogic()
        {
            _players = new HashTable<string, Player>(StringHashTableExtras.HashFunction, 100);
            _grid = new GameGrid(100);
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
            var newPlayer = new Player(this, this, name, password);
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
                target.TakeDamage(1);
                Console.WriteLine($" {target.Health})");
            }
        }
    }
}
