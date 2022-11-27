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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        
        private void Type_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string menu = e.ClickedItem.Text;
            this.panel1.Controls.Clear();
            switch (menu)
            {
                case "General Car":
                    var ctrl = new UserControl1();
                    this.panel1.Controls.Add(ctrl);
                    break;
                case "Sport Car":
                    var ctr2 = new UserControl2();
                    this.panel1.Controls.Add(ctr2);
                    break;
                case "Super Car":
                    var ctr3 = new UserControl3();
                    this.panel1.Controls.Add(ctr3);
                    break;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 f16 = new Form16();
            f16.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var ctrl = new UserControl1();
            this.panel1.Controls.Add(ctrl);
            
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
