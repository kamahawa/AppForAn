namespace GenerateLicense
{
    partial class frmGenerate
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
            this._txtProductId = new System.Windows.Forms.TextBox();
            this._cboLicenseType = new System.Windows.Forms.ComboBox();
            this._txtExperience = new System.Windows.Forms.TextBox();
            this._txtProductKey = new System.Windows.Forms.TextBox();
            this._btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Id : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "License Type : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience Days : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product Key : ";
            // 
            // _txtProductId
            // 
            this._txtProductId.Location = new System.Drawing.Point(110, 5);
            this._txtProductId.Name = "_txtProductId";
            this._txtProductId.ReadOnly = true;
            this._txtProductId.Size = new System.Drawing.Size(431, 20);
            this._txtProductId.TabIndex = 4;
            // 
            // _cboLicenseType
            // 
            this._cboLicenseType.FormattingEnabled = true;
            this._cboLicenseType.Items.AddRange(new object[] {
            "Full",
            "Trial"});
            this._cboLicenseType.Location = new System.Drawing.Point(110, 35);
            this._cboLicenseType.Name = "_cboLicenseType";
            this._cboLicenseType.Size = new System.Drawing.Size(121, 21);
            this._cboLicenseType.TabIndex = 5;
            // 
            // _txtExperience
            // 
            this._txtExperience.Location = new System.Drawing.Point(110, 70);
            this._txtExperience.Name = "_txtExperience";
            this._txtExperience.Size = new System.Drawing.Size(121, 20);
            this._txtExperience.TabIndex = 6;
            // 
            // _txtProductKey
            // 
            this._txtProductKey.Location = new System.Drawing.Point(110, 103);
            this._txtProductKey.Name = "_txtProductKey";
            this._txtProductKey.ReadOnly = true;
            this._txtProductKey.Size = new System.Drawing.Size(431, 20);
            this._txtProductKey.TabIndex = 7;
            // 
            // _btnGenerate
            // 
            this._btnGenerate.Location = new System.Drawing.Point(415, 139);
            this._btnGenerate.Name = "_btnGenerate";
            this._btnGenerate.Size = new System.Drawing.Size(126, 23);
            this._btnGenerate.TabIndex = 8;
            this._btnGenerate.Text = "&Generate";
            this._btnGenerate.UseVisualStyleBackColor = true;
            this._btnGenerate.Click += new System.EventHandler(this._btnGenerate_Click);
            // 
            // frmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 175);
            this.Controls.Add(this._btnGenerate);
            this.Controls.Add(this._txtProductKey);
            this.Controls.Add(this._txtExperience);
            this.Controls.Add(this._cboLicenseType);
            this.Controls.Add(this._txtProductId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGenerate";
            this.Text = "Generate License";
            this.Load += new System.EventHandler(this.frmGenerate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _txtProductId;
        private System.Windows.Forms.ComboBox _cboLicenseType;
        private System.Windows.Forms.TextBox _txtExperience;
        private System.Windows.Forms.TextBox _txtProductKey;
        private System.Windows.Forms.Button _btnGenerate;
    }
}

