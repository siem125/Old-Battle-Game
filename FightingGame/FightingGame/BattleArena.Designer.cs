namespace FightingGame
{
    partial class BattleArena
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
            this.components = new System.ComponentModel.Container();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.flpAttacks = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAlternatives = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnMoves = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pbEnemyPlatform = new System.Windows.Forms.PictureBox();
            this.pbEnemyCharacterImage = new System.Windows.Forms.PictureBox();
            this.lblOwnName = new System.Windows.Forms.Label();
            this.lblOwnLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlOwnhealth = new System.Windows.Forms.Panel();
            this.lblOwnCurrentHealth = new System.Windows.Forms.Label();
            this.lblOwnMaxHealth = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlOwnTypes = new System.Windows.Forms.Panel();
            this.pnlOwn = new System.Windows.Forms.Panel();
            this.pnlEnemyHealth = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEnemyCurrentHealth = new System.Windows.Forms.Label();
            this.lblEnemyLevel = new System.Windows.Forms.Label();
            this.lblEnemyMaxHealth = new System.Windows.Forms.Label();
            this.lblEnemyName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flpEnemyAilments = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEnemyTypes = new System.Windows.Forms.Panel();
            this.pnlEnemy = new System.Windows.Forms.Panel();
            this.pbOwnPlatform = new System.Windows.Forms.PictureBox();
            this.pbOwnCharacterImage = new System.Windows.Forms.PictureBox();
            this.flpOwnAilments = new System.Windows.Forms.FlowLayoutPanel();
            this.BackgroundWorkerReceiver = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSender = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyCharacterImage)).BeginInit();
            this.pnlOwn.SuspendLayout();
            this.pnlEnemy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnCharacterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackground
            // 
            this.pbBackground.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackground.Location = new System.Drawing.Point(0, 0);
            this.pbBackground.Margin = new System.Windows.Forms.Padding(4);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(1475, 662);
            this.pbBackground.TabIndex = 0;
            this.pbBackground.TabStop = false;
            // 
            // flpAttacks
            // 
            this.flpAttacks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpAttacks.AutoScroll = true;
            this.flpAttacks.BackColor = System.Drawing.Color.Gray;
            this.flpAttacks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAttacks.Location = new System.Drawing.Point(24, 497);
            this.flpAttacks.Margin = new System.Windows.Forms.Padding(4);
            this.flpAttacks.Name = "flpAttacks";
            this.flpAttacks.Size = new System.Drawing.Size(764, 156);
            this.flpAttacks.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.btnAlternatives);
            this.panel3.Controls.Add(this.btnChange);
            this.panel3.Controls.Add(this.btnMoves);
            this.panel3.Location = new System.Drawing.Point(24, 497);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1040, 156);
            this.panel3.TabIndex = 9;
            // 
            // btnAlternatives
            // 
            this.btnAlternatives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlternatives.Location = new System.Drawing.Point(784, 128);
            this.btnAlternatives.Name = "btnAlternatives";
            this.btnAlternatives.Size = new System.Drawing.Size(253, 56);
            this.btnAlternatives.TabIndex = 2;
            this.btnAlternatives.Text = "Alternatives";
            this.btnAlternatives.UseVisualStyleBackColor = true;
            this.btnAlternatives.Click += new System.EventHandler(this.btnAlternatives_Click);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.Location = new System.Drawing.Point(784, 66);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(253, 56);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnMoves
            // 
            this.btnMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoves.Location = new System.Drawing.Point(784, 4);
            this.btnMoves.Name = "btnMoves";
            this.btnMoves.Size = new System.Drawing.Size(253, 56);
            this.btnMoves.TabIndex = 0;
            this.btnMoves.Text = "Moves";
            this.btnMoves.UseVisualStyleBackColor = true;
            this.btnMoves.Click += new System.EventHandler(this.btnMoves_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.Location = new System.Drawing.Point(1100, 15);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(363, 638);
            this.pnlChat.TabIndex = 17;
            // 
            // pbEnemyPlatform
            // 
            this.pbEnemyPlatform.Location = new System.Drawing.Point(551, 125);
            this.pbEnemyPlatform.Margin = new System.Windows.Forms.Padding(4);
            this.pbEnemyPlatform.Name = "pbEnemyPlatform";
            this.pbEnemyPlatform.Size = new System.Drawing.Size(475, 113);
            this.pbEnemyPlatform.TabIndex = 5;
            this.pbEnemyPlatform.TabStop = false;
            // 
            // pbEnemyCharacterImage
            // 
            this.pbEnemyCharacterImage.Location = new System.Drawing.Point(657, 15);
            this.pbEnemyCharacterImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbEnemyCharacterImage.Name = "pbEnemyCharacterImage";
            this.pbEnemyCharacterImage.Size = new System.Drawing.Size(308, 207);
            this.pbEnemyCharacterImage.TabIndex = 6;
            this.pbEnemyCharacterImage.TabStop = false;
            // 
            // lblOwnName
            // 
            this.lblOwnName.AutoSize = true;
            this.lblOwnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnName.Location = new System.Drawing.Point(4, 26);
            this.lblOwnName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnName.Name = "lblOwnName";
            this.lblOwnName.Size = new System.Drawing.Size(53, 20);
            this.lblOwnName.TabIndex = 0;
            this.lblOwnName.Text = "Name";
            // 
            // lblOwnLevel
            // 
            this.lblOwnLevel.AutoSize = true;
            this.lblOwnLevel.Location = new System.Drawing.Point(308, 26);
            this.lblOwnLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnLevel.Name = "lblOwnLevel";
            this.lblOwnLevel.Size = new System.Drawing.Size(28, 16);
            this.lblOwnLevel.TabIndex = 1;
            this.lblOwnLevel.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "LVL";
            // 
            // pnlOwnhealth
            // 
            this.pnlOwnhealth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlOwnhealth.Location = new System.Drawing.Point(119, 46);
            this.pnlOwnhealth.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOwnhealth.Name = "pnlOwnhealth";
            this.pnlOwnhealth.Size = new System.Drawing.Size(223, 33);
            this.pnlOwnhealth.TabIndex = 3;
            // 
            // lblOwnCurrentHealth
            // 
            this.lblOwnCurrentHealth.AutoSize = true;
            this.lblOwnCurrentHealth.Location = new System.Drawing.Point(155, 87);
            this.lblOwnCurrentHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnCurrentHealth.Name = "lblOwnCurrentHealth";
            this.lblOwnCurrentHealth.Size = new System.Drawing.Size(21, 16);
            this.lblOwnCurrentHealth.TabIndex = 4;
            this.lblOwnCurrentHealth.Text = "85";
            // 
            // lblOwnMaxHealth
            // 
            this.lblOwnMaxHealth.AutoSize = true;
            this.lblOwnMaxHealth.Location = new System.Drawing.Point(220, 87);
            this.lblOwnMaxHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOwnMaxHealth.Name = "lblOwnMaxHealth";
            this.lblOwnMaxHealth.Size = new System.Drawing.Size(28, 16);
            this.lblOwnMaxHealth.TabIndex = 5;
            this.lblOwnMaxHealth.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "/";
            // 
            // pnlOwnTypes
            // 
            this.pnlOwnTypes.Location = new System.Drawing.Point(8, 52);
            this.pnlOwnTypes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOwnTypes.Name = "pnlOwnTypes";
            this.pnlOwnTypes.Size = new System.Drawing.Size(103, 79);
            this.pnlOwnTypes.TabIndex = 7;
            // 
            // pnlOwn
            // 
            this.pnlOwn.Controls.Add(this.pnlOwnTypes);
            this.pnlOwn.Controls.Add(this.label6);
            this.pnlOwn.Controls.Add(this.lblOwnMaxHealth);
            this.pnlOwn.Controls.Add(this.lblOwnCurrentHealth);
            this.pnlOwn.Controls.Add(this.pnlOwnhealth);
            this.pnlOwn.Controls.Add(this.label3);
            this.pnlOwn.Controls.Add(this.lblOwnLevel);
            this.pnlOwn.Controls.Add(this.lblOwnName);
            this.pnlOwn.Location = new System.Drawing.Point(684, 294);
            this.pnlOwn.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOwn.Name = "pnlOwn";
            this.pnlOwn.Size = new System.Drawing.Size(367, 134);
            this.pnlOwn.TabIndex = 7;
            // 
            // pnlEnemyHealth
            // 
            this.pnlEnemyHealth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlEnemyHealth.Location = new System.Drawing.Point(119, 46);
            this.pnlEnemyHealth.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnemyHealth.Name = "pnlEnemyHealth";
            this.pnlEnemyHealth.Size = new System.Drawing.Size(223, 33);
            this.pnlEnemyHealth.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(265, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "LVL";
            // 
            // lblEnemyCurrentHealth
            // 
            this.lblEnemyCurrentHealth.AutoSize = true;
            this.lblEnemyCurrentHealth.Location = new System.Drawing.Point(155, 87);
            this.lblEnemyCurrentHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnemyCurrentHealth.Name = "lblEnemyCurrentHealth";
            this.lblEnemyCurrentHealth.Size = new System.Drawing.Size(21, 16);
            this.lblEnemyCurrentHealth.TabIndex = 11;
            this.lblEnemyCurrentHealth.Text = "85";
            // 
            // lblEnemyLevel
            // 
            this.lblEnemyLevel.AutoSize = true;
            this.lblEnemyLevel.Location = new System.Drawing.Point(308, 26);
            this.lblEnemyLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnemyLevel.Name = "lblEnemyLevel";
            this.lblEnemyLevel.Size = new System.Drawing.Size(28, 16);
            this.lblEnemyLevel.TabIndex = 8;
            this.lblEnemyLevel.Text = "100";
            // 
            // lblEnemyMaxHealth
            // 
            this.lblEnemyMaxHealth.AutoSize = true;
            this.lblEnemyMaxHealth.Location = new System.Drawing.Point(220, 87);
            this.lblEnemyMaxHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnemyMaxHealth.Name = "lblEnemyMaxHealth";
            this.lblEnemyMaxHealth.Size = new System.Drawing.Size(28, 16);
            this.lblEnemyMaxHealth.TabIndex = 12;
            this.lblEnemyMaxHealth.Text = "100";
            // 
            // lblEnemyName
            // 
            this.lblEnemyName.AutoSize = true;
            this.lblEnemyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnemyName.Location = new System.Drawing.Point(4, 26);
            this.lblEnemyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnemyName.Name = "lblEnemyName";
            this.lblEnemyName.Size = new System.Drawing.Size(53, 20);
            this.lblEnemyName.TabIndex = 7;
            this.lblEnemyName.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 87);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "/";
            // 
            // flpEnemyAilments
            // 
            this.flpEnemyAilments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpEnemyAilments.Location = new System.Drawing.Point(0, 0);
            this.flpEnemyAilments.Margin = new System.Windows.Forms.Padding(4);
            this.flpEnemyAilments.Name = "flpEnemyAilments";
            this.flpEnemyAilments.Size = new System.Drawing.Size(366, 22);
            this.flpEnemyAilments.TabIndex = 14;
            // 
            // pnlEnemyTypes
            // 
            this.pnlEnemyTypes.Location = new System.Drawing.Point(8, 50);
            this.pnlEnemyTypes.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnemyTypes.Name = "pnlEnemyTypes";
            this.pnlEnemyTypes.Size = new System.Drawing.Size(103, 79);
            this.pnlEnemyTypes.TabIndex = 8;
            // 
            // pnlEnemy
            // 
            this.pnlEnemy.Controls.Add(this.pnlEnemyTypes);
            this.pnlEnemy.Controls.Add(this.flpEnemyAilments);
            this.pnlEnemy.Controls.Add(this.label7);
            this.pnlEnemy.Controls.Add(this.lblEnemyName);
            this.pnlEnemy.Controls.Add(this.lblEnemyMaxHealth);
            this.pnlEnemy.Controls.Add(this.lblEnemyLevel);
            this.pnlEnemy.Controls.Add(this.lblEnemyCurrentHealth);
            this.pnlEnemy.Controls.Add(this.label10);
            this.pnlEnemy.Controls.Add(this.pnlEnemyHealth);
            this.pnlEnemy.Location = new System.Drawing.Point(16, 15);
            this.pnlEnemy.Margin = new System.Windows.Forms.Padding(4);
            this.pnlEnemy.Name = "pnlEnemy";
            this.pnlEnemy.Size = new System.Drawing.Size(367, 134);
            this.pnlEnemy.TabIndex = 8;
            // 
            // pbOwnPlatform
            // 
            this.pbOwnPlatform.Location = new System.Drawing.Point(0, 356);
            this.pbOwnPlatform.Margin = new System.Windows.Forms.Padding(4);
            this.pbOwnPlatform.Name = "pbOwnPlatform";
            this.pbOwnPlatform.Size = new System.Drawing.Size(475, 113);
            this.pbOwnPlatform.TabIndex = 3;
            this.pbOwnPlatform.TabStop = false;
            // 
            // pbOwnCharacterImage
            // 
            this.pbOwnCharacterImage.Location = new System.Drawing.Point(88, 245);
            this.pbOwnCharacterImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbOwnCharacterImage.Name = "pbOwnCharacterImage";
            this.pbOwnCharacterImage.Size = new System.Drawing.Size(308, 207);
            this.pbOwnCharacterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOwnCharacterImage.TabIndex = 4;
            this.pbOwnCharacterImage.TabStop = false;
            // 
            // flpOwnAilments
            // 
            this.flpOwnAilments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpOwnAilments.Location = new System.Drawing.Point(684, 294);
            this.flpOwnAilments.Margin = new System.Windows.Forms.Padding(4);
            this.flpOwnAilments.Name = "flpOwnAilments";
            this.flpOwnAilments.Size = new System.Drawing.Size(367, 22);
            this.flpOwnAilments.TabIndex = 15;
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
            // BattleArena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 662);
            this.Controls.Add(this.flpOwnAilments);
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.flpAttacks);
            this.Controls.Add(this.pbOwnCharacterImage);
            this.Controls.Add(this.pbOwnPlatform);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlEnemy);
            this.Controls.Add(this.pnlOwn);
            this.Controls.Add(this.pbEnemyCharacterImage);
            this.Controls.Add(this.pbEnemyPlatform);
            this.Controls.Add(this.pbBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BattleArena";
            this.Text = "BattleArena";
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyCharacterImage)).EndInit();
            this.pnlOwn.ResumeLayout(false);
            this.pnlOwn.PerformLayout();
            this.pnlEnemy.ResumeLayout(false);
            this.pnlEnemy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnCharacterImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.FlowLayoutPanel flpAttacks;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnMoves;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.PictureBox pbEnemyPlatform;
        private System.Windows.Forms.PictureBox pbEnemyCharacterImage;
        private System.Windows.Forms.Label lblOwnName;
        private System.Windows.Forms.Label lblOwnLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlOwnhealth;
        private System.Windows.Forms.Label lblOwnCurrentHealth;
        private System.Windows.Forms.Label lblOwnMaxHealth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlOwnTypes;
        private System.Windows.Forms.Panel pnlOwn;
        private System.Windows.Forms.Panel pnlEnemyHealth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEnemyCurrentHealth;
        private System.Windows.Forms.Label lblEnemyLevel;
        private System.Windows.Forms.Label lblEnemyMaxHealth;
        private System.Windows.Forms.Label lblEnemyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flpEnemyAilments;
        private System.Windows.Forms.Panel pnlEnemyTypes;
        private System.Windows.Forms.Panel pnlEnemy;
        private System.Windows.Forms.PictureBox pbOwnPlatform;
        private System.Windows.Forms.PictureBox pbOwnCharacterImage;
        private System.Windows.Forms.FlowLayoutPanel flpOwnAilments;
        private System.Windows.Forms.Button btnAlternatives;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerReceiver;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSender;
    }
}