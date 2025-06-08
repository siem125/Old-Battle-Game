namespace FightingGame
{
    partial class ChooseCharacters
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
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.pnlTeams = new System.Windows.Forms.Panel();
            this.pnlCharacters = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(169, 184);
            this.pnlFilters.TabIndex = 0;
            // 
            // pnlTeams
            // 
            this.pnlTeams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeams.Location = new System.Drawing.Point(0, 190);
            this.pnlTeams.Name = "pnlTeams";
            this.pnlTeams.Size = new System.Drawing.Size(169, 176);
            this.pnlTeams.TabIndex = 1;
            // 
            // pnlCharacters
            // 
            this.pnlCharacters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCharacters.Location = new System.Drawing.Point(188, 34);
            this.pnlCharacters.Name = "pnlCharacters";
            this.pnlCharacters.Size = new System.Drawing.Size(412, 332);
            this.pnlCharacters.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(316, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Characters";
            // 
            // ChooseCharacters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlCharacters);
            this.Controls.Add(this.pnlTeams);
            this.Controls.Add(this.pnlFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChooseCharacters";
            this.Text = "ChooseCharacters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Panel pnlTeams;
        private System.Windows.Forms.Panel pnlCharacters;
        private System.Windows.Forms.Label label1;
    }
}