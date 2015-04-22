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
using System.Windows;

namespace MandelbrotVisualizer
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        private Pen pero;
        public Bitmap bmp;
        public Bitmap old_bmp;
        public Brush stet;

        private Color barvaMnoziny = Color.Black;

        int whiteSpaceLeft = 0;//scale     
        int whiteSpaceTop = 0;

        private PointF relativePosition;
        private Boolean kliknutoR;

        complex max, min;
        complex new_max, new_min;
        int max_count = 500;

        float line_width = 1f; 

        public Form1()
        {
            InitializeComponent();

            max = new complex(2, 2);
            min = new complex(-2, -2);

            iteraci_box.Text = max_count.ToString();

            putBounds();

            osy.Checked = true;
            bmp = new Bitmap(panel1.Width, panel1.Height);
            graphics = Graphics.FromImage(bmp);
            pero = new Pen(Color.Green);
            stet = new SolidBrush(Color.Green);
            graphics.Clear(Color.White);
            drawMandel(this.bmp);
            drawAxes();
             
        }

        private void clearPanel()
        {
            graphics.Clear(Color.White);
        }

        private void paintIntoPanel()
        {
            panel1_Paint(this, null);            
        }

        private void ulozBmp()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Empty;
            sfd.Filter = "Portable graphics *.png|*.png|Windows Bitmap *.bmp|*.bmp|Jpeg *.jpg|*.jpg";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            try
            {
                bmp.Save(sfd.FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        //vykreslovani do panelu
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null) return;
            Graphics grp = panel1.CreateGraphics();
            
            double aspectRatioSrc = (double)bmp.Width / bmp.Height;
            double aspectRatioDst = (double)panel1.Width / panel1.Height;
            if (aspectRatioSrc > aspectRatioDst)
            {
                whiteSpaceTop = panel1.Height - (int)(panel1.Width / aspectRatioSrc);
                whiteSpaceTop >>= 1;
            }
            else
            {
                whiteSpaceLeft = panel1.Width - (int)(panel1.Height * aspectRatioSrc);
                whiteSpaceLeft >>= 1;
            }
            Rectangle rSource = new Rectangle(0, 0, bmp.Width, bmp.Height);
            Rectangle rDestination = new Rectangle(whiteSpaceLeft, whiteSpaceTop, panel1.Width - (whiteSpaceLeft << 1), panel1.Height - (whiteSpaceTop << 1));
            grp.DrawImage(bmp, rDestination, rSource, GraphicsUnit.Pixel);

            //grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //grp.DrawImage(bmp, 0, 0, panel1.Width, panel1.Height);
            grp.Dispose();

        }

        //uklid
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bmp.Dispose();
            graphics.Dispose();
        }

        private void nakresli_Click(object sender, EventArgs e)
        {
            int tmp_maxcount = max_count;
            try
            {
                max_count = Int32.Parse(iteraci_box.Text);

            }catch(Exception){
                return;
            }

            max = new_max;
            min = new_min;

            if (max.re <= min.re || max.im <= min.im || max_count <=0)
            {
                resetDraw();
            }

            drawMandel(this.bmp);
            if (osy.Checked)
            {
                drawAxes();
            }
            paintIntoPanel();
        }

        private complex pixToCom(int i, int j)
        {
            complex res = new complex();
            res.re = (double)i * Math.Abs(max.re - min.re) / bmp.Width + min.re;
            res.im = -(double)j * Math.Abs(max.im - min.im) / bmp.Height + max.im;
            return res;
        }

        private Point comToPix(complex z)
        {
            return comToPix(z.re, z.im);
        }
       
        private Point comToPix(double re, double im)
        {
            Point p = new Point();
            p.X = (int)Math.Round((re - min.re) / Math.Abs(max.re - min.re) * bmp.Width);
            p.Y = (int)Math.Round((-im + max.im) / Math.Abs(max.im - min.im) * bmp.Height);
            return p;
        }

        private void drawAxes()
        {
            graphics.DrawLine(pero, comToPix(-2, 0), comToPix(2, 0));
            graphics.DrawLine(pero, comToPix(0, 2), comToPix(0, -2));
            graphics.DrawEllipse(pero, new Rectangle(comToPix(-2,2).X, comToPix(-2,2).Y, -comToPix(-2,2).X+ comToPix(2,-2).X, -comToPix(-2,2).Y + comToPix(2,-2).Y));
            graphics.DrawString("-2", new Font(FontFamily.GenericSerif,10), stet, comToPix(-2, 0).X, comToPix(-2, 0).Y);
            graphics.DrawString("2", new Font(FontFamily.GenericSerif, 10), stet, comToPix(1.95, 0).X, comToPix(1.95, 0).Y);
            graphics.DrawString("-1", new Font(FontFamily.GenericSerif, 10), stet, comToPix(-1, 0).X, comToPix(-1, 0).Y);
            graphics.DrawString("1", new Font(FontFamily.GenericSerif, 10), stet, comToPix(1, 0).X, comToPix(1, 0).Y);
            graphics.DrawString("-1i", new Font(FontFamily.GenericSerif, 10), stet, comToPix(0, -1).X, comToPix(0, -1).Y);
            graphics.DrawString("1i", new Font(FontFamily.GenericSerif, 10), stet, comToPix(0, 1).X, comToPix(0, 1).Y);
            graphics.DrawString("0", new Font(FontFamily.GenericSerif, 10), stet, comToPix(0, 0).X, comToPix(0, 0).Y);
            graphics.DrawString("-2i", new Font(FontFamily.GenericSerif, 10), stet, comToPix(0, -1.93).X, comToPix(0, -1.93).Y);
            graphics.DrawString("2i", new Font(FontFamily.GenericSerif, 10), stet, comToPix(0, 2).X, comToPix(0, 2).Y);

        }

        private void drawMandel(Bitmap bmp)
        {
            progressBar1.Value = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {

                    int c = mandelCount(pixToCom(i, j).re, pixToCom(i, j).im, max_count);
                    if (max_count == c)
                    {
                        bmp.SetPixel(i, j, barvaMnoziny);
                    }
                    else
                    {
                        Color b = Color.FromArgb( (255*(c ) /9/ max_count),  (255 * (c ) /3/ max_count), (255*(c) / max_count));
                        bmp.SetPixel(i, j, b);
                    }

                }
                if (i != 0)
                {
                    progressBar1.Value = (int)Math.Round((double)i / bmp.Width  * 100);
                }
            }


        }

        private int mandelCount(complex z, int max)
        {
            return mandelCount(z.re, z.im, max);
        }

        private int mandelCount(double cx, double cy, int max)
        {
            double prah = 4.0;
            double y, x, tmpx, fsq;
            int i = 0;


            x = cx;
            y = cy;
            fsq = x * x + y * y;
            while (i < max && fsq <= prah)
            {
                i++;
                tmpx = x;
                x = x * x - y * y + cx;
                y = 2.0 * y * tmpx + cy;
                fsq = x * x + y * y;    
            }
            return i;
        }

        private void drawMandelSeries(complex z, int max)
        {
            bool fin = false;
            double prah = 4.0;
            double y, x, tmpx, tmpy, fsq;
            int i = 0;
            pero = new Pen(Color.Gray, line_width);
           
            x = z.re;
            y = z.im;
            fsq = x * x + y * y;
            while (i < max && !fin)
            { 
                if (fsq > prah)
                {
                    fin = true;
                    pero = new Pen(Color.Red, line_width);
                }
                i++;
                tmpx = x;
                tmpy = y;
                x = x * x - y * y + z.re;
                y = 2.0 * y * tmpx + z.im;
                fsq = x * x + y * y;
                Point b1 = comToPix(tmpx, tmpy);
                Point b2 = comToPix(x, y);
                graphics.DrawLine(pero,b1, b2 );
            }
            pero = new Pen(Color.Green);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                kliknutoR = true;
                complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                reMaxBox.Text = z.re.ToString();
                imMaxBox.Text = z.im.ToString();

                new_max = z;
              
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {//kvuli scalu, prepocet pro klikani, aby se kliklo, kam potrebujeme
            relativePosition.X = (float)(e.X - whiteSpaceLeft) / (panel1.Width - 2 * whiteSpaceLeft);
            relativePosition.Y = (float)(e.Y - whiteSpaceTop) / (panel1.Height - 2 * whiteSpaceTop);

            relativePosition.X = relativePosition.X * bmp.Width;
            relativePosition.Y = relativePosition.Y * bmp.Height;

            if (kliknutoR)
            {
                complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y)); 

                if (!(z.re > new_max.re || z.im > new_max.im))
                {

                    double s = Math.Max(new_max.re-z.re, new_max.im - z.im );

                    new_min = new complex(new_max.re - s, new_max.im - s);


                    reMaxBox.Text = new_max.re.ToString();
                    imMaxBox.Text = new_max.im.ToString();
                    reMinBox.Text = new_min.re.ToString();
                    imMinBox.Text = new_min.im.ToString();

                    Point levy_horni_roh = comToPix(new complex(new_min.re, new_max.im));
                    Point dolni_pravy_roh = comToPix(new_max.re, new_min.im);
                    Size velikost = new Size(-levy_horni_roh.X + dolni_pravy_roh.X, -levy_horni_roh.Y + dolni_pravy_roh.Y);

                    graphics.DrawRectangle(pero, new Rectangle(levy_horni_roh, velikost));

                    paintIntoPanel();
                   
                }

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            kliknutoR = false;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            relativePosition.X = (float)(e.X - whiteSpaceLeft) / (panel1.Width - 2 * whiteSpaceLeft);
            relativePosition.Y = (float)(e.Y - whiteSpaceTop) / (panel1.Height - 2 * whiteSpaceTop);

            relativePosition.X = relativePosition.X * bmp.Width;
            relativePosition.Y = relativePosition.Y * bmp.Height;
  
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                int k = mandelCount(z, max_count);

                BodRe.Text = z.re.ToString();
                BodIm.Text = z.im.ToString();

                label2.Text = "Iteraci: " + k.ToString();
                drawMandelSeries(z, max_count);
            }
            paintIntoPanel();
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            ulozBmp();
        }

        private void vykresli_bod_Click(object sender, EventArgs e)
        {
            complex z;
            try
            {
                z = new complex(Double.Parse(BodRe.Text),Double.Parse(BodIm.Text));

            }
            catch (Exception)
            {
                
                return;
            }
            int k = mandelCount(z, max_count);

            BodRe.Text = z.re.ToString();
            BodIm.Text = z.im.ToString();

            label2.Text = "Iteraci: " + k.ToString();
            drawMandelSeries(z, max_count);
            paintIntoPanel();

        }

        private void reset_Click(object sender, EventArgs e)
        {
            resetDraw();
            iteraci_box.Text = max_count.ToString();
            putBounds();
            nakresli_Click(null, null);

        }

        private void putBounds()
        {
            reMaxBox.Text = max.re.ToString();
            imMaxBox.Text = max.im.ToString();

            reMinBox.Text = min.re.ToString();
            imMinBox.Text = min.im.ToString();

        }

        private void resetDraw()
        {
            max = new complex(2, 2);
            min = new complex(-2, -2);
            max_count = 500;
        }

        private void boundriesBox_TextChanged(object sender, EventArgs e)
        {
            if (!kliknutoR)
            {
                try
                {
                    new_min.re = Double.Parse(reMinBox.Text);
                    new_min.im = Double.Parse(imMinBox.Text);
                    new_max.re = Double.Parse(reMaxBox.Text);
                    new_max.im = Double.Parse(imMaxBox.Text);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ulozBmp();
        }

        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vyber_barvu_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            barvaMnoziny = colorDialog1.Color;
        }

    }

    struct complex{
       public double re;
       public double im;
     

       public complex(double p1, double p2)
       {
           this.re = p1;
           this.im = p2;
       }
    }
}