using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace CameraApp
{
    public partial class frmAddList : Form
    {
        public frmAddList()
        {
            InitializeComponent();
        }

        private void _btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ReadExcel(dlg.FileName);
            }
        }

        void ReadExcel(string fileName)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileName);
            // Lấy Sheet 1
            Excel.Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets.get_Item(1);
            // Lấy phạm vi dữ liệu
            Excel.Range xlRange = xlWorksheet.UsedRange;
            // Tạo mảng lưu trữ dữ liệu
            object[,] valueArray = (object[,])xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

            DataTable dt = new DataTable();

            // Hiển thị nọi dung
            for (int row = 1; row <= xlWorksheet.UsedRange.Rows.Count; ++row)//đọc row hiện có trong Excel
            {
                DataRow workRow = dt.NewRow();
                for (int colum = 1; colum <= xlWorksheet.UsedRange.Columns.Count; ++colum)//đọc colum trong Excel
                {
                    if(valueArray[row, colum] == null)
                    {
                        workRow[colum-1] = "";
                    }
                    else
                    {
                        workRow[colum-1] = valueArray[row, colum].ToString();
                    }

                }
            }

            dataGridView1.DataSource = dt;

            // Đóng Workbook.
            xlWorkbook.Close(false);
            // Đóng application.
            xlApp.Quit();
            //Khử hết đối tượng
            releaseObject(xlWorkbook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
