using Shared;
using System;

namespace Сoursework_Server.Commands.Realization
{
    public class Move : Command
    {
        private string _username;
        private string _password;
        private Vector2 _direction;

        public Move(Client source, IReceiver receiver, string username, string password, Vector2 direction) : base(source, receiver)
        {
            _username = username;
            _password = password;
            _direction = direction;
        }

        public override void Execute()
        {
            Receiver.Move(_username, _password, _direction);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
