using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class Form11 : Form
    {

        string username = Form10.to;
        public Form11()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text) 
            {
                MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");

            }
        }
    }
}
