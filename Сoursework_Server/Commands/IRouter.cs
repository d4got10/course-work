using Shared;

namespace Сoursework_Server.Commands
{
    public interface IRouter
    {
        Command GetCommand(Client player, Packet packet);
    }
}
