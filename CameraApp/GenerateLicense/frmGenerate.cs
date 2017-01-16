using FoxLearn.License;
using System;
using System.Windows.Forms;

namespace GenerateLicense
{
    public partial class frmGenerate : Form
    {
        const int ProductCode = 1;

        public frmGenerate()
        {
            InitializeComponent();
        }

        private void frmGenerate_Load(object sender, EventArgs e)
        {
            _cboLicenseType.SelectedIndex = 0;
            _txtProductId.Text = ComputerInfo.GetComputerId();
        }

        private void _btnGenerate_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(_txtProductId.Text);
            KeyValuesClass kv;
            string productKey = string.Empty;
            if(_cboLicenseType.SelectedIndex == 0)
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.FULL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1
                };
            }
            else
            {
                kv = new KeyValuesClass()
                {
                    Type = LicenseType.TRIAL,
                    Header = Convert.ToByte(9),
                    Footer = Convert.ToByte(6),
                    ProductCode = (byte)ProductCode,
                    Edition = Edition.ENTERPRISE,
                    Version = 1,
                    Expiration = DateTime.Now.Date.AddDays(Convert.ToInt32(_txtExperience.Text))
                };
            }
            if (!km.GenerateKey(kv, ref productKey))
            {
                _txtProductKey.Text = "Lỗi khi kích hoạt bản quyền. Vui lòng kích hoạt lại.";
            }
            else
            {
                _txtProductKey.Text = productKey;
            }
        }
    }
}
