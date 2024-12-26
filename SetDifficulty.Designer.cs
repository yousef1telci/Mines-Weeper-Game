namespace MinesWeeperGame
{
    partial class SetDifficulty
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
            this.bntPlay = new System.Windows.Forms.Button();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMines = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bntPlay
            // 
            this.bntPlay.BackColor = System.Drawing.SystemColors.Highlight;
            this.bntPlay.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bntPlay.Location = new System.Drawing.Point(151, 159);
            this.bntPlay.Name = "bntPlay";
            this.bntPlay.Size = new System.Drawing.Size(103, 38);
            this.bntPlay.TabIndex = 0;
            this.bntPlay.Text = "play";
            this.bntPlay.UseVisualStyleBackColor = false;
            this.bntPlay.Click += new System.EventHandler(this.bntPlay_Click);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(293, 40);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(97, 34);
            this.txtSize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set Number Of Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Andalus", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Set Number OF Mines";
            // 
            // txtMines
            // 
            this.txtMines.Location = new System.Drawing.Point(293, 88);
            this.txtMines.Name = "txtMines";
            this.txtMines.Size = new System.Drawing.Size(97, 34);
            this.txtMines.TabIndex = 3;
            // 
            // SetDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(434, 221);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.bntPlay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SetDifficulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetDifficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntPlay;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMines;
    }
}