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
using System.Numerics;

namespace FractalExplorer
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        ColorF[,] pixels;
        public Bitmap bmp;
        
        public Brush stet;
        private Pen pero;

        int whiteSpaceLeft = 0;//scale     
        int whiteSpaceTop = 0;

        private PointF relativePosition;
        private Boolean kliknutoR;

        Complex max, min;
        Complex new_max, new_min;
        int max_count = 100;
        double prah = 4.0;

        expression pocitadlo;

        float line_width = 1f; 

        public Form1()
        {
            InitializeComponent();

            pocitadlo = new expression();

            max = new Complex(2, 2);
            min = new Complex(-2, -2);

            iteraci_box.Text = max_count.ToString();

            putBounds();

            osy.Checked = true;
            pixels = new ColorF[panel1.Width, panel1.Height];
            pero = new Pen(Color.Green);
            stet = new SolidBrush(Color.Green);
            
            //drawMandel(pixels);
            refreshbmp();
            
            
            drawAxes();

            paintIntoPanel();
        }

        private void clearPanel()
        {
            graphics.Clear(Color.White);
        }

        private void paintIntoPanel()
        {
            panel1_Paint(this, null);            
        }

        private void refreshbmp()
        {
            bmp = colorfToBitmap(pixels);
            graphics = Graphics.FromImage(bmp);
        }

        private void putBounds()
        {
            reMaxBox.Text = max.Real.ToString();
            imMaxBox.Text = max.Imaginary.ToString();

            reMinBox.Text = min.Real.ToString();
            imMinBox.Text = min.Imaginary.ToString();

        }

        private void resetDraw()
        {
            max = new Complex(2, 2);
            min = new Complex(-2, -2);
            max_count = 500;
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

            if (max.Real <= min.Real || max.Imaginary <= min.Imaginary || max_count <=0)
            {
                resetDraw();
            }

            drawMandel(pixels);
            refreshbmp();
            if (osy.Checked)
            {
                drawAxes();
            }
            paintIntoPanel();
        }

        private Complex pixToCom(int i, int j)
        {
            Complex res = new Complex((double)i * Math.Abs(max.Real - min.Real) / panel1.Width + min.Real,
                -(double)j * Math.Abs(max.Imaginary - min.Imaginary) / panel1.Height + max.Imaginary);
            return res;
        }

        private Point comToPix(Complex z)
        {
            return comToPix(z.Real, z.Imaginary);
        }
       
        private Point comToPix(double re, double im)
        {
            Point p = new Point();
            p.X = (int)Math.Round((re - min.Real) / Math.Abs(max.Real - min.Real) * bmp.Width);
            p.Y = (int)Math.Round((-im + max.Imaginary) / Math.Abs(max.Imaginary - min.Imaginary) * bmp.Height);
            return p;
        }

        private ColorF[,] bitmapToColorf(Bitmap souce)
        {//pole o velikosti bmp
            if (souce == null) return null;

            ColorF[,] rv = new ColorF[souce.Height, souce.Width];

            BitmapData bd = null;
            try
            {//zamkneme to
                bd = souce.LockBits(new Rectangle(0, 0, souce.Width, souce.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
            ColorF c = new ColorF();
            unsafe//chova se to jako ccko
            {
                byte* ptr = null;
                byte* lnptr = (byte*)bd.Scan0;//nacte adresu prvniho bytu (1 pixel - 4 bity - BGRA), takze dostaneme adresu na B

                for (int i = 0; i < bd.Height; ++i)
                {
                    ptr = lnptr;
                    for (int j = 0; j < bd.Width; ++j)
                    {
                        //*ptr, *ptr+1, *ptr+2, *ptr+3 = B, G, R, A
                        c.b = (float)(*ptr) / 255.0f;//1. kanal barvy pixelu
                        c.g = (float)(*(ptr + 1)) / 255.0f;
                        c.r = (float)(*(ptr + 2)) / 255.0f;
                        c.a = (float)(*(ptr + 3)) / 255.0f;

                        rv[i, j] = c;
                        ptr += 4; //ARGB = 4 bytes
                    }
                    lnptr += bd.Stride;//posun na dalsi radek
                }

            }

            souce.UnlockBits(bd);

            return rv;
        }

        /// <summary>
        /// Prevede pole float4 barev do obrazku.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Bitmap colorfToBitmap(ColorF[,] source)
        {
            Bitmap rv = new Bitmap(source.GetLength(1), source.GetLength(0), PixelFormat.Format32bppArgb);

            BitmapData bd = null;
            try
            {
                bd = rv.LockBits(new Rectangle(0, 0, rv.Width, rv.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
            unsafe
            {
                byte* ptr = null;
                byte* lnptr = (byte*)bd.Scan0;
                ColorF c;
                for (int i = 0; i < bd.Height; ++i)
                {
                    ptr = lnptr;
                    for (int j = 0; j < bd.Width; ++j)
                    {
                        c = source[i, j];
                        //*ptr, *ptr+1, *ptr+2, *ptr+3 = B, G, R, A
                        *ptr = (byte)(c.b * 255.0f);
                        *(ptr + 1) = (byte)(c.g * 255.0f);
                        *(ptr + 2) = (byte)(c.r * 255.0f);
                        *(ptr + 3) = (byte)(c.a * 255.0f);

                        ptr += 4; //ARGB = 4 bytes
                    }
                    lnptr += bd.Stride;
                }

            }

            rv.UnlockBits(bd);

            return rv;
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

        private void drawMandel(ColorF[,] pixels)
        {
            progressBar1.Value = 0;
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {

                    int c = mandelCount(pixToCom(j, i), max_count);
                    if (max_count == c)
                    {
                        pixels[i, j] = new ColorF(0, 0, 0);//TODO allow changing set color
                    }
                    else
                    {
                        pixels[i, j] = new ColorF((float)c / 9.0f / max_count, (float)c / 3.0f / max_count, (float)c / max_count);//TODO allow changing border and exterior color
                    }

                }
                if (i != 0)
                {
                    progressBar1.Value = (int)Math.Round((double)i / panel1.Width  * 100);
                }
            }


        }

        private int mandelCount(Complex z, int max)
        {
            int i = 0;
            Complex tmpz = z;
            double fsq = calc.fsq(tmpz);

            while (i < max && fsq <= prah)
            {
                i++;
                tmpz = pocitadlo.nextIteration(tmpz, z);
                fsq = calc.fsq(tmpz);
            }
            return i;
        }

        private void drawSeries(Complex z, int max)
        {
            bool fin = false;
            int i = 0;
            Complex tmpz = z;
            double fsq = calc.fsq(tmpz);
            
            pero = new Pen(Color.Gray, line_width);

            while (i < max && !fin)
            { 
                if (fsq > prah)
                {
                    fin = true;
                    pero = new Pen(Color.Red, line_width);
                }
                i++;
                Point b1 = comToPix(tmpz);
                tmpz = pocitadlo.nextIteration(tmpz,z);
                fsq = calc.fsq(tmpz);
                Point b2 = comToPix(tmpz);
                graphics.DrawLine(pero, b1, b2 );
            }
            pero = new Pen(Color.Green);
        }

        private void vykresli_posl_z_bod()
        {
            Complex z;
            try
            {
                z = new Complex(Double.Parse(BodRe.Text), Double.Parse(BodIm.Text));

            }
            catch (Exception)
            {
                return;
            }
            int k = mandelCount(z, max_count);
            label2.Text = "Iteraci: " + k.ToString();
            drawSeries(z, max_count);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                kliknutoR = true;
                Complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                reMaxBox.Text = z.Real.ToString();
                imMaxBox.Text = z.Imaginary.ToString();

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
                Complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y)); 

                if (!(z.Real > new_max.Real || z.Imaginary > new_max.Imaginary))
                {

                    double s = Math.Max(new_max.Real-z.Real, new_max.Imaginary - z.Imaginary );

                    new_min = new Complex(new_max.Real - s, new_max.Imaginary - s);


                    reMaxBox.Text = new_max.Real.ToString();
                    imMaxBox.Text = new_max.Imaginary.ToString();
                    reMinBox.Text = new_min.Real.ToString();
                    imMinBox.Text = new_min.Imaginary.ToString();

                    Point levy_horni_roh = comToPix(new Complex(new_min.Real, new_max.Imaginary));
                    Point dolni_pravy_roh = comToPix(new_max.Real, new_min.Imaginary);
                    Size velikost = new Size(-levy_horni_roh.X + dolni_pravy_roh.X, -levy_horni_roh.Y + dolni_pravy_roh.Y);

                    refreshbmp();
                    if (osy.Checked)
                    {
                        drawAxes();
                    }
                    vykresli_posl_z_bod();
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
                Complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                int k = mandelCount(z, max_count);

                BodRe.Text = z.Real.ToString();
                BodIm.Text = z.Imaginary.ToString();

                label2.Text = "Iteraci: " + k.ToString();
                drawSeries(z, max_count);
            }
            paintIntoPanel();
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            ulozBmp();
        }

        private void vykresli_bod_Click(object sender, EventArgs e)
        {
            vykresli_posl_z_bod();
            paintIntoPanel();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            resetDraw();
            iteraci_box.Text = max_count.ToString();
            putBounds();
            nakresli_Click(null, null);

        }

        private void boundriesBox_TextChanged(object sender, EventArgs e)
        {
            if (!kliknutoR)
            {
                try
                {
                    new_min = new Complex(Double.Parse(reMinBox.Text), Double.Parse(imMinBox.Text));
                    new_max = new Complex(Double.Parse(reMaxBox.Text), Double.Parse(imMaxBox.Text));
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
            //TODO set and border color selection
        }

        private void Pouzit_Click(object sender, EventArgs e)
        {
            pocitadlo.setExpression(predpis.Text.Replace(" ",""));
            //nakresli_Click(this, null);
            vysledek.Text = pocitadlo.nextIteration(new Complex(1, 0), new Complex(0, 0)).ToString();

        }

    }
}