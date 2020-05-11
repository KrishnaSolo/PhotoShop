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
    public partial class Form2 : Form
    {
        public SolidBrush[] brush;
        public Form2(Color[] arr)
        {
            InitializeComponent();
            int size = arr.Length;

            brush = new SolidBrush[18];

            for(int i = 0; i < 18; i++)
            {
                if (i < size)
                {
                    brush[i] = new SolidBrush(arr[i]);
                }
                else
                {
                    brush[i] = new SolidBrush(Color.Black);
                }
            }

            Panel[] panel = new Panel[]
            {
                panel1,
                panel2,
                panel3,
                panel4,
                panel5,
                panel6,
                panel7,
                panel8,
                panel9,
                panel10,
                panel11,panel12,panel13,panel14,panel15,panel16,panel17,panel18
            };

            Graphics[] g = new Graphics[18];

            for(int x = 0; x < 18; x++)
            {
                panel[x].Paint += new PaintEventHandler(panel1_Paint);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            int num = Convert.ToInt32(Convert.ToString(p.Name).Remove(0,5))-1;

            Point[] points = new Point[4];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, p.Height);
            points[2] = new Point(p.Width, p.Height);
            points[3] = new Point(p.Width, 0);

            g.FillPolygon(brush[num], points);
        }

        private void Panel1_MouseHover(object sender, EventArgs e)
        {
            var pan = sender as Panel;
            int id = Convert.ToInt32(Convert.ToString(pan.Name).Remove(0, 5)) - 1;
            ToolTip code = new ToolTip();
            string info = "Hex: " + ColorTranslator.ToHtml(brush[id].Color) + "\nRGB: " + brush[id].Color.ToString();
            code.Show(info, pan);
        }
    }
}
