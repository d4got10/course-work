using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Сoursework_Server.Commands.Realization;

namespace Сoursework_Server.Commands
{

    public class Router : IRouter
    {
        private IReceiver _receiver;

        public Router(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public Command GetCommand(Client client, Packet packet)
        {
            byte commandID = packet.ReadByte();
            switch (commandID)
            {
                case (byte)Packet.PACKET_IDS.MESSAGE:
                    return GetDisplayMessageCommand(client, packet);
                case (byte)Packet.PACKET_IDS.RESEND:
                    return GetResendMessageCommand(client, packet);
                default:
                    return null;
            }
        }

        public DisplayMessage GetDisplayMessageCommand(Client client, Packet packet)
        {
            return new DisplayMessage(client, _receiver, packet.ReadString());
        }

        public ResendMessage GetResendMessageCommand(Client client, Packet packet)
        {
            return new ResendMessage(client, _receiver, packet.ReadString());
        }
    }
}
