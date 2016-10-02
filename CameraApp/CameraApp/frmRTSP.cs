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

namespace CameraApp
{
    public partial class frmRTSP : Form
    {
        private FilterInfoCollection _videoCaptureDevices;

        private int X;
        private int Y;

        private int XCenter;
        private int YCenter;

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
            LoadCamera();
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
            //lay tam
            MessageBox.Show(string.Format("X: {0} Y: {1}", XCenter, YCenter));
        }

        private void _ptbCamera_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            drawPoint(X, Y);
        }

        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(_ptbCamera.Handle);
            SolidBrush brush = new SolidBrush(Color.Red);
            Point dPoint = new Point(x, y);
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            g.Dispose();
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

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
