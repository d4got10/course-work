using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Сoursework_Server
{
    class Server
    {
        public static ManualResetEvent allDone;

        public bool IsRunning { get; private set; }
        public Socket ListenerSocket { get; private set; }

        public Server()
        {
            IsRunning = false;
            allDone = new ManualResetEvent(false);
        }

        public void Start()
        {
            IsRunning = true;

            BeginListening();
        }

        public void BeginListening()
        {
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8000);
            ListenerSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                ListenerSocket.Bind(localEndPoint);
                ListenerSocket.Listen(100);

                while (true)
                {
                    allDone.Reset();

                    Console.WriteLine("Waiting for a connection...");
                    ListenerSocket.BeginAccept(new AsyncCallback(AcceptCallback), ListenerSocket);

                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            var listener = (Socket)ar.AsyncState;
            var handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;

            Console.WriteLine($"Received connection from {handler.RemoteEndPoint}");

            var client = new Client();
            client.Socket = handler;

            Thread clientThread = new Thread(new ThreadStart(client.Listen));
            clientThread.Start();

            allDone.Set();
        }
    }
}
