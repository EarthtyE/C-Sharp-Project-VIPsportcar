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
    public partial class Form19 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            ShowRentalCarInformation();
            searchData("");
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

        private void ShowRentalCarInformation()
        {
            MySqlDataAdapter da;
            DataTable dt;
            openConnection();
            da = new MySqlDataAdapter("SELECT * FROM rental_data", conn);
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }

        private void button4_Click(object sender, EventArgs e) //ปุ่มออก
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e) //ปุ่มรีเฟรช
        {
            this.Hide();
            Form19 f19 = new Form19();
            f19.ShowDialog();
        }

        //ทำช่องค้นหามีคำหลักให้การค้น
        //อย่าลืมไปใส่Poppoty
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Status, Username, CarID")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Status, Username, CarID";
                textBox1.ForeColor = Color.Silver;
            }
        }
        //สุด
        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM cartis.rental_data WHERE CONCAT(Status,Username,CarID) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[18].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            dataGridView1.CurrentRow.Selected = true;
            label6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string updataQuery = "UPDATE rental_data SET Status=@status WHERE CarID =@carid";
            conn.Open();

            MySqlCommand command = new MySqlCommand(updataQuery, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = comboBox1.Text;
            command.Parameters["@carid"].Value = label5.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Data Updated");
            }
            
            conn.Close();
        }
    }
}
