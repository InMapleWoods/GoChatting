using System;

namespace GoChatting.Voice
{
    public interface IAudioSender : IDisposable
    {
        void Send(byte[] payload);
    }
}