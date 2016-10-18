namespace CameraApp
{
    partial class frmConfigCamera
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
            this._lblName = new System.Windows.Forms.Label();
            this._txtUrlCamera = new System.Windows.Forms.TextBox();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._txtUrlCamera1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._txtUrlCamera2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(12, 18);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(85, 13);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Nhập url camera";
            // 
            // _txtUrlCamera
            // 
            this._txtUrlCamera.Location = new System.Drawing.Point(103, 15);
            this._txtUrlCamera.Name = "_txtUrlCamera";
            this._txtUrlCamera.Size = new System.Drawing.Size(488, 20);
            this._txtUrlCamera.TabIndex = 1;
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(210, 96);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 2;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(291, 96);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 3;
            this._btnCancel.Text = "Hủy";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _txtUrlCamera1
            // 
            this._txtUrlCamera1.Location = new System.Drawing.Point(104, 41);
            this._txtUrlCamera1.Name = "_txtUrlCamera1";
            this._txtUrlCamera1.Size = new System.Drawing.Size(488, 20);
            this._txtUrlCamera1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập url camera";
            // 
            // _txtUrlCamera2
            // 
            this._txtUrlCamera2.Location = new System.Drawing.Point(104, 67);
            this._txtUrlCamera2.Name = "_txtUrlCamera2";
            this._txtUrlCamera2.Size = new System.Drawing.Size(488, 20);
            this._txtUrlCamera2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nhập url camera";
            // 
            // frmConfigCamera
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 131);
            this.Controls.Add(this._txtUrlCamera2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtUrlCamera1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._txtUrlCamera);
            this.Controls.Add(this._lblName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 170);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 170);
            this.Name = "frmConfigCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera url";
            this.Load += new System.EventHandler(this.frmConfigCamera_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _txtUrlCamera;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.TextBox _txtUrlCamera1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtUrlCamera2;
        private System.Windows.Forms.Label label2;
    }
}