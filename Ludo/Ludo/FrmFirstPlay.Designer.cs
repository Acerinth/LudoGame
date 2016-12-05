namespace Ludo
{
    partial class FrmFirstPlay
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
            this.label1 = new System.Windows.Forms.Label();
            this.rBPlayer = new System.Windows.Forms.RadioButton();
            this.rBRandom = new System.Windows.Forms.RadioButton();
            this.btnPlay = new System.Windows.Forms.Button();
            this.cBoxPlayers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "The game is set! Who would you like to play first?";
            // 
            // rBPlayer
            // 
            this.rBPlayer.AutoSize = true;
            this.rBPlayer.Checked = true;
            this.rBPlayer.Location = new System.Drawing.Point(140, 111);
            this.rBPlayer.Name = "rBPlayer";
            this.rBPlayer.Size = new System.Drawing.Size(95, 17);
            this.rBPlayer.TabIndex = 1;
            this.rBPlayer.TabStop = true;
            this.rBPlayer.Text = "Choose player:";
            this.rBPlayer.UseVisualStyleBackColor = true;
            this.rBPlayer.CheckedChanged += new System.EventHandler(this.rBPlayer_CheckedChanged);
            // 
            // rBRandom
            // 
            this.rBRandom.AutoSize = true;
            this.rBRandom.Location = new System.Drawing.Point(140, 146);
            this.rBRandom.Name = "rBRandom";
            this.rBRandom.Size = new System.Drawing.Size(148, 17);
            this.rBRandom.TabIndex = 2;
            this.rBRandom.Text = "Let CPU choose randomly";
            this.rBRandom.UseVisualStyleBackColor = true;
            this.rBRandom.CheckedChanged += new System.EventHandler(this.rBRandom_CheckedChanged);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(207, 218);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(182, 56);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play!";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // cBoxPlayers
            // 
            this.cBoxPlayers.FormattingEnabled = true;
            this.cBoxPlayers.Location = new System.Drawing.Point(277, 110);
            this.cBoxPlayers.Name = "cBoxPlayers";
            this.cBoxPlayers.Size = new System.Drawing.Size(153, 21);
            this.cBoxPlayers.TabIndex = 4;
            // 
            // FrmFirstPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 315);
            this.Controls.Add(this.cBoxPlayers);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.rBRandom);
            this.Controls.Add(this.rBPlayer);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmFirstPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Who plays first?";
            this.Load += new System.EventHandler(this.FrmFirstPlay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rBPlayer;
        private System.Windows.Forms.RadioButton rBRandom;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ComboBox cBoxPlayers;
    }
}