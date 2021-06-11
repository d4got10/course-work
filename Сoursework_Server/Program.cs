using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using CourseWork_Server.DataStructures.Danil;

namespace Сoursework_Server
{
    public class Program
    {
        public static int Main(String[] args)
        {
            var server = new Server();
            server.Start();
            return 0;
        }
    }
}