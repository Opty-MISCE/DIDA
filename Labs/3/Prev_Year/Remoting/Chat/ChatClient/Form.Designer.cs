namespace Chat {
    partial class Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TB1 = new System.Windows.Forms.TextBox();
            this.IPTB = new System.Windows.Forms.TextBox();
            this.TB2 = new System.Windows.Forms.TextBox();
            this.PortTB = new System.Windows.Forms.TextBox();
            this.TB3 = new System.Windows.Forms.TextBox();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.TB4 = new System.Windows.Forms.TextBox();
            this.ChatTB = new System.Windows.Forms.TextBox();
            this.TB5 = new System.Windows.Forms.TextBox();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB1
            // 
            this.TB1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB1.Location = new System.Drawing.Point(50, 29);
            this.TB1.Name = "TB1";
            this.TB1.ReadOnly = true;
            this.TB1.Size = new System.Drawing.Size(223, 13);
            this.TB1.TabIndex = 0;
            this.TB1.TabStop = false;
            this.TB1.Text = "Chat Server IP";
            this.TB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPTB
            // 
            this.IPTB.Location = new System.Drawing.Point(50, 48);
            this.IPTB.Name = "IPTB";
            this.IPTB.Size = new System.Drawing.Size(223, 20);
            this.IPTB.TabIndex = 1;
            // 
            // TB2
            // 
            this.TB2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB2.Location = new System.Drawing.Point(279, 29);
            this.TB2.Name = "TB2";
            this.TB2.ReadOnly = true;
            this.TB2.Size = new System.Drawing.Size(130, 13);
            this.TB2.TabIndex = 2;
            this.TB2.TabStop = false;
            this.TB2.Text = "Chat Server Port";
            this.TB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PortTB
            // 
            this.PortTB.Location = new System.Drawing.Point(279, 48);
            this.PortTB.Name = "PortTB";
            this.PortTB.Size = new System.Drawing.Size(130, 20);
            this.PortTB.TabIndex = 3;
            // 
            // TB3
            // 
            this.TB3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB3.Location = new System.Drawing.Point(415, 29);
            this.TB3.Name = "TB3";
            this.TB3.ReadOnly = true;
            this.TB3.Size = new System.Drawing.Size(254, 13);
            this.TB3.TabIndex = 4;
            this.TB3.TabStop = false;
            this.TB3.Text = "User Name";
            this.TB3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserNameTB
            // 
            this.UserNameTB.Location = new System.Drawing.Point(415, 48);
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(254, 20);
            this.UserNameTB.TabIndex = 5;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(675, 22);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 46);
            this.ConnectButton.TabIndex = 6;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TB4
            // 
            this.TB4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB4.Location = new System.Drawing.Point(50, 107);
            this.TB4.Name = "TB4";
            this.TB4.ReadOnly = true;
            this.TB4.Size = new System.Drawing.Size(359, 13);
            this.TB4.TabIndex = 7;
            this.TB4.TabStop = false;
            this.TB4.Text = "Chat Messages";
            this.TB4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChatTB
            // 
            this.ChatTB.Location = new System.Drawing.Point(50, 126);
            this.ChatTB.Multiline = true;
            this.ChatTB.Name = "ChatTB";
            this.ChatTB.Size = new System.Drawing.Size(359, 184);
            this.ChatTB.TabIndex = 8;
            // 
            // TB5
            // 
            this.TB5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB5.Location = new System.Drawing.Point(415, 107);
            this.TB5.Name = "TB5";
            this.TB5.ReadOnly = true;
            this.TB5.Size = new System.Drawing.Size(254, 13);
            this.TB5.TabIndex = 9;
            this.TB5.TabStop = false;
            this.TB5.Text = "Message";
            this.TB5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(415, 126);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(254, 184);
            this.MessageTB.TabIndex = 10;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(675, 126);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 184);
            this.SendButton.TabIndex = 11;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(675, 74);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(100, 46);
            this.DisconnectButton.TabIndex = 12;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 347);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.TB5);
            this.Controls.Add(this.ChatTB);
            this.Controls.Add(this.TB4);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.UserNameTB);
            this.Controls.Add(this.TB3);
            this.Controls.Add(this.PortTB);
            this.Controls.Add(this.TB2);
            this.Controls.Add(this.IPTB);
            this.Controls.Add(this.TB1);
            this.Name = "Form";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB1;
        private System.Windows.Forms.TextBox IPTB;
        private System.Windows.Forms.TextBox TB2;
        private System.Windows.Forms.TextBox PortTB;
        private System.Windows.Forms.TextBox TB3;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox TB4;
        private System.Windows.Forms.TextBox ChatTB;
        private System.Windows.Forms.TextBox TB5;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button DisconnectButton;
    }
}
