namespace Snake
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
            this.components = new System.ComponentModel.Container();
            this.snapBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.scoreTxt = new System.Windows.Forms.TextBox();
            this.highScoreTxt = new System.Windows.Forms.TextBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // snapBtn
            // 
            this.snapBtn.BackColor = System.Drawing.Color.Cyan;
            this.snapBtn.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapBtn.Location = new System.Drawing.Point(596, 109);
            this.snapBtn.Name = "snapBtn";
            this.snapBtn.Size = new System.Drawing.Size(126, 64);
            this.snapBtn.TabIndex = 0;
            this.snapBtn.Text = "Snap";
            this.snapBtn.UseVisualStyleBackColor = false;
            this.snapBtn.Click += new System.EventHandler(this.TakeSnapshot);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.startBtn.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(596, 39);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(126, 64);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.StartGame);
            // 
            // scoreTxt
            // 
            this.scoreTxt.Enabled = false;
            this.scoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTxt.Location = new System.Drawing.Point(596, 205);
            this.scoreTxt.Name = "scoreTxt";
            this.scoreTxt.ReadOnly = true;
            this.scoreTxt.Size = new System.Drawing.Size(126, 29);
            this.scoreTxt.TabIndex = 2;
            this.scoreTxt.Text = "Score: 0";
            this.scoreTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // highScoreTxt
            // 
            this.highScoreTxt.Enabled = false;
            this.highScoreTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreTxt.Location = new System.Drawing.Point(596, 261);
            this.highScoreTxt.Name = "highScoreTxt";
            this.highScoreTxt.ReadOnly = true;
            this.highScoreTxt.Size = new System.Drawing.Size(126, 29);
            this.highScoreTxt.TabIndex = 3;
            this.highScoreTxt.Text = "High Score: 0";
            this.highScoreTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(580, 680);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 725);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.highScoreTxt);
            this.Controls.Add(this.scoreTxt);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.snapBtn);
            this.Name = "Form1";
            this.Text = "Classic Snake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button snapBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox scoreTxt;
        private System.Windows.Forms.TextBox highScoreTxt;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

