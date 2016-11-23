namespace CameraApp
{
    partial class frmRegistration
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
            this._txtProductId = new System.Windows.Forms.TextBox();
            this._txtProductKey = new System.Windows.Forms.TextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID sản phẩm : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã sản phẩm : ";
            // 
            // _txtProductId
            // 
            this._txtProductId.Location = new System.Drawing.Point(102, 6);
            this._txtProductId.Name = "_txtProductId";
            this._txtProductId.ReadOnly = true;
            this._txtProductId.Size = new System.Drawing.Size(449, 20);
            this._txtProductId.TabIndex = 2;
            // 
            // _txtProductKey
            // 
            this._txtProductKey.Location = new System.Drawing.Point(102, 38);
            this._txtProductKey.Name = "_txtProductKey";
            this._txtProductKey.Size = new System.Drawing.Size(449, 20);
            this._txtProductKey.TabIndex = 2;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(392, 66);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(158, 23);
            this._btnOK.TabIndex = 3;
            this._btnOK.Text = "Đăng ký";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // frmRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 103);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._txtProductKey);
            this.Controls.Add(this._txtProductId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegistration_FormClosed);
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtProductId;
        private System.Windows.Forms.TextBox _txtProductKey;
        private System.Windows.Forms.Button _btnOK;
    }
}