using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Networking;
using TMPro;
using UnityEngine.UI;
using Shared;

public class LoginForm : MonoBehaviour
{
    public UnityEvent LoggedIn;

    [SerializeField] private TMP_InputField _loginInput;
    [SerializeField] private TMP_InputField _passwordInput;
    [SerializeField] private Button _playButton;

    private Client _client;

    private void Awake()
    {
        _client = FindObjectOfType<Client>();
        _playButton.onClick.AddListener(OnClick_Connect);
    }

    public void OnClick_Connect()
    {
        if (InputIsValid())
        {
            _client.Init(_loginInput.text, _passwordInput.text);
            _client.Connect();
            StartCoroutine(WaitForAnswerCoroutine());
        }
    }

    private IEnumerator WaitForAnswerCoroutine()
    {
        yield return new WaitUntil(() => _client.IsConnected);
        SendSignInPacket();

        yield return new WaitUntil(() => _client.ReceivedPackets.Count > 0);
        if(_client.ReceivedPackets.TryDequeue(out var packet))
        {
            ProccessPacket(packet);
        }
        else
        {
            Debug.LogError("Ошибка. Не удалось получить welcome пакет");
        }
    }

    private void SendSignInPacket()
    {
        var packet = new Packet();
        packet.WriteByte((byte)Packet.PACKET_IDS.SIGNIN);
        packet.WriteString(_loginInput.text);
        packet.WriteString(_passwordInput.text);

        _client.Send(packet);
    }

    private void ProccessPacket(Packet packet)
    {
        int id = packet.ReadByte();
        if(id == (byte)Packet.PACKET_IDS.SIGNIN)
        {
            int code = packet.ReadByte();
            if(code == 0)
            {
                Debug.Log("Successfully signed in!");
                LoggedIn.Invoke();
            }
            else
            {
                Debug.Log("Error while signing in!");
            }
        }
    }

    private bool InputIsValid()
    {
        return (string.IsNullOrEmpty(_loginInput.text) || string.IsNullOrEmpty(_passwordInput.text)) == false;
    }
}
