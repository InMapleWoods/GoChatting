using System;

namespace GoChatting.Voice
{
    public interface IAudioReceiver : IDisposable
    {
        void OnReceived(Action<byte[]> handler);
    }
}