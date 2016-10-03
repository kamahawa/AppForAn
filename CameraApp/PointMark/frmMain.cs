using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PointMark
{
    public partial class frmMain : Form
    {
        private int X;
        private int Y;

        private int XCenter;
        private int YCenter;

        List<string> _lstDS;

        public frmMain()
        {
            InitializeComponent();
        }

        private void _btnCenter_Click(object sender, EventArgs e)
        {
            XCenter = X;
            YCenter = Y;
            //lay tam
            //MessageBox.Show(string.Format("X: {0} Y: {1}", XCenter, YCenter));
        }

        private void _btnScore_Click(object sender, EventArgs e)
        {
            //_lblPoint.Text = string.Format("XCenter: {0} YCenter: {1} X: {2} Y: {3}", XCenter, YCenter, X, Y);

            if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 55)
            {
                _lblScore.Text = "10";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 105)
            {
                _lblScore.Text = "9";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 160)
            {
                _lblScore.Text = "8";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 220)
            {
                _lblScore.Text = "7";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 275)
            {
                _lblScore.Text = "6";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 325)
            {
                _lblScore.Text = "5";
            }
            else
            {
                _lblScore.Text = "0";
            }

        }
        
        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(axVLCPlugin21.Handle);
            SolidBrush brush = new SolidBrush(Color.Red);
            Point dPoint = new Point(x, y);
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }

        private void _btnNext_Click(object sender, EventArgs e)
        {
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //axVLCPlugin21.playlist.add("rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100", null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
            //axVLCPlugin21.playlist.add("http://68.114.48.220:80/videostream.cgi?user=admin&pwd=", null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
            axVLCPlugin21.playlist.add("rtsp://iprobocam.marmitek.com/mpeg4", null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");

            axVLCPlugin21.playlist.play();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            drawPoint(X, Y);
            MessageBox.Show(string.Format("X: {0} Y: {1}", X, Y));
        }

        private void nhậpDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void xuấtFileĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            if (od.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReadExcelContents(od.FileName);

                    //get list
                    _lstDS = new List<string>();

                    _lstDS.Add("Nguyen Van A");
                    _lstDS.Add("Nguyen Van B");
                    _lstDS.Add("Tran Quang C");
                }
                catch(Exception ex)
                { }
            }
        }

        public DataTable ReadExcelContents(string fileName)
        {
            try
            {
                /*
                string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", fileName);
                string query = String.Format("select * from [{0}$]", "Sheet1");
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                */
                string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""", fileName);
                string query = String.Format("select * from [{0}$]", "Sheet1");
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectionString);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                //dataGridView1.DataSource = dataSet.Tables[0];


                DataTable dt = dataSet.Tables[0];
                
                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Program can't read file. " + ex.Message, "Please Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void _btnExport_Click(object sender, EventArgs e)
        {
            ExportExcel(GetTable());
        }

        public void ExportExcel(DataTable dt)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "xls files (*.xls)|*.xls";
            sd.FilterIndex = 2;
            sd.RestoreDirectory = true;

            if (sd.ShowDialog() == DialogResult.OK)
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                /*
                xlWorkSheet.Cells[0, 1] = "Tên";
                xlWorkSheet.Cells[0, 2] = "Lần 1";
                xlWorkSheet.Cells[0, 3] = "Lần 2";
                xlWorkSheet.Cells[0, 4] = "Lần 3";
                xlWorkSheet.Cells[0, 5] = "Tổng";
                */

                //chay tu 1, 0 la title
                for (int i = 1; i <= dt.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dt.Columns.Count - 1; j++)
                    {
                        string data = dt.Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 1, j + 1] = data;
                    }
                }
                xlWorkBook.SaveAs(sd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }

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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Lần 1", typeof(int));
            table.Columns.Add("Lần 2", typeof(int));
            table.Columns.Add("Lần 3", typeof(int));
            table.Columns.Add("Tổng", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add("Nguyễn Văn A", 10, 8, 9, 27);
            table.Rows.Add("Nguyễn Văn b", 10, 8, 8, 26);
            table.Rows.Add("Nguyễn Văn c", 10, 8, 7, 25);
            return table;
        }
    }
}
