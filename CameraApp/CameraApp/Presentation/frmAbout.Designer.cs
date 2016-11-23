namespace CameraApp
{
    partial class frmAbout
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
            this._lblProductName = new System.Windows.Forms.Label();
            this._lblProductId = new System.Windows.Forms.Label();
            this._lblProductKey = new System.Windows.Forms.Label();
            this._lblLicenseType = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID sản phẩm : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã sản phẩm : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại bản quyền : ";
            // 
            // _lblProductName
            // 
            this._lblProductName.AutoSize = true;
            this._lblProductName.Location = new System.Drawing.Point(149, 13);
            this._lblProductName.Name = "_lblProductName";
            this._lblProductName.Size = new System.Drawing.Size(112, 13);
            this._lblProductName.TabIndex = 0;
            this._lblProductName.Text = "Phần mềm chấm điểm";
            // 
            // _lblProductId
            // 
            this._lblProductId.AutoSize = true;
            this._lblProductId.Location = new System.Drawing.Point(149, 41);
            this._lblProductId.Name = "_lblProductId";
            this._lblProductId.Size = new System.Drawing.Size(13, 13);
            this._lblProductId.TabIndex = 0;
            this._lblProductId.Text = "?";
            // 
            // _lblProductKey
            // 
            this._lblProductKey.AutoSize = true;
            this._lblProductKey.Location = new System.Drawing.Point(149, 75);
            this._lblProductKey.Name = "_lblProductKey";
            this._lblProductKey.Size = new System.Drawing.Size(13, 13);
            this._lblProductKey.TabIndex = 0;
            this._lblProductKey.Text = "?";
            // 
            // _lblLicenseType
            // 
            this._lblLicenseType.AutoSize = true;
            this._lblLicenseType.Location = new System.Drawing.Point(149, 105);
            this._lblLicenseType.Name = "_lblLicenseType";
            this._lblLicenseType.Size = new System.Drawing.Size(13, 13);
            this._lblLicenseType.TabIndex = 0;
            this._lblLicenseType.Text = "?";
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(203, 133);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 1;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 168);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._lblLicenseType);
            this.Controls.Add(this._lblProductKey);
            this.Controls.Add(this._lblProductId);
            this.Controls.Add(this._lblProductName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin sản phẩm";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblProductName;
        private System.Windows.Forms.Label _lblProductId;
        private System.Windows.Forms.Label _lblProductKey;
        private System.Windows.Forms.Label _lblLicenseType;
        private System.Windows.Forms.Button _btnOK;
    }
}