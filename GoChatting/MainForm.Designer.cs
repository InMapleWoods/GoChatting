﻿namespace GoChatting
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.onlineUsersComboBox = new System.Windows.Forms.ComboBox();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.functionPanel = new System.Windows.Forms.Panel();
            this.switchButton = new System.Windows.Forms.Button();
            this.communicatePanel = new System.Windows.Forms.Panel();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.readySendRichTextBox = new System.Windows.Forms.RichTextBox();
            this.communicateToolStrip = new System.Windows.Forms.ToolStrip();
            this.communicateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.communicateToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.communicateVoiceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.showContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.communicateButton = new System.Windows.Forms.Button();
            this.connectStatusLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectStatusTipLabel = new System.Windows.Forms.Label();
            this.functionPanel.SuspendLayout();
            this.communicatePanel.SuspendLayout();
            this.communicateToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // onlineUsersComboBox
            // 
            this.onlineUsersComboBox.FormattingEnabled = true;
            this.onlineUsersComboBox.Location = new System.Drawing.Point(240, 32);
            this.onlineUsersComboBox.Name = "onlineUsersComboBox";
            this.onlineUsersComboBox.Size = new System.Drawing.Size(151, 28);
            this.onlineUsersComboBox.TabIndex = 0;
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(153, 35);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(69, 20);
            this.onlineLabel.TabIndex = 1;
            this.onlineLabel.Text = "在线列表";
            // 
            // functionPanel
            // 
            this.functionPanel.Controls.Add(this.switchButton);
            this.functionPanel.Controls.Add(this.communicatePanel);
            this.functionPanel.Controls.Add(this.communicateButton);
            this.functionPanel.Controls.Add(this.onlineLabel);
            this.functionPanel.Controls.Add(this.onlineUsersComboBox);
            this.functionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.functionPanel.Enabled = false;
            this.functionPanel.Location = new System.Drawing.Point(0, 105);
            this.functionPanel.Name = "functionPanel";
            this.functionPanel.Size = new System.Drawing.Size(813, 461);
            this.functionPanel.TabIndex = 5;
            // 
            // switchButton
            // 
            this.switchButton.Location = new System.Drawing.Point(527, 32);
            this.switchButton.Name = "switchButton";
            this.switchButton.Size = new System.Drawing.Size(66, 29);
            this.switchButton.TabIndex = 4;
            this.switchButton.Text = "切换";
            this.switchButton.UseVisualStyleBackColor = true;
            this.switchButton.Click += new System.EventHandler(this.switchButton_Click);
            // 
            // communicatePanel
            // 
            this.communicatePanel.Controls.Add(this.sendMessageButton);
            this.communicatePanel.Controls.Add(this.readySendRichTextBox);
            this.communicatePanel.Controls.Add(this.communicateToolStrip);
            this.communicatePanel.Controls.Add(this.showContentRichTextBox);
            this.communicatePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.communicatePanel.Enabled = false;
            this.communicatePanel.Location = new System.Drawing.Point(0, 93);
            this.communicatePanel.Name = "communicatePanel";
            this.communicatePanel.Size = new System.Drawing.Size(813, 368);
            this.communicatePanel.TabIndex = 3;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendMessageButton.Location = new System.Drawing.Point(0, 326);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(813, 42);
            this.sendMessageButton.TabIndex = 4;
            this.sendMessageButton.Text = "发送";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // readySendRichTextBox
            // 
            this.readySendRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.readySendRichTextBox.Location = new System.Drawing.Point(0, 183);
            this.readySendRichTextBox.Name = "readySendRichTextBox";
            this.readySendRichTextBox.Size = new System.Drawing.Size(813, 143);
            this.readySendRichTextBox.TabIndex = 3;
            this.readySendRichTextBox.Text = "";
            // 
            // communicateToolStrip
            // 
            this.communicateToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.communicateToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.communicateToolStripButton,
            this.communicateToolStripComboBox,
            this.communicateVoiceToolStripButton});
            this.communicateToolStrip.Location = new System.Drawing.Point(0, 155);
            this.communicateToolStrip.Name = "communicateToolStrip";
            this.communicateToolStrip.Size = new System.Drawing.Size(813, 28);
            this.communicateToolStrip.TabIndex = 2;
            this.communicateToolStrip.Text = "toolStrip";
            // 
            // communicateToolStripButton
            // 
            this.communicateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.communicateToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("communicateToolStripButton.Image")));
            this.communicateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.communicateToolStripButton.Name = "communicateToolStripButton";
            this.communicateToolStripButton.Size = new System.Drawing.Size(29, 25);
            this.communicateToolStripButton.Text = "表情";
            // 
            // communicateToolStripComboBox
            // 
            this.communicateToolStripComboBox.Name = "communicateToolStripComboBox";
            this.communicateToolStripComboBox.Size = new System.Drawing.Size(136, 28);
            // 
            // communicateVoiceToolStripButton
            // 
            this.communicateVoiceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.communicateVoiceToolStripButton.Name = "communicateVoiceToolStripButton";
            this.communicateVoiceToolStripButton.Size = new System.Drawing.Size(73, 25);
            this.communicateVoiceToolStripButton.Text = "语音通话";
            this.communicateVoiceToolStripButton.Click += new System.EventHandler(this.communicateVoiceToolStripButton_Click);
            // 
            // showContentRichTextBox
            // 
            this.showContentRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.showContentRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.showContentRichTextBox.Name = "showContentRichTextBox";
            this.showContentRichTextBox.ReadOnly = true;
            this.showContentRichTextBox.Size = new System.Drawing.Size(813, 155);
            this.showContentRichTextBox.TabIndex = 1;
            this.showContentRichTextBox.Text = "";
            // 
            // communicateButton
            // 
            this.communicateButton.Location = new System.Drawing.Point(442, 32);
            this.communicateButton.Name = "communicateButton";
            this.communicateButton.Size = new System.Drawing.Size(63, 29);
            this.communicateButton.TabIndex = 2;
            this.communicateButton.Text = "聊天";
            this.communicateButton.UseVisualStyleBackColor = true;
            this.communicateButton.Click += new System.EventHandler(this.communicateButton_Click);
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.AutoSize = true;
            this.connectStatusLabel.Location = new System.Drawing.Point(240, 42);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.connectStatusLabel.TabIndex = 4;
            this.connectStatusLabel.Text = "未连接";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(442, 38);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(151, 29);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "连接";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // connectStatusTipLabel
            // 
            this.connectStatusTipLabel.AutoSize = true;
            this.connectStatusTipLabel.Location = new System.Drawing.Point(153, 42);
            this.connectStatusTipLabel.Name = "connectStatusTipLabel";
            this.connectStatusTipLabel.Size = new System.Drawing.Size(69, 20);
            this.connectStatusTipLabel.TabIndex = 2;
            this.connectStatusTipLabel.Text = "连接状态";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 566);
            this.Controls.Add(this.connectStatusTipLabel);
            this.Controls.Add(this.connectStatusLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.functionPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.functionPanel.ResumeLayout(false);
            this.functionPanel.PerformLayout();
            this.communicatePanel.ResumeLayout(false);
            this.communicatePanel.PerformLayout();
            this.communicateToolStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox onlineUsersComboBox;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.Panel functionPanel;
        private System.Windows.Forms.Panel communicatePanel;
        private System.Windows.Forms.RichTextBox showContentRichTextBox;
        private System.Windows.Forms.Button communicateButton;
        private System.Windows.Forms.ToolStrip communicateToolStrip;
        private System.Windows.Forms.ToolStripButton communicateToolStripButton;
        private System.Windows.Forms.ToolStripComboBox communicateToolStripComboBox;
        private System.Windows.Forms.ToolStripButton communicateVoiceToolStripButton;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.RichTextBox readySendRichTextBox;
        private System.Windows.Forms.Label connectStatusLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectStatusTipLabel;
        private System.Windows.Forms.Button switchButton;
    }
}