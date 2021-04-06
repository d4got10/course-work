using System.Collections.Generic;
using System.Text;
using Сoursework_Server;

namespace Сoursework_Server.Commands
{
    public abstract class Command
    {
        protected Client Source;

        public Command(Client source)
        {
            Source = source;
        }

        public abstract void Execute();
        public abstract void Undo();
    }
}
