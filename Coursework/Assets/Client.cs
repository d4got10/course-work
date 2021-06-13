using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shared;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Networking
{

    public class Client : MonoBehaviour
    {
        public ConcurrentQueue<Packet> ReceivedPackets;

        public string Username { get; private set; }
        public string Password { get; private set; }

        public Socket Socket { get; private set; }
        public bool IsConnected { get; private set; }
        public byte[] Buffer { get; private set; }

        private bool _connectionDone;
        private bool _receiveDone;


        private void Awake()
        {
            var others = FindObjectsOfType<Client>();
            foreach(var other in others)
                if (other != this) Destroy(other.gameObject);

            DontDestroyOnLoad(gameObject);
            ReceivedPackets = new ConcurrentQueue<Packet>();
        }

        public void Init(string username, string password)
        {
            Username = username;
            Password = password;
            Buffer = new byte[Packet.PACKET_BUFFER_SIZE];
        }

        public void Connect() => StartCoroutine(ConnectCoroutine());

        public void Send(Packet packet) => Socket.Send(packet.ToBytes());

        private IEnumerator ConnectCoroutine()
        {
            IPAddress ipAddress = IPAddress.Parse(NetworkSettings.IP);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, NetworkSettings.Port);

            Socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            Debug.Log("Started connecting to server...");

            Socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), Socket);

            yield return new WaitUntil(() => _connectionDone);

            StartCoroutine(ReceiveCoroutine());
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            Socket.EndConnect(ar);

            Debug.Log($"Socket connected to {Socket.RemoteEndPoint}");

            _connectionDone = true;
            IsConnected = true;
        }

        private void Receive()
        {
            Debug.Log("Started receiving...");
            Socket.BeginReceive(Buffer, 0, Packet.PACKET_BUFFER_SIZE, 0, new AsyncCallback(ReceiveCallback), null);
        }

        private IEnumerator ReceiveCoroutine()
        {
            while (true)
            {
                Receive();
                yield return new WaitUntil(() => _receiveDone);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            int bytesRead = Socket.EndReceive(ar);

            if (bytesRead > 0)
            {
                var packet = new Packet(Buffer);
                ReceivedPackets.Enqueue(packet);
                Socket.BeginReceive(Buffer, 0, Packet.PACKET_BUFFER_SIZE, 0,
                    new AsyncCallback(ReceiveCallback), null);
            }
            else
            {
                Debug.Log("Received data.");
                _receiveDone = true;
            }
        }
    }
}
