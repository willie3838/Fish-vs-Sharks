namespace FishvsSharks
{
    partial class GameForm
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
            this.tmrGeneral = new System.Windows.Forms.Timer(this.components);
            this.lblWaterPower = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pnlGameOver = new System.Windows.Forms.Panel();
            this.lblGameOverPoints = new System.Windows.Forms.Label();
            this.lblGameOverLevel = new System.Windows.Forms.Label();
            this.picHeart = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlGameOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGeneral
            // 
            this.tmrGeneral.Enabled = true;
            this.tmrGeneral.Interval = 10;
            this.tmrGeneral.Tick += new System.EventHandler(this.tmrGeneral_Tick);
            // 
            // lblWaterPower
            // 
            this.lblWaterPower.AutoSize = true;
            this.lblWaterPower.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaterPower.Location = new System.Drawing.Point(30, 426);
            this.lblWaterPower.Name = "lblWaterPower";
            this.lblWaterPower.Size = new System.Drawing.Size(101, 17);
            this.lblWaterPower.TabIndex = 0;
            this.lblWaterPower.Text = "Water power: 0";
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLives.Location = new System.Drawing.Point(30, 458);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(54, 17);
            this.lblLives.TabIndex = 3;
            this.lblLives.Text = "Lives: 3";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(30, 490);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(55, 17);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level: 1";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(30, 518);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(66, 17);
            this.lblPoints.TabIndex = 5;
            this.lblPoints.Text = "Points:  0";
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlGameOver.BackgroundImage = global::FishvsSharks.Properties.Resources.gameover;
            this.pnlGameOver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGameOver.Controls.Add(this.lblGameOverPoints);
            this.pnlGameOver.Controls.Add(this.lblGameOverLevel);
            this.pnlGameOver.Location = new System.Drawing.Point(0, 1);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(925, 556);
            this.pnlGameOver.TabIndex = 6;
            this.pnlGameOver.Visible = false;
            // 
            // lblGameOverPoints
            // 
            this.lblGameOverPoints.AutoSize = true;
            this.lblGameOverPoints.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOverPoints.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverPoints.Location = new System.Drawing.Point(397, 351);
            this.lblGameOverPoints.Name = "lblGameOverPoints";
            this.lblGameOverPoints.Size = new System.Drawing.Size(133, 24);
            this.lblGameOverPoints.TabIndex = 1;
            this.lblGameOverPoints.Text = "Total Points:";
            // 
            // lblGameOverLevel
            // 
            this.lblGameOverLevel.AutoSize = true;
            this.lblGameOverLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOverLevel.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverLevel.Location = new System.Drawing.Point(397, 306);
            this.lblGameOverLevel.Name = "lblGameOverLevel";
            this.lblGameOverLevel.Size = new System.Drawing.Size(67, 24);
            this.lblGameOverLevel.TabIndex = 0;
            this.lblGameOverLevel.Text = "Level:";
            // 
            // picHeart
            // 
            this.picHeart.BackgroundImage = global::FishvsSharks.Properties.Resources.heart;
            this.picHeart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHeart.Location = new System.Drawing.Point(0, 458);
            this.picHeart.Name = "picHeart";
            this.picHeart.Size = new System.Drawing.Size(24, 24);
            this.picHeart.TabIndex = 2;
            this.picHeart.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FishvsSharks.Properties.Resources.waterpower;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 416);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 27);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(925, 554);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.picHeart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblWaterPower);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.pnlGameOver.ResumeLayout(false);
            this.pnlGameOver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGeneral;
        private System.Windows.Forms.Label lblWaterPower;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picHeart;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Panel pnlGameOver;
        private System.Windows.Forms.Label lblGameOverPoints;
        private System.Windows.Forms.Label lblGameOverLevel;
    }
}

