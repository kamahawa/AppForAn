﻿namespace CameraApp
{
    partial class frmRTSP
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
            this._btnGetCenter = new System.Windows.Forms.Button();
            this._ptbCamera = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtFileĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._btnScore = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblScore = new System.Windows.Forms.Label();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._ptbCamera)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnGetCenter
            // 
            this._btnGetCenter.Location = new System.Drawing.Point(12, 534);
            this._btnGetCenter.Name = "_btnGetCenter";
            this._btnGetCenter.Size = new System.Drawing.Size(75, 23);
            this._btnGetCenter.TabIndex = 1;
            this._btnGetCenter.Text = "Lấy tâm";
            this._btnGetCenter.UseVisualStyleBackColor = true;
            this._btnGetCenter.Click += new System.EventHandler(this._btnGetCenter_Click);
            // 
            // _ptbCamera
            // 
            this._ptbCamera.Location = new System.Drawing.Point(12, 37);
            this._ptbCamera.Name = "_ptbCamera";
            this._ptbCamera.Size = new System.Drawing.Size(640, 480);
            this._ptbCamera.TabIndex = 2;
            this._ptbCamera.TabStop = false;
            this._ptbCamera.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ptbCamera_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmDanhSáchToolStripMenuItem,
            this.xuấtFileĐiểmToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // thêmDanhSáchToolStripMenuItem
            // 
            this.thêmDanhSáchToolStripMenuItem.Name = "thêmDanhSáchToolStripMenuItem";
            this.thêmDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.thêmDanhSáchToolStripMenuItem.Text = "Thêm danh sách";
            // 
            // xuấtFileĐiểmToolStripMenuItem
            // 
            this.xuấtFileĐiểmToolStripMenuItem.Name = "xuấtFileĐiểmToolStripMenuItem";
            this.xuấtFileĐiểmToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.xuấtFileĐiểmToolStripMenuItem.Text = "Xuất file điểm";
            // 
            // _btnScore
            // 
            this._btnScore.Location = new System.Drawing.Point(93, 534);
            this._btnScore.Name = "_btnScore";
            this._btnScore.Size = new System.Drawing.Size(75, 23);
            this._btnScore.TabIndex = 4;
            this._btnScore.Text = "Chấm điểm";
            this._btnScore.UseVisualStyleBackColor = true;
            this._btnScore.Click += new System.EventHandler(this._btnScore_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._lblScore);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._lblName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(669, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 169);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ và tên : ";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(8, 43);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(0, 24);
            this._lblName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Điểm :";
            // 
            // _lblScore
            // 
            this._lblScore.AutoSize = true;
            this._lblScore.Location = new System.Drawing.Point(79, 89);
            this._lblScore.Name = "_lblScore";
            this._lblScore.Size = new System.Drawing.Size(0, 24);
            this._lblScore.TabIndex = 3;
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // frmRTSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnScore);
            this.Controls.Add(this._ptbCamera);
            this.Controls.Add(this._btnGetCenter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRTSP";
            this.Text = "frmRTSP";
            this.Load += new System.EventHandler(this.frmRTSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this._ptbCamera)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _btnGetCenter;
        private System.Windows.Forms.PictureBox _ptbCamera;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmDanhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtFileĐiểmToolStripMenuItem;
        private System.Windows.Forms.Button _btnScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
    }
}