namespace FightingGame
{
    partial class Homescreen
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
            this.btnLobby = new System.Windows.Forms.Button();
            this.btnSingleplayer = new System.Windows.Forms.Button();
            this.btnShop = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLobby
            // 
            this.btnLobby.Location = new System.Drawing.Point(414, 60);
            this.btnLobby.Name = "btnLobby";
            this.btnLobby.Size = new System.Drawing.Size(374, 221);
            this.btnLobby.TabIndex = 0;
            this.btnLobby.Text = "Enter lobby";
            this.btnLobby.UseVisualStyleBackColor = true;
            this.btnLobby.Click += new System.EventHandler(this.btnLobby_Click);
            // 
            // btnSingleplayer
            // 
            this.btnSingleplayer.Location = new System.Drawing.Point(12, 60);
            this.btnSingleplayer.Name = "btnSingleplayer";
            this.btnSingleplayer.Size = new System.Drawing.Size(374, 221);
            this.btnSingleplayer.TabIndex = 1;
            this.btnSingleplayer.Text = "Enter singleplayer";
            this.btnSingleplayer.UseVisualStyleBackColor = true;
            this.btnSingleplayer.Click += new System.EventHandler(this.btnSingleplayer_Click);
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(12, 287);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(776, 151);
            this.btnShop.TabIndex = 2;
            this.btnShop.Text = "Enter shop";
            this.btnShop.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(675, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(113, 41);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // Homescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnShop);
            this.Controls.Add(this.btnSingleplayer);
            this.Controls.Add(this.btnLobby);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Homescreen";
            this.Text = "Homescreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLobby;
        private System.Windows.Forms.Button btnSingleplayer;
        private System.Windows.Forms.Button btnShop;
        private System.Windows.Forms.Button btnSettings;
    }
}