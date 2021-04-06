using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public class CommandRouter
    {
        private Client _client;
        private Receiver _receiver;

        public CommandRouter(Client client, Receiver receiver)
        {
            _client = client;
            _receiver = receiver;
        }

        public Command GetCommand(Packet packet)
        {
            byte commandID = packet.ReadByte();
            switch (commandID)
            {
                case 1:
                    return GetDisplayMessageCommand(packet);
                default:
                    return null;
            }
        }

        public DisplayMessage GetDisplayMessageCommand(Packet packet)
        {
            return new DisplayMessage(_client, _receiver, packet.ReadString());
        }
    }
}
