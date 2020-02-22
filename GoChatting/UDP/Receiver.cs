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
    public class Receiver
    {
        /// <summary>
        /// 回调委托
        /// </summary>
        /// <param name="strinfo">输入信息</param>
        delegate void CallBackDelegate(string strinfo);
        
        /// <summary>
        /// 是否
        /// </summary>
        bool listenMessage = true;
        bool isListenning = false;
        bool isConnecting = false;
        private void StartListenning(object o)
        {
            isListenning = true;
            int port = 17722;
            UdpClient udpclient = new UdpClient(port);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);
            CallBackDelegate callBack = o as CallBackDelegate;
            try
            {
                while (true)
                {
                    if (!listenMessage)
                    {
                        Console.WriteLine("End Listenner");
                        break;
                    }
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    string strinfo = Encoding.GetEncoding("utf-8").GetString(bytes, 0, bytes.Length);
                    callBack(strinfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!!!!" + e.ToString());
            }
            finally
            {
                udpclient.Close();
            }
        }
    }
}
