namespace Junction_Simulator
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.left_paddle = new System.Windows.Forms.PictureBox();
            this.right_paddle = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_paddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_paddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // left_paddle
            // 
            this.left_paddle.Image = ((System.Drawing.Image)(resources.GetObject("left_paddle.Image")));
            this.left_paddle.Location = new System.Drawing.Point(12, 240);
            this.left_paddle.Name = "left_paddle";
            this.left_paddle.Size = new System.Drawing.Size(50, 200);
            this.left_paddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.left_paddle.TabIndex = 0;
            this.left_paddle.TabStop = false;
            // 
            // right_paddle
            // 
            this.right_paddle.Image = ((System.Drawing.Image)(resources.GetObject("right_paddle.Image")));
            this.right_paddle.Location = new System.Drawing.Point(922, 470);
            this.right_paddle.Name = "right_paddle";
            this.right_paddle.Size = new System.Drawing.Size(50, 200);
            this.right_paddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.right_paddle.TabIndex = 1;
            this.right_paddle.TabStop = false;
            // 
            // ball
            // 
            this.ball.Image = ((System.Drawing.Image)(resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(425, 313);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(50, 50);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.right_paddle);
            this.Controls.Add(this.left_paddle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Junction Simulator";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_paddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_paddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox left_paddle;
        private System.Windows.Forms.PictureBox right_paddle;
        private System.Windows.Forms.PictureBox ball;
    }
}

