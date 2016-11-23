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
    public partial class frmRegistration : Form
    {
        const int ProductCode = 1;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            _txtProductId.Text = ComputerInfo.GetComputerId();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(_txtProductId.Text);
            string productkey = _txtProductKey.Text;
            if(km.ValidKey(ref productkey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if(km.DisassembleKey(productkey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productkey;
                    lic.FullName = "Phần mềm chấm điểm";
                    if(kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("Bạn đã kích hoạt thành công.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm bạn nhập không chính xác.\nVui lòng kiểm tra lại mã sản phẩm.", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            KeyManager km = new KeyManager(ComputerInfo.GetComputerId());
            LicenseInfo lic = new LicenseInfo();
            int value = km.LoadSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), ref lic);
            string productKey = lic.ProductKey;
            bool isActive = false;//bien kiem tra kich hoat
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        //dung thu ma con ngay thi cho chay
                        if ((kv.Expiration - DateTime.Now.Date).Days > 0)
                        {
                            isActive = true;
                        }
                    }
                    else
                    {
                        isActive = true;
                    }
                }
            }

            // neu khong con ngay su dung, thoat khoi chuong trinh
            if (!isActive)
            {
                Application.Exit();
            }
        }
    }
}
