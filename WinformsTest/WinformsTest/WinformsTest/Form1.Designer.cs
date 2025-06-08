namespace WinformsTest
{
    partial class Form1
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
            this.BackgroundWorkerReceiver = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSender = new System.ComponentModel.BackgroundWorker();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lbChat = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(13, 277);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(621, 161);
            this.txtMessage.TabIndex = 0;
            // 
            // lbChat
            // 
            this.lbChat.FormattingEnabled = true;
            this.lbChat.ItemHeight = 16;
            this.lbChat.Location = new System.Drawing.Point(13, 13);
            this.lbChat.Name = "lbChat";
            this.lbChat.Size = new System.Drawing.Size(551, 212);
            this.lbChat.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(641, 277);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(147, 161);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbChat);
            this.Controls.Add(this.txtMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BackgroundWorkerReceiver;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSender;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox lbChat;
        private System.Windows.Forms.Button btnSend;
    }
}

