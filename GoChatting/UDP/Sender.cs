using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Util;

namespace GoChatting.UDP
{
    /// <summary>
    /// 发送UDP数据报
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// UDP发送对象
        /// </summary>
        private UdpSender udpSender = new UdpSender();

        /// <summary>
        /// 本地IP
        /// </summary>
        private string LocalIP = "";

        /// <summary>
        /// 服务器IP
        /// </summary>
        private string ServerIP = "152.136.73.240";

        /// <summary>
        /// 用户信息
        /// </summary>
        private string userName;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Sender(string userName)
        {
            LocalIP = GetLocalIP();
            this.userName = userName;
        }

        /// <summary>
        /// 初始化端口
        /// </summary>
        /// <returns>成功与否</returns>
        public bool Init()
        {
            try
            {
                UdpMessage ConnectRequestLiveRecorder = new UdpMessage("ConnectRequestLiveRecorder", userName);
                UdpMessage ConnectRequestLivePlayer = new UdpMessage("ConnectRequestLivePlayer", userName);
                UdpMessage ConnectRequestSender = new UdpMessage("ConnectRequestSender", userName);
                UdpMessage ConnectRequestReceiver = new UdpMessage("ConnectRequestReceiver", userName);
                //打开各个端口
                udpSender.Send(ServerIP, 17722, LocalIP, 17719, ConnectRequestLiveRecorder.ToString());
                udpSender.Send(ServerIP, 17722, LocalIP, 17720, ConnectRequestLivePlayer.ToString());
                udpSender.Send(ServerIP, 17722, LocalIP, 17721, ConnectRequestSender.ToString());
                udpSender.Send(ServerIP, 17721, LocalIP, 17722, ConnectRequestReceiver.ToString());
                udpSender.Send(ServerIP, 17722, LocalIP, 17722, ConnectRequestReceiver.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <returns>本地IP</returns>
        public string GetLocalIP()
        {
            string hostName = Dns.GetHostName();                    //获取主机名称  
            IPAddress[] addresses = Dns.GetHostAddresses(hostName); //解析主机IP地址  
            string netType = "InterNetwork";
            List<string> IPList = new List<string>();
            if (netType == string.Empty)
            {
                for (int i = 0; i < addresses.Length; i++)
                {
                    IPList.Add(addresses[i].ToString());
                }
            }
            else
            {
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                for (int i = 0; i < addresses.Length; i++)
                {
                    if (addresses[i].AddressFamily.ToString() == netType)
                    {
                        IPList.Add(addresses[i].ToString());
                    }
                }
            }
            int errorCount = 0;//判断是否是一个无法连接的网络
            for (int i = 0; i < IPList.Count; i++)
            {
                try
                {
                    udpSender.Send("152.136.73.240", 17722, IPList[i], 17721, new UdpMessage("","").ToString());
                    return IPList[i];
                }
                catch (System.Net.Sockets.SocketException)
                {
                    errorCount++;
                }
            }
            if (errorCount == IPList.Count)
            {
                throw new Exception("Have No Useable Network");
            }
            return "";
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        public void Send(UdpMessage message)
        {
            udpSender.Send(ServerIP, 17722, LocalIP, 17721, message.ToString());
        }
        
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        public void Send(string msg)
        {
            UdpMessage message = new UdpMessage(msg, userName, false);
            Send(message);
        }
    }

}
