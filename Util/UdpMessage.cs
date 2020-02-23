using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    /// <summary>
    /// 信息类
    /// </summary>
    public class UdpMessage
    {
        /// <summary>
        /// 信息标题
        /// </summary>
        public string MessageType;

        /// <summary>
        /// 信息内容
        /// </summary>
        public string MessageContent;

        /// <summary>
        /// 信息发送方
        /// </summary>
        public string UserName;

        /// <summary>
        /// 信息接收方
        /// </summary>
        public string Receiver;

        /// <summary>
        /// 控制信息构造函数
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="name">控制方名称</param>
        /// <param name="isServer">是否是服务端</param>
        public UdpMessage(string message, string name, bool isServer = false)
        {
            MessageContent = message;
            if (!isServer)
            {
                MessageType = "Control_Client";
                UserName = name;
                Receiver = "Server";
            }
            else
            {
                MessageType = "Control_Server";
                UserName = "Server";
                Receiver = name;
            }
        }

        /// <summary>
        /// 交流信息构造函数
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="srcname">发送方名称</param>
        /// <param name="desname">接收方名称</param>
        public UdpMessage(string message, string srcname, string desname)
        {
            MessageType = "Communicate";
            MessageContent = message;
            UserName = srcname;
            Receiver = desname;
        }

        /// <summary>
        /// 重写ToString方法
        /// </summary>
        /// <returns>信息内容</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 获取Message对象
        /// </summary>
        /// <param name="str">要反序列化的字符串</param>
        /// <returns>Message对象</returns>
        public static UdpMessage GetUdpMessage(string str)
        {
            return JsonConvert.DeserializeObject<UdpMessage>(str);
        }
    }
}
