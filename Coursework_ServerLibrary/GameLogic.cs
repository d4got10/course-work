using CourseWork_Server.DataStructures.Danil;
using Shared;
using System;

namespace Сoursework_Server
{
    public class GameLogic : IAttackService, IMoveService, IDeathService
    {
        public GameGrid Grid { get; private set; }

        private System.Collections.Generic.List<Player> _players;
        private HashTable<string, Clan> _clans;
        private HashTable<string, UserData> _users;
        private RedBlackTree<string, Player> _playersByName;

        public event Action UsersUpdated
        {
            add => _users.Changed += value;
            remove => _users.Changed -= value;
        }
        public System.Collections.Generic.IReadOnlyList<Player> Players => _players;
        public HashTable<string, UserData>.ValueWithHash[] UsersValues => _users.Values;
        public IHashTableFinder<string, UserData> UsersFinder => _users;

        private IClientsProvider _clientsProvider;

        public GameLogic(IClientsProvider clientsProvider)
        {
            _players = new System.Collections.Generic.List<Player>();
            _users = new HashTable<string, UserData>(StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            _clans = new HashTable<string, Clan>(StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            _playersByName = new RedBlackTree<string, Player>();

            Grid = new GameGrid(AppConstants.GameGridSize);
            _clientsProvider = clientsProvider;
        }

        public bool TryGetUserData(string name, string password, out UserData data)
        {
            if(_users.TryFind(name, out data, out var hash))
            {
                if(password == data.Password)
                {
                    return true;
                }
            }
            
            return false;
        }

        public bool TryGetPlayer(string name, string password, out Player player)
        {
            if(_playersByName.TryFind(name, out var playerList)){
                foreach(var playerIt in playerList)
                {
                    if(playerIt.Password == password)
                    {
                        player = playerIt;
                        return true;
                    }       
                }
            }

            player = null;
            return false;
        }

        public UserData CreateUser(string name, string password)
        {
            if (_users.TryFind(name, out _, out _))
                throw new Exception("User data with the same name is already exits");

            var userData = new UserData(name, password);

            if (_users.Add(name, userData) == false)
                throw new Exception("User data wasn't added to hashtable.");

            return userData;
        }

        public Player CreateAndAddPlayer(UserData userData)
        {
            return CreateAndAddPlayer(userData, Grid.GetEmptyCellPosition(), null, 3, 5);
        }

        public Player CreateAndAddPlayer(UserData userData, Vector2 position, Clan clan, int actionPoints, int health)
        {
            if (_playersByName.TryFind(userData.Login, out var players))
                throw new Exception("Player with the same username already exists.");

            var newPlayer = new Player(this, this, this, userData);
            newPlayer.Clan = clan;
            newPlayer.ActionPointsCount = actionPoints;
            newPlayer.Health = health;

            if (Grid.TryPlacePlayer(newPlayer, position) == false) 
                throw new Exception($"Cell in position {position} is already taken.");

            _players.Add(newPlayer);
            _playersByName.Add(userData.Login, newPlayer);

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

                _users.Changed?.Invoke();
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

                _users.Changed?.Invoke();
            }
        }

        public void Die(Player target)
        {
            Console.WriteLine($"MOVE: {target.Name} died.");
            RemovePlayer(target);
        }

        public void RemovePlayer(Player target)
        {
            _users.Remove(target.Name);
            Grid.RemovePlayer(target);
        }
    }
}
