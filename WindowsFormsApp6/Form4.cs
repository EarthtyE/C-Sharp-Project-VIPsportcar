using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


    namespace WindowsFormsApp6
{
    public partial class Form4 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        
        public Form4()
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
        public void dataAdaterLogin(string query)
        {
            openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Form5 frm5 = new Form5();
                frm5.Show();
            }
            else
            {
                MessageBox.Show("You have entered an incorrect username or password.", "Wrong");
            }
        }

        private void button1_Keypress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
            else
            {
                MessageBox.Show("กรุณาระบุข้อมูลเป็นภาษาอังกฤษ");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = "SELECT * FROM cartis.loginadmin WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
            dataAdaterLogin(login);
                        
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}
