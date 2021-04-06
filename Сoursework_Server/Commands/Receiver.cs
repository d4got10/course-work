using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public class Receiver
    {
        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void SendMessage(Client target, Packet packet)
        {
            target.Send(packet);
        }
    }
}
