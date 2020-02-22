namespace GoChatting
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
            this.connectStatusTipLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.connectStatusLabel = new System.Windows.Forms.Label();
            this.functionPanel = new System.Windows.Forms.Panel();
            this.communicatePanel = new System.Windows.Forms.Panel();
            this.showContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.communicateButton = new System.Windows.Forms.Button();
            this.communicateToolStrip = new System.Windows.Forms.ToolStrip();
            this.communicateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.communicateToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.communicateVoiceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.functionPanel.SuspendLayout();
            this.communicatePanel.SuspendLayout();
            this.communicateToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // onlineUsersComboBox
            // 
            this.onlineUsersComboBox.FormattingEnabled = true;
            this.onlineUsersComboBox.Location = new System.Drawing.Point(213, 24);
            this.onlineUsersComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.onlineUsersComboBox.Name = "onlineUsersComboBox";
            this.onlineUsersComboBox.Size = new System.Drawing.Size(135, 23);
            this.onlineUsersComboBox.TabIndex = 0;
            // 
            // onlineLabel
            // 
            this.onlineLabel.AutoSize = true;
            this.onlineLabel.Location = new System.Drawing.Point(136, 26);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(67, 15);
            this.onlineLabel.TabIndex = 1;
            this.onlineLabel.Text = "在线列表";
            // 
            // connectStatusTipLabel
            // 
            this.connectStatusTipLabel.AutoSize = true;
            this.connectStatusTipLabel.Location = new System.Drawing.Point(136, 28);
            this.connectStatusTipLabel.Name = "connectStatusTipLabel";
            this.connectStatusTipLabel.Size = new System.Drawing.Size(67, 15);
            this.connectStatusTipLabel.TabIndex = 2;
            this.connectStatusTipLabel.Text = "连接状态";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(393, 25);
            this.connectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(134, 22);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "连接";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // connectStatusLabel
            // 
            this.connectStatusLabel.AutoSize = true;
            this.connectStatusLabel.Location = new System.Drawing.Point(213, 28);
            this.connectStatusLabel.Name = "connectStatusLabel";
            this.connectStatusLabel.Size = new System.Drawing.Size(52, 15);
            this.connectStatusLabel.TabIndex = 4;
            this.connectStatusLabel.Text = "未连接";
            // 
            // functionPanel
            // 
            this.functionPanel.Controls.Add(this.communicatePanel);
            this.functionPanel.Controls.Add(this.communicateButton);
            this.functionPanel.Controls.Add(this.onlineLabel);
            this.functionPanel.Controls.Add(this.onlineUsersComboBox);
            this.functionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.functionPanel.Location = new System.Drawing.Point(0, 70);
            this.functionPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.functionPanel.Name = "functionPanel";
            this.functionPanel.Size = new System.Drawing.Size(727, 346);
            this.functionPanel.TabIndex = 5;
            // 
            // communicatePanel
            // 
            this.communicatePanel.Controls.Add(this.communicateToolStrip);
            this.communicatePanel.Controls.Add(this.showContentRichTextBox);
            this.communicatePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.communicatePanel.Location = new System.Drawing.Point(0, 70);
            this.communicatePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.communicatePanel.Name = "communicatePanel";
            this.communicatePanel.Size = new System.Drawing.Size(727, 276);
            this.communicatePanel.TabIndex = 3;
            // 
            // showContentRichTextBox
            // 
            this.showContentRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.showContentRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.showContentRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.showContentRichTextBox.Name = "showContentRichTextBox";
            this.showContentRichTextBox.Size = new System.Drawing.Size(727, 117);
            this.showContentRichTextBox.TabIndex = 1;
            this.showContentRichTextBox.Text = "";
            // 
            // communicateButton
            // 
            this.communicateButton.Location = new System.Drawing.Point(393, 24);
            this.communicateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.communicateButton.Name = "communicateButton";
            this.communicateButton.Size = new System.Drawing.Size(134, 22);
            this.communicateButton.TabIndex = 2;
            this.communicateButton.Text = "聊天";
            this.communicateButton.UseVisualStyleBackColor = true;
            // 
            // communicateToolStrip
            // 
            this.communicateToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.communicateToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.communicateToolStripButton,
            this.communicateToolStripComboBox,
            this.communicateVoiceToolStripButton});
            this.communicateToolStrip.Location = new System.Drawing.Point(0, 117);
            this.communicateToolStrip.Name = "communicateToolStrip";
            this.communicateToolStrip.Size = new System.Drawing.Size(727, 28);
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
            this.communicateToolStripButton.Text = "toolStripButton";
            // 
            // communicateToolStripComboBox
            // 
            this.communicateToolStripComboBox.Name = "communicateToolStripComboBox";
            this.communicateToolStripComboBox.Size = new System.Drawing.Size(121, 28);
            // 
            // communicateVoiceToolStripButton
            // 
            this.communicateVoiceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.communicateVoiceToolStripButton.Name = "communicateVoiceToolStripButton";
            this.communicateVoiceToolStripButton.Size = new System.Drawing.Size(73, 25);
            this.communicateVoiceToolStripButton.Text = "语音通话";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 416);
            this.Controls.Add(this.functionPanel);
            this.Controls.Add(this.connectStatusTipLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.connectStatusLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.functionPanel.ResumeLayout(false);
            this.functionPanel.PerformLayout();
            this.communicatePanel.ResumeLayout(false);
            this.communicatePanel.PerformLayout();
            this.communicateToolStrip.ResumeLayout(false);
            this.communicateToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox onlineUsersComboBox;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.Label connectStatusTipLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label connectStatusLabel;
        private System.Windows.Forms.Panel functionPanel;
        private System.Windows.Forms.Panel communicatePanel;
        private System.Windows.Forms.RichTextBox showContentRichTextBox;
        private System.Windows.Forms.Button communicateButton;
        private System.Windows.Forms.ToolStrip communicateToolStrip;
        private System.Windows.Forms.ToolStripButton communicateToolStripButton;
        private System.Windows.Forms.ToolStripComboBox communicateToolStripComboBox;
        private System.Windows.Forms.ToolStripButton communicateVoiceToolStripButton;
    }
}