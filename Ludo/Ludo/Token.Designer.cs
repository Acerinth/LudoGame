﻿namespace Ludo
{
    partial class Token
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
            this.SuspendLayout();
            // 
            // Token
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Token";
            this.Size = new System.Drawing.Size(50, 50);
            this.Load += new System.EventHandler(this.Token_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Token_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
