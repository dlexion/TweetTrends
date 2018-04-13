using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapping
{
    public partial class Form1 : Form
    {
        List<State> states;
        public Form1()
        {
            InitializeComponent();
            states = StatesReader.Read(@"D:\PS3_TweetTrens\trends\data\states1.json");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var state in states)
            {
                foreach (var points in state.Polygons)
                {
                    g.DrawPolygon(new Pen(Color.Black, 2), points.ToArray());
                    g.FillPolygon(Brushes.Blue, points.ToArray());

                }
            }

            g.Dispose();
            Console.WriteLine(states.Count);

            Bitmap bitmap = new Bitmap(Convert.ToInt32(1180), Convert.ToInt32(640), PixelFormat.Format32bppArgb);
            Graphics gr = Graphics.FromImage(bitmap);
            gr.Clear(Color.White);
            foreach (var state in states)
            {
                foreach (var points in state.Polygons)
                {
                    gr.DrawPolygon(new Pen(Color.Black, 2), points.ToArray());
                    gr.FillPolygon(Brushes.Red, points.ToArray());
                }
            }
            bitmap.Save(@"pic.bmp", ImageFormat.Bmp);
        }
    }
}
