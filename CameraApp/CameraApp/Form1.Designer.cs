namespace CameraApp
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
            this.ptbCamera = new System.Windows.Forms.PictureBox();
            this._btnGetStream = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._txtIpCameraAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbCamera
            // 
            this.ptbCamera.Location = new System.Drawing.Point(16, 12);
            this.ptbCamera.Name = "ptbCamera";
            this.ptbCamera.Size = new System.Drawing.Size(640, 480);
            this.ptbCamera.TabIndex = 0;
            this.ptbCamera.TabStop = false;
            // 
            // _btnGetStream
            // 
            this._btnGetStream.Location = new System.Drawing.Point(581, 510);
            this._btnGetStream.Name = "_btnGetStream";
            this._btnGetStream.Size = new System.Drawing.Size(75, 23);
            this._btnGetStream.TabIndex = 1;
            this._btnGetStream.Text = "Get Stream";
            this._btnGetStream.UseVisualStyleBackColor = true;
            this._btnGetStream.Click += new System.EventHandler(this._btnGetStream_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Camera Address : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _txtIpCameraAddress
            // 
            this._txtIpCameraAddress.Location = new System.Drawing.Point(125, 512);
            this._txtIpCameraAddress.Name = "_txtIpCameraAddress";
            this._txtIpCameraAddress.Size = new System.Drawing.Size(450, 20);
            this._txtIpCameraAddress.TabIndex = 3;
            this._txtIpCameraAddress.Text = "http://68.114.48.220:80/videostream.cgi?user=admin&pwd=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 548);
            this.Controls.Add(this._txtIpCameraAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnGetStream);
            this.Controls.Add(this.ptbCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ptbCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbCamera;
        private System.Windows.Forms.Button _btnGetStream;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtIpCameraAddress;
    }
}

