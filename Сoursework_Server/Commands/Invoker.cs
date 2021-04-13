using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{

    public class Invoker : IInvoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
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
