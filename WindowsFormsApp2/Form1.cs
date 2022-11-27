using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        Form opener;
        public Form2(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
