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
            string message = $"Received message from Client{Source.Name}\n";
            message += "Message: " + _message;
            _receiver.DisplayMessage(message);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
