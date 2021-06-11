using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public class TestReceiver : IReceiver
    {
        private Server _server;

        public TestReceiver(Server server)
        {
            _server = server;
        }

        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void SendPacket(Client player, Packet packet)
        {
            player.Send(packet);
        }

        public void SendToAll(Packet packet)
        {
            foreach(var client in _server.Clients)
            {
                client.Send(packet);
            }
        }

        public void SignIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void ProcessMoves(Client player, List<Move> moves)
        {
            throw new NotImplementedException();
        }
    }
}
