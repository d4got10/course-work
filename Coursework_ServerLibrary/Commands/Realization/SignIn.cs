using System;

namespace Сoursework_Server.Commands.Realization
{
    public class SignIn : Command
    {
        private string _username;
        private string _password;

        public SignIn(Client source, IReceiver receiver, string username, string password) : base(source, receiver)
        {
            _username = username;
            _password = password;
        }

        public override void Execute()
        {
            Receiver.SignIn(_username, _password);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
