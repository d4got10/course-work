using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public class Invoker
    {
        private Command _command;

        public void SetCommand(Command c)
        {
            _command = c;
        }

        public void Run()
        {
            _command.Execute();
        }

        public void Cancel()
        {
            _command.Undo();
        }
    }
}
