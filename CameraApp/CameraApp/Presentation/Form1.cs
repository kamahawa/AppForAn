using AForge.Video;
using AForge.Video.DirectShow;
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
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        //private VideoCaptureDevice FinalVideoDevice;

        public Form1()
        {
            InitializeComponent();
        }
        
        void FinalVideoDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                ptbCamera.Image = (Bitmap)e.Frame.Clone();

                //ve trong tam
                drawPoint(320, 240);
                //ptbCamera.Image.Save("temp.jpg");
            }
            catch { }
        }

        private void _btnGetStream_Click(object sender, EventArgs e)
        {
            
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                if (_txtIpCameraAddress.Text != "")
                {
                    //rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100
                    //test link : http://68.114.48.220:80/videostream.cgi?user=admin&pwd=
                    //test link : http://68.186.171.207:86/videostream.cgi?user=admin&pwd=
                    MJPEGStream stream = new MJPEGStream(_txtIpCameraAddress.Text);
                    stream.NewFrame += new NewFrameEventHandler(FinalVideoDevice_NewFrame);                    
                    stream.Start();
                }
                else
                {
                    MessageBox.Show("Please input camera ip.");
                }
            }
            catch
            {
                MessageBox.Show("Get stream fail. Please try again later");
            }
        }

        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(ptbCamera.Handle);
            SolidBrush brush = new SolidBrush(Color.Red);
            Point dPoint = new Point(x, (ptbCamera.Height - y));
            dPoint.X = dPoint.X - 2;
            dPoint.Y = dPoint.Y - 2;
            Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }
    }
}
