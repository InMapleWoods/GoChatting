using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Util
{
    public class UdpSender
    {
        public void Send(string desAddr, int desPort,string srcAddr,int srcPort,string message)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] btContent = Encoding.GetEncoding("utf-8").GetBytes(message);
            IPEndPoint srcIPEndPoint = new IPEndPoint(IPAddress.Parse(srcAddr), srcPort);
            IPEndPoint desIPEndPoint = new IPEndPoint(IPAddress.Parse(desAddr), desPort);
            socket.Bind(srcIPEndPoint);
            socket.SendTo(btContent, desIPEndPoint);
            socket.Close();
            socket.Dispose();
        }
        public void Send(string desAddr, int desPort,string message)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] btContent = Encoding.GetEncoding("utf-8").GetBytes(message);
            IPEndPoint desIPEndPoint = new IPEndPoint(IPAddress.Parse(desAddr), desPort);
            socket.SendTo(btContent, desIPEndPoint);
            socket.Close();
            socket.Dispose();
        }
        public void Send(string desAddr, string desPort, string srcAddr, string srcPort, string message)
        {
            Send(desAddr, int.Parse(desPort), srcAddr, int.Parse(srcPort),message);
        }
        public void Send(IPEndPoint iPEndPoint, string srcAddr, string srcPort, string message)
        {
            Send(iPEndPoint.Address.ToString(), iPEndPoint.Port, srcAddr, int.Parse(srcPort), message);
        }

    }
}
