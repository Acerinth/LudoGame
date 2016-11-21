namespace Ludo
{
    partial class FrmNewGame
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBox1 = new System.Windows.Forms.ComboBox();
            this.cBox2 = new System.Windows.Forms.ComboBox();
            this.cBox3 = new System.Windows.Forms.ComboBox();
            this.cBox4 = new System.Windows.Forms.ComboBox();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.txtP4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 3:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Player 4:";
            // 
            // cBox1
            // 
            this.cBox1.FormattingEnabled = true;
            this.cBox1.Location = new System.Drawing.Point(173, 44);
            this.cBox1.Name = "cBox1";
            this.cBox1.Size = new System.Drawing.Size(169, 21);
            this.cBox1.TabIndex = 4;
            // 
            // cBox2
            // 
            this.cBox2.FormattingEnabled = true;
            this.cBox2.Location = new System.Drawing.Point(173, 88);
            this.cBox2.Name = "cBox2";
            this.cBox2.Size = new System.Drawing.Size(169, 21);
            this.cBox2.TabIndex = 5;
            // 
            // cBox3
            // 
            this.cBox3.FormattingEnabled = true;
            this.cBox3.Location = new System.Drawing.Point(173, 131);
            this.cBox3.Name = "cBox3";
            this.cBox3.Size = new System.Drawing.Size(169, 21);
            this.cBox3.TabIndex = 6;
            // 
            // cBox4
            // 
            this.cBox4.FormattingEnabled = true;
            this.cBox4.Location = new System.Drawing.Point(173, 176);
            this.cBox4.Name = "cBox4";
            this.cBox4.Size = new System.Drawing.Size(169, 21);
            this.cBox4.TabIndex = 7;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(122, 233);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(182, 56);
            this.btnStartGame.TabIndex = 8;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // txtP1
            // 
            this.txtP1.Enabled = false;
            this.txtP1.Location = new System.Drawing.Point(62, 44);
            this.txtP1.Name = "txtP1";
            this.txtP1.ReadOnly = true;
            this.txtP1.Size = new System.Drawing.Size(26, 20);
            this.txtP1.TabIndex = 9;
            // 
            // txtP2
            // 
            this.txtP2.Enabled = false;
            this.txtP2.Location = new System.Drawing.Point(62, 88);
            this.txtP2.Name = "txtP2";
            this.txtP2.ReadOnly = true;
            this.txtP2.Size = new System.Drawing.Size(26, 20);
            this.txtP2.TabIndex = 10;
            // 
            // txtP3
            // 
            this.txtP3.Enabled = false;
            this.txtP3.Location = new System.Drawing.Point(62, 131);
            this.txtP3.Name = "txtP3";
            this.txtP3.ReadOnly = true;
            this.txtP3.Size = new System.Drawing.Size(26, 20);
            this.txtP3.TabIndex = 11;
            // 
            // txtP4
            // 
            this.txtP4.Enabled = false;
            this.txtP4.Location = new System.Drawing.Point(62, 176);
            this.txtP4.Name = "txtP4";
            this.txtP4.ReadOnly = true;
            this.txtP4.Size = new System.Drawing.Size(26, 20);
            this.txtP4.TabIndex = 12;
            // 
            // FrmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 315);
            this.Controls.Add(this.txtP4);
            this.Controls.Add(this.txtP3);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.cBox4);
            this.Controls.Add(this.cBox3);
            this.Controls.Add(this.cBox2);
            this.Controls.Add(this.cBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBox1;
        private System.Windows.Forms.ComboBox cBox2;
        private System.Windows.Forms.ComboBox cBox3;
        private System.Windows.Forms.ComboBox cBox4;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.TextBox txtP4;
    }
}