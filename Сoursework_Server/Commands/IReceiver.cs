using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public interface IReceiver
    {
        void SignIn(Client player, string name);
        void DisplayMessage(string message);
        void SendPacket(Client player, Packet packet);
        void ProcessMoves(Client player, List<Move> moves);
    }
}
