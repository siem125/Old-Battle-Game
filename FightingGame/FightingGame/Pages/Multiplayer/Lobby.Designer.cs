namespace FightingGame
{
    partial class Lobby
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
            this.lbChat = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.BackgroundWorkerReceiver = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSender = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartMatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbChat
            // 
            this.lbChat.FormattingEnabled = true;
            this.lbChat.Location = new System.Drawing.Point(10, 11);
            this.lbChat.Margin = new System.Windows.Forms.Padding(2);
            this.lbChat.Name = "lbChat";
            this.lbChat.Size = new System.Drawing.Size(392, 238);
            this.lbChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(9, 259);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(439, 97);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(453, 259);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(138, 97);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // BackgroundWorkerReceiver
            // 
            this.BackgroundWorkerReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerReceiver_DoWork);
            this.BackgroundWorkerReceiver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerReceiver_ProgressChanged);
            // 
            // backgroundWorkerSender
            // 
            this.backgroundWorkerSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSender_DoWork);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(418, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 186);
            this.panel1.TabIndex = 3;
            // 
            // btnStartMatch
            // 
            this.btnStartMatch.Location = new System.Drawing.Point(420, 11);
            this.btnStartMatch.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartMatch.Name = "btnStartMatch";
            this.btnStartMatch.Size = new System.Drawing.Size(171, 47);
            this.btnStartMatch.TabIndex = 4;
            this.btnStartMatch.Text = "Start";
            this.btnStartMatch.UseVisualStyleBackColor = true;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnStartMatch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerReceiver;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartMatch;
    }
}