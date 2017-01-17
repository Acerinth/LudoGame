namespace Ludo
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayerOnTheMove = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDice = new System.Windows.Forms.Label();
            this.diceNumber = new System.Windows.Forms.Label();
            this.btnRollDice = new System.Windows.Forms.Button();
            this.tkoNaRedu = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panelBoard
            // 
            this.panelBoard.Location = new System.Drawing.Point(24, 39);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(651, 651);
            this.panelBoard.TabIndex = 1;
            this.panelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoard_Paint);
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnColor);
            this.panelControls.Controls.Add(this.lblStatus);
            this.panelControls.Controls.Add(this.label2);
            this.panelControls.Controls.Add(this.lblPlayerOnTheMove);
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Controls.Add(this.lblDice);
            this.panelControls.Controls.Add(this.diceNumber);
            this.panelControls.Controls.Add(this.btnRollDice);
            this.panelControls.Controls.Add(this.tkoNaRedu);
            this.panelControls.Location = new System.Drawing.Point(723, 39);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(273, 651);
            this.panelControls.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(39, 250);
            this.lblStatus.MaximumSize = new System.Drawing.Size(200, 400);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(86, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Begining game...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status:";
            // 
            // lblPlayerOnTheMove
            // 
            this.lblPlayerOnTheMove.AutoSize = true;
            this.lblPlayerOnTheMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPlayerOnTheMove.Location = new System.Drawing.Point(135, 51);
            this.lblPlayerOnTheMove.Name = "lblPlayerOnTheMove";
            this.lblPlayerOnTheMove.Size = new System.Drawing.Size(54, 17);
            this.lblPlayerOnTheMove.TabIndex = 5;
            this.lblPlayerOnTheMove.Text = "Player";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "On the move:";
            // 
            // lblDice
            // 
            this.lblDice.AutoSize = true;
            this.lblDice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDice.Location = new System.Drawing.Point(133, 174);
            this.lblDice.Name = "lblDice";
            this.lblDice.Size = new System.Drawing.Size(17, 17);
            this.lblDice.TabIndex = 3;
            this.lblDice.Text = "1";
            // 
            // diceNumber
            // 
            this.diceNumber.AutoSize = true;
            this.diceNumber.Location = new System.Drawing.Point(19, 178);
            this.diceNumber.Name = "diceNumber";
            this.diceNumber.Size = new System.Drawing.Size(70, 13);
            this.diceNumber.TabIndex = 2;
            this.diceNumber.Text = "Dice number:";
            // 
            // btnRollDice
            // 
            this.btnRollDice.Location = new System.Drawing.Point(89, 107);
            this.btnRollDice.Name = "btnRollDice";
            this.btnRollDice.Size = new System.Drawing.Size(100, 46);
            this.btnRollDice.TabIndex = 1;
            this.btnRollDice.Text = "Roll dice";
            this.btnRollDice.UseVisualStyleBackColor = true;
            this.btnRollDice.Click += new System.EventHandler(this.btnRollDice_Click);
            // 
            // tkoNaRedu
            // 
            this.tkoNaRedu.AutoSize = true;
            this.tkoNaRedu.Location = new System.Drawing.Point(16, 15);
            this.tkoNaRedu.Name = "tkoNaRedu";
            this.tkoNaRedu.Size = new System.Drawing.Size(94, 13);
            this.tkoNaRedu.TabIndex = 0;
            this.tkoNaRedu.Text = "Welcome to Ludo!";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(98, 48);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(31, 23);
            this.btnColor.TabIndex = 8;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ludo";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblDice;
        private System.Windows.Forms.Label diceNumber;
        private System.Windows.Forms.Button btnRollDice;
        private System.Windows.Forms.Label tkoNaRedu;
        private System.Windows.Forms.Label lblPlayerOnTheMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnColor;
    }
}

