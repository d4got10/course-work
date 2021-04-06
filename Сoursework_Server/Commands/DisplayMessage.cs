using Shared;
using System;

namespace Сoursework_Server.Commands
{
    public class DisplayMessage : Command
    {
        private Receiver _receiver;
        private string _message;

        public DisplayMessage(Client source, Receiver receiver, string message) : base(source)
        {
            _receiver = receiver;
            _message = message;
        }

        public override void Execute()
        {
            string message = $"Received message from Client[{Source.Name}]\n";
            message += "Message: " + _message;
            _receiver.DisplayMessage(message);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }

    public class ResendMessage : Command
    {
        private Receiver _receiver;
        private string _message;

        public ResendMessage(Client source, Receiver receiver, string message) : base(source)
        {
            _receiver = receiver;
            _message = message;
        }

        public override void Execute()
        {
            var packet = new Packet();
            packet.WriteByte((byte)Packet.PACKET_IDS.MESSAGE);
            packet.WriteString(_message);

            foreach(var client in Source.Server.Clients)
            {
                if (client != Source)
                {
                    _receiver.SendMessage(client, packet);
                }
            }
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
