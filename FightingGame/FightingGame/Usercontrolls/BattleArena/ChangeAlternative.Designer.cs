namespace FightingGame
{
    partial class ChangeAlternative
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
            this.lblMaxHealth = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentHealth = new System.Windows.Forms.Label();
            this.flpAilments = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaxHealth
            // 
            this.lblMaxHealth.AutoSize = true;
            this.lblMaxHealth.Location = new System.Drawing.Point(102, 103);
            this.lblMaxHealth.Name = "lblMaxHealth";
            this.lblMaxHealth.Size = new System.Drawing.Size(42, 16);
            this.lblMaxHealth.TabIndex = 11;
            this.lblMaxHealth.Text = "40000";
            this.lblMaxHealth.Click += new System.EventHandler(this.Clicker);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "/";
            this.label3.Click += new System.EventHandler(this.Clicker);
            // 
            // lblCurrentHealth
            // 
            this.lblCurrentHealth.AutoSize = true;
            this.lblCurrentHealth.Location = new System.Drawing.Point(2, 103);
            this.lblCurrentHealth.Name = "lblCurrentHealth";
            this.lblCurrentHealth.Size = new System.Drawing.Size(42, 16);
            this.lblCurrentHealth.TabIndex = 9;
            this.lblCurrentHealth.Text = "20000";
            this.lblCurrentHealth.Click += new System.EventHandler(this.Clicker);
            // 
            // flpAilments
            // 
            this.flpAilments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpAilments.Location = new System.Drawing.Point(100, 8);
            this.flpAilments.Name = "flpAilments";
            this.flpAilments.Size = new System.Drawing.Size(65, 72);
            this.flpAilments.TabIndex = 8;
            this.flpAilments.Click += new System.EventHandler(this.Clicker);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(2, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(115, 16);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "NameOfCharacter";
            this.lblName.Click += new System.EventHandler(this.Clicker);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(2, 8);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(91, 72);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 6;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.Clicker);
            // 
            // ChangeAlternative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblMaxHealth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurrentHealth);
            this.Controls.Add(this.flpAilments);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbImage);
            this.Name = "ChangeAlternative";
            this.Size = new System.Drawing.Size(166, 120);
            this.Click += new System.EventHandler(this.Clicker);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaxHealth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentHealth;
        private System.Windows.Forms.FlowLayoutPanel flpAilments;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbImage;
    }
}
