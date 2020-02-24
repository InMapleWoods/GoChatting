using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Util;

namespace LinuxServer
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
        /// 服务器IP
        /// </summary>
        private string ServerIP = "172.21.0.10";

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        /// <param name="iPEndPoint">接收方地址</param>
        public void Send(UdpMessage message, IPEndPoint iPEndPoint)
        {
            udpSender.Send(iPEndPoint, ServerIP, "17721", message.ToString());
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        /// <param name="name">接收用户名</param>
        /// <param name="iPEndPoint">接收方地址</param>
        public void Send(string message, string name, IPEndPoint iPEndPoint)
        {
            UdpMessage udpMessage = new UdpMessage(message, name, true);
            Send(udpMessage, iPEndPoint);
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        /// <param name="ip">接收方地址</param>
        /// <param name="port">接收方地址</param>
        public void Send(UdpMessage message, string ip, string port)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            Send(message, iPEndPoint);
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="message">待发送信息</param>
        /// <param name="name">接收用户名</param>
        /// <param name="ip">接收方地址</param>
        /// <param name="port">接收方地址</param>
        public void Send(string message, string name, string ip, string port)
        {
            UdpMessage udpMessage = new UdpMessage(message, name, true);
            Send(udpMessage, ip, port);
        }
    }

}
