namespace CameraApp
{
    partial class frmEditBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditBox));
            this._txtContent = new System.Windows.Forms.TextBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtContent
            // 
            this._txtContent.Location = new System.Drawing.Point(13, 13);
            this._txtContent.Name = "_txtContent";
            this._txtContent.Size = new System.Drawing.Size(436, 20);
            this._txtContent.TabIndex = 0;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(142, 43);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 1;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(234, 43);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // frmEditBox
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 78);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._txtContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 117);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(476, 117);
            this.Name = "frmEditBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thay đổi tên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtContent;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
    }
}