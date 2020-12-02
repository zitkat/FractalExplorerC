namespace FractalExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.paint_set = new System.Windows.Forms.Button();
            this.ulozit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.show_series = new System.Windows.Forms.CheckBox();
            this.inser_point = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BodIm = new System.Windows.Forms.TextBox();
            this.draw_series_but = new System.Windows.Forms.Button();
            this.BodRe = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_threshold = new System.Windows.Forms.TextBox();
            this.show_axes = new System.Windows.Forms.CheckBox();
            this.reset = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imMinBox = new System.Windows.Forms.TextBox();
            this.imMaxBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.reMinBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.iteraci_box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.reMaxBox = new System.Windows.Forms.TextBox();
            this.set_color_choice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zobrazeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.překresliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barvyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.množinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hraniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.use_formula = new System.Windows.Forms.Button();
            this.current_formula = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ext2_color_disp = new System.Windows.Forms.TextBox();
            this.ext1_color_disp = new System.Windows.Forms.TextBox();
            this.exterior_color_choice = new System.Windows.Forms.Button();
            this.set_color_disp = new System.Windows.Forms.TextBox();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.predpis = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(132, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // paint_set
            // 
            this.paint_set.Location = new System.Drawing.Point(22, 229);
            this.paint_set.Name = "paint_set";
            this.paint_set.Size = new System.Drawing.Size(75, 23);
            this.paint_set.TabIndex = 1;
            this.paint_set.Text = "Překresli";
            this.paint_set.UseVisualStyleBackColor = true;
            this.paint_set.Click += new System.EventHandler(this.paint_set_Click);
            // 
            // ulozit
            // 
            this.ulozit.Location = new System.Drawing.Point(29, 639);
            this.ulozit.Name = "ulozit";
            this.ulozit.Size = new System.Drawing.Size(75, 23);
            this.ulozit.TabIndex = 3;
            this.ulozit.Text = "Uložit";
            this.ulozit.UseVisualStyleBackColor = true;
            this.ulozit.Click += new System.EventHandler(this.ulozit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.show_series);
            this.groupBox1.Controls.Add(this.inser_point);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BodIm);
            this.groupBox1.Controls.Add(this.draw_series_but);
            this.groupBox1.Controls.Add(this.BodRe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bod";
            // 
            // show_series
            // 
            this.show_series.AutoSize = true;
            this.show_series.Checked = true;
            this.show_series.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_series.Location = new System.Drawing.Point(29, 80);
            this.show_series.Name = "show_series";
            this.show_series.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.show_series.Size = new System.Drawing.Size(64, 17);
            this.show_series.TabIndex = 21;
            this.show_series.Text = "Zobrazit";
            this.show_series.UseVisualStyleBackColor = true;
            this.show_series.CheckedChanged += new System.EventHandler(this.show_series_CheckedChanged);
            // 
            // inser_point
            // 
            this.inser_point.Location = new System.Drawing.Point(22, 132);
            this.inser_point.Name = "inser_point";
            this.inser_point.Size = new System.Drawing.Size(75, 23);
            this.inser_point.TabIndex = 9;
            this.inser_point.Text = "Vlož";
            this.inser_point.UseVisualStyleBackColor = true;
            this.inser_point.Click += new System.EventHandler(this.insert_point_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Im:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Re:";
            // 
            // BodIm
            // 
            this.BodIm.Location = new System.Drawing.Point(29, 54);
            this.BodIm.Name = "BodIm";
            this.BodIm.Size = new System.Drawing.Size(80, 20);
            this.BodIm.TabIndex = 6;
            // 
            // draw_series_but
            // 
            this.draw_series_but.Location = new System.Drawing.Point(22, 103);
            this.draw_series_but.Name = "draw_series_but";
            this.draw_series_but.Size = new System.Drawing.Size(75, 23);
            this.draw_series_but.TabIndex = 7;
            this.draw_series_but.Text = "Nakresli";
            this.draw_series_but.UseVisualStyleBackColor = true;
            this.draw_series_but.Click += new System.EventHandler(this.draw_serires_but_Click);
            // 
            // BodRe
            // 
            this.BodRe.Location = new System.Drawing.Point(29, 32);
            this.BodRe.Name = "BodRe";
            this.BodRe.Size = new System.Drawing.Size(80, 20);
            this.BodRe.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_threshold);
            this.groupBox2.Controls.Add(this.show_axes);
            this.groupBox2.Controls.Add(this.reset);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.imMinBox);
            this.groupBox2.Controls.Add(this.imMaxBox);
            this.groupBox2.Controls.Add(this.paint_set);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.reMinBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.iteraci_box);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.reMaxBox);
            this.groupBox2.Location = new System.Drawing.Point(11, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 262);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zobrazení";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Práh:";
            // 
            // textBox_threshold
            // 
            this.textBox_threshold.Location = new System.Drawing.Point(53, 45);
            this.textBox_threshold.Name = "textBox_threshold";
            this.textBox_threshold.Size = new System.Drawing.Size(56, 20);
            this.textBox_threshold.TabIndex = 21;
            // 
            // show_axes
            // 
            this.show_axes.AutoSize = true;
            this.show_axes.Checked = true;
            this.show_axes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_axes.Location = new System.Drawing.Point(22, 177);
            this.show_axes.Name = "show_axes";
            this.show_axes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.show_axes.Size = new System.Drawing.Size(44, 17);
            this.show_axes.TabIndex = 20;
            this.show_axes.Text = "Osy";
            this.show_axes.UseVisualStyleBackColor = true;
            this.show_axes.CheckedChanged += new System.EventHandler(this.show_axes_CheckedChanged);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(22, 200);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 18;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Max.Im:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Min.Im:";
            // 
            // imMinBox
            // 
            this.imMinBox.Location = new System.Drawing.Point(53, 151);
            this.imMinBox.Name = "imMinBox";
            this.imMinBox.Size = new System.Drawing.Size(56, 20);
            this.imMinBox.TabIndex = 14;
            this.imMinBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // imMaxBox
            // 
            this.imMaxBox.Location = new System.Drawing.Point(53, 99);
            this.imMaxBox.Name = "imMaxBox";
            this.imMaxBox.Size = new System.Drawing.Size(56, 20);
            this.imMaxBox.TabIndex = 16;
            this.imMaxBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min.Re:";
            // 
            // reMinBox
            // 
            this.reMinBox.Location = new System.Drawing.Point(53, 125);
            this.reMinBox.Name = "reMinBox";
            this.reMinBox.Size = new System.Drawing.Size(56, 20);
            this.reMinBox.TabIndex = 10;
            this.reMinBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Iterací:";
            // 
            // iteraci_box
            // 
            this.iteraci_box.Location = new System.Drawing.Point(53, 19);
            this.iteraci_box.Name = "iteraci_box";
            this.iteraci_box.Size = new System.Drawing.Size(56, 20);
            this.iteraci_box.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Max.Re:";
            // 
            // reMaxBox
            // 
            this.reMaxBox.Location = new System.Drawing.Point(53, 73);
            this.reMaxBox.Name = "reMaxBox";
            this.reMaxBox.Size = new System.Drawing.Size(56, 20);
            this.reMaxBox.TabIndex = 12;
            this.reMaxBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // set_color_choice
            // 
            this.set_color_choice.Location = new System.Drawing.Point(21, 19);
            this.set_color_choice.Name = "set_color_choice";
            this.set_color_choice.Size = new System.Drawing.Size(75, 23);
            this.set_color_choice.TabIndex = 14;
            this.set_color_choice.Text = "Množina";
            this.set_color_choice.UseVisualStyleBackColor = true;
            this.set_color_choice.Click += new System.EventHandler(this.set_color_choice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Iterační předpis:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.zobrazeníToolStripMenuItem,
            this.barvyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uložitToolStripMenuItem,
            this.toolStripSeparator1,
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // uložitToolStripMenuItem
            // 
            this.uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
            this.uložitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.uložitToolStripMenuItem.Text = "Uložit";
            this.uložitToolStripMenuItem.Click += new System.EventHandler(this.uložitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // zobrazeníToolStripMenuItem
            // 
            this.zobrazeníToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.překresliToolStripMenuItem});
            this.zobrazeníToolStripMenuItem.Name = "zobrazeníToolStripMenuItem";
            this.zobrazeníToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.zobrazeníToolStripMenuItem.Text = "Zobrazení";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.reset_Click);
            // 
            // překresliToolStripMenuItem
            // 
            this.překresliToolStripMenuItem.Name = "překresliToolStripMenuItem";
            this.překresliToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.překresliToolStripMenuItem.Text = "Překresli";
            this.překresliToolStripMenuItem.Click += new System.EventHandler(this.paint_set_Click);
            // 
            // barvyToolStripMenuItem
            // 
            this.barvyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.množinaToolStripMenuItem,
            this.hraniceToolStripMenuItem});
            this.barvyToolStripMenuItem.Name = "barvyToolStripMenuItem";
            this.barvyToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.barvyToolStripMenuItem.Text = "Barvy";
            // 
            // množinaToolStripMenuItem
            // 
            this.množinaToolStripMenuItem.Name = "množinaToolStripMenuItem";
            this.množinaToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.množinaToolStripMenuItem.Text = "Množina";
            this.množinaToolStripMenuItem.Click += new System.EventHandler(this.set_color_choice_Click);
            // 
            // hraniceToolStripMenuItem
            // 
            this.hraniceToolStripMenuItem.Name = "hraniceToolStripMenuItem";
            this.hraniceToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.hraniceToolStripMenuItem.Text = "Hranice";
            this.hraniceToolStripMenuItem.Click += new System.EventHandler(this.exterior_color_choice_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(133, 653);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(529, 12);
            this.progressBar1.TabIndex = 13;
            // 
            // use_formula
            // 
            this.use_formula.Location = new System.Drawing.Point(551, 24);
            this.use_formula.Name = "use_formula";
            this.use_formula.Size = new System.Drawing.Size(75, 23);
            this.use_formula.TabIndex = 14;
            this.use_formula.Text = "Použít";
            this.use_formula.UseVisualStyleBackColor = true;
            this.use_formula.Click += new System.EventHandler(this.use_formula_from_TextBox_Click);
            // 
            // current_formula
            // 
            this.current_formula.AutoSize = true;
            this.current_formula.Location = new System.Drawing.Point(632, 31);
            this.current_formula.Name = "current_formula";
            this.current_formula.Size = new System.Drawing.Size(41, 13);
            this.current_formula.TabIndex = 15;
            this.current_formula.Text = "label10";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ext2_color_disp);
            this.groupBox3.Controls.Add(this.ext1_color_disp);
            this.groupBox3.Controls.Add(this.exterior_color_choice);
            this.groupBox3.Controls.Add(this.set_color_disp);
            this.groupBox3.Controls.Add(this.set_color_choice);
            this.groupBox3.Location = new System.Drawing.Point(11, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 160);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Barvy";
            // 
            // ext2_color_disp
            // 
            this.ext2_color_disp.Enabled = false;
            this.ext2_color_disp.Location = new System.Drawing.Point(22, 129);
            this.ext2_color_disp.Name = "ext2_color_disp";
            this.ext2_color_disp.ReadOnly = true;
            this.ext2_color_disp.ShortcutsEnabled = false;
            this.ext2_color_disp.Size = new System.Drawing.Size(74, 20);
            this.ext2_color_disp.TabIndex = 18;
            this.ext2_color_disp.TabStop = false;
            // 
            // ext1_color_disp
            // 
            this.ext1_color_disp.Enabled = false;
            this.ext1_color_disp.Location = new System.Drawing.Point(22, 103);
            this.ext1_color_disp.Name = "ext1_color_disp";
            this.ext1_color_disp.ReadOnly = true;
            this.ext1_color_disp.Size = new System.Drawing.Size(74, 20);
            this.ext1_color_disp.TabIndex = 17;
            this.ext1_color_disp.TabStop = false;
            // 
            // exterior_color_choice
            // 
            this.exterior_color_choice.Location = new System.Drawing.Point(21, 74);
            this.exterior_color_choice.Name = "exterior_color_choice";
            this.exterior_color_choice.Size = new System.Drawing.Size(75, 23);
            this.exterior_color_choice.TabIndex = 16;
            this.exterior_color_choice.Text = "Hranice";
            this.exterior_color_choice.UseVisualStyleBackColor = true;
            this.exterior_color_choice.Click += new System.EventHandler(this.exterior_color_choice_Click);
            // 
            // set_color_disp
            // 
            this.set_color_disp.Enabled = false;
            this.set_color_disp.Location = new System.Drawing.Point(22, 48);
            this.set_color_disp.Name = "set_color_disp";
            this.set_color_disp.ReadOnly = true;
            this.set_color_disp.ShortcutsEnabled = false;
            this.set_color_disp.Size = new System.Drawing.Size(74, 20);
            this.set_color_disp.TabIndex = 15;
            this.set_color_disp.TabStop = false;
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(668, 649);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.ReadOnly = true;
            this.textBox_time.Size = new System.Drawing.Size(65, 20);
            this.textBox_time.TabIndex = 17;
            // 
            // predpis
            // 
            this.predpis.FormattingEnabled = true;
            this.predpis.Location = new System.Drawing.Point(132, 24);
            this.predpis.Name = "predpis";
            this.predpis.Size = new System.Drawing.Size(413, 21);
            this.predpis.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 671);
            this.Controls.Add(this.predpis);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.current_formula);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.use_formula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ulozit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(750, 710);
            this.MinimumSize = new System.Drawing.Size(750, 710);
            this.Name = "Form1";
            this.Text = "Fractal Explorer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button paint_set;
        private System.Windows.Forms.Button ulozit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BodIm;
        private System.Windows.Forms.TextBox BodRe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox iteraci_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox imMaxBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox imMinBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox reMaxBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox reMinBox;
        private System.Windows.Forms.Button draw_series_but;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.CheckBox show_axes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button set_color_choice;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button use_formula;
        private System.Windows.Forms.Label current_formula;
        private System.Windows.Forms.Button inser_point;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button exterior_color_choice;
        private System.Windows.Forms.TextBox set_color_disp;
        private System.Windows.Forms.TextBox ext1_color_disp;
        private System.Windows.Forms.TextBox ext2_color_disp;
        private System.Windows.Forms.CheckBox show_series;
        private System.Windows.Forms.ToolStripMenuItem zobrazeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem překresliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barvyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem množinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hraniceToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_threshold;
        private System.Windows.Forms.ComboBox predpis;
    }
}

