using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using Util;

namespace LinuxServer
{
    /// <summary>
    /// 接收类
    /// </summary>
    public class UDPReceiver
    {
        /// <summary>
        /// 用户仓库对象
        /// </summary>
        UserHub userHub = new UserHub();
        /// <summary>
        /// UDP接收
        /// </summary>
        public Receiver receiver = new Receiver();
        /// <summary>
        /// 接收线程
        /// </summary>
        public Thread receiverThread;
        public void StartListenning()
        {
            UdpReceiver.CallBackWithIPDelegate opCallBack = ServerStartListener;
            UdpReceiver.CallBackConsoleDelegate consoleCallBack = formConsoleCallBack;
            receiverThread = new Thread(() => { receiver.StartListenning(opCallBack, consoleCallBack); });
            receiverThread.IsBackground = true;
            Thread.Sleep(1000);
            receiverThread.Start();
        }

        /// <summary>
        /// 侦听回调
        /// </summary>
        /// <param name="message">内容</param>
        /// <param name="srcip">发送者公网IP</param>
        /// <param name="srcport">发送者公网端口</param>
        private void ServerStartListener(string message, string srcip, string srcport)
        {
            UdpMessage udpMessage = UdpMessage.GetUdpMessage(message);
            List<IPEndPoint> iPs = new List<IPEndPoint>();
            Sender udpSender = new Sender();
            string strinfo = udpMessage.MessageContent;
            string name = udpMessage.UserName;
            string desname = udpMessage.Receiver;
            try
            {
                if (udpMessage.MessageType == MessageType.Control_Client)
                {
                    if (Regex.IsMatch(strinfo, "ConnectRequest(.*)"))
                    {
                        Match match = Regex.Match(strinfo, "ConnectRequest(.*)");
                        string op = match.Groups[1].Value.ToString();
                        User user = new User(name);
                        userHub.AddUser(user);
                        if (op == "Sender")
                        {
                            userHub.SetUserSendPoint(name, srcip, srcport);
                        }
                        else if (op == "Receiver")
                        {
                            userHub.SetUserReceivePoint(name, srcip, srcport);
                        }
                        else if (op == "LiveRecorder")
                        {
                            userHub.SetUserRecordPoint(name, srcip, srcport);
                        }
                        else if (op == "LivePlayer")
                        {
                            userHub.SetUserListenPoint(name, srcip, srcport);
                        }
                        UdpMessage msg = new UdpMessage("ConnectResponse" + op, name, true);
                        Timer timer = new Timer((state) =>
                        {
                            udpSender.Send(msg,
                                (string)((object[])state)[0],
                                (string)((object[])state)[1]
                                );
                        }, new object[] { srcip, srcport }, 2000, 60000);
                    }
                    else if (strinfo == "Connect")
                    {
                        IPEndPoint iPEndPoint = GetReceiverOfUser(name);
                        if (iPEndPoint != null)
                        {
                            foreach (var i in userHub.GetUsers())
                            {
                                udpSender.Send("Onliner:" + i.Name, name, iPEndPoint);
                            }
                            udpSender.Send("ConnectSuccess", name, iPEndPoint);
                            Console.WriteLine(name + "已连接");
                        }
                    }
                    else if (strinfo == "DisConnect")
                    {
                        userHub.RemoveUser(name);
                        Console.WriteLine(name + "断开连接");
                    }
                    else if (Regex.IsMatch(strinfo, "RequestUserInfo:(.*)"))
                    {
                        #region A->B A端
                        IPEndPoint AiPEndPoint = GetReceiverOfUser(name);
                        Match match = Regex.Match(strinfo, "RequestUserInfo:(.*)");
                        string requestName = match.Groups[1].Value.ToString();
                        string[] ips = GetAllAddrOfUser(requestName);
                        string msg = JsonConvert.SerializeObject(new object[] { requestName, ips });
                        udpSender.Send("ResponseUserInfo:" + msg, name, AiPEndPoint);
                        #endregion
                        #region A->B B端
                        IPEndPoint BiPEndPoint = GetReceiverOfUser(requestName);
                        udpSender.Send("BeReadyForCommunicate:" + name, requestName, BiPEndPoint);
                        #endregion
                    }
                    else if(Regex.IsMatch(strinfo, "ReadyToVoiceCommunicate:(.*)"))
                    {
                        #region A->B A端
                        Match match = Regex.Match(strinfo, "ReadyToVoiceCommunicate:(.*)");
                        string requestName = match.Groups[1].Value.ToString();
                        #endregion
                        #region A->B B端
                        IPEndPoint BiPEndPoint = GetReceiverOfUser(requestName);
                        udpSender.Send("ReadyToVoiceCommunicate:" + name, requestName, BiPEndPoint);
                        #endregion
                    }
                    else if(Regex.IsMatch(strinfo, "BPlayToARecHoleOpened:(.*)"))
                    {
                        #region A->B B端
                        Match match = Regex.Match(strinfo, "BPlayToARecHoleOpened:(.*)");
                        string requestName = match.Groups[1].Value.ToString();
                        #endregion
                        #region A->B A端
                        IPEndPoint AiPEndPoint = GetReceiverOfUser(requestName);
                        udpSender.Send("BPlayToARec:"+name, requestName, AiPEndPoint);
                        #endregion
                    }
                    else if(Regex.IsMatch(strinfo, "APlayToBRecHoleOpened:(.*)"))
                    {
                        #region A->B A端
                        Match match = Regex.Match(strinfo, "APlayToBRecHoleOpened:(.*)");
                        string requestName = match.Groups[1].Value.ToString();
                        #endregion
                        #region A->B B端
                        IPEndPoint BiPEndPoint = GetReceiverOfUser(requestName);
                        udpSender.Send("APlayToBRec:" + name, requestName, BiPEndPoint);
                        #endregion
                    }
                    else if(Regex.IsMatch(strinfo, "EndVoice:(.*)"))
                    {
                        Match match = Regex.Match(strinfo, "EndVoice:(.*)");
                        string requestName = match.Groups[1].Value.ToString();
                        IPEndPoint BiPEndPoint = GetReceiverOfUser(requestName);
                        udpSender.Send("EndVoice", name, BiPEndPoint);
                    }
                }
                else if (udpMessage.MessageType == MessageType.Communicate)
                {
                    udpSender.Send(udpMessage, GetReceiverOfUser(desname));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private IPEndPoint GetReceiverOfUser(string name)
        {
            User user = userHub.GetUser(name);
            if (user != null)
            {
                if (user.Listenpoint != null && user.Sendpoint != null && user.Receivepoint != null && user.Recordpoint != null)
                {
                    return user.Receivepoint;
                }
            }
            return null;
        }
        private string[] GetAllAddrOfUser(string name)
        {
            User user = userHub.GetUser(name);
            if (user != null)
            {
                if (user.Listenpoint != null && user.Sendpoint != null && user.Receivepoint != null && user.Recordpoint != null)
                {
                    return new string[] { GetStringOfIPEndPoint(user.Sendpoint), GetStringOfIPEndPoint(user.Receivepoint), GetStringOfIPEndPoint(user.Recordpoint), GetStringOfIPEndPoint(user.Listenpoint) };
                }
            }
            return null;
        }
        private IPEndPoint GetSenderOfUser(string name)
        {
            User user = userHub.GetUser(name);
            if (user != null)
            {
                if (user.Listenpoint != null && user.Sendpoint != null && user.Receivepoint != null && user.Recordpoint != null)
                {
                    return user.Sendpoint;
                }
            }
            return null;
        }
        private IPEndPoint GetListennerOfUser(string name)
        {
            User user = userHub.GetUser(name);
            if (user != null)
            {
                if (user.Listenpoint != null && user.Sendpoint != null && user.Receivepoint != null && user.Recordpoint != null)
                {
                    return user.Listenpoint;
                }
            }
            return null;
        }

        private IPEndPoint GetRecorderOfUser(string name)
        {
            User user = userHub.GetUser(name);
            if (user != null)
            {
                if (user.Listenpoint != null && user.Sendpoint != null && user.Receivepoint != null && user.Recordpoint != null)
                {
                    return user.Recordpoint;
                }
            }
            return null;
        }

        private string GetStringOfIPEndPoint(IPEndPoint iPEndPoint)
        {
            if (iPEndPoint != null)
            {
                return ("IP|" + iPEndPoint.Address.ToString() + "|PORT|" + iPEndPoint.Port);
            }
            return null;
        }

        /// <summary>
        /// 控制台信息打印
        /// </summary>
        /// <param name="message">要打印的信息</param>
        private void formConsoleCallBack(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        public static int Id { get; set; } = 0;
        public string Name { get; set; }
        public IPEndPoint Sendpoint { get; set; }
        public IPEndPoint Receivepoint { get; set; }
        public IPEndPoint Listenpoint { get; set; }
        public IPEndPoint Recordpoint { get; set; }

        public User(string name)
        {
            Id += 1;
            Name = name;
        }
    }

    /// <summary>
    /// 用户仓库类
    /// </summary>
    public class UserHub
    {
        private List<User> users = new List<User>();
        public List<User> GetUsers()
        {
            return users;
        }
        public User GetUser(string userName)
        {
            var user = from i in users
                       where i.Name == userName
                       select i;
            if (user.Count() > 0)
                return user.ToArray()[0];
            return null;
        }
        public void AddUser(User user)
        {
            if (GetUser(user.Name) == null)
                users.Add(user);
        }

        public void RemoveUser(User user)
        {
            if (GetUser(user.Name) != null)
                users.Remove(user);
        }

        public void RemoveUser(string userName)
        {
            var item = from i in users
                       where i.Name == userName
                       select i;
            var items = item.ToList();
            if (items.Count() > 0)
            {
                foreach (var i in items)
                {
                    users.Remove(i);
                }
            }
        }

        #region Send
        public void SetUserSendPoint(string userName, string ip, int port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            user.Sendpoint = iPEndPoint;
        }
        public void SetUserSendPoint(string userName, string ip, string port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            user.Sendpoint = iPEndPoint;
        }
        public void SetUserSendPoint(string userName, IPEndPoint iPEndPoint)
        {
            User user = GetUser(userName);
            user.Sendpoint = iPEndPoint;
        }
        #endregion
        #region Receive
        public void SetUserReceivePoint(string userName, string ip, int port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            user.Receivepoint = iPEndPoint;
        }
        public void SetUserReceivePoint(string userName, string ip, string port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            user.Receivepoint = iPEndPoint;
        }
        public void SetUserReceivePoint(string userName, IPEndPoint iPEndPoint)
        {
            User user = GetUser(userName);
            user.Receivepoint = iPEndPoint;
        }
        #endregion
        #region Listen
        public void SetUserListenPoint(string userName, string ip, int port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            user.Listenpoint = iPEndPoint;
        }
        public void SetUserListenPoint(string userName, string ip, string port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            user.Listenpoint = iPEndPoint;
        }
        public void SetUserListenPoint(string userName, IPEndPoint iPEndPoint)
        {
            User user = GetUser(userName);
            user.Listenpoint = iPEndPoint;
        }
        #endregion
        #region Record
        public void SetUserRecordPoint(string userName, string ip, int port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            user.Recordpoint = iPEndPoint;
        }
        public void SetUserRecordPoint(string userName, string ip, string port)
        {
            User user = GetUser(userName);
            IPAddress iPAddress = IPAddress.Parse(ip);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            user.Recordpoint = iPEndPoint;
        }
        public void SetUserRecordPoint(string userName, IPEndPoint iPEndPoint)
        {
            User user = GetUser(userName);
            user.Recordpoint = iPEndPoint;
        }
        #endregion
    }

    /// <summary>
    /// 接收UDP数据报
    /// </summary>
    public class Receiver : Util.UdpReceiver
    {
        /// <summary>
        /// 侦听信息
        /// </summary>
        /// <param name="operate">委托对象</param>
        /// <param name="console">控制台对象</param>
        public void StartListenning(object operate, object console)
        {
            Listenning(operate, console, true);
        }
    }
}
