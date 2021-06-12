using System;
using System.Text;
using CourseWork_Server.DataStructures.Danil;
using Shared;
using Сoursework_Server.Commands;

namespace Сoursework_Server
{
    public class GameLogic
    {
        private HashTable<string, Player> _players;

        public GameLogic()
        {
            _players = new HashTable<string, Player>(StringHashTableExtras.HashFunction, 100);

            CreateAndAddPlayer("4got10", "qwerty123");
            CreateAndAddPlayer("danger441", "hghgjy");
            CreateAndAddPlayer("qwe11111111", "qwe1111111111");

            _players.Display();

            if(TryGetPlayer("4got10", "qwerty123", out var player))
            {
                Console.WriteLine(player.Position);
            }

            _players.Remove("4got10");
            _players.Display();
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
            var newPlayer = new Player(name, password);
            _players.Add(name, newPlayer);
            return newPlayer;
        }

        public void MovePlayer(Player player, Vector2 direction)
        {
            player.Position += direction;
        }
    }
}
