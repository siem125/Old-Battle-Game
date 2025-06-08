namespace FightingGame
{
    partial class ChatArea
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlChat = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnTurns = new System.Windows.Forms.Button();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.AutoScroll = true;
            this.pnlChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChat.Location = new System.Drawing.Point(0, 33);
            this.pnlChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(272, 445);
            this.pnlChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(0, 483);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(273, 36);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.btnChat);
            this.pnlOptions.Controls.Add(this.btnTurns);
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(270, 28);
            this.pnlOptions.TabIndex = 2;
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChat.Location = new System.Drawing.Point(136, 0);
            this.btnChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(134, 28);
            this.btnChat.TabIndex = 5;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnTurns
            // 
            this.btnTurns.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTurns.Location = new System.Drawing.Point(0, 0);
            this.btnTurns.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTurns.Name = "btnTurns";
            this.btnTurns.Size = new System.Drawing.Size(134, 28);
            this.btnTurns.TabIndex = 4;
            this.btnTurns.Text = "Turns";
            this.btnTurns.UseVisualStyleBackColor = true;
            this.btnTurns.Click += new System.EventHandler(this.btnTurns_Click);
            // 
            // ChatArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.pnlChat);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChatArea";
            this.Size = new System.Drawing.Size(272, 518);
            this.pnlOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnTurns;
    }
}
