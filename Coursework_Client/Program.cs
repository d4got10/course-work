using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using Shared;

namespace Coursework_Client
{
    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = Packet.PACKET_BUFFER_SIZE;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        public static Socket Client;

        // The port number for the remote device.  
        private const int port = 8000;

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        private static String response = String.Empty;

        private static void StartClient()
        {
            // Connect to a remote device.  
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                Client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                
                // Connect to the remote endpoint.  
                Client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), Client);
                connectDone.WaitOne();

                while (true)
                {
                    var message = Console.ReadLine();

                    var packet = new Packet();
                    packet.WriteByte((byte)Packet.PACKET_IDS.RESEND);
                    packet.WriteString(message);

                    // Send test data to the remote device.  
                    Send(Client, packet.ToBytes());
                    sendDone.WaitOne(); 
                }

                // Release the socket.  
                Client.Shutdown(SocketShutdown.Both);
                Client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
            }
        }

        public static void RecieveThread()
        {
            while (true)
            {
                Receive();
                receiveDone.WaitOne();

                Console.WriteLine("Response received : {0}", response);
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Complete the connection.  
                Client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    Client.RemoteEndPoint.ToString());


                // Signal that the connection has been made.
                connectDone.Set();

                Receive();
                receiveDone.WaitOne();

                var receiveThread = new Thread(new ThreadStart(RecieveThread));
                receiveThread.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive()
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = Client;

                // Begin receiving the data from the remote device.  
                Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    var packet = new Packet(state.buffer);

                    byte id = packet.ReadByte();
                    switch (id)
                    {
                        case (byte)Packet.PACKET_IDS.MESSAGE:
                            var message = packet.ReadString();
                            Console.WriteLine("Response: " + message);
                            break;
                        case (byte)Packet.PACKET_IDS.RESEND:
                            var newPacket = new Packet();
                            newPacket.WriteByte((byte)Packet.PACKET_IDS.MESSAGE);
                            newPacket.WriteString(packet.ReadString());
                            Send(client, newPacket.ToBytes());
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }

                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        
                    }
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void Send(Socket client, byte[] data)
        {
            client.BeginSend(data, 0, data.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }
    }
}