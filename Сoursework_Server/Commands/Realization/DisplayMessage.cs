using System;

namespace Сoursework_Server.Commands.Realization
{
    public class DisplayMessage : Command
    {
        private string _message;

        public DisplayMessage(Client source, IReceiver receiver, string message) : base(source, receiver)
        {
            _message = GenerateMessage(message); 
        }

        public override void Execute()
        {
            Receiver.DisplayMessage(_message);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }

        private string GenerateMessage(string message)
        {
            string answer = $"Received message from Client[{Source.Name}]\n";
            answer += "Message: " + message;

            return answer;
        }
    }
}
