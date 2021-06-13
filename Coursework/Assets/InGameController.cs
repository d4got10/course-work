using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Networking;
using Shared;

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

    private void SendGetMapPacket()
    {
        var packet = new Packet();
        packet.WriteByte((byte)Packet.PACKET_IDS.GET_MAP);
        packet.WriteString(_client.Username);
        packet.WriteString(_client.Password);
        _client.Send(packet);
        StartCoroutine(WaitForMapData());
    }

    private IEnumerator WaitForMapData()
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
        }
        else
        {
            Debug.LogError("Error while receiving game grid data.");
        }
    }
}
