using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Сoursework_Server.Commands;

namespace Сoursework_Server
{
    public class Client : IReceiver
    {
        public const int BUFFER_SIZE = Packet.PacketBufferSize;

        public Action<Exception> Shutdown;

        public readonly Server Server;

        public Guid Name = Guid.NewGuid();
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public Socket Socket;

        public Player LinkedPlayer { get; private set; }

        private IReceiver _receiver;
        private IRouter _router;
        private IInvoker _invoker;

        public Client(Server server, IInvoker invoker)
        {
            Server = server;
            _receiver = this;
            _router = new Router(_receiver);
            _invoker = invoker;
        }

        public void Listen()
        {
            Socket.BeginReceive(Buffer, 0, BUFFER_SIZE, 0,
                new AsyncCallback(ReadCallback), null);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            try
            {
                if (Server.IsRunning == false) return;

                int bytesRead = Socket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    var packet = new Packet(Buffer);
                    var command = _router.GetCommand(this, packet);
                    _invoker.SetCommand(command);
                    _invoker.Run();
                }

                Socket.BeginReceive(Buffer, 0, BUFFER_SIZE, 0,
                        new AsyncCallback(ReadCallback), null);
            }
            catch(Exception ex)
            {
                Shutdown?.Invoke(ex);
            }
        }

        public void Send(Packet packet)
        {
            if (Server.IsRunning == false) return;

            Socket.Send(packet.ToBytes());
        }

        public void SignIn(string username, string password)
        {
            if(Server.GameLogic.TryGetPlayer(username, password, out var player))
            {
                LinkedPlayer = player;

                var packet = new Packet();
                packet.WriteByte((byte)Packet.PACKET_IDS.SIGNIN);
                packet.WriteByte(0);
                Send(packet);
            }
            else
            {
                var packet = new Packet();
                packet.WriteByte((byte)Packet.PACKET_IDS.SIGNIN);
                packet.WriteByte(1);
                Send(packet);
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void SendPacket(Client player, Packet packet)
        {
            player.Send(packet);
        }

        public void SendToAll(Packet packet)
        {
            foreach (var client in Server.Clients)
            {
                client.Send(packet);
            }
        }

        public void GetMap(string username, string password)
        {
            if(Server.GameLogic.TryGetPlayer(username, password, out var player))
            {
                var gridIndoPacket = new Packet();
                gridIndoPacket.WriteByte((byte)Packet.PACKET_IDS.GET_MAP);
                byte size = (byte)Server.GameLogic.Grid.Size;
                gridIndoPacket.WriteByte(size);
                gridIndoPacket.WriteByte((byte)(player.Position.X + size/2));
                gridIndoPacket.WriteByte((byte)(player.Position.Y + size/2));
                Send(gridIndoPacket);

                for(int i = 0; i < Server.GameLogic.Grid.Size; i++)
                {
                    Thread.Sleep(100);
                    var gridRowPacket = new Packet();
                    gridRowPacket.WriteByte((byte)Packet.PACKET_IDS.GET_MAP);
                    for(int j = 0; j < Server.GameLogic.Grid.Size; j++)
                    {
                        gridRowPacket.WriteByte((byte)Server.GameLogic.Grid.GetCellByIndex(new Vector2(j, i)).Type);
                    }
                    Send(gridRowPacket);
                }
            }
            else
            {
                var packet = new Packet();
                packet.WriteByte((byte)Packet.PACKET_IDS.WELCOME);
                Send(packet);
            }
        }

        public void Move(string username, string password, Vector2 direction)
        {
            direction.X -= 1;
            direction.Y -= 1;

            if (Server.GameLogic.TryGetPlayer(username, password, out var player))
            {
                if(player.Password == password)
                {
                    Server.GameLogic.Move(player, direction);
                    return;
                }
            }

            var packet = new Packet();
            packet.WriteByte((byte)Packet.PACKET_IDS.WELCOME);
            Send(packet);
        }
    }
}
