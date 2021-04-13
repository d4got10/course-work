using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Сoursework_Server.Commands;

namespace Сoursework_Server
{
    public class Client
    {
        public const int BUFFER_SIZE = Packet.PACKET_BUFFER_SIZE;

        public Action<Exception> Shutdown;

        public string Name = new Random().Next(0, 1000).ToString();
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public Socket Socket;

        private IReceiver _receiver;
        private IRouter _router;
        private IInvoker _invoker;

        public Client(IReceiver receiver, IRouter router, IInvoker invoker)
        {
            _receiver = receiver;
            _router = router;
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
            Socket.Send(packet.ToBytes());
        }
    }
}
