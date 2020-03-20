using System.Net;
using System.Net.Sockets;

namespace GoChatting.Voice
{
    public class UdpAudioSender : IAudioSender
    {
        private readonly UdpClient udpSender;
        public UdpAudioSender(IPEndPoint endPoint, IPEndPoint srcPoint)
        {
            udpSender = new UdpClient();
            udpSender.Client.Bind(srcPoint);
            udpSender.Connect(endPoint);
        }

        public void Send(byte[] payload)
        {
            udpSender.Send(payload, payload.Length);
        }

        public void Dispose()
        {
            udpSender?.Close();
        }
    }
}