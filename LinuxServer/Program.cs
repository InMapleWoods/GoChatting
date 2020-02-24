using System;

namespace LinuxServer
{
    /// <summary>
    /// 主程序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            UDPReceiver udpReceiver = new UDPReceiver();
            udpReceiver.StartListenning();
        }
    }

}
