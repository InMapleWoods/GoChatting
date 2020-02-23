using GoChatting.Model;
using GoChatting.UDP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Util;

namespace GoChatting
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region 使用变量
        /// <summary>
        /// 当前用户
        /// </summary>
        private User user;

        /// <summary>
        /// UDP发送
        /// </summary>
        public Sender _sender;

        /// <summary>
        /// UDP接收
        /// </summary>
        public Receiver receiver;

        /// <summary>
        /// 接收线程
        /// </summary>
        public Thread receiverThread;

        /// <summary>
        /// 设置Combox数据源
        /// </summary>
        /// <param name="c">目标操作控件</param>
        /// <param name="obj">数据源</param>
        delegate void SetControlDataSourceCallback(Control c, List<string> obj);

        /// <summary>
        /// 设置控件Text
        /// </summary>
        /// <param name="c">目标操作控件</param>
        /// <param name="obj">修改文字</param>
        delegate void SetControlTextCallback(Control c, string obj);

        /// <summary>
        /// 设置控件Enable
        /// </summary>
        /// <param name="c">目标操作控件</param>
        /// <param name="obj">修改可用性</param>
        delegate void SetControlEnableCallback(Control c, bool obj);

        /// <summary>
        /// 当前登录用户列表
        /// </summary>
        List<string> speakers = new List<string>();
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">当前用户</param>
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
            _sender = new Sender(user.UserName);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _sender = new Sender(user.UserName);
            receiver = new Receiver();
        }

        /// <summary>
        /// 打开语音通话窗口
        /// </summary>
        private void communicateVoiceToolStripButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void connectButton_Click(object sender, EventArgs e)
        {
            Receiver.CallBackDelegate opCallBack = callBack;
            Receiver.CallBackConsoleDelegate consoleCallBack = formConsoleCallBack;
            receiverThread = new Thread(() => { receiver.StartListenning(opCallBack, consoleCallBack); });
            receiverThread.IsBackground = true;
            Thread.Sleep(1000);
            receiverThread.Start();
            if (_sender.Init())
            {
                Console.WriteLine("客户端连接服务器初始化完成！");
            }
            else
            {
                Console.WriteLine("失败");
            }
        }

        private void communicateButton_Click(object sender, EventArgs e)
        {

        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 控制台信息打印
        /// </summary>
        /// <param name="message">要打印的信息</param>
        private void formConsoleCallBack(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 接收端口信息并处理
        /// </summary>
        /// <param name="message">信息</param>
        private void callBack(string message)
        {
            UdpMessage udpMessage = UdpMessage.GetUdpMessage(message);
            string content = udpMessage.MessageContent;
            if (udpMessage.MessageType == "Control_Server")
            {
                if (content == "ConnectSuccess")
                {
                    setObj(connectStatusLabel, "连接成功");
                    setObj(functionPanel, true);
                }
                else if (Regex.IsMatch(content, "Speaker:(.*)"))
                {
                    string name = Regex.Match(content, "Speaker:(.*)").Groups[1].Value.ToString();
                    if (!speakers.Contains(name))
                    {
                        speakers.Add(name);
                    }
                    setObj(onlineUsersComboBox, speakers);
                }
            }
            else if (udpMessage.MessageType == "Communicate")
            {

            }
        }

        /// <summary>
        /// 设置控件Text
        /// </summary>
        public void setObj(Control c, string obj)
        {
            if (c.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                while (c.IsHandleCreated == false)
                {
                    if (c.Disposing || c.IsDisposed) return;
                }
                SetControlTextCallback d = new SetControlTextCallback(setObj);
                c.Invoke(d, new object[] { c, obj });

            }
            else
            {
                c.Text = obj;
            }
        }

        /// <summary>
        /// 设置Combox数据源
        /// </summary>
        public void setObj(Control c, List<string> obj)
        {
            if (c.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                while (c.IsHandleCreated == false)
                {
                    if (c.Disposing || c.IsDisposed) return;
                }
                SetControlDataSourceCallback d = new SetControlDataSourceCallback(setObj);
                c.Invoke(d, new object[] { c, obj });

            }
            else
            {
                ((ComboBox)c).DataSource = obj;
            }
        }

        /// <summary>
        /// 设置控件Enable
        /// </summary>
        public void setObj(Control c, bool enable)
        {
            if (c.InvokeRequired)
            {
                // 解决窗体关闭时出现“访问已释放句柄”异常
                while (c.IsHandleCreated == false)
                {
                    if (c.Disposing || c.IsDisposed) return;
                }
                SetControlEnableCallback d = new SetControlEnableCallback(setObj);
                c.Invoke(d, new object[] { c, enable });

            }
            else
            {
                c.Enabled = enable;
            }
        }

    }
}
