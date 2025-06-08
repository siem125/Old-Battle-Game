namespace FightingGame
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
            this.btnBattle = new System.Windows.Forms.Button();
            this.btnFillParty = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBattle
            // 
            this.btnBattle.Enabled = false;
            this.btnBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBattle.Location = new System.Drawing.Point(538, 301);
            this.btnBattle.Name = "btnBattle";
            this.btnBattle.Size = new System.Drawing.Size(250, 137);
            this.btnBattle.TabIndex = 0;
            this.btnBattle.Text = "Go to battle";
            this.btnBattle.UseVisualStyleBackColor = true;
            this.btnBattle.Click += new System.EventHandler(this.btnBattle_Click);
            // 
            // btnFillParty
            // 
            this.btnFillParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFillParty.Location = new System.Drawing.Point(12, 301);
            this.btnFillParty.Name = "btnFillParty";
            this.btnFillParty.Size = new System.Drawing.Size(250, 137);
            this.btnFillParty.TabIndex = 1;
            this.btnFillParty.Text = "Fill party\'s";
            this.btnFillParty.UseVisualStyleBackColor = true;
            this.btnFillParty.Click += new System.EventHandler(this.btnFillParty_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFillParty);
            this.Controls.Add(this.btnBattle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBattle;
        private System.Windows.Forms.Button btnFillParty;
    }
}

