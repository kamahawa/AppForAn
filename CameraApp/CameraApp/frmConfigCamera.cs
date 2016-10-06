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
            frmRTSP.urlCamera = _txtUrlCamera.Text;
            this.Close();
        }

        private void frmConfigCamera_Load(object sender, EventArgs e)
        {
            _txtUrlCamera.Text = frmRTSP.urlCamera;
        }
    }
}
