using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraApp.Business
{
    class ProcessImage
    {

        public int[,] data; // mang du lieu pixel image
        int _width; // chieu rong
        int _height; // chieu dai

        int[] _histogram; // mang histogram
        int _minHist; // phan tu nho nhat trong histogram
        int _maxHist; // phan tu lon nhat trong histogram
        int _thresh; // nguong cua histogram

        public ProcessImage(Bitmap bm)
        {
            this._height = bm.Height;
            this._width = bm.Width;
            this.data = new int[_width, _height];

            // convert image to graycales image for process
            Convert2GrayScale(bm);

            // lay gia tri min cua histogram
            _histogram = GetHistogram();
            // tim nguong cua histogram
            _thresh = FindThresh(_histogram);
            //tim min histogram
            _minHist = FindMinHistogram(_histogram, _thresh);
            //tim max histogram
            _maxHist = FindMaxHistogram(_histogram, _thresh);
        }

        public void Process()
        {
            AutoContrast();
            Binary();
        }
        #region process
        /* resize inmage*/
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //chuyen doi anh xam, bat buoc, de xu ly nhanh hon
        private void Convert2GrayScale(Bitmap bm)
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Color c = bm.GetPixel(i, j);
                    data[i, j] = Convert.ToInt32(.299 * c.R + .587 * c.G + .114 * c.B);
                }
            }
        }

        private void AutoContrast()
        {
            //Cai dat gia tri cho mang (o day la gia tri cua mang tru cho min cua histogram)
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (data[i, j] - _minHist < 0)
                        data[i, j] = 0;
                    else
                        data[i, j] -= _minHist;
                }
            }

            //lay gia tri min cua histogram
            //_histogram = getHistogram();

            _maxHist -= _minHist;
            double heSo = 255.0 / _maxHist;

            //Cai dat gia tri cho mang (o day la gia tri cua mang tru cho min cua histogram)
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if ((int)Math.Round(data[i, j] * heSo) > 255)
                        data[i, j] = 255;
                    else
                        data[i, j] = (int)Math.Round(data[i, j] * heSo);
                }
            }


        }

        //lay histogram
        private int[] GetHistogram()
        {
            int[] hist = new int[256];
            for (int i = 0; i < hist.Length; i++)
            {
                hist[i] = 0;
            }

            for (int i = 0; i < this._width; i++)
            {
                for (int j = 0; j < this._height; j++)
                {
                    hist[data[i, j]]++;
                }
            }

            return hist;
        }

        //tim nguong cho nhi phan
        private int FindThresh(int[] hist)
        {
            int max = FindMaxHistogram(hist, 0) + 1;
            int min = FindMinHistogram(hist, 0) - 1;
            int t1 = 0;
            int t2 = 0;
            int nguong = (max + min) / 2;
            int tempA = 0;
            int tempB = 0;
            int delta = 1000;
            while (delta > 1)
            {
                for (int i = 0; i < nguong; i++)
                {
                    tempA += i * hist[i];
                    tempB += hist[i];
                }
                if (tempB == 0)
                {
                    tempB = 1;
                }

                t1 = tempA / tempB;
                tempA = 0;
                tempB = 0;
                for (int i = nguong; i < hist.Length; i++)
                {
                    tempA += i * hist[i];
                    tempB += hist[i];
                }
                if (tempB == 0)
                {
                    tempB = 1;
                }
                t2 = tempA / tempB;
                tempA = 0;
                tempB = 0;
                delta = Math.Abs((t2 + t1) / 2 - nguong);
                nguong = (t2 + t1) / 2;
            }
            return nguong;
        }

        //tim diem min cua historgram
        private int FindMinHistogram(int[] histogram, int nguong)
        {
            int min = 0;
            for (int i = 0; i < histogram.Length; i++)
            {
                if (histogram[i] > nguong)
                {
                    return i;
                }
            }
            return min;
        }

        //tim diem max cua historgram
        private int FindMaxHistogram(int[] histogram, int nguong)
        {
            int max = histogram.Length - 1;
            for (int i = histogram.Length - 1; i >= 0; i--)
            {
                if (histogram[i] > nguong)
                {
                    return i;
                }
            }
            return max;
        }

        //nhi phan
        private void Binary()
        {
            for (int i = 0; i < this._width; i++)
            {
                for (int j = 0; j < this._height; j++)
                {
                    data[i, j] = (data[i, j] >= _thresh) ? 255 : 0;
                }
            }
        }
        
        //tra ve anh bitmap
        public Bitmap Result()
        {
            Bitmap bm = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Color c = Color.FromArgb(data[i, j], data[i, j], data[i, j]);
                    bm.SetPixel(i, j, c);
                }
            }

            return bm;
        }

        //compare point difference
        public static Bitmap Compare(Bitmap bm1, Bitmap bm2)
        {
            int w = Math.Min(bm1.Width, bm2.Width);
            int h = Math.Min(bm1.Height, bm2.Height);

            Bitmap bm3 = new Bitmap(w, h);

            // Create the difference image.
            Color eq_color = Color.White;
            Color ne_color = Color.Red;
            int X = 0, Y = 0;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    if (bm1.GetPixel(x, y).Equals(bm2.GetPixel(x, y)))
                    {
                        //bm3.SetPixel(x, y, eq_color);
                        bm3.SetPixel(x, y, bm1.GetPixel(x, y));
                        X = x;
                        Y = y;
                        ProcessImage.X = x;
                        ProcessImage.Y = y;
                    }
                    else
                    {
                        bm3.SetPixel(x, y, ne_color);
                    }
                    /*
                    if (x == w / 2 && y == h / 2)
                    {
                        bm3.SetPixel(x, y, ne_color);
                    }
                    if (x == w / 2 - 48 && y == h / 2)
                    {
                        bm3.SetPixel(x, y, ne_color);
                    }
                    if (x == w / 2 - 95 && y == h / 2)
                    {
                        bm3.SetPixel(x, y, ne_color);
                    }
                    if (x == w / 2 - 142 && y == h / 2)
                    {
                        bm3.SetPixel(x, y, ne_color);
                    }
                    */
                    if (Math.Sqrt(Math.Pow((X - 200), 2) + Math.Pow((Y - 200), 2)) <= 48)
                    {
                        diem = 10;
                    }
                    else if (Math.Sqrt(Math.Pow((X - 200), 2) + Math.Pow((Y - 200), 2)) <= 95)
                    {
                        diem = 9;
                    }
                    else if (Math.Sqrt(Math.Pow((X - 200), 2) + Math.Pow((Y - 200), 2)) <= 142)
                    {
                        diem = 8;
                    }
                    else
                    {
                        diem = 0;
                    }
                }
            }

            return bm3;
        }
        public static int diem = 0;
        public static int X = 0, Y = 0;


        public static int[,] ConvertBitmapToArray(Bitmap bm)
        {
            int[,] data = new int[bm.Width, bm.Height];            
            BitmapData bmData = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //lay dia chi cua dong dau
            IntPtr ptr = bmData.Scan0;

            //khai bao 1 mang de chua byte cua bitmap
            int bytes = Math.Abs(bmData.Stride) * bmData.Height;
            byte[] rgbValues = new byte[bytes];

            //copy gia tri rgb vao mang
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);


            for (int i = 0; i < bm.Height; i++)
            {
                int t = 0;
                for (int j = 0; j < bm.Width * 3; j += 3)
                {
                    int index = i * bmData.Stride + j;
                    data[t, i] = rgbValues[index];
                    /*
                    if (rgbValues[index] == 255)
                    {
                        data[t, i] = 255;
                    }
                    else
                    {
                        data[t, i] = 0;
                    }
                    */
                    t++;
                }
            }
            return data;
        }

        public static Bitmap ConvertArrayToBitmap(int[,] data)
        {
            Bitmap bmp = new Bitmap(data.GetLength(0), data.GetLength(1));
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //lay dia chi cua dong dau
            IntPtr ptr = bmData.Scan0;

            //khai bao 1 mang de chua int cua bitmap
            int bytes = Math.Abs(bmData.Stride) * bmData.Height;
            Byte[] rgbValues = new Byte[bytes];

            //copy gia tri rgb vao mang
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < data.GetLength(1); i++)
            {
                int t = 0;
                for (int j = 0; j < data.GetLength(0) * 3; j += 3)
                {
                    int index = i * bmData.Stride + j;
                    rgbValues[index] = (byte)data[t, i];
                    rgbValues[index + 1] = rgbValues[index];
                    rgbValues[index + 2] = rgbValues[index];
                    t++;
                }
            }

            //copy gia tri rgb tro ve lai bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            //unlock the bits
            bmp.UnlockBits(bmData);

            return bmp;
        }


        #endregion

        #region
        /*
        //chuyen doi anh xam
        public static Bitmap Convert2GrayScale(Bitmap bmp)
        {
            BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //khai bao 1 mang de chua int cua bitmap
            int ints = Math.Abs(bmData.Stride) * bmData.Height;
            Byte[] rgbValues = new Byte[ints];

            IntPtr ptr = bmData.Scan0;

            //copy gia tri rgb vao mang
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, ints);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                //cong thuc chuyen doi anh xam
                rgbValues[0] = (byte)(.299 * rgbValues[2] + .587 * rgbValues[1] + .114 * rgbValues[0]);
                rgbValues[1] = rgbValues[0];
                rgbValues[2] = rgbValues[0];
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, ints);
            bmp.UnlockBits(bmData);
            return bmp;
        } 
        
        //Chuyen doi ve anh trang den
        public static Bitmap ConvertToBinaryImage(Bitmap bm, int Target)
        { //-- Target là ngưỡng xám
            Bitmap org = new Bitmap(bm, bm.Width, bm.Height);
            Bitmap result = new Bitmap(org.Width, org.Height);
            for (int i = 0; i < org.Width; i++)
            {
                for (int j = 0; j < org.Height; j++)
                {
                    Color curColor = org.GetPixel(i, j);

                    //-- Lấy giá trị mức xám
                    int desColor = Convert.ToInt32((curColor.R * 0.2989) + (curColor.G * 0.5870) + (curColor.B * 0.1140));

                    //-- Kiểm tra giá trị màu với ngưỡng xám
                    if (desColor < Target)
                    { 
                        desColor = 0;
                    }
                    else
                    { 
                        desColor = 255;
                    }

                    result.SetPixel(i, j, Color.FromArgb(255, desColor, desColor, desColor));
                }
            }
            return result;
        }
        */
        #endregion

    }
}
