namespace PointMark
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this._btnCenter = new System.Windows.Forms.Button();
            this._btnScore = new System.Windows.Forms.Button();
            this._lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblName = new System.Windows.Forms.Label();
            this._btnNext = new System.Windows.Forms.Button();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtFileĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.thêmDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ptbImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnCenter
            // 
            this._btnCenter.Location = new System.Drawing.Point(13, 518);
            this._btnCenter.Name = "_btnCenter";
            this._btnCenter.Size = new System.Drawing.Size(75, 23);
            this._btnCenter.TabIndex = 1;
            this._btnCenter.Text = "Lấy tâm";
            this._btnCenter.UseVisualStyleBackColor = true;
            this._btnCenter.Click += new System.EventHandler(this._btnCenter_Click);

            this._ptbImage.Image = ((System.Drawing.Image)(resources.GetObject("_ptbImage.Image")));
            this._ptbImage.Location = new System.Drawing.Point(13, 27);
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
            this._lblScore.Location = new System.Drawing.Point(785, 86);
            this._lblScore.Location = new System.Drawing.Point(786, 74);
            this._lblScore.Name = "_lblScore";
            this._lblScore.Size = new System.Drawing.Size(0, 24);
            this._lblScore.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.label1.Location = new System.Drawing.Point(675, 86);
=======
            this.label1.Location = new System.Drawing.Point(676, 74);
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Điểm số bắn : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.label2.Location = new System.Drawing.Point(679, 32);
=======
            this.label2.Location = new System.Drawing.Point(676, 27);
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên : ";
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this._lblName.Location = new System.Drawing.Point(746, 38);
=======
            this._lblName.Location = new System.Drawing.Point(743, 33);
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(0, 24);
            this._lblName.TabIndex = 6;
            // 
            // _btnNext
            // 
            this._btnNext.Location = new System.Drawing.Point(206, 518);
            this._btnNext.Name = "_btnNext";
            this._btnNext.Size = new System.Drawing.Size(100, 23);
            this._btnNext.TabIndex = 7;
            this._btnNext.Text = "Lượt tiếp theo";
            this._btnNext.UseVisualStyleBackColor = true;
            this._btnNext.Click += new System.EventHandler(this._btnNext_Click);
            // 
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(12, 32);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(640, 480);
            this.axVLCPlugin21.TabIndex = 8;
            // 
=======
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.menuStrip1.TabIndex = 9;
=======
            this.menuStrip1.TabIndex = 8;
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.nhậpDanhSáchToolStripMenuItem,
            this.xuấtFileĐiểmToolStripMenuItem});
=======
            this.thêmDanhSáchToolStripMenuItem});
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            // nhậpDanhSáchToolStripMenuItem
            // 
            this.nhậpDanhSáchToolStripMenuItem.Name = "nhậpDanhSáchToolStripMenuItem";
            this.nhậpDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.nhậpDanhSáchToolStripMenuItem.Text = "Nhập danh sách";
            this.nhậpDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.nhậpDanhSáchToolStripMenuItem_Click);
            // 
            // xuấtFileĐiểmToolStripMenuItem
            // 
            this.xuấtFileĐiểmToolStripMenuItem.Name = "xuấtFileĐiểmToolStripMenuItem";
            this.xuấtFileĐiểmToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.xuấtFileĐiểmToolStripMenuItem.Text = "Xuất file điểm";
            this.xuấtFileĐiểmToolStripMenuItem.Click += new System.EventHandler(this.xuấtFileĐiểmToolStripMenuItem_Click);
            // 
            // frmMain
=======
            // thêmDanhSáchToolStripMenuItem
            // 
            this.thêmDanhSáchToolStripMenuItem.Name = "thêmDanhSáchToolStripMenuItem";
            this.thêmDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.thêmDanhSáchToolStripMenuItem.Text = "Thêm danh sách";
            this.thêmDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.thêmDanhSáchToolStripMenuItem_Click);
            // 
            // _btnExport
            // 
            this._btnExport.Location = new System.Drawing.Point(327, 518);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(99, 23);
            this._btnExport.TabIndex = 9;
            this._btnExport.Text = "Xuất file điểm";
            this._btnExport.UseVisualStyleBackColor = true;
            this._btnExport.Click += new System.EventHandler(this._btnExport_Click);
            // 
            // Form1
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 557);
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.Controls.Add(this.axVLCPlugin21);
=======
            this.Controls.Add(this._btnExport);
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.Controls.Add(this._btnNext);
            this.Controls.Add(this._lblName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lblScore);
            this.Controls.Add(this._btnScore);
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
            this.Controls.Add(this._btnCenter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
=======
            this.Controls.Add(this._btnOpen);
            this.Controls.Add(this._ptbImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._ptbImage)).EndInit();
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _btnCenter;
        private System.Windows.Forms.Button _btnScore;
        private System.Windows.Forms.Label _lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Button _btnNext;
<<<<<<< HEAD:CameraApp/PointMark/frmMain.Designer.cs
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpDanhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtFileĐiểmToolStripMenuItem;
=======
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmDanhSáchToolStripMenuItem;
        private System.Windows.Forms.Button _btnExport;
>>>>>>> 3422f90fec3cf29ef0d1a4ab998affdcc48eb883:CameraApp/PointMark/Form1.Designer.cs
    }
}

