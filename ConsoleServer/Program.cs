using System;
using Сoursework_Server;

namespace ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();
            server.Start();

            string message = "";
            while(message != "/q")
            {
                message = Console.ReadLine();
                message.ToLower();
                switch (message)
                {
                    case "/new":
                        try
                        {
                            Console.Write("Введите имя нового пользователя: ");
                            var name = Console.ReadLine();
                            Console.Write("Введите пароль нового пользователя: ");
                            var password = Console.ReadLine();
                            var userData = new UserData(name, password);
                            server.GameLogic.CreateAndAddPlayer(userData);
                            Console.WriteLine("Пользователь успешно создан");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                        break;
                    case "/users":
                        try
                        {
                            foreach(var player in server.GameLogic.Players)
                            {
                                Console.WriteLine($"{player.Name} {player.Password} \"{player.Clan}\" [{player.Position}][{player.ActionPointsCount}][{player.Health}]");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
            server.Stop();
            Environment.Exit(Environment.ExitCode);
        }
    }
}
