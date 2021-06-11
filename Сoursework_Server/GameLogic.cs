using System;
using System.Text;
using CourseWork_Server.DataStructures.Danil;
using Shared;
using Сoursework_Server.Commands;

namespace Сoursework_Server
{
    public class GameLogic
    {
        private List<Player> _players;
        private RedBlackTree<string, Player> _playersByName;

        public GameLogic()
        {
            _players = new List<Player>();
            _playersByName = new RedBlackTree<string, Player>();
            foreach(var player in _players)
            {
                _playersByName.Add(player.Name, player);
            }

            CreateAndAddPlayer("4got10", "qwerty123");
            CreateAndAddPlayer("danger441", "hghgjy");
        }

        public bool TryGetPlayer(string name, string password, out Player player)
        {
            if(_playersByName.TryFind(name, out var playerList)){
                player = playerList[0];
                return (player.Password == password);
            }

            player = null;
            return false;
        }

        public Player CreateAndAddPlayer(string name, string password)
        {
            var newPlayer = new Player(name, password);
            _players.Add(newPlayer);
            _playersByName.Add(newPlayer.Name, newPlayer);
            return newPlayer;
        }

        public void MovePlayer(Player player, Vector2 direction)
        {
            player.Position += direction;
        }
    }
}
