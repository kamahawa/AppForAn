using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

using System.IO;
using CameraApp.Help;

namespace CameraApp
{
    public partial class frmRTSP : Form
    {
        //"http://68.114.48.220:80/videostream.cgi?user=admin&pwd=";
        //"rtsp://192.168.1.12:533/user=admin&password=&channel=1&stream=0.sdp?real_stream--rtp-caching=100";
        //"rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100";
        private string urlCamera = "http://68.114.48.220:80/videostream.cgi?user=admin&pwd=";
        private FilterInfoCollection _videoCaptureDevices;

        private int X;
        private int Y;
        
        // test and get is 318, 218
        private int XCenter = 318;
        private int YCenter = 218;

        //luot ban
        private int luot = 1;
        
        public frmRTSP()
        {
            InitializeComponent();
        }

        private void _btnGetStream_Click(object sender, EventArgs e)
        {
            //axVLCPlugin21.playlist.add("rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100", null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
            //axVLCPlugin21.playlist.play();
        }
        
        private void frmRTSP_Load(object sender, EventArgs e)
        {
            //LoadCamera();
            axVLCPlugin21.playlist.add(urlCamera, null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
            axVLCPlugin21.playlist.play();
        }
        
        void LoadCamera()
        {
            _videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                //rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100
                //test link : http://68.114.48.220:80/videostream.cgi?user=admin&pwd=
                //test link : http://68.186.171.207:86/videostream.cgi?user=admin&pwd=
                MJPEGStream stream = new MJPEGStream("http://68.114.48.220:80/videostream.cgi?user=admin&pwd=");
                stream.NewFrame += new NewFrameEventHandler(FinalVideoDevice_NewFrame);
                stream.Start();
            }
            catch
            {
                MessageBox.Show("Get stream fail. Please try again later");
            }
        }

        void FinalVideoDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                _ptbCamera.Image = (Bitmap)e.Frame.Clone();
            }
            catch { }
        }

        private void _btnGetCenter_Click(object sender, EventArgs e)
        {
            XCenter = X;
            YCenter = Y;
            drawPoint(XCenter, YCenter, _transpCtrl);
            //lay tam
            //MessageBox.Show(string.Format("X: {0} Y: {1}", XCenter, YCenter));
        }

        public void drawPoint(int x, int y, Control c)
        {
            Graphics g = Graphics.FromHwnd(c.Handle);
            /*
            SolidBrush brush = new SolidBrush(Color.Red);
            Point dPoint = new Point(x, y);
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            */
            //Icon xIcon = Properties.Resources.x;
            //g.DrawIcon(Properties.Resources.x, x, y);

            //cho chinh giua file
            g.DrawImage(Properties.Resources.x, x - 8, y - 8);
            g.Dispose();
        }

        private void _btnScore_Click(object sender, EventArgs e)
        {
            if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 37.5)
            {
                _lblScore.Text = "10";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 75)
            {
                _lblScore.Text = "9";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 112.5)
            {
                _lblScore.Text = "8";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 150)
            {
                _lblScore.Text = "7";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 187.5)
            {
                _lblScore.Text = "6";
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 225)
            {
                _lblScore.Text = "5";
            }
            else
            {
                _lblScore.Text = "0";
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void xuấtFileĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelHelp.ExportExcel(GetTable());
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

        private void thêmDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            this.Hide();
            frmAddList frm = new frmAddList();
            frm.ShowDialog();
            this.Show();
            */
            DataTable table = new DataTable();
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Lần 1", typeof(int));
            table.Columns.Add("Lần 2", typeof(int));
            table.Columns.Add("Lần 3", typeof(int));
            table.Columns.Add("Tổng", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add("Nguyễn Văn A", null, null, null, null);
            table.Rows.Add("Nguyễn Văn b", null, null, null, null);
            table.Rows.Add("Nguyễn Văn c", null, null, null, null);

            _dtgScore.DataSource = table;

            _lblName.Text = table.Rows[0][0].ToString();
        }

        private void _transpCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            //drawPoint(X, Y, _transpCtrl);
            addShotIcon(X, Y);
        }

        private void addShotIcon(int x, int y)
        {
            PictureBox px = new PictureBox();
            px.Size = new Size(8, 8);
            px.BackColor = Color.Transparent;
            px.SizeMode = PictureBoxSizeMode.StretchImage;
            px.Image = Properties.Resources.x;
            // tru di 4 don vi de chinh giua hinh
            px.Location = new Point(x - 4, y - 4);
            _panCam.Controls.Add(px);
            px.BringToFront();
        }

        private void _btnMiss_Click(object sender, EventArgs e)
        {
            _lblScore.Text = "0";
        }
    }
}
