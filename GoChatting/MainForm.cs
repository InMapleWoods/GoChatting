using GoChatting.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">当前用户</param>
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开语音通话窗口
        /// </summary>
        private void communicateVoiceToolStripButton_Click(object sender, EventArgs e)
        {

        }
    }
}
