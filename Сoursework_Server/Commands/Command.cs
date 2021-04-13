using System.Collections.Generic;
using System.Text;
using Сoursework_Server;

namespace Сoursework_Server.Commands
{
    public abstract class Command
    {
        protected Client Source;
        protected IReceiver Receiver;

        public Command(Client source, IReceiver reciever)
        {
            Source = source;
            Receiver = reciever;
        }

        public abstract void Execute();
        public abstract void Undo();
    }
}
