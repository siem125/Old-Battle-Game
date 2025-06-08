namespace FightingGame
{
    partial class MoveListInfoItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPPMax = new System.Windows.Forms.Label();
            this.lblPP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblPPMax);
            this.panel1.Controls.Add(this.lblPP);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(14, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 121);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.Clicker);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(52, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "/";
            this.label3.Click += new System.EventHandler(this.Clicker);
            // 
            // lblPPMax
            // 
            this.lblPPMax.AutoSize = true;
            this.lblPPMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPPMax.Location = new System.Drawing.Point(69, 81);
            this.lblPPMax.Name = "lblPPMax";
            this.lblPPMax.Size = new System.Drawing.Size(45, 25);
            this.lblPPMax.TabIndex = 6;
            this.lblPPMax.Text = "100";
            this.lblPPMax.Click += new System.EventHandler(this.Clicker);
            // 
            // lblPP
            // 
            this.lblPP.AutoSize = true;
            this.lblPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPP.Location = new System.Drawing.Point(3, 81);
            this.lblPP.Name = "lblPP";
            this.lblPP.Size = new System.Drawing.Size(45, 25);
            this.lblPP.TabIndex = 5;
            this.lblPP.Text = "100";
            this.lblPP.Click += new System.EventHandler(this.Clicker);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(24, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.Clicker);
            // 
            // MoveListInfoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.panel1);
            this.Name = "MoveListInfoItem";
            this.Click += new System.EventHandler(this.Clicker);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPPMax;
        private System.Windows.Forms.Label lblPP;
        private System.Windows.Forms.Label lblName;
    }
}
