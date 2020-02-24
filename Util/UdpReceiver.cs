using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Util
{
    /// <summary>
    /// 接收UDP数据报
    /// </summary>
    public class UdpReceiver
    {
        /// <summary>
        /// 回调委托
        /// </summary>
        /// <param name="strinfo">输入信息</param>
        public delegate void CallBackDelegate(string strinfo);

        /// <summary>
        /// 回调委托
        /// </summary>
        /// <param name="strinfo">输入信息</param>
        public delegate void CallBackWithIPDelegate(string strinfo, string ip, string port);

        /// <summary>
        /// 回调控制台委托
        /// </summary>
        /// <param name="strinfo">输入信息</param>
        public delegate void CallBackConsoleDelegate(string strinfo);

        /// <summary>
        /// 是否侦听控制信息
        /// </summary>
        private bool listenMessage = true;

        /// <summary>
        /// 是否正在侦听
        /// </summary>
        private bool isListenning = false;

        /// <summary>
        /// 侦听信息
        /// </summary>
        /// <param name="operate">委托对象</param>
        /// <param name="console">控制台对象</param>
        public void Listenning(object operate, object console, bool isServer = false)
        {
            isListenning = true;
            int port = 17722;
            UdpClient udpclient = new UdpClient(port);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);
            Delegate callBack;
            if (!isServer)
            {
                callBack = operate as CallBackDelegate;
            }
            else
            {
                callBack = operate as CallBackWithIPDelegate;
            }
            CallBackConsoleDelegate consoleDelegate = console as CallBackConsoleDelegate;
            try
            {
                while (true)
                {
                    if (!listenMessage)
                    {
                        isListenning = false;
                        consoleDelegate("End Listenner");
                        break;
                    }
                    byte[] bytes = udpclient.Receive(ref ipendpoint);
                    string strinfo = Encoding.GetEncoding("utf-8").GetString(bytes, 0, bytes.Length);
                    string srcip = ipendpoint.Address.ToString();
                    string srcport = ipendpoint.Port.ToString();
                    if (!isServer)
                    {
                        ((CallBackDelegate)callBack)(strinfo);
                    }
                    else
                    {
                        ((CallBackWithIPDelegate)callBack)(strinfo, srcip, srcport);
                    }
                }
            }
            catch (Exception e)
            {
                consoleDelegate("Error!!!!" + e.ToString());
            }
            finally
            {
                udpclient.Close();
            }
        }

        /// <summary>
        /// 获取是否侦听
        /// </summary>
        /// <returns>侦听侦听</returns>
        public bool GetListenStatus()
        {
            return isListenning;
        }

        /// <summary>
        /// 停止侦听
        /// </summary>
        public void StopListenning()
        {
            listenMessage = false;
        }
    }
}
