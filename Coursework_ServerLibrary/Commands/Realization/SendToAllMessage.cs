using Shared;
using System;

namespace Сoursework_Server.Commands.Realization
{
    public class SendToAllMessage : Command
    {
        private string _message;

        public SendToAllMessage(Client source, IReceiver receiver, string message) : base(source, receiver)
        {
            _message = message;
        }

        public override void Execute()
        {
            var packet = new Packet();
            packet.WriteByte((byte)Packet.PACKET_IDS.MESSAGE);
            packet.WriteString(_message);

            Receiver.SendToAll(packet);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
