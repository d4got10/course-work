using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Сoursework_Server.Commands;

namespace Сoursework_Server
{

    public class Server : IClientsProvider
    {
        private static ManualResetEvent acceptedConnection;

        public bool IsRunning { get; private set; }
        public Socket ListenerSocket { get; private set; }

        private List<Client> _clients;
        public IReadOnlyList<Client> Clients => _clients;

        public GameLogic GameLogic { get; private set; }
        public IInvoker Invoker { get; private set; }

        private List<Thread> _threads;

        public Server()
        {
            Initialize();
            Configurate();
            GameLogic = new GameLogic(this);
            Populate();
        }

        private void Populate()
        {
            GameLogic.CreateAndAddPlayer("123", "d4got10");
            GameLogic.CreateAndAddPlayer("d4got10", "d4got10");
            GameLogic.CreateAndAddPlayer("Fedor", "Fet");
            GameLogic.CreateAndAddPlayer("German", "Pedorenko");
        }

        private void Initialize()
        {
            _threads = new List<Thread>();
            IsRunning = false;
            acceptedConnection = new ManualResetEvent(false);
            _clients = new List<Client>();
        }

        private void Configurate()
        {
            Invoker = new Invoker();
        }

        public void Start()
        {
            IsRunning = true;
            Thread t = new Thread(new ThreadStart(BeginListening));
            _threads.Add(t);
            t.Start();
        }

        public void Stop()
        {
            IsRunning = false;
            foreach(var client in Clients)
            {
                DisconnectClient(client, new Exception("Server was shutdown."));
                ListenerSocket.Shutdown(SocketShutdown.Both);
                ListenerSocket.Disconnect(true);
                ListenerSocket = null;
            }
            foreach(var thread in _threads)
            {
                try
                {
                    if(thread.ThreadState == ThreadState.Running)
                        thread.Abort();
                }
                catch (Exception)
                {
                }
            }
        }

        #region Client Connection
        private void BeginListening()
        {
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 8000);
            if(ListenerSocket == null)
                ListenerSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {
                ListenerSocket.Bind(localEndPoint);
                ListenerSocket.Listen(100);

                while (true)
                {
                    acceptedConnection.Reset();
                    if (IsRunning == false) return;

                    Console.WriteLine("Waiting for a connection...");
                    ListenerSocket.BeginAccept(new AsyncCallback(AcceptCallback), ListenerSocket);

                    acceptedConnection.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            if (IsRunning == false)
            {
                acceptedConnection.Set();
                return;
            }

            var listener = (Socket)ar.AsyncState;
            var handler = listener.EndAccept(ar);

            Console.WriteLine($"Received connection from {handler.RemoteEndPoint}");

            var client = new Client(this, Invoker);
            client.Socket = handler;
            client.Shutdown += (ex) => { DisconnectClient(client, ex); };

            _clients.Add(client);

            Thread clientThread = new Thread(new ThreadStart(client.Listen));
            _threads.Add(clientThread);
            clientThread.Start();

            acceptedConnection.Set();
        }

        private void DisconnectClient(Client client, Exception ex)
        {
            client.Socket.Shutdown(SocketShutdown.Both);
            _clients.Remove(client);
            Console.WriteLine($"Client [{client.Name}] disconnected!");
            if (ex != null)
                Console.WriteLine($"Error: {ex.Message}");
        }
        #endregion
    }
}
