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
    public partial class Form21 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis;convert zero datetime=True");
        DataSet ds = new DataSet();

        public Form21()
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

        private void ShowCustomInformation()
        {
            openConnection();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM customer_data";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            closeConnection();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form21_Load(object sender, EventArgs e)
        {
            ShowCustomInformation();
        }
    }
}
