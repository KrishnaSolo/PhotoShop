using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoShop
{   
    public partial class Form1 : Form
    {
        public int fw = 3;
        public int fh = 3;
        public string pic = null;


        int[,] edge = new int[3, 3] {
                                    {-1,-1,-1},
                                    { -1,8,-1},
                                    { -1,-1,-1}
                                    };
        int[,] blur = new int[3, 3] {
                                    {1,2,1},
                                    { 2,4,2},
                                    { 1,2,1}
                                    };
        int[,] sharp = new int[3, 3] {
                                    {0,-1,0},
                                    { -1,5,-1},
                                    { 0,-1,0}
                                    };

        public Form1()
        {
            InitializeComponent();
           // BG();
        }
        
        public void BG()
        {
            string img1 = pic;// @"C:\Users\ksolo\Documents\photos\pics\photo3.png";
            Bitmap img = new Bitmap(img1);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            //MessageBox.Show(img.Palette.Entries.Length.ToString());
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string img1 = pic;// @"C:\Users\ksolo\Documents\photos\pics\photo3.png";
            Bitmap img = new Bitmap(img1);
            for (int x = 0; x<img.Width; x++)
            {
                for(int y = 0; y<img.Height; y++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    Color newColor = Color.FromArgb(Math.Abs(pixelColor.R-10), Math.Abs(pixelColor.B - 21), Math.Abs(pixelColor.G - 91));
                    img.SetPixel(x, y, newColor);
                }
            }
        
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string img1 = pic;//@"C:\Users\ksolo\Documents\photos\pics\photo3.png";
            Bitmap img = new Bitmap(img1);
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            double bias = 0.0;
            double factor = 1.0;
            string img1 = pic;// @"C:\Users\ksolo\Documents\photos\pics\photo3.png";
            Bitmap img = new Bitmap(img1);
            int w = img.Width;
            int h = img.Height;
           // MessageBox.Show("start");
            for (int x = 0; x<w; x++)
            {
                for(int y = 0; y<h; y++)
                {
                    int red = 0; int blue = 0; int green = 0;
                    for(int fy = 0; fy<fh; fy++)
                    {
                        for(int fx = 0; fx<fw; fx++)
                        {
                            int imgx = (x - fw / 2 + fx + w) % w;
                            int imgy = (y - fh / 2 + fy + h) % h;
                            Color pixelColor = img.GetPixel(imgx,imgy);
                            red += (pixelColor.R) * (sharp[fy, fx]);
                            blue += (pixelColor.B) * (sharp[fy, fx]);
                            green += (pixelColor.G) * (sharp[fy, fx]);
                        }
                    }
                    red = Math.Min(Math.Max(Convert.ToInt32(factor * red), 0),255);
                    blue = Math.Min(Math.Max(Convert.ToInt32(factor * blue), 0), 255);
                    green = Math.Min(Math.Max(Convert.ToInt32(factor * green), 0), 255);
                   // Console.WriteLine("R: " + red + " B: " + blue + " G: " + green);
                    Color newColor = Color.FromArgb(red, green, blue);
                    img.SetPixel(x, y, newColor);

                }
            }
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //MessageBox.Show("done");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double bias = 0.0;
            double factor = 1.0 / 16.0;
            string img1 = pic;// @"C:\Users\ksolo\Documents\photos\pics\photo3.png";
            Bitmap img = new Bitmap(img1);
            int w = img.Width;
            int h = img.Height;
            // MessageBox.Show("start");
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    int red = 0; int blue = 0; int green = 0;
                    for (int fy = 0; fy < fh; fy++)
                    {
                        for (int fx = 0; fx < fw; fx++)
                        {
                            int imgx = (x - fw / 2 + fx + w) % w;
                            int imgy = (y - fh / 2 + fy + h) % h;
                            Color pixelColor = img.GetPixel(imgx, imgy);
                            red += (pixelColor.R) * (blur[fy, fx]);
                            blue += (pixelColor.B) * (blur[fy, fx]);
                            green += (pixelColor.G) * (blur[fy, fx]);
                        }
                    }
                    red = Math.Min(Math.Max(Convert.ToInt32(factor * red), 0), 255);
                    blue = Math.Min(Math.Max(Convert.ToInt32(factor * blue), 0), 255);
                    green = Math.Min(Math.Max(Convert.ToInt32(factor * green), 0), 255);
                    // Console.WriteLine("R: " + red + " B: " + blue + " G: " + green);
                    Color newColor = Color.FromArgb(red, green, blue);
                    img.SetPixel(x, y, newColor);

                }
            }
            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pic = openFileDialog1.FileName;
            BG();
        }
    }
}
