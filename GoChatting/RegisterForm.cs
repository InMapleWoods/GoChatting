using GoChatting.Bll;
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
    /// 注册窗体
    /// </summary>
    public partial class RegisterForm : Form
    {
        #region 使用变量
        /// <summary>
        /// 用户操作对象
        /// </summary>
        private UserBll userBll = new UserBll();

        /// <summary>
        /// 登录窗体
        /// </summary>
        private LoginForm form;
        #endregion

        /// <summary>
        /// 注册窗体构造函数
        /// </summary>
        /// <param name="loginForm">登录窗体</param>
        public RegisterForm(LoginForm loginForm)
        {
            InitializeComponent();
            form = loginForm;
        }

        /// <summary>
        /// 注册窗体关闭事件
        /// </summary>
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Show();
            Hide();
        }

        /// <summary>
        /// 取消按钮点击事件
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void registerButton_Click(object sender, EventArgs e)
        {
            string userName = nameTextBox.Text;
            string userPassword = passwordTextBox.Text;
            string userRepeatPwd = repeatPasswordTextBox.Text;
            string account;
            try
            {
                if (!userBll.Register(userName, userPassword, userRepeatPwd, out account))
                {
                    MessageBox.Show("注册失败");
                }
                else
                {
                    MessageBox.Show("注册成功");
                    MessageBox.Show("请牢记登录账号：" + account);
                    form.SetUser(account,userPassword);
                    form.Show();
                    Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
