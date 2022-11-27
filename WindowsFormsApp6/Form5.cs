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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.ShowDialog();
        }
    }
}
