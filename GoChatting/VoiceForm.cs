using GoChatting.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using Util;

namespace GoChatting
{
    /// <summary>
    /// 语音通话窗口
    /// </summary>
    public partial class VoiceForm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">对方信息</param>
        /// <param name="isPlay">是否是被动方</param>
        public VoiceForm(User user, List<IPEndPoint> list, string otherName, bool isPlay = false)
        {
            InitializeComponent();
            udpSender = new UDP.Sender(user.UserName);
            this.user = user;
            this.otherName = otherName;
            this.list = list;
            if (isPlay)
            {
                startButton.Text = "接通";
                endButton.Text = "挂断";
                startButton.Click += new EventHandler(startPlayButton_Click);
                endButton.Click += new EventHandler(endPlayButton_Click);
            }
            else
            {
                startButton.Text = "拨号";
                endButton.Text = "取消";
                startButton.Click += new EventHandler(startRecordButton_Click);
                endButton.Click += new EventHandler(endRecordButton_Click);
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        private User user;

        /// <summary>
        /// 对方用户信息
        /// </summary>
        private List<IPEndPoint> list;

        /// <summary>
        /// UDP控制发送
        /// </summary>
        private UDP.Sender udpSender;

        /// <summary>
        /// UDP声音发送
        /// </summary>
        private Voice.Sender voiceSender;

        /// <summary>
        /// UDP声音播放
        /// </summary>
        private Voice.Receiver voiceReceiver;

        /// <summary>
        /// 对方姓名
        /// </summary>
        private string otherName;
        private void startRecordButton_Click(object sender, EventArgs e)
        {
            udpSender.Send("ReadyToVoiceCommunicate:" + otherName);
        }

        private void endRecordButton_Click(object sender, EventArgs e)
        {
            udpSender.Send("EndVoice:" + otherName);
            End();
        }
        private void startPlayButton_Click(object sender, EventArgs e)
        {
            ReadyToPlay(list);
        }

        private void endPlayButton_Click(object sender, EventArgs e)
        {
            udpSender.Send("EndVoice:" + otherName);
            End();
        }

        public void End()
        {
            voiceSender.Disconnect();
            voiceReceiver.Disconnect();
        }

        public void ReadyToPlay(List<IPEndPoint> iPEnds)
        {
            UdpSender sender = new UdpSender();
            UdpMessage messageToA = new UdpMessage("BPlayToARec", user.UserName);
            sender.Send(iPEnds[2], udpSender.GetLocalIP(), "17720", messageToA.ToString());
            UdpMessage messageToServer = new UdpMessage("BPlayToARecHoleOpened:" + otherName, user.UserName);
            sender.Send("152.136.73.240", "17722", udpSender.GetLocalIP(), "17721", messageToServer.ToString());
            voiceReceiver.Start();
        }

        public void BPlayer(List<IPEndPoint> iPEnds)
        {
            IPEndPoint srcEndPoint = new IPEndPoint(IPAddress.Parse(udpSender.GetLocalIP()), 17719);
            voiceSender.Start(iPEnds[3], srcEndPoint);
        }

        public void ReadyToRecord(List<IPEndPoint> iPEnds)
        {
            UdpSender sender = new UdpSender();
            UdpMessage messageToB1 = new UdpMessage("ARecToBPlay", user.UserName);
            sender.Send(iPEnds[3], udpSender.GetLocalIP(), "17719", messageToB1.ToString());
            UdpMessage messageToB2 = new UdpMessage("APlayToBRec", user.UserName);
            sender.Send(iPEnds[2], udpSender.GetLocalIP(), "17720", messageToB2.ToString());
            UdpMessage messageToServer = new UdpMessage("APlayToBRecHoleOpened:" + otherName, user.UserName);
            sender.Send("152.136.73.240", "17722", udpSender.GetLocalIP(), "17721", messageToServer.ToString());
            voiceReceiver.Start();
            IPEndPoint srcEndPoint = new IPEndPoint(IPAddress.Parse(udpSender.GetLocalIP()), 17719);
            voiceSender.Start(iPEnds[3], srcEndPoint);
        }
    }
}
