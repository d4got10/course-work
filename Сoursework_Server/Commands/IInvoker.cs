namespace Сoursework_Server.Commands
{
    public interface IInvoker
    {
        void SetCommand(Command command);
        void Run();
        void Cancel();
    }
}
