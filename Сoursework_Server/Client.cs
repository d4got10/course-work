using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Сoursework_Server
{
    class Client
    {
        public const int BUFFER_SIZE = 1024;

        public string Name = new Random().Next(0, 1000).ToString();

        public byte[] Buffer = new byte[BUFFER_SIZE];
        public Socket Socket;

        public void Listen()
        {
            Socket.BeginReceive(Buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), null);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            string content = "";

            int bytesRead = Socket.EndReceive(ar);

            if (bytesRead > 0)
            {
                content = Encoding.ASCII.GetString(Buffer);

                if (content.Length > 5 && content.Substring(0, 5) == "<EOF>")
                {
                    content = content.Substring(5);
                    Console.WriteLine("Read {0} bytes from client [{1}].\nData: {2}",
                        content.Length, Name, content);
                }
                else
                {
                    Console.WriteLine($"Received bad request from client [{Name}]. Request body: {content}");
                }
            }

            Socket.BeginReceive(Buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), null);
        }
    }
}
