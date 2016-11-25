using FoxLearn.License;
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
    public partial class frmAbout : Form
    {
        const int ProductCode = 1;

        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            _lblProductId.Text = ComputerInfo.GetComputerId();
            KeyManager km = new KeyManager(_lblProductId.Text);
            LicenseInfo lic = new LicenseInfo();
            int value = km.LoadSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), ref lic);
            string productKey = lic.ProductKey;
            if(km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if(km.DisassembleKey(productKey, ref kv))
                {
                    //_lblProductName.Text = "Phần mềm chấm điểm";
                    _lblProductKey.Text = productKey;
                    if(kv.Type == LicenseType.TRIAL)
                    {
                        _lblLicenseType.Text = string.Format("Bản dùng thử còn {0} ngày", (kv.Expiration - DateTime.Now.Date).Days);
                    }
                    else
                    {
                        _lblLicenseType.Text = "Bản quyền đã kích hoạt";
                    }
                }
            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
