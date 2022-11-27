using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form17 : Form
    {
        public Form17() //หน้ารวม
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctrl = new UserControl5();
            this.panel1.Controls.Add(ctrl);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctr2 = new UserControl6();
            this.panel1.Controls.Add(ctr2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctr3 = new UserControl7();
            this.panel1.Controls.Add(ctr3);
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctr4 = new UserControl8();
            this.panel1.Controls.Add(ctr4);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var ctr5 = new UserControl8();
            this.panel1.Controls.Add(ctr5);
        }

        private void cONTACTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctr6 = new UserControl9();
            this.panel1.Controls.Add(ctr6);
        }

        private void hISTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var ctr7 = new UserControl10();
            this.panel1.Controls.Add(ctr7);
        }
    }
}
