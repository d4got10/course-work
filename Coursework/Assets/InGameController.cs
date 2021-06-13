using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Networking;
using Shared;
using System.Text;
using System;

public class InGameController : MonoBehaviour
{
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private GameObject _connectingView;

    private Client _client;
    private PlayerCamera _playerCamera;

    private void Awake()
    {
        _client = FindObjectOfType<Client>();
        _playerCamera = FindObjectOfType<PlayerCamera>();
        SendGetMapPacket();
    }

    public void MoveUp() => Move(new Vector2Int(0, 1));
    public void MoveRight() => Move(new Vector2Int(1, 0));
    public void MoveDown() => Move(new Vector2Int(0, -1));
    public void MoveLeft() => Move(new Vector2Int(-1, 0));

    private void Move(Vector2Int direction)
    {
        var packet = new Packet();
        packet.WriteByte((byte)Packet.PACKET_IDS.MOVE);
        packet.WriteString(_client.Username);
        packet.WriteString(_client.Password);
        packet.WriteByte((byte)(direction.x + 1));
        packet.WriteByte((byte)(direction.y + 1));
        _client.Send(packet);
    }

    private void SendGetMapPacket()
    {
        var packet = new Packet();
        packet.WriteByte((byte)Packet.PACKET_IDS.GET_MAP);
        packet.WriteString(_client.Username);
        packet.WriteString(_client.Password);
        _client.Send(packet);
        StartCoroutine(WaitForMapDataCoroutine());
    }

    private IEnumerator WaitForMapDataCoroutine()
    {
        yield return new WaitUntil(() => _client.ReceivedPackets.Count > 0);
        if (_client.ReceivedPackets.TryDequeue(out var gridInfoPacket))
        {
            int id = gridInfoPacket.ReadByte();

            if(id == (byte)Packet.PACKET_IDS.WELCOME)
            {
                Application.Quit();
            }

            int size = gridInfoPacket.ReadByte();
            int positionX = gridInfoPacket.ReadByte() - size / 2;
            int positionY = gridInfoPacket.ReadByte() - size / 2;
            var playerPosition = new Vector2Int(positionX, positionY);
            _playerCamera.SetPosition(playerPosition + Vector2Int.one);

            byte[,] gridData = new byte[size, size];
            for(int i = 0; i < size; i++)
            {
                yield return new WaitUntil(() => _client.ReceivedPackets.Count > 0);
                if (_client.ReceivedPackets.TryDequeue(out var gridRowPacket))
                {
                    _ = gridRowPacket.ReadByte();
                    for(int j = 0; j < size; j++)
                    {
                        gridData[j, i] = gridRowPacket.ReadByte();
                    }
                }
            }
            _gameGrid.Init(size, gridData);
            _connectingView.SetActive(false);
            StartCoroutine(ReceiveMoveDataCoroutine());
        }
        else
        {
            Debug.LogError("Error while receiving game grid data.");
        }
    }

    private IEnumerator ReceiveMoveDataCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => _client.ReceivedPackets.Count > 0);
            if(_client.ReceivedPackets.TryDequeue(out var packet)){
                int id = packet.ReadByte();
                if(id == (byte)Packet.PACKET_IDS.MOVE)
                {
                    var name = ReadString(packet);

                    int x = packet.ReadByte() - _gameGrid.Size / 2;
                    int y = packet.ReadByte() - _gameGrid.Size / 2;
                    var from = new Vector3Int(x, y, 0);

                    x = packet.ReadByte() - _gameGrid.Size / 2;
                    y = packet.ReadByte() - _gameGrid.Size / 2;
                    var to = new Vector3Int(x, y, 0);

                    _gameGrid.SetCellType(from, 0); 
                    _gameGrid.SetCellType(to, 2);

                    if(name == _client.Username)
                    {
                        _playerCamera.SetPosition(new Vector3(x + 1, y + 1));
                    }
                }
                else if(id == (byte)Packet.PACKET_IDS.SIGNIN)
                {
                    string name = ReadString(packet);
                    int x = packet.ReadByte() + _gameGrid.Size / 2;
                    int y = packet.ReadByte() + _gameGrid.Size / 2;
                    var position = new Vector3Int(x, y, 0);
                    _gameGrid.SetCellType(position, 2);
                }
            }
        }
    }

    private string ReadString(Packet packet)
    {
        int length = packet.ReadByte(); packet.ReadByte(); packet.ReadByte(); packet.ReadByte();

        var str = new StringBuilder();
        for (int i = 0; i < length; i++)
        {
            str.Append(BitConverter.ToChar(packet.ReadBytes(2), 0));
        }
        return str.ToString();
    }
}
