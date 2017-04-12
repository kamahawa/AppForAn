using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using CameraApp.Help;
using System.IO;
//using ImageMagick;
using AxAXVLC;
using System.Media;
using System.Threading;
using CameraApp.Business;
using System.Drawing.Imaging;
using FoxLearn.License;
using WebEye;

namespace CameraApp
{
    public partial class frmMain : Form
    {
        //ECJ72-E7F17-J57G9-G5PPD-BEPG0-43ZTF
        //B62RB-HVZRB-TH3G9-091K1-5N8N5-05373 1 days
        //BP8R4-65Z6B-28PG9-X0JY2-84CF7-E09G6 1 days
        //AFLY0-PJB03-WY909-5H0SC-SCHDC-N4P7B 30days
        //"http://68.114.48.220:80/videostream.cgi?user=admin&pwd=";
        //"rtsp://192.168.1.12:533/user=admin&password=&channel=1&stream=0.sdp?real_stream--rtp-caching=100";
        //"rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100";
        //rtsp://mpv.cdn3.bigCDN.com:554/bigCDN/definst/mp4:bigbuckbunnyiphone_400.mp4
        public static string[] urlCamera = new string[3];
        
        //luot ban
        private int luotBia1 = 1, luotBia2 = 1, luotBia3 = 1;
        //nguoi ban hien tai o cac bia
        private int currentMemberBia1 = 0, currentMemberBia2 = 0, currentMemberBia3 = 0;
        private int[] tong3Bia;
                
        public frmMain()
        {
            InitializeComponent();
            
            //kiem tra license
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
                        if((kv.Expiration - DateTime.Now.Date).Days > 0)
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

            if(isActive)
            {
                //da kich hoat thi load url camera
                LoadUrlCamera();
            }
            else
            {
                using (frmRegistration frm = new frmRegistration())
                {
                    frm.ShowDialog();
                }
            }
        }

        private void frmRTSP_Load(object sender, EventArgs e)
        {
            LoadCamera();
        }

        #region be so 1        
        private void _btnScore_Click(object sender, EventArgs e)
        {
            //ShowScore(ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, 1);
            //_panCam.Controls.Clear();
            for (int i = _panCam.Controls.Count - 1; i >= 0; i--)
            {
                PictureBox control = _panCam.Controls[i] as PictureBox;
                if (control == null)
                    continue;
                control.Dispose();
            }
        }

        private void _transpCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            //neu chua co danh sach thi khong cho click
            if(_dtgScore.DataSource == null)
            {
                return;
            }
            addShotIcon(e.X, e.Y, _panCam);
            XuLyBe1(e.X, e.Y);
        }

        
        private void XuLyBe1(int x, int y)
        {
            Bitmap bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_8, _ptbCamera.Width, _ptbCamera.Height);
            Bitmap bitmap = bmResize;// Properties.Resources.bia4_8;
            int be = 1;// ban o be so 1
            Color c = bitmap.GetPixel(x, y);
            //dung thuat toan quicksort
            if (c.ToArgb().Equals(Color.Red.ToArgb()))
            {
                bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_9, _ptbCamera.Width, _ptbCamera.Height);
                bitmap = bmResize;//Properties.Resources.bia4_9;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_10, _ptbCamera.Width, _ptbCamera.Height);
                    bitmap = bmResize;//Properties.Resources.bia4_10;
                    c = bitmap.GetPixel(x, y);
                    // neu nam o tam 10 thi la 10, khong la 9
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        //10 diem
                        _lblScore.Text = "10";
                        ChamDiem(10, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                    else
                    {
                        //9 diem
                        _lblScore.Text = "9";
                        ChamDiem(9, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                }
                else
                {
                    // neu khong nam trong 9 thi la 8 diem
                    //8 diem
                    _lblScore.Text = "8";
                    ChamDiem(8, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                }
            }
            else
            {
                bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_6, _ptbCamera.Width, _ptbCamera.Height);
                bitmap = bmResize;//Properties.Resources.bia4_6;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_7, _ptbCamera.Width, _ptbCamera.Height);
                    bitmap = bmResize;//Properties.Resources.bia4_7;
                    c = bitmap.GetPixel(x, y);
                    // neu nam o tam 7 thi la 7, khong la 6
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        //7 diem
                        _lblScore.Text = "7";
                        ChamDiem(7, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                    else
                    {
                        //6 diem
                        _lblScore.Text = "6";
                        ChamDiem(6, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                }
                else
                {
                    bmResize = ProcessImage.ResizeImage(Properties.Resources.bia4_5, _ptbCamera.Width, _ptbCamera.Height);
                    bitmap = bmResize;//Properties.Resources.bia4_5;
                    c = bitmap.GetPixel(x, y);
                    //neu nam o trong 5 thi la 5, con o ngoai la truot
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        //5 diem
                        _lblScore.Text = "5";
                        ChamDiem(5, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                    else
                    {
                        //0 diem
                        _lblScore.Text = "0";
                        ChamDiem(0, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, be);
                    }
                }
            }
        }

        private void _btnMiss_Click(object sender, EventArgs e)
        {
            _lblScore.Text = "0";
            ChamDiem(0, ref luotBia1, ref currentMemberBia1, _dtgScore, _lblName, _lblScore, 1);
        }
        #endregion

        #region be so 2
        private void _btnScore2_Click(object sender, EventArgs e)
        {
            //ShowScore(ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, 2);
            //_panCam2.Controls.Clear();
            for (int i = _panCam2.Controls.Count - 1; i >= 0; i--)
            {
                PictureBox control = _panCam2.Controls[i] as PictureBox;
                if (control == null)
                    continue;

                control.Dispose();
            }
        }

        private void _btnMiss2_Click(object sender, EventArgs e)
        {
            _lblScore2.Text = "0";
            ChamDiem(0, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, 2);
        }

        private void _transpCtrl2_MouseDown(object sender, MouseEventArgs e)
        {
            //neu chua co danh sach thi khong cho click
            if (_dtgScore2.DataSource == null)
            {
                return;
            }
            addShotIcon(e.X, e.Y, _panCam2);
            XuLyBe2(e.X, e.Y);
        }

        private void XuLyBe2(int x, int y)
        {
            Bitmap bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_5, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_5;
            int be = 2;// ban o be so 2
            Color c = bitmap.GetPixel(x, y);
            //dung thuat toan quicksort
            if (c.ToArgb().Equals(Color.Red.ToArgb()))
            {
                bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_8, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_8;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_9, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_9;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_10, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_10;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //10 diem
                            _lblScore2.Text = "10";
                            ChamDiem(10, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                        else
                        {
                            //9 diem
                            _lblScore2.Text = "9";
                            ChamDiem(9, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                    }
                    else
                    {
                        _lblScore2.Text = "8";
                        ChamDiem(8, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                    }
                }
                else
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_6, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_6;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_7, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_7;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //7 diem
                            _lblScore2.Text = "7";
                            ChamDiem(7, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                        else
                        {
                            //6 diem
                            _lblScore2.Text = "6";
                            ChamDiem(6, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                    }
                    else
                    {
                        //5 diem
                        _lblScore2.Text = "5";
                        ChamDiem(5, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                    }
                }
            }
            else
            {
                bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_3, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_3;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_4, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_4;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        //4 diem
                        _lblScore2.Text = "4";
                        ChamDiem(4, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                    }
                    else
                    {
                        //3 diem
                        _lblScore2.Text = "3";
                        ChamDiem(3, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                    }
                }
                else
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_1, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_1;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia7_2, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia7_2;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //2 diem
                            _lblScore2.Text = "2";
                            ChamDiem(2, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                        else
                        {
                            //1 diem
                            _lblScore2.Text = "1";
                            ChamDiem(1, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                        }
                    }
                    else
                    {
                        //0 diem
                        _lblScore2.Text = "0";
                        ChamDiem(0, ref luotBia2, ref currentMemberBia2, _dtgScore2, _lblName2, _lblScore2, be);
                    }
                }
            }
        }
        #endregion

        #region be so 3
        private void _btnScore3_Click(object sender, EventArgs e)
        {
            //ShowScore(ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, 3);
            //_panCam3.Controls.Clear();
            for (int i = _panCam3.Controls.Count - 1; i >= 0; i--)
            {
                PictureBox control = _panCam3.Controls[i] as PictureBox;
                if (control == null)
                    continue;

                control.Dispose();
            }
        }

        private void _btnMiss3_Click(object sender, EventArgs e)
        {
            _lblScore3.Text = "0";
            ChamDiem(0, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, 3);
        }

        private void _transpCtrl3_MouseDown(object sender, MouseEventArgs e)
        {
            //neu chua co danh sach thi khong cho click
            if (_dtgScore3.DataSource == null)
            {
                return;
            }
            addShotIcon(e.X, e.Y, _panCam3);
            XuLyBe3(e.X, e.Y);
        }

        private void XuLyBe3(int x, int y)
        {
            Bitmap bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_5, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_5;
            int be = 3;// ban o be so 3
            Color c = bitmap.GetPixel(x, y);
            //dung thuat toan quicksort
            if (c.ToArgb().Equals(Color.Red.ToArgb()))
            {
                bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_8, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_8;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_9, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_9;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_10, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_10;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //10 diem
                            _lblScore3.Text = "10";
                            ChamDiem(10, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                        else
                        {
                            //9 diem
                            _lblScore3.Text = "9";
                            ChamDiem(9, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                    }
                    else
                    {
                        _lblScore3.Text = "8";
                        ChamDiem(8, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                    }
                }
                else
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_6, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_6;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_7, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_7;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //7 diem
                            _lblScore3.Text = "7";
                            ChamDiem(7, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                        else
                        {
                            //6 diem
                            _lblScore3.Text = "6";
                            ChamDiem(6, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                    }
                    else
                    {
                        //5 diem
                        _lblScore3.Text = "5";
                        ChamDiem(5, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                    }
                }
            }
            else
            {
                bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_3, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_3;
                c = bitmap.GetPixel(x, y);
                if (c.ToArgb().Equals(Color.Red.ToArgb()))
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_4, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_4;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        //4 diem
                        _lblScore3.Text = "4";
                        ChamDiem(4, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                    }
                    else
                    {
                        //3 diem
                        _lblScore3.Text = "3";
                        ChamDiem(3, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                    }
                }
                else
                {
                    bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_1, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_1;
                    c = bitmap.GetPixel(x, y);
                    if (c.ToArgb().Equals(Color.Red.ToArgb()))
                    {
                        bitmap = ProcessImage.ResizeImage(Properties.Resources.bia8_2, _ptbCamera.Width, _ptbCamera.Height);//Properties.Resources.bia8_2;
                        c = bitmap.GetPixel(x, y);
                        if (c.ToArgb().Equals(Color.Red.ToArgb()))
                        {
                            //2 diem
                            _lblScore3.Text = "2";
                            ChamDiem(2, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                        else
                        {
                            //1 diem
                            _lblScore3.Text = "1";
                            ChamDiem(1, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                        }
                    }
                    else
                    {
                        //0 diem
                        _lblScore3.Text = "0";
                        ChamDiem(0, ref luotBia3, ref currentMemberBia3, _dtgScore3, _lblName3, _lblScore3, be);
                    }
                }
            }
        }
        #endregion

        #region xu ly cham diem
        
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

        private void ChamDiem(int diem, ref int luot, ref int currentMember, DataGridView dtgScore, Label lblName, Label lblScore, int be)
        {
            try
            {
                //DataTable dt = (DataTable)_dtgScore.DataSource;
                DataTable dt = (DataTable)dtgScore.DataSource;
                dt.Rows[currentMember][luot] = diem;

                //set tong diem
                tong3Bia[currentMember] += diem;
                //dt.Rows[currentMember][5] = tong3Bia[currentMember];
                //set tong diem
                setTongDiem3Bia(currentMember);

                docDiem(diem);

                if (luot == 3)
                {
                    //ban het luot thi tinh tong diem
                    int l1 = Int32.Parse(dt.Rows[currentMember][1].ToString());
                    int l2 = Int32.Parse(dt.Rows[currentMember][2].ToString());
                    int l3 = Int32.Parse(dt.Rows[currentMember][3].ToString());

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
                //playSound(@"ScoreSound\Tong_diem_be_so_1_la.wav");
                playSound(Properties.Resources.Tong_diem_be_so_1_la);
            }
            else if (be == 2)
            {
                //playSound(@"ScoreSound\Tong_diem_be_so_2_la.wav");
                playSound(Properties.Resources.Tong_diem_be_so_2_la);
            }
            else if (be == 3)
            {
                //playSound(@"ScoreSound\Tong_diem_be_so_3_la.wav");
                playSound(Properties.Resources.Tong_diem_be_so_3_la);
            }
            //nghi 2 giay de doc so diem o luot tong diem be
            Thread.Sleep(2000);
            docDiem(tong);            
        }

        private void playSound(string fileName)
        {
            SoundPlayer simpleSound = new SoundPlayer(fileName);
            simpleSound.Play();
        }

        private void playSound(Stream file)
        {
            SoundPlayer simpleSound = new SoundPlayer(file);
            simpleSound.Play();
        }

        private void docDiem(int diem)
        {
            switch (diem)
            {
                case 0:
                    playSound(Properties.Resources._0_diem);
                    break;
                case 1:
                    playSound(Properties.Resources._1_diem);
                    break;
                case 2:
                    playSound(Properties.Resources._2_diem);
                    break;
                case 3:
                    playSound(Properties.Resources._3_diem);
                    break;
                case 4:
                    playSound(Properties.Resources._4_diem);
                    break;
                case 5:
                    playSound(Properties.Resources._5_diem);
                    break;
                case 6:
                    playSound(Properties.Resources._6_diem);
                    break;
                case 7:
                    playSound(Properties.Resources._7_diem);
                    break;
                case 8:
                    playSound(Properties.Resources._8_diem);
                    break;
                case 9:
                    playSound(Properties.Resources._9_diem);
                    break;
                case 10:
                    playSound(Properties.Resources._10_diem);
                    break;
                case 11:
                    playSound(Properties.Resources._11_diem);
                    break;
                case 12:
                    playSound(Properties.Resources._12_diem);
                    break;
                case 13:
                    playSound(Properties.Resources._13_diem);
                    break;
                case 14:
                    playSound(Properties.Resources._14_diem);
                    break;
                case 15:
                    playSound(Properties.Resources._15_diem);
                    break;
                case 16:
                    playSound(Properties.Resources._16_diem);
                    break;
                case 17:
                    playSound(Properties.Resources._17_diem);
                    break;
                case 18:
                    playSound(Properties.Resources._18_diem);
                    break;
                case 19:
                    playSound(Properties.Resources._19_diem);
                    break;
                case 20:
                    playSound(Properties.Resources._20_diem);
                    break;
                case 21:
                    playSound(Properties.Resources._21_diem);
                    break;
                case 22:
                    playSound(Properties.Resources._22_diem);
                    break;
                case 23:
                    playSound(Properties.Resources._23_diem);
                    break;
                case 24:
                    playSound(Properties.Resources._24_diem);
                    break;
                case 25:
                    playSound(Properties.Resources._25_diem);
                    break;
                case 26:
                    playSound(Properties.Resources._26_diem);
                    break;
                case 27:
                    playSound(Properties.Resources._27_diem);
                    break;
                case 28:
                    playSound(Properties.Resources._28_diem);
                    break;
                case 29:
                    playSound(Properties.Resources._29_diem);
                    break;
                case 30:
                    playSound(Properties.Resources._30_diem);
                    break;
                    /*
                    case 0:
                        playSound(@"ScoreSound\0_diem.wav");
                        break;
                    case 1:
                        playSound(@"ScoreSound\1_diem.wav");
                        break;
                    case 2:
                        playSound(@"ScoreSound\2_diem.wav");
                        break;
                    case 3:
                        playSound(@"ScoreSound\3_diem.wav");
                        break;
                    case 4:
                        playSound(@"ScoreSound\4_diem.wav");
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

                */
            }
        }

        private void setTongDiem3Bia(int currentMember)
        {
            string xeploai = "Không đạt";// ngoai dieu kien ben duoi la khong dat thanh tich
            if (tong3Bia[currentMember] >= 72)
            {
                xeploai = "Giỏi";
            }
            else if (tong3Bia[currentMember] >= 59 && tong3Bia[currentMember] <= 71)
            {
                xeploai = "Khá";
            }
            else if (tong3Bia[currentMember] >= 45 && tong3Bia[currentMember] <= 58)
            {
                xeploai = "Đạt";
            }
            DataTable dt = (DataTable)_dtgScore.DataSource;
            dt.Rows[currentMember][5] = tong3Bia[currentMember];
            dt.Rows[currentMember][6] = xeploai;

            DataTable dt2 = (DataTable)_dtgScore2.DataSource;
            dt2.Rows[currentMember][5] = tong3Bia[currentMember];
            dt2.Rows[currentMember][6] = xeploai;

            DataTable dt3 = (DataTable)_dtgScore3.DataSource;
            dt3.Rows[currentMember][5] = tong3Bia[currentMember];
            dt3.Rows[currentMember][6] = xeploai;
            
        }

        #endregion

        #region menu progress
        
        void LoadCamera()
        {
            /*
            _videoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                //rtsp://192.168.1.199:554/user=admin&password=&channel=3&stream=0.sdp?real_stream--rtp-caching=100
                // http://47.20.99.105:81/videostream.cgi?loginuse=admin&loginpas=
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
            try
            {
                /*
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
                */
                if (urlCamera[0] != "")
                {
                    var uri = new Uri(urlCamera[0]);
                    _spcCamera.StartPlay(uri, TimeSpan.FromSeconds(15.0));
                    _toolStripLabel.Text = "Camera đang kết nối...";
                }
                else
                {
                    _toolStripLabel.Text = "Vui lòng nhập đường dẫn cho camera số 1";
                }
                if (urlCamera[1] != "")
                {
                    var uri = new Uri(urlCamera[1]);
                    _spcCamera1.StartPlay(uri, TimeSpan.FromSeconds(15.0));
                    _toolStripLabel1.Text = "Camera đang kết nối...";
                }
                else
                {
                    _toolStripLabel1.Text = "Vui lòng nhập đường dẫn cho camera số 2";
                }
                if (urlCamera[2] != "")
                {
                    var uri = new Uri(urlCamera[2]);
                    _spcCamera2.StartPlay(uri, TimeSpan.FromSeconds(15.0));
                    _toolStripLabel2.Text = "Camera đang kết nối...";
                }
                else
                {
                    _toolStripLabel2.Text = "Vui lòng nhập đường dẫn cho camera số 3";
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
        
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void xuấtFileĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelHelp.ExportExcel((DataTable)_dtgScore.DataSource, (DataTable)_dtgScore2.DataSource, (DataTable)_dtgScore3.DataSource);
        }
        
        private void thêmDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "xls, xlsx|*.xls;*.xlsx";
            try
            {
                if(op.ShowDialog() == DialogResult.OK)
                { 
                    //load info be so 1
                    DataTable table = ExcelHelp.getDataTableExcel(op.FileName);//new DataTable();

                    //khoi tao tinh tong 3 bia
                    tong3Bia = new int[table.Rows.Count];

                    /*
                    table.Columns.Add("Tên", typeof(string));
                    table.Columns.Add("Lần 1", typeof(int));
                    table.Columns.Add("Lần 2", typeof(int));
                    table.Columns.Add("Lần 3", typeof(int));
                    table.Columns.Add("Tổng", typeof(string));            
                    table.Rows.Add("Nguyễn Văn A", null, null, null, null);
                    table.Rows.Add("Nguyễn Văn b", null, null, null, null);
                    table.Rows.Add("Nguyễn Văn c", null, null, null, null);
                    */
                    _dtgScore.DataSource = table;
                    //mo rong phan ten
                    _dtgScore.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    _lblName.Text = table.Rows[0][0].ToString();
            
                    //load info be so 2
                    DataTable table2 = ExcelHelp.getDataTableExcel(op.FileName);//new DataTable();
                    _dtgScore2.DataSource = table2;
                    _dtgScore2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    _lblName2.Text = table.Rows[0][0].ToString();

                    //load info be so 3
                    DataTable table3 = ExcelHelp.getDataTableExcel(op.FileName);//new DataTable();
                    _dtgScore3.DataSource = table3;
                    _dtgScore3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    _lblName3.Text = table.Rows[0][0].ToString();
                }
            }
            catch(Exception ex)
            { }
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

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            var uri = new Uri(urlCamera[0]);
            _spcCamera.StartPlay(uri, TimeSpan.FromSeconds(15.0));
            _toolStripLabel.Text = "Camera đang kết nối...";
        }

        private void _btnConnect1_Click(object sender, EventArgs e)
        {
            var uri = new Uri(urlCamera[1]);
            _spcCamera1.StartPlay(uri, TimeSpan.FromSeconds(15.0));
            _toolStripLabel1.Text = "Camera đang kết nối...";
        }

        private void _btnConnect2_Click(object sender, EventArgs e)
        {
            var uri = new Uri(urlCamera[2]);
            _spcCamera2.StartPlay(uri, TimeSpan.FromSeconds(15.0));
            _toolStripLabel2.Text = "Camera đang kết nối...";
        }

        private void HandleStreamStartedEvent(object sender, EventArgs e)
        {
            _toolStripLabel.Text = "Camera đang chạy";
            _btnConnect.Enabled = false;
        }

        private void HandleStreamFailedEvent(object sender, StreamFailedEventArgs e)
        {
            _toolStripLabel.Text = "Camera kết nối thất bại";
            //MessageBox.Show(e.Error, "Stream Player Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _btnConnect.Enabled = true;
        }

        private void HandleStreamStartedEvent1(object sender, EventArgs e)
        {
            _toolStripLabel1.Text = "Camera đang chạy";
            _btnConnect1.Enabled = false;
        }

        private void HandleStreamFailedEvent1(object sender, StreamFailedEventArgs e)
        {
            _toolStripLabel1.Text = "Camera kết nối thất bại";
            //MessageBox.Show(e.Error, "Stream Player Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _btnConnect1.Enabled = true;
        }

        private void HandleStreamStartedEvent2(object sender, EventArgs e)
        {
            _toolStripLabel2.Text = "Camera đang chạy";
            _btnConnect2.Enabled = false;
        }

        private void HandleStreamFailedEvent2(object sender, StreamFailedEventArgs e)
        {
            _toolStripLabel2.Text = "Camera kết nối thất bại";
            //MessageBox.Show(e.Error, "Stream Player Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _btnConnect2.Enabled = true;
        }

        private void bảnQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmAbout frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRegistration frm = new frmRegistration())
            {
                frm.ShowDialog();
            }
        }

        #endregion

    }
}
