namespace PointMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._ptbImage = new System.Windows.Forms.PictureBox();
            this._btnOpen = new System.Windows.Forms.Button();
            this._btnScore = new System.Windows.Forms.Button();
            this._lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ptbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _ptbImage
            // 
            this._ptbImage.Image = ((System.Drawing.Image)(resources.GetObject("_ptbImage.Image")));
            this._ptbImage.Location = new System.Drawing.Point(13, 13);
            this._ptbImage.Name = "_ptbImage";
            this._ptbImage.Size = new System.Drawing.Size(640, 480);
            this._ptbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._ptbImage.TabIndex = 0;
            this._ptbImage.TabStop = false;
            this._ptbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ptbImage_MouseUp);
            // 
            // _btnOpen
            // 
            this._btnOpen.Location = new System.Drawing.Point(13, 518);
            this._btnOpen.Name = "_btnOpen";
            this._btnOpen.Size = new System.Drawing.Size(75, 23);
            this._btnOpen.TabIndex = 1;
            this._btnOpen.Text = "Lấy tâm";
            this._btnOpen.UseVisualStyleBackColor = true;
            this._btnOpen.Click += new System.EventHandler(this._btnOpen_Click);
            // 
            // _btnScore
            // 
            this._btnScore.Location = new System.Drawing.Point(106, 518);
            this._btnScore.Name = "_btnScore";
            this._btnScore.Size = new System.Drawing.Size(75, 23);
            this._btnScore.TabIndex = 2;
            this._btnScore.Text = "Chấm điểm";
            this._btnScore.UseVisualStyleBackColor = true;
            this._btnScore.Click += new System.EventHandler(this._btnScore_Click);
            // 
            // _lblScore
            // 
            this._lblScore.AutoSize = true;
            this._lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblScore.Location = new System.Drawing.Point(786, 67);
            this._lblScore.Name = "_lblScore";
            this._lblScore.Size = new System.Drawing.Size(0, 24);
            this._lblScore.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(676, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Điểm số bắn : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(680, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên : ";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblName.Location = new System.Drawing.Point(747, 19);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(0, 24);
            this._lblName.TabIndex = 6;
            // 
            // _btnNext
            // 
            this._btnNext.Location = new System.Drawing.Point(209, 518);
            this._btnNext.Name = "_btnNext";
            this._btnNext.Size = new System.Drawing.Size(100, 23);
            this._btnNext.TabIndex = 7;
            this._btnNext.Text = "Lượt tiếp theo";
            this._btnNext.UseVisualStyleBackColor = true;
            this._btnNext.Click += new System.EventHandler(this._btnNext_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 557);
            this.Controls.Add(this._btnNext);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lblScore);
            this.Controls.Add(this._btnScore);
            this.Controls.Add(this._btnOpen);
            this.Controls.Add(this._ptbImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._ptbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ptbImage;
        private System.Windows.Forms.Button _btnOpen;
        private System.Windows.Forms.Button _btnScore;
        private System.Windows.Forms.Label _lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Button _btnNext;
    }
}

