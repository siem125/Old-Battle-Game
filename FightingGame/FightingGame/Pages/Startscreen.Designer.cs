namespace FightingGame
{
    partial class Startscreen
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
            this.btnHomescreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHomescreen
            // 
            this.btnHomescreen.Location = new System.Drawing.Point(108, 253);
            this.btnHomescreen.Name = "btnHomescreen";
            this.btnHomescreen.Size = new System.Drawing.Size(587, 168);
            this.btnHomescreen.TabIndex = 0;
            this.btnHomescreen.Text = "Enter arena";
            this.btnHomescreen.UseVisualStyleBackColor = true;
            this.btnHomescreen.Click += new System.EventHandler(this.btnHomescreen_Click);
            // 
            // Startscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHomescreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Startscreen";
            this.Text = "Startscreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHomescreen;
    }
}