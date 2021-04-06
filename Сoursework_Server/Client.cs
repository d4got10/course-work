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

        public readonly Server Server;

        public string Name = new Random().Next(0, 1000).ToString();
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public Socket Socket;

        private Receiver _receiver;
        private Invoker _invoker;

        public Client(Server server)
        {
            _receiver = new Receiver();
            _invoker = new Invoker();
            Server = server;
        }

        public void Listen()
        {
            Socket.BeginReceive(Buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), null);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            string content = "";

            int bytesRead = Socket.EndReceive(ar);

            if (bytesRead > 0)
            {
                var packet = new Packet(Buffer);
                var router = new CommandRouter(this, _receiver);
                var command = router.GetCommand(packet);
                _invoker.SetCommand(command);
                _invoker.Run();

                //if (commandID == 1)
                //{
                //    Console.WriteLine($"Received message from client [{Name}]. Message: {packet.ReadString()}");
                //}
                //else
                //{
                //    Console.WriteLine($"Received bad request from client [{Name}]. Request body: {commandID}");
                //}

                //content = Encoding.ASCII.GetString(Buffer);

                //if (content.Length > 5 && content.Substring(0, 5) == "<EOF>")
                //{
                //    content = content.Substring(5);
                //    Console.WriteLine("Read {0} bytes from client [{1}].\nData: {2}",
                //        content.Length, Name, content);
                //}
                //else
                //{
                //    Console.WriteLine($"Received bad request from client [{Name}]. Request body: {content}");
                //}
            }

            Socket.BeginReceive(Buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), null);
        }

        public void Send(Packet packet)
        {
            Socket.Send(packet.ToBytes());
        }
    }
}
