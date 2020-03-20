using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Linq;

namespace GoChatting.Voice
{
    public class NetworkAudioSender : IDisposable
    {
        private readonly INetworkChatCodec codec;
        private readonly IAudioSender audioSender;
        private readonly WaveInEvent waveIn;

        public NetworkAudioSender(INetworkChatCodec codec, int inputDeviceNumber, IAudioSender audioSender)
        {
            var devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();
            this.codec = codec;
            this.audioSender = audioSender;
            //waveIn = new WasapiCapture(devices[0], true, 1);
            waveIn = new WaveInEvent();
            waveIn.BufferMilliseconds = 50;
            waveIn.DeviceNumber = inputDeviceNumber;
            waveIn.WaveFormat = codec.RecordFormat;
            waveIn.DataAvailable += OnAudioCaptured;
            waveIn.StartRecording();
        }

        void OnAudioCaptured(object sender, WaveInEventArgs e)
        {
            byte[] encoded = codec.Encode(e.Buffer, 0, e.BytesRecorded);
            audioSender.Send(encoded);
        }

        public void Dispose()
        {
            waveIn.DataAvailable -= OnAudioCaptured;
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn?.Dispose();
            audioSender?.Dispose();
        }
    }
}