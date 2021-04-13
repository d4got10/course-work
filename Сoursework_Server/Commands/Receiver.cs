using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public class Receiver : IReceiver
    {
        private Server _server;

        public Receiver(Server server)
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

        public void SignIn(Client player, string name)
        {
            throw new NotImplementedException();
        }

        public void ProcessMoves(Client player, List<Move> moves)
        {
            throw new NotImplementedException();
        }
    }
}
