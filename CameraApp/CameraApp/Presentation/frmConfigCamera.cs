using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraApp
{
    public partial class frmConfigCamera : Form
    {
        public frmConfigCamera()
        {
            InitializeComponent();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            string[] urlArr = { _txtUrlCamera.Text.Trim(), _txtUrlCamera1.Text.Trim(), _txtUrlCamera2.Text.Trim() };
            frmMain.WriteUrlCameraArray(urlArr);
            this.Close();
        }

        private void frmConfigCamera_Load(object sender, EventArgs e)
        {
            _txtUrlCamera.Text = frmMain.urlCamera[0];
            _txtUrlCamera1.Text = frmMain.urlCamera[1];
            _txtUrlCamera2.Text = frmMain.urlCamera[2];
        }
    }
}
