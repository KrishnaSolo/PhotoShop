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
                                    {-1,-1,-1},
                                    { -1,9,-1},
                                    { -1,-1,-1}
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
            double factor = 1.0/9.0;
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
                            red += (pixelColor.R) * (sharp[fx, fy]);
                            blue += (pixelColor.B) * (sharp[fx, fy]);
                            green += (pixelColor.G) * (sharp[fx, fy]);
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

        private void Button6_Click(object sender, EventArgs e)
        {
            int K;

            if(textBox1.TextLength == 0)
            {
                MessageBox.Show("Nothing has been entered");
                return;
            }
            else
            {
                try
                {
                    K = Int32.Parse(textBox1.Text);
                }
                catch (Exception E)
                {
                    MessageBox.Show("Not a valid number! Try again.");
                    return;
                }


                Bitmap img = new Bitmap(pic);
                Dictionary<Tuple<int, int>, Tuple<double, double, double>> imageData
                    = new Dictionary<Tuple<int, int>, Tuple<double, double, double>>();

                for(int i = 0; i < img.Width; i++)
                {
                    for(int j = 0; j < img.Height; j++)
                    {
                        Color pixelColor = img.GetPixel(i,j);
                        Tuple<int, int> pt = new Tuple<int,int>(i,j);
  
                        double red = (pixelColor.R) / Convert.ToDouble(255);
                        double blue = (pixelColor.B) / Convert.ToDouble(255);
                        double green = (pixelColor.G) / Convert.ToDouble(255);
                  
                        //Color normdata = Color.FromArgb(red,green,blue); use this at end!
                        //Console.WriteLine("{0}, {1}, {2}",pt.Item2,j/img.Height,img.Height); sanity check 
                        imageData.Add(pt, new Tuple<double,double,double>(red,blue,green));
                    }
                }

                SortedSet<Tuple<double, double, double>> clustersCenters = new SortedSet<Tuple<double, double, double>>();
                List<List<Tuple<double, double, double>>> clusters = new List<List<Tuple<double, double, double>>>();
                Random gen = new Random();

                for (int i = 0; i < K; i++)
                {
                    Tuple<int, int> center;
                    Tuple<double, double, double> colCenter;
                    clusters.Add(new List<Tuple<double, double, double>>());
                    do
                    {
                        center = new Tuple<int, int>(gen.Next(0, img.Width), gen.Next(0, img.Height));

                        colCenter = imageData[center];
                  
                    } while (!clustersCenters.Add(colCenter));
                }

                //actual Kmeans - using a loop to reduce time to reach convergence 
                for (int epoch = 0; epoch < 150; epoch++)
                {
                    //Now to assign pixels to each cluster center
                    foreach (var pt in imageData)
                    {
                        double minDist = 1000000;
                        int min = -1;
                        Tuple<double, double, double> minMu = pt.Value;
                        int index = 0;
                        foreach (var mu in clustersCenters)
                        {
                            double rDist = Math.Pow(Math.Abs(mu.Item1 - pt.Value.Item1), 2);
                            double bDist = Math.Pow(Math.Abs(mu.Item2 - pt.Value.Item2), 2);
                            double gDist = Math.Pow(Math.Abs(mu.Item3 - pt.Value.Item3), 2);

                            double MSE = Math.Sqrt(rDist + bDist + gDist);

                            if (MSE <= minDist)
                            {
                                min = index;
                                minDist = MSE;
                                minMu = mu;
                            }

                            index++;
                        }

                        clusters[min].Add(minMu);
                    }

                    //assign a new cluster for the cluster groups
                    int cnt = 0;
                    SortedSet<Tuple<double, double, double>> tempCenters = new SortedSet<Tuple<double, double, double>>();

                    foreach (var cluster in clusters)
                    {
                        double r = 0, g = 0, b = 0;
                        foreach (var pt in clusters[cnt])
                        {
                            r += pt.Item1;
                            b += pt.Item2;
                            g += pt.Item3;
                        }
                        double size = Convert.ToDouble(clusters[cnt].Count);
                        cnt++;

                        double rAvg = r / size;
                        double bAvg = b / size;
                        double gAvg = g / size;

                        tempCenters.Add(new Tuple<double, double, double>(rAvg, bAvg, gAvg));
                    }

                    int chk = 0;

                    for (int x = 0; x < tempCenters.Count; x++)
                    {
                        double rDiff = Math.Abs(tempCenters.ElementAt(x).Item1 - clustersCenters.ElementAt(x).Item1);
                        double bDiff = Math.Abs(tempCenters.ElementAt(x).Item2 - clustersCenters.ElementAt(x).Item2);
                        double gDiff = Math.Abs(tempCenters.ElementAt(x).Item3 - clustersCenters.ElementAt(x).Item3);

                        if ((rDiff < 0.0000000000001) && (bDiff < 0.0000000000001) && (gDiff < 0.0000000000001))
                        {
                            chk++;
                        }
                    }

                    if (chk == tempCenters.Count)
                    {
                        Console.WriteLine("done");
                        break;
                    }
                    else
                    {
                        clustersCenters = tempCenters;
                    }
                }

                //ColorDialog dlg = new ColorDialog();
                Color[] arr = new Color[K];
                int inc = 0;

                foreach (var col in clustersCenters)
                {

                    int rFinal = Convert.ToInt32(col.Item1 * 255);
                    int bFinal = Convert.ToInt32(col.Item2 * 255);
                    int gFinal = Convert.ToInt32(col.Item3 * 255);

                    arr[inc] = Color.FromArgb(rFinal, gFinal, bFinal);

                    Console.WriteLine("Center:{0} - R={1} B={2} G={3} ole:{4}", inc, rFinal, bFinal, gFinal, arr[inc]);
                    inc++;
                }
                //dlg.Container.Remove(Component)
                //dlg.CustomColors = arr;
                //dlg.ShowDialog();
                Form2 palgen = new Form2(arr);
                palgen.ShowDialog();
            }
        }
    }
}
