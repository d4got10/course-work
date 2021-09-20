using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Packet
    {
        public const int PacketBufferSize = 1024;

        private byte[] _data;
        private int _readPosition;

        public enum PACKET_IDS
        {
            WELCOME = 1,
            MESSAGE,
            RESEND,
            SEND_TO_ALL,
            SIGNIN,
            GET_MAP,
            MOVE
        }

        public Packet()
        {
            _data = new byte[PacketBufferSize];
            _readPosition = 0;
        }

        public Packet(byte[] data)
        {
            _data = data;
            _readPosition = 0;
        }

        #region Read
        public byte ReadByte()
        {
            var value = _data[_readPosition];
            _readPosition += 1;
            return value;
        }

        public byte[] ReadBytes(int count)
        {
            var bytes = new byte[count];
            for (int i = 0; i < count; i++)
            {
                bytes[i] = _data[_readPosition];
                _readPosition += 1;
            }
            return bytes;
        }

        public int ReadInt32()
        {
            var bytes = ReadBytes(4);
            int value = BitConverter.ToInt32(bytes, 0);
            return value;
        }

        public char ReadChar()
        {
            var bytes = ReadBytes(2);
            char value = BitConverter.ToChar(bytes, 0);
            return value;
        }

        public string ReadString()
        {
            int length = ReadInt32();
            var str = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                str.Append(ReadChar());
            }
            return str.ToString();
        }

        #endregion

        #region Write

        public void WriteByte(byte value)
        {
            _data[_readPosition] = value;
            _readPosition++;
        }
        public void WriteBytes(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                WriteByte(bytes[i]);
            }
        }

        public void WriteInt(int value)
        {
            var bytes = BitConverter.GetBytes(value);
            WriteBytes(bytes);
        }
        public void WriteChar(char value)
        {
            var bytes = BitConverter.GetBytes(value);
            WriteBytes(bytes);
        }

        public void WriteString(string value)
        {
            WriteInt(value.Length);
            for(int i = 0; i < value.Length; i++)
            {
                WriteChar(value[i]);
            }
        }

        #endregion

        public byte[] ToBytes()
        {
            return _data;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < _data.Length; i++) 
            {
                str.Append(_data[i]);
                str.Append(" ");
            }
            return str.ToString();
        }
    }
}
