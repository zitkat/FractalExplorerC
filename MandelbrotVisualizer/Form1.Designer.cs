namespace MandelbrotVisualizer
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
            this.nakresli = new System.Windows.Forms.Button();
            this.ulozit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BodIm = new System.Windows.Forms.TextBox();
            this.vykresli_bod = new System.Windows.Forms.Button();
            this.BodRe = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vyber_barvu = new System.Windows.Forms.Button();
            this.osy = new System.Windows.Forms.CheckBox();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(133, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // nakresli
            // 
            this.nakresli.Location = new System.Drawing.Point(22, 208);
            this.nakresli.Name = "nakresli";
            this.nakresli.Size = new System.Drawing.Size(75, 23);
            this.nakresli.TabIndex = 1;
            this.nakresli.Text = "Překresli";
            this.nakresli.UseVisualStyleBackColor = true;
            this.nakresli.Click += new System.EventHandler(this.nakresli_Click);
            // 
            // ulozit
            // 
            this.ulozit.Location = new System.Drawing.Point(12, 568);
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
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BodIm);
            this.groupBox1.Controls.Add(this.vykresli_bod);
            this.groupBox1.Controls.Add(this.BodRe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bod";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Im:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Re:";
            // 
            // BodIm
            // 
            this.BodIm.Location = new System.Drawing.Point(29, 71);
            this.BodIm.Name = "BodIm";
            this.BodIm.Size = new System.Drawing.Size(80, 20);
            this.BodIm.TabIndex = 6;
            // 
            // vykresli_bod
            // 
            this.vykresli_bod.Location = new System.Drawing.Point(22, 97);
            this.vykresli_bod.Name = "vykresli_bod";
            this.vykresli_bod.Size = new System.Drawing.Size(75, 23);
            this.vykresli_bod.TabIndex = 7;
            this.vykresli_bod.Text = "Nakresli bod";
            this.vykresli_bod.UseVisualStyleBackColor = true;
            this.vykresli_bod.Click += new System.EventHandler(this.vykresli_bod_Click);
            // 
            // BodRe
            // 
            this.BodRe.Location = new System.Drawing.Point(29, 45);
            this.BodRe.Name = "BodRe";
            this.BodRe.Size = new System.Drawing.Size(80, 20);
            this.BodRe.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.vyber_barvu);
            this.groupBox2.Controls.Add(this.osy);
            this.groupBox2.Controls.Add(this.reset);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.imMinBox);
            this.groupBox2.Controls.Add(this.imMaxBox);
            this.groupBox2.Controls.Add(this.nakresli);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.reMinBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.iteraci_box);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.reMaxBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 275);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Množina";
            // 
            // vyber_barvu
            // 
            this.vyber_barvu.Location = new System.Drawing.Point(22, 237);
            this.vyber_barvu.Name = "vyber_barvu";
            this.vyber_barvu.Size = new System.Drawing.Size(75, 23);
            this.vyber_barvu.TabIndex = 14;
            this.vyber_barvu.Text = "Barva";
            this.vyber_barvu.UseVisualStyleBackColor = true;
            this.vyber_barvu.Click += new System.EventHandler(this.vyber_barvu_Click);
            // 
            // osy
            // 
            this.osy.AutoSize = true;
            this.osy.Location = new System.Drawing.Point(22, 156);
            this.osy.Name = "osy";
            this.osy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.osy.Size = new System.Drawing.Size(44, 17);
            this.osy.TabIndex = 20;
            this.osy.Text = "Osy";
            this.osy.UseVisualStyleBackColor = true;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(22, 179);
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
            this.label9.Location = new System.Drawing.Point(11, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Max.Im:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Min.Im:";
            // 
            // imMinBox
            // 
            this.imMinBox.Location = new System.Drawing.Point(53, 130);
            this.imMinBox.Name = "imMinBox";
            this.imMinBox.Size = new System.Drawing.Size(56, 20);
            this.imMinBox.TabIndex = 14;
            this.imMinBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // imMaxBox
            // 
            this.imMaxBox.Location = new System.Drawing.Point(53, 71);
            this.imMaxBox.Name = "imMaxBox";
            this.imMaxBox.Size = new System.Drawing.Size(56, 20);
            this.imMaxBox.TabIndex = 16;
            this.imMaxBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Min.Re:";
            // 
            // reMinBox
            // 
            this.reMinBox.Location = new System.Drawing.Point(53, 104);
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
            this.label7.Location = new System.Drawing.Point(9, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Max.Re:";
            // 
            // reMaxBox
            // 
            this.reMaxBox.Location = new System.Drawing.Point(53, 45);
            this.reMaxBox.Name = "reMaxBox";
            this.reMaxBox.Size = new System.Drawing.Size(56, 20);
            this.reMaxBox.TabIndex = 12;
            this.reMaxBox.TextChanged += new System.EventHandler(this.boundriesBox_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(639, 20);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Iterační předpis:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 24);
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(133, 644);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(600, 13);
            this.progressBar1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 662);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ulozit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Fractal Explorer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nakresli;
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
        private System.Windows.Forms.Button vykresli_bod;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.CheckBox osy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button vyber_barvu;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

