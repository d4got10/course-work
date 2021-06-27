using CourseWork_Server.DataStructures;
using CourseWork_Server.DataStructures.Danil;
using CourseWork_Server.DataStructures.Matvey;
using Shared;
using System;

namespace Сoursework_Server
{
    public class GameLogic : IAttackService, IMoveService, IDeathService
    {
        public GameGrid Grid { get; private set; }
        public event Action UsersUpdated
        {
            add => _users.Changed += value;
            remove => _users.Changed -= value;
        }
        private Action _playersChanged;
        public event Action PlayersUpdated
        {
            add => _playersChanged += value;
            remove => _playersChanged -= value;
        }
        private Action _clansChanged;
        public event Action ClansUpdated //TODO: Добавить ивенты
        {
            add => _clansChanged += value;
            remove => _clansChanged -= value;
        }
        public System.Collections.Generic.IReadOnlyList<Player> Players => _players;
        public CourseWork_Server.DataStructures.Danil.HashTable<string, UserData>.ValueWithHash[] UsersValues => _users.Values;
        public CourseWork_Server.DataStructures.Matvey.HashTable<string, Clan>.ValueWithHash[] ClansValues => _clans.Values;
        public IHashTableDoubleFinder<string, UserData> UsersFinder => _users;
        public IHashTableFinder<string, Clan> ClansFinder => _clans;
        public ITreeFinder<string, Player> PlayersByName => _playersByName;
        public ITreeFinder<string, Player> PlayersByClan => _playersByClan;
        public ITreeRangeFinder<int, Player> PlayersByHealth => _playersByHealth;
        public ITreeRangeFinder<int, Player> PlayersByActionPoints => _playersByActionPoints;


        private System.Collections.Generic.List<Player> _players;
        private CourseWork_Server.DataStructures.Matvey.HashTable<string, Clan> _clans;
        private CourseWork_Server.DataStructures.Danil.HashTable<string, UserData> _users;
        private RedBlackTree<string, Player> _playersByName;
        private AVLTree<string, Player> _playersByClan; //TODO: Поменять на дерево Матвея
        private RedBlackTree<int, Player> _playersByHealth;
        private RedBlackTree<int, Player> _playersByActionPoints;
        private IClientsProvider _clientsProvider;


        public GameLogic(IClientsProvider clientsProvider)
        {
            _players = new System.Collections.Generic.List<Player>();
            _users = new CourseWork_Server.DataStructures.Danil.HashTable<string, UserData>(CourseWork_Server.DataStructures.Danil.StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            _clans = new CourseWork_Server.DataStructures.Matvey.HashTable<string, Clan>(Coursework_Server.DataStructures.Matvey.StringHashTableExtras.HashFunction, AppConstants.MaxPlayers);
            _playersByName = new RedBlackTree<string, Player>("Дерево поиска по имени");
            _playersByClan = new AVLTree<string, Player>("Дерево поиска по клану");
            _playersByHealth = new RedBlackTree<int, Player>("Дерево поиска по здоровью");
            _playersByActionPoints = new RedBlackTree<int, Player>("Дерево поиска по очкам действий");

            Grid = new GameGrid(AppConstants.GameGridSize);
            _clientsProvider = clientsProvider;

            var clan = new Clan("FEDORI", "#ff00ff");
            _clans.Add(clan.Name, clan);
        }

        public bool TryGetUserData(string name, string password, out UserData data)
        {
            if(_users.TryFind(name, out data, out _, out _))
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
            if (_users.TryFind(name, out _, out _, out _))
                throw new Exception("Пользователь с таким именем уже существует.");

            var userData = new UserData(name, password);

            if (_users.Add(name, userData) == false)
                throw new Exception("Пользователь не был добавлен в хэш-таблицу.");

            return userData;
        }

        public Clan CreateClan(string name, string colorCode)
        {
            if(_clans.TryFind(name, out _, out _))
                throw new Exception("Клан с таким названием уже существует.");

            var clan = new Clan(name, colorCode);

            _clans.Add(clan.Name, clan);
            _clansChanged?.Invoke();
            return clan;
        }

        public Player CreateAndAddPlayer(UserData userData)
        {
            return CreateAndAddPlayer(userData, Grid.GetEmptyCellPosition(), null, 3, 5);
        }

        public Player CreateAndAddPlayer(UserData userData, Vector2 position, Clan clan, int actionPoints, int health)
        {
            if (_playersByName.TryFind(userData.Login, out var players))
                throw new Exception("Пользователь с таким именем уже существует.");

            var newPlayer = new Player(this, this, this, userData);
            newPlayer.Clan = clan;
            newPlayer.ActionPointsCount = actionPoints;
            newPlayer.Health = health;

            if (Grid.TryPlacePlayer(newPlayer, position) == false) 
                throw new Exception($"Клетка в позиции {position} уже занята.");

            _players.Add(newPlayer);
            _playersByName.Add(newPlayer.Name, newPlayer);
            
            if(newPlayer.Clan != null)
                _playersByClan.Add(newPlayer.Clan.Name, newPlayer);

            _playersByHealth.Add(newPlayer.Health, newPlayer);
            _playersByActionPoints.Add(newPlayer.ActionPointsCount, newPlayer);

            _playersChanged?.Invoke();
            return newPlayer;
        }

        public void Move(Player player, Vector2 direction)
        {
            var prevPosition = player.Position;
            if(Grid.Move(player, player.Position + direction))
            {
                Console.WriteLine($"ХОД: {player.Name} переместился ({prevPosition} -> {player.Position})");
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

                _playersChanged?.Invoke();
            }
        }

        public void Attack(Player source, Player target)
        {
            var direction = target.Position - source.Position;
            if (direction.SqrMagnitude == 1)
            {
                Console.Write($"ХОД: {source.Name} атаковал {target.Name} ({target.Health} ->");
                bool died = target.TakeDamage(1);
                Console.WriteLine($" {target.Health})");

                if (died) target.Die();

                _playersChanged?.Invoke();
            }
        }

        public void Die(Player target)
        {
            Console.WriteLine($"ХОД: {target.Name} умер.");
            RemovePlayer(target);
        }

        public void RemovePlayer(Player target)
        {
            _players.Remove(target);
            _playersByName.Remove(target.Name, target);
            if (target.Clan != null)
                _playersByClan.Remove(target.Clan.Name, target);

            _playersByHealth.Remove(target.Health, target);
            _playersByActionPoints.Remove(target.ActionPointsCount, target);
            Grid.RemovePlayer(target);
            _playersChanged?.Invoke();
        }

        public void RemoveUser(UserData user)
        {
            _users.Remove(user.Login);
            if (_playersByName.TryFind(user.Login, out var players))
            {
                foreach(var player in players)
                {
                    if (player != null)
                        RemovePlayer(player);
                    else
                        break;
                }
            }
        }

        public void RemoveClan(Clan clan)
        {
            _clans.Remove(clan.Name, clan);
            if(_playersByClan.TryFind(clan.Name, out var players))
            {
                foreach (var player in players)
                {
                    if (player != null)
                        ChangeClan(player, null);
                    else
                        break;
                }
            }
            _clansChanged?.Invoke();
        }

        public void ChangeClan(Player player, Clan target)
        {
            player.Clan = target;
            //Message others
        }
    }
}
