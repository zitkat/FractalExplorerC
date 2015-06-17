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
        ColorF[,] my_pixels;
        public Bitmap bmp;

        ColorF set_color;
        ColorF ext1, ext2 ;
        
        public Brush stet;
        private Pen pero;

        int whiteSpaceLeft = 0;//scale     
        int whiteSpaceTop = 0;

        private PointF relativePosition;
        private Boolean right_b_pressed;

        Complex max, min;
        Complex new_max, new_min;
        int max_count = 10;
        double threshold = 4.0;

        /// <summary>
        /// Iteration formula
        /// </summary>
        expression formula;

        float line_width = 1f; 

        public Form1()
        {
            InitializeComponent();

            formula = new expression();

            max = new Complex(2, 2);
            min = new Complex(-2, -2);

            predpis.Text = "z^2 + c";
            use_formula_from_TextBox_Click(this, null);

            iteraci_box.Text = max_count.ToString();

            putBounds();

            show_axes.Checked = true;
            my_pixels = new ColorF[panel1.Width, panel1.Height];
            pero = new Pen(Color.Green);
            stet = new SolidBrush(Color.Green);
            set_color = new ColorF(0f, 0, 0.2f);
            set_color_disp.BackColor = colorFToColor(set_color);

            ext1 = new ColorF(1f, 1f, 0f);
            ext1_color_disp.BackColor = colorFToColor(ext1);
            ext2 = new ColorF(.3f, 0, .8f);
            ext2_color_disp.BackColor = colorFToColor(ext2);

            color_set(my_pixels);
            refresh_bmp();
            repaint_graphics();
            paint_into_panel();
        }

        private void clear_panel()
        {
            graphics.Clear(Color.White);
        }

        private void paint_into_panel()
        {
            panel1_Paint(this, null);            
        }

        /// <summary>
        /// Rewrites bmp with mypixels
        /// </summary>
        private void refresh_bmp()
        {
            if (my_pixels != null)
            { 
                bmp = colorfToBitmap(my_pixels);
                graphics = Graphics.FromImage(bmp);
            }
        }

        /// <summary>
        /// Repaints other graphical elements - axes and series
        /// according to choice of a user in checkboxes
        /// </summary>
        private void repaint_graphics()
        {
            if (show_axes.Checked)
            {
                draw_axes();
            }
            if (show_series.Checked)
            {
                draw_series_point_from_TextBox();
            }
        }

        /// <summary>
        /// Prints bound into according textboxes
        /// </summary>
        private void putBounds()
        {
            reMaxBox.Text = max.Real.ToString();
            imMaxBox.Text = max.Imaginary.ToString();

            reMinBox.Text = min.Real.ToString();
            imMinBox.Text = min.Imaginary.ToString();

        }

        /// <summary>
        /// Resets bounds and maximal count to default values
        /// i.e. (-2,2) x (-2,2) and 100
        /// </summary>
        private void resetDraw()
        {
            max = new Complex(2, 2);
            min = new Complex(-2, -2);
            max_count = 100;
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

        private void paint_set_Click(object sender, EventArgs e)
        {
            int tmp_maxcount = max_count;
            try
            {
                max_count = Int32.Parse(iteraci_box.Text);

            }catch(Exception){
                max_count = tmp_maxcount;
            }

            max = new_max;
            min = new_min;

            if (max.Real <= min.Real || max.Imaginary <= min.Imaginary || max_count <=0)
            {
                resetDraw();
            }

            color_set(my_pixels);
            refresh_bmp();
            repaint_graphics();
            paint_into_panel();
        }

        /// <summary>
        /// Transforms position on bitmap in pixels into position in
        /// Gaussian plane
        /// </summary>
        /// <param name="i">Transormed into real part</param>
        /// <param name="j">Transformed into imaginary part</param>
        /// <returns></returns>
        private Complex pixToCom(int i, int j)
        {
            Complex res = new Complex((double)i * Math.Abs(max.Real - min.Real) / panel1.Width + min.Real,
                                     -(double)j * Math.Abs(max.Imaginary - min.Imaginary) / panel1.Height + max.Imaginary);
            return res;
        }

        /// <summary>
        /// Transforms complex number into pixels
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        private Point comToPix(Complex z)
        {
            return comToPix(z.Real, z.Imaginary);
        }
       
        /// <summary>
        /// Transforms complex number into pixel coordinates according to
        /// current bounds.
        /// </summary>
        /// <param name="re">Real part</param>
        /// <param name="im">Imaginary part</param>
        /// <returns></returns>
        private Point comToPix(double re, double im)
        {
            Point p = new Point();
            p.X = (int)Math.Round((re - min.Real) / Math.Abs(max.Real - min.Real) * bmp.Width);
            p.Y = (int)Math.Round((-im + max.Imaginary) / Math.Abs(max.Imaginary - min.Imaginary) * bmp.Height);
            return p;
        }

        private Color colorFToColor(ColorF c)
        {
            return Color.FromArgb(255, (int)Math.Round(255 * c.r), (int)Math.Round(255 * c.g), (int)Math.Round(255 * c.b));
        }

        private ColorF colorToColorF(Color c)
        {
            return new ColorF(c.R / 255, c.G / 255, c.B / 255);
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

        /// <summary>
        /// Draws axis and labels them
        /// TODO clean up. change drawing from complex numbers to drawing from pixels
        /// </summary>
        private void draw_axes()
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

        /// <summary>
        /// Colors set, ethier mandel or julia, depending on the iteration formula in expression
        /// </summary>
        /// <param name="pixels"></param>
        private void color_set(ColorF[,] pixels)
        {
            progressBar1.Value = 0;
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {

                    int c = count_iterations(pixToCom(j, i), max_count);
                    if (max_count == c)
                    {
                        pixels[i, j] = set_color;
                    }
                    else
                    {
                          pixels[i, j] = new ColorF(
                                     ext1.r * (float)c/max_count + ext2.r*(1-(float)c/max_count),
                                     ext1.g * (float)c/max_count + ext2.g*(1-(float)c/max_count),
                                     ext1.b * (float)c/max_count + ext2.b*(1-(float)c/max_count));  
                    }

                }
                if (i != 0)
                {
                    progressBar1.Value = (int)Math.Round((double)i / panel1.Width  * 100);
                }
            }
        }

        /// <summary>
        /// Calculates number of iterations for number z before it diverges
        /// or reaches max
        /// </summary>
        /// <param name="z"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int count_iterations(Complex z, int max)
        {
            int i = 0;
            Complex tmpz = z;
            double fsq = calc.fsq(tmpz);

            while (i < max && fsq <= threshold)
            {
                i++;
                tmpz = formula.value_at(tmpz, z);
                fsq = calc.fsq(tmpz);
            }
            return i;
        }

        /// <summary>
        /// Draws series generated by iteration formula starting at z,
        /// stops one step after series diverges or after max iterations
        /// </summary>
        /// <param name="z"></param>
        /// <param name="max"></param>
        private void draw_series(Complex z, int max)
        {
            bool fin = false;
            int i = 0;
            Complex tmpz = z;
            double fsq = calc.fsq(tmpz);
            
            pero = new Pen(Color.Gray, line_width);

            while (i < max && !fin)
            { 
               
                i++;
                Point b1 = comToPix(tmpz);
                tmpz = formula.value_at(tmpz, z);
                fsq = calc.fsq(tmpz);

                if (fsq > threshold)
                {
                    fin = true;
                    pero = new Pen(Color.Red, line_width);
                }
                Point b2 = comToPix(tmpz);
                graphics.DrawLine(pero, b1, b2 ); 
            }
            pero = new Pen(Color.Green);
        }

        /// <summary>
        /// Handles call of drawSeries
        /// </summary>
        private void draw_series_point_from_TextBox()
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
            int k = count_iterations(z, max_count);
            label2.Text = "Iteraci: " + k.ToString();
            draw_series(z, max_count);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                right_b_pressed = true;
                Complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                reMaxBox.Text = z.Real.ToString();
                imMaxBox.Text = z.Imaginary.ToString();

                new_max = z;
              
            }
        }

        /// <summary>
        /// If kliknotoR is true creates selection box and saves new bounds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {//kvuli scalu, prepocet pro klikani, aby se kliklo, kam potrebujeme
            relativePosition.X = (float)(e.X - whiteSpaceLeft) / (panel1.Width - 2 * whiteSpaceLeft);
            relativePosition.Y = (float)(e.Y - whiteSpaceTop) / (panel1.Height - 2 * whiteSpaceTop);

            relativePosition.X = relativePosition.X * bmp.Width;
            relativePosition.Y = relativePosition.Y * bmp.Height;

            if (right_b_pressed)
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

                    refresh_bmp();
                    repaint_graphics();
                    graphics.DrawRectangle(pero, new Rectangle(levy_horni_roh, velikost));
                    paint_into_panel();
                   
                }

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            right_b_pressed = false;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            relativePosition.X = (float)(e.X - whiteSpaceLeft) / (panel1.Width - 2 * whiteSpaceLeft);
            relativePosition.Y = (float)(e.Y - whiteSpaceTop) / (panel1.Height - 2 * whiteSpaceTop);

            relativePosition.X = relativePosition.X * bmp.Width;
            relativePosition.Y = relativePosition.Y * bmp.Height;
  
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                show_series.Checked = true;
                Complex z = pixToCom((int)Math.Round(relativePosition.X), (int)Math.Round(relativePosition.Y));
                int k = count_iterations(z, max_count);

                BodRe.Text = z.Real.ToString();
                BodIm.Text = z.Imaginary.ToString();

                label2.Text = "Iteraci: " + k.ToString();
                refresh_bmp();
                repaint_graphics();
                draw_series(z, max_count);
            }
            paint_into_panel();
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            ulozBmp();
        }

        private void draw_serires_but_Click(object sender, EventArgs e)
        {
            draw_series_point_from_TextBox();
            paint_into_panel();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            resetDraw();
            iteraci_box.Text = max_count.ToString();
            putBounds();
        }

        private void boundriesBox_TextChanged(object sender, EventArgs e)
        {
            if (!right_b_pressed)
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

        private void set_color_choice_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            set_color = colorToColorF(colorDialog1.Color);
            set_color_disp.BackColor = colorDialog1.Color;      
        }

        /// <summary>
        /// Handles calling of parser and error reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void use_formula_from_TextBox_Click(object sender, EventArgs e)
        {
            try
            {
                formula.set_expression(predpis.Text.Replace(" ", ""));
            }
            catch (parsingException ex)
            {
                MessageBox.Show(ex.Message + " at position " + ex.index.ToString() + " in \"" + predpis.Text.Replace(" ", "")+"\"", "Parsing error");
                return;
            }
            current_formula.Text = predpis.Text.Replace(" ", "");

        }

        /// <summary>
        /// Adds point in textboxes to iteration formula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insert_point_Click(object sender, EventArgs e)
        {
            predpis.Text += BodRe.Text + " + " + BodIm.Text + "i"; 
        }

        private void exterior_color_choice_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ext1 = colorToColorF(colorDialog1.Color);
            ext1_color_disp.BackColor = colorDialog1.Color;

            colorDialog1.ShowDialog();
            ext2 = colorToColorF(colorDialog1.Color);
            ext2_color_disp.BackColor = colorDialog1.Color;
        }

        private void show_axes_CheckedChanged(object sender, EventArgs e)
        {
            refresh_bmp();
            repaint_graphics();
            paint_into_panel();
        }

        private void show_series_CheckedChanged(object sender, EventArgs e)
        {
            refresh_bmp();
            repaint_graphics();
            paint_into_panel();

        }

    }
}