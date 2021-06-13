using Shared;
using System;

namespace Сoursework_Server.Commands.Realization
{
    public class ResendMessage : Command
    {
        private string _message;

        public ResendMessage(Client source, IReceiver receiver, string message) : base(source, receiver)
        {
            _message = message;
        }

        public override void Execute()
        {
            var packet = new Packet();
            packet.WriteByte((byte)Packet.PACKET_IDS.MESSAGE);
            packet.WriteString(_message);

            //Receiver.SendPacket(client, packet);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
