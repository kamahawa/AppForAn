using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using AForge.Video;
using CameraApp.Help;
using Microsoft.VisualBasic;
using System.IO;
using ImageMagick;
using AxAXVLC;
using System.Media;
using System.Threading;

namespace CameraApp
{
    public partial class frmRTSP : Form
    {
        //CCC24QW-D22-21EA7A046N
        //"http://68.114.48.220:80/videostream.cgi?user=admin&pwd=";
        //"rtsp://192.168.1.12:533/user=admin&password=&channel=1&stream=0.sdp?real_stream--rtp-caching=100";
        //"rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100";
        public static string[] urlCamera = new string[3];
        //private FilterInfoCollection _videoCaptureDevices;

        private int X;
        private int Y;

        // test and get is 322, 226
        //346 , 294
        private int XCenter = 321;
        private int YCenter = 225;

        //luot ban
        private int luotBia1 = 1, luotBia2 = 1, luotBia3 = 1;
        private int currentMemberBia1 = 0, currentMemberBia2 = 0, currentMemberBia3 = 0;

        public frmRTSP()
        {
            InitializeComponent();
            //urlCamera = LoadUrlCamera();
            LoadUrlCamera();
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
            /*
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
            */
            /*
            if (axVLCPlugin21.playlist.isPlaying)
            { 
                axVLCPlugin21.playlist.stop();
            }
            */
            try
            {
                if (urlCamera[0] != "")
                {
                    _vlc.playlist.add(urlCamera[0], null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
                    _vlc.playlist.next();
                }
                if (urlCamera[1] != "")
                {
                    _vlc1.playlist.add(urlCamera[1], null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
                    _vlc1.playlist.next();
                }
                if (urlCamera[2] != "")
                {
                    _vlc2.playlist.add(urlCamera[2], null, ":sout=#transcode{vcodec=theo,vb=800,acodec=flac,ab=128,channels=2,samplerate=44100}:file{dst=C:\\123.ogg,no-overwrite} :sout-keep");
                    _vlc2.playlist.next();
                }
            }
            catch
            { }
        }

        void LoadUrlCamera()
        {
            string path = @"UrlCamera.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn camera.");
                //return "";
            }
            else
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(path);

                    //Read the first line of text
                    String line = sr.ReadLine();

                    for (int i = 0; i < 3; i++)
                    {
                        if (line != null)
                        {
                            urlCamera[i] = line;

                            //Read the next line
                            line = sr.ReadLine();
                        }
                    }

                    /*
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        //Console.WriteLine(line);

                        //Read the next line
                        line = sr.ReadLine();
                    }
                    */

                    //close the file
                    sr.Close();
                }
                catch (Exception ex)
                { }
            }
            //return File.ReadAllText(path);
        }

        public static void WriteUrlCamera(string url)
        {
            string path = @"UrlCamera.txt";
            File.WriteAllText(path, url);
        }

        public static void WriteUrlCameraArray(string[] urlArr)
        {
            string path = @"UrlCamera.txt";
            File.WriteAllLines(path, urlArr);
        }

        void FinalVideoDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            try
            {
                _ptbCamera.Image = (Bitmap)e.Frame.Clone();
            }
            catch { }
        }

        #region be so 1
        private void _btnGetCenter_Click(object sender, EventArgs e)
        {
            //224,134  416,133  204,333   438,334
            //toa do do bang pts : 285,85    646,85   238,483    689,484
            /*
            XCenter = X;
            YCenter = Y;
            addShotIcon(XCenter, YCenter, _panCam);
            //lay tam
            MessageBox.Show(string.Format("X: {0} Y: {1}", XCenter, YCenter));
            */
            double h = _ptbCamera.Height;//578 is real height
            double w = _ptbCamera.Width;//928 is real widht

            double _lenghtDistort = 430;

            using (MagickImage image = new MagickImage("D:\\bia.png"))
            {
                image.VirtualPixelMethod = VirtualPixelMethod.Tile;
                //224,134,  0,0,  416,133,  500,0,  204,333,  0,h,  438,334,  500,h
                double[] args =
                {
                    285,85, // toa do diem dau
                    0,0, // toa do dat diem dau tien

                    646,85, // toa do diem 2
                    400,0, // toa do dat diem 2
                    
                    238,483, // toa do diem 3
                    0,400, // toa do dat diem 3

                    689,484, // toa do diem 4
                    400,400 // toa do dat diem 4
                };

                image.Distort(DistortMethod.Perspective, args);
                image.Crop(400, 400, Gravity.Northwest);
                //image.Write("D:\\test.png");
                _ptbCamera.Image = image.ToBitmap();
            }
        }

        private void _btnScore_Click(object sender, EventArgs e)
        {
            ShowScore(ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, 1);
            //ShowScore(ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore);
            /*
            if (_ptbCamera.Visible == false)
                _ptbCamera.Visible = true;
            else
            {
                _ptbCamera.Visible = false;
            }
            ShowPictureCrop(_vlc, _ptbCamera);
            */
        }

        private void _transpCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            addShotIcon(X, Y, _panCam);
        }

        private void _btnMiss_Click(object sender, EventArgs e)
        {
            _lblScore.Text = "0";
            chamDiem(0, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, 1);
        }
        #endregion

        #region be so 2
        private void _btnScore2_Click(object sender, EventArgs e)
        {
            ShowScore(ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, 2);
        }

        private void _btnMiss2_Click(object sender, EventArgs e)
        {
            _lblScore2.Text = "0";
            chamDiem(0, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, 2);
        }

        private void _transpCtrl2_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            addShotIcon(X, Y, _panCam2);
        }
        #endregion

        #region be so 3
        private void _btnScore3_Click(object sender, EventArgs e)
        {
            ShowScore(ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, 3);
        }

        private void _btnMiss3_Click(object sender, EventArgs e)
        {
            _lblScore3.Text = "0";
            chamDiem(0, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, 3);
        }

        private void _transpCtrl3_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            addShotIcon(X, Y, _panCam3);
        }
        #endregion

        #region xu ly cham diem

        private void ShowPictureCrop(AxVLCPlugin2 vlc, PictureBox picCamera)
        {
            vlc.video.takeSnapshot();
            
            picCamera.Image = Image.FromFile("CAXVLC24C0S1.bmp");
        }

        private void addShotIcon(int x, int y, Panel panCam)
        {
            PictureBox px = new PictureBox();
            px.Size = new Size(4, 4);
            px.BackColor = Color.Transparent;
            px.SizeMode = PictureBoxSizeMode.StretchImage;
            px.Image = Properties.Resources.x;
            // tru di 4 don vi de chinh giua hinh
            px.Location = new Point(x - 2, y - 2);
            //_panCam.Controls.Add(px);
            panCam.Controls.Add(px);
            px.BringToFront();
        }

        private void ShowScore(ref int luotBia, ref int currentMemberBia,DataGridView dtgScore, Label lblName, Label lblScore, int be)
        {
            int diem = 0;
            if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 26.5)
            {
                if (Y > 200 && Y < 250)
                {
                    lblScore.Text = "10";
                    diem = 10;
                }
                else
                {
                    lblScore.Text = "9";
                    diem = 9;
                }
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 53)
            {
                if (Y > 180 && Y < 275)
                {
                    lblScore.Text = "9";
                    diem = 9;
                }
                else
                {
                    lblScore.Text = "8";
                    diem = 8;
                }

            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 79)
            {
                if (Y > 158 && Y < 303)
                {
                    lblScore.Text = "8";
                    diem = 8;
                }
                else
                {
                    lblScore.Text = "7";
                    diem = 7;
                }
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 105)
            {
                if (Y > 137 && Y < 330)
                {
                    lblScore.Text = "7";
                    diem = 7;
                }
                else
                {
                    lblScore.Text = "6";
                    diem = 6;
                }
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 133)
            {
                lblScore.Text = "6";
                diem = 6;
            }
            else if (Math.Sqrt(Math.Pow((X - XCenter), 2) + Math.Pow((Y - YCenter), 2)) <= 158)
            {
                lblScore.Text = "5";
                diem = 5;
            }
            else
            {
                lblScore.Text = "0";
                diem = 0;
            }
            chamDiem(diem, ref luotBia, ref currentMemberBia, dtgScore, lblName, lblScore, be);
        }

        private void chamDiem(int diem, ref int luot, ref int currentMember, DataGridView dtgScore, Label lblName, Label lblScore, int be)
        {
            try
            {
                //DataTable dt = (DataTable)_dtgScore.DataSource;
                DataTable dt = (DataTable)dtgScore.DataSource;
                dt.Rows[currentMember][luot] = diem;

                switch (diem)
                {
                    case 0:
                        playSound(@"ScoreSound\0_diem.wav");
                        break;
                    case 5:
                        playSound(@"ScoreSound\5_diem.wav");
                        break;
                    case 6:
                        playSound(@"ScoreSound\6_diem.wav");
                        break;
                    case 7:
                        playSound(@"ScoreSound\7_diem.wav");
                        break;
                    case 8:
                        playSound(@"ScoreSound\8_diem.wav");
                        break;
                    case 9:
                        playSound(@"ScoreSound\9_diem.wav");
                        break;
                    case 10:
                        playSound(@"ScoreSound\10_diem.wav");
                        break;
                }

                if (luot == 3)
                {
                    //ban het luot thi tinh tong diem
                    int l1 = (int)dt.Rows[currentMember][1];
                    int l2 = (int)dt.Rows[currentMember][2];
                    int l3 = (int)dt.Rows[currentMember][3];

                    int tong = l1 + l2 + l3;

                    //tong diem
                    dt.Rows[currentMember][4] = tong;

                    luot = 1;
                    currentMember++; // het luot thi nguoi khac vao ban

                    //load ten
                    //_lblName.Text = dt.Rows[currentMember][0].ToString();
                    //_lblScore.Text = "";
                    if(dt.Rows.Count < currentMember)
                    { 
                        lblName.Text = dt.Rows[currentMember][0].ToString();
                        lblScore.Text = "";
                    }

                    Thread thread = new Thread(() => soundDiem(be, tong));
                    thread.Start();
                    //soundDiem(be, tong);
                }
                else
                {
                    luot++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void soundDiem(int be, int tong)
        {

            //nghi 1 giay de doc so diem o luot 3
            Thread.Sleep(1000);
            //neu la o be nao thi phat len tong o be do
            if (be == 1)
            {
                playSound(@"ScoreSound\Tong_diem_be_so_1_la.wav");
            }
            else if (be == 2)
            {
                playSound(@"ScoreSound\Tong_diem_be_so_2_la.wav");
            }
            else if (be == 3)
            {
                playSound(@"ScoreSound\Tong_diem_be_so_3_la.wav");
            }
            //nghi 2 giay de doc so diem o luot tong diem be
            Thread.Sleep(2000);
            switch (tong)
            {
                case 0:
                    playSound(@"ScoreSound\0_diem.wav");
                    break;
                case 5:
                    playSound(@"ScoreSound\5_diem.wav");
                    break;
                case 6:
                    playSound(@"ScoreSound\6_diem.wav");
                    break;
                case 7:
                    playSound(@"ScoreSound\7_diem.wav");
                    break;
                case 8:
                    playSound(@"ScoreSound\8_diem.wav");
                    break;
                case 9:
                    playSound(@"ScoreSound\9_diem.wav");
                    break;
                case 10:
                    playSound(@"ScoreSound\10_diem.wav");
                    break;
                case 11:
                    playSound(@"ScoreSound\11_diem.wav");
                    break;
                case 12:
                    playSound(@"ScoreSound\12_diem.wav");
                    break;
                case 13:
                    playSound(@"ScoreSound\13_diem.wav");
                    break;
                case 14:
                    playSound(@"ScoreSound\14_diem.wav");
                    break;
                case 15:
                    playSound(@"ScoreSound\15_diem.wav");
                    break;
                case 16:
                    playSound(@"ScoreSound\16_diem.wav");
                    break;
                case 17:
                    playSound(@"ScoreSound\17_diem.wav");
                    break;
                case 18:
                    playSound(@"ScoreSound\18_diem.wav");
                    break;
                case 19:
                    playSound(@"ScoreSound\19_diem.wav");
                    break;
                case 20:
                    playSound(@"ScoreSound\20_diem.wav");
                    break;
                case 21:
                    playSound(@"ScoreSound\21_diem.wav");
                    break;
                case 22:
                    playSound(@"ScoreSound\22_diem.wav");
                    break;
                case 23:
                    playSound(@"ScoreSound\23_diem.wav");
                    break;
                case 24:
                    playSound(@"ScoreSound\24_diem.wav");
                    break;
                case 25:
                    playSound(@"ScoreSound\25_diem.wav");
                    break;
                case 26:
                    playSound(@"ScoreSound\26_diem.wav");
                    break;
                case 27:
                    playSound(@"ScoreSound\27_diem.wav");
                    break;
                case 28:
                    playSound(@"ScoreSound\28_diem.wav");
                    break;
                case 29:
                    playSound(@"ScoreSound\29_diem.wav");
                    break;
                case 30:
                    playSound(@"ScoreSound\30_diem.wav");
                    break;
            }
        }

        private void playSound(string fileName)
        {
            SoundPlayer simpleSound = new SoundPlayer(fileName);
            simpleSound.Play();
        }

        #endregion

        #region menu progress
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void xuấtFileĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelHelp.ExportExcel((DataTable)_dtgScore.DataSource);
        }
        
        private void thêmDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //load info be so 1
            DataTable table = new DataTable();
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Lần 1", typeof(int));
            table.Columns.Add("Lần 2", typeof(int));
            table.Columns.Add("Lần 3", typeof(int));
            table.Columns.Add("Tổng", typeof(string));            
            table.Rows.Add("Nguyễn Văn A", null, null, null, null);
            table.Rows.Add("Nguyễn Văn b", null, null, null, null);
            table.Rows.Add("Nguyễn Văn c", null, null, null, null);
            _dtgScore.DataSource = table;
            //mo rong phan ten
            _dtgScore.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _lblName.Text = table.Rows[0][0].ToString();
            
            //load info be so 2
            DataTable table2 = new DataTable();
            table2.Columns.Add("Tên", typeof(string));
            table2.Columns.Add("Lần 1", typeof(int));
            table2.Columns.Add("Lần 2", typeof(int));
            table2.Columns.Add("Lần 3", typeof(int));
            table2.Columns.Add("Tổng", typeof(string));
            table2.Rows.Add("Nguyễn Văn A", null, null, null, null);
            table2.Rows.Add("Nguyễn Văn b", null, null, null, null);
            table2.Rows.Add("Nguyễn Văn c", null, null, null, null);
            _dtgScore2.DataSource = table2;
            _dtgScore2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _lblName2.Text = table.Rows[0][0].ToString();

            //load info be so 3
            DataTable table3 = new DataTable();
            table3.Columns.Add("Tên", typeof(string));
            table3.Columns.Add("Lần 1", typeof(int));
            table3.Columns.Add("Lần 2", typeof(int));
            table3.Columns.Add("Lần 3", typeof(int));
            table3.Columns.Add("Tổng", typeof(string));
            table3.Rows.Add("Nguyễn Văn A", null, null, null, null);
            table3.Rows.Add("Nguyễn Văn b", null, null, null, null);
            table3.Rows.Add("Nguyễn Văn c", null, null, null, null);
            _dtgScore3.DataSource = table3;
            _dtgScore3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            _lblName3.Text = table.Rows[0][0].ToString();
        }


        private void nhậpĐịaChỉCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigCamera frm = new frmConfigCamera();
            frm.ShowDialog();
            //urlCamera = LoadUrlCamera();
            LoadUrlCamera();
            LoadCamera();
        }

        private void đổiTênFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditBox frm = new frmEditBox("Đổi tên form");
            frm.ShowDialog();
            if (frmEditBox.content.Trim() != "")
            {
                this.Text = frmEditBox.content;
            }
        }

        private void biaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void biaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
