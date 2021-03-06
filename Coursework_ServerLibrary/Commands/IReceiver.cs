using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Сoursework_Server.Commands
{
    public interface IReceiver
    {
        void SignIn(string name, string password);
        void GetMap(string name, string password);
        void Move(string name, string password, Vector2 direction);
        void DisplayMessage(string message);
        void SendPacket(Client player, Packet packet);
        void SendToAll(Packet packet);
    }
}
