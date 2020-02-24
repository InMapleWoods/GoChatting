using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GoChatting.UDP
{
    /// <summary>
    /// 接收UDP数据报
    /// </summary>
    public class Receiver:Util.UdpReceiver
    {
        /// <summary>
        /// 侦听信息
        /// </summary>
        /// <param name="operate">委托对象</param>
        /// <param name="console">控制台对象</param>
        public void StartListenning(object operate, object console)
        {
            Listenning(operate, console, false);
        }
    }
}
