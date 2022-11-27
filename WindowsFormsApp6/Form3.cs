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
using System.IO;


namespace WindowsFormsApp6
{
    public partial class Form3 : Form
    {


        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();


        public Form3()
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
        /*
        private void ShowCarInformation()
        {
            openConnection();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM car_data";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            closeConnection();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        */
        private void Form3_Load(object sender, EventArgs e)
        {

            label13.Text = Form1.Username;

            try
            {
                openConnection();
                if (conn.State == ConnectionState.Open)
                {
                    connected.Text = "Connected";
                    connected.ForeColor = Color.Green;
                }
                else
                {
                    connected.Text = "Disconnected";
                    connected.ForeColor = Color.Red;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            ShowCarSegmentInformation();
            
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
        private void ShowCarSegmentInformation()
        {
            MySqlDataAdapter da;
            DataTable dt;
            openConnection();
            da = new MySqlDataAdapter("SELECT * FROM car_data", conn);
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }
        private void ShowCarSportInformation()
        {
            MySqlDataAdapter da;
            DataTable dt;
            openConnection();
            da = new MySqlDataAdapter("SELECT * FROM car_sport_data", conn);
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }
        private void ShowCarSuperInformation()
        {
            MySqlDataAdapter da;
            DataTable dt;
            openConnection();
            da = new MySqlDataAdapter("SELECT * FROM car_super_data", conn);
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }
        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void carSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSegmentInformation();
        }

        private void sportsCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSportInformation();
        }

        private void superCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSuperInformation();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[10].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);

            dataGridView1.CurrentRow.Selected = true;
            
            txtCarid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtModel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtColor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPlate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPirce.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDeposit.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;

            TimeSpan t = d2 -d1;
            double dDays = t.TotalDays;
            int days = Convert.ToInt32(dDays);

            textBox2.Text = days.ToString();

        }

        private void Count()
        {
            int days;
            int price;
            int deposit;
            double discount;

            days = Convert.ToInt32(textBox2.Text);
            price = Convert.ToInt32(txtPirce.Text);
            deposit = Convert.ToInt32(txtDeposit.Text);
            
        

            if (days >= 1 && days <= 6)
            {
                discount = (price * days) + deposit;
            }
            else if (days >= 7 && days <= 14)
            {
                discount = (((price * 98) / 100) * days) + deposit;
            }
            else if (days >= 15 && days <= 20)
            {
                discount = (((price * 96) / 100) * days) + deposit;
            }
            else
            {
                discount = (((price * 92) / 100) * days) + deposit;
            }
            label17.Text = days + " Day" + " + Deposit " + deposit + " Baht.\n" + "Total Price = " + discount.ToString() + " Baht.";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Count();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
