using CourseWork_Server.DataStructures.Danil;
using Shared;
using System;

namespace Сoursework_Server
{
    public class GameLogic : IAttackService, IMoveService, IDeathService
    {
        public GameGrid Grid { get; private set; }
        private HashTable<string, Player> _players;

        private IClientsProvider _clientsProvider;

        public GameLogic(IClientsProvider clientsProvider)
        {
            _players = new HashTable<string, Player>(StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            Grid = new GameGrid(AppConstants.GameGridSize);
            _clientsProvider = clientsProvider;
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
            Grid.PlaceNewPlayer(newPlayer);
            _players.Add(name, newPlayer);
            //send message
            return newPlayer;
        }

        public void Move(Player player, Vector2 direction)
        {
            var prevPosition = player.Position;
            if(Grid.Move(player, player.Position + direction))
            {
                Console.WriteLine($"MOVE: {player.Name} moved ({prevPosition} -> {player.Position})");
                var packet = new Packet();
                packet.WriteByte((byte)Packet.PACKET_IDS.MOVE);
                packet.WriteString(player.Name);
                packet.WriteByte((byte)(prevPosition.X + Grid.Size / 2));
                packet.WriteByte((byte)(prevPosition.Y + Grid.Size / 2));
                packet.WriteByte((byte)(player.Position.X + Grid.Size / 2));
                packet.WriteByte((byte)(player.Position.Y + Grid.Size / 2));

                foreach(var client in _clientsProvider.Clients)
                {
                    if (client.Socket.Connected)
                    {
                        client.Send(packet);
                    }
                    else
                    {
                        client.Socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    }
                }
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
            Grid.RemovePlayer(target);
        }
    }
}
