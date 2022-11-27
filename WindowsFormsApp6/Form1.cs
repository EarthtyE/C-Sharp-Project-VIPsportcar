using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");

        public Form1() //UI Login
        {
            InitializeComponent();
        }

        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void dataAdaterLoginCus(string query) //Check Login
        {
            openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Form17 frm17 = new Form17(); //หน้าแรกรวม
                frm17.Show();
                Program.message = txtUsernameCus.Text;
            }
            else
            {
                MessageBox.Show("You have entered an incorrect username or password.", "Wrong.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPasswordCus.UseSystemPasswordChar = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) //BTN Register
        {
            Form2 f2 = new Form2(); //UI Register
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e) //BTN Admin
        {
            this.Hide();
            Form4 f = new Form4(); //UI Admin
            f.ShowDialog();
        }

        public static string Username = "";

        private void but_login_Click(object sender, EventArgs e) 
        {
            if (txtUsernameCus.Text == "" || txtPasswordCus.Text == "") //เช็คช่องว่าง
            {
                MessageBox.Show("You have not entered a username or password.", "Wrong.");
            }
            else
            {
                string login = "SELECT * FROM cartis.customer_data WHERE username = '" + txtUsernameCus.Text + "' AND password = '" + txtPasswordCus.Text + "'";
                dataAdaterLoginCus(login);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //Show Pass
        {
            if (checkBox1.Checked)
            {
                txtPasswordCus.UseSystemPasswordChar = false;
            }
            else
            {
                txtPasswordCus.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 f10 = new Form10();
            this.Hide();
            f10.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.ShowDialog();
        }

    }
}
