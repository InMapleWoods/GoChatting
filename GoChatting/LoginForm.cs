﻿using GoChatting.Bll;
using GoChatting.Model;
using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace GoChatting
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        #region 使用变量
        /// <summary>
        /// 用户操作对象
        /// </summary>
        private UserBll userBll = new UserBll();

        /// <summary>
        /// 验证码对象
        /// </summary>
        private Captcha captcha = new Captcha();

        /// <summary>
        /// 错误次数
        /// </summary>
        private int errorCount = 0;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            errorCount = 0;
            captchaPanel.BackgroundImage = captcha.GetValidate(4);
        }

        /// <summary>
        /// 验证码点击事件
        /// </summary>
        private void captchaPanel_Click(object sender, EventArgs e)
        {
            captchaPanel.BackgroundImage = captcha.GetValidate(4);//更换验证码图片
        }

        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        private void loginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        /// <summary>
        /// 获取按键
        /// </summary>
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)//如果按下回车键
            {
                if (accountTextBox.Focused)//若正在输入账号
                {
                    passwordTextBox.Focus();
                }
                else if (passwordTextBox.Focused)//若正在输入密码
                {
                    if (captchaTextBox.Visible)//若要求输入验证码
                    {
                        captchaTextBox.Focus();
                    }
                    else//不要求输入验证码
                    {
                        Login();
                    }
                }
            }
        }
        private void Login()
        {
            if (IsOnLine())
            {
                if (errorCount >= 3)//3次登录失败后输入验证码
                {
                    captchaLabel.Visible = true;//显示验证码提示
                    captchaPanel.Visible = true;//显示验证码图片
                    captchaTextBox.Visible = true;//显示验证码输入框
                                                  //获取用户输入验证码
                    string captchaText = captchaTextBox.Text.Trim().ToLower();
                    if (string.IsNullOrEmpty(captchaText))
                    {
                        MessageBox.Show("请输入验证码");
                        return;
                    }
                    //判断验证码是否相等
                    if (captchaText != captcha.GetValidateNum().ToLower())
                    {
                        errorCount++;//错误次数增加
                        return;
                    }
                }
                string account = accountTextBox.Text;//获取输入账号
                string password = passwordTextBox.Text;//获取输入密码
                try
                {
                    if (!userBll.Login(account, password))
                    {
                        errorCount++;//错误次数增加
                        return;
                    }
                    else
                    {
                        MessageBox.Show("登录成功");
                        User user = userBll.GetUserLogin(account);//获取登录用户
                        MainForm mainForm = new MainForm(user);
                        mainForm.Show();
                        Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    errorCount++;//错误次数增加
                }
                captchaPanel.BackgroundImage = captcha.GetValidate(4);
            }
            else
            {
                MessageBox.Show("未联网");
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();//退出程序
        }

        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        private void registerLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsOnLine())
            {
                RegisterForm registerForm = new RegisterForm(this);
                registerForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("未联网");
            }
        }

        /// <summary>
        /// 设置登录窗体用户账号和密码
        /// </summary>
        /// <param name="userAccount">用户账号</param>
        /// <param name="userPassword">用户密码</param>
        /// <returns>设置成功与否</returns>
        public bool SetUser(string userAccount, string userPassword)
        {
            try
            {
                accountTextBox.Text = userAccount;
                passwordTextBox.Text = userPassword;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 判断是否联网
        /// </summary>
        /// <returns>是否联网</returns>
        private bool IsOnLine()
        {
            try
            {
                Ping objPingSender = new Ping();
                PingOptions objPinOptions = new PingOptions
                {
                    DontFragment = true
                };
                string data = "";
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int intTimeout = 1000;
                PingReply objPinReply = objPingSender.Send("152.136.73.240", intTimeout, buffer, objPinOptions);
                string strInfo = objPinReply.Status.ToString();
                if (strInfo == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
