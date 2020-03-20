using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GoChatting.Voice
{
    public class Receiver
    {
        private INetworkChatCodec selectedCodec;
        private NetworkAudioSender audioSender;
        private NetworkAudioPlayer player;
        private volatile bool connected;
        private List<CodecItem> codecItems = new List<CodecItem>();
        static bool endSignal = false;
        public void Start()
        {
            if (!endSignal)
            {
                PopulateCodecs();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 17720);
                int inputDeviceNumber = 0;
                selectedCodec = codecItems[0].Codec;
                Connect(endPoint, inputDeviceNumber, selectedCodec);
            }
        }

        private void PopulateCodecs()
        {
            var codecs = GetCodec.GetCodecs<INetworkChatCodec>();
            var sorted = from codec in codecs
                         where codec.IsAvailable
                         orderby codec.BitsPerSecond ascending
                         select codec;
            foreach (var codec in sorted)
            {
                var bitRate = codec.BitsPerSecond == -1 ? "VBR" : $"{codec.BitsPerSecond / 1000.0:0.#}kbps";
                var text = $"{codec.Name} ({bitRate})";
                codecItems.Add(new CodecItem { Text = text, Codec = codec });
            }
        }

        private void Connect(IPEndPoint endPoint, int inputDeviceNumber, INetworkChatCodec codec)
        {
            var receiver = (IAudioReceiver)new UdpAudioReceiver(endPoint.Port);
            player = new NetworkAudioPlayer(codec, receiver);
            connected = true;
        }
        public void Disconnect()
        {
            if (connected)
            {
                connected = false;
                //audioSender.Dispose();

                // a bit naughty but we have designed the codecs to support multiple calls to Dispose, 
                // recreating their resources if Encode/Decode called again
                selectedCodec.Dispose();
            }
        }


    }

}
