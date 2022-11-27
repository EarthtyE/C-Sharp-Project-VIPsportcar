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
    public partial class Form20 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public Form20()
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
        private void ShowCarSegmentInformation()
        {
            MySqlDataAdapter da;
            DataTable dt;
            openConnection();
            da = new MySqlDataAdapter("SELECT Type,Status,CarID,Brand,CarModel,Color,NumberPlate,Image FROM car_data", conn);
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
            da = new MySqlDataAdapter("SELECT Type,Status,CarID,Brand,CarModel,Color,NumberPlate,Image FROM car_sport_data", conn);
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
            da = new MySqlDataAdapter("SELECT Type,Status,CarID,Brand,CarModel,Color,NumberPlate,Image FROM car_super_data", conn); 
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }
        private void Form20_Load(object sender, EventArgs e)
        {
            Status_combo();
        }
        public void Status_combo() //combo1
        {
            comboBox1.Items.Add("Ready");
            comboBox1.Items.Add("Rented");

        }

        public void General_Car()
        {
            comboBox2.Items.Add("NISSAN");
            comboBox2.Items.Add("TOYOTA");
            comboBox2.Items.Add("ISUZU");

            comboBox3.Items.Add("NISSAN");
            comboBox3.Items.Add("TOYOTA");
            comboBox3.Items.Add("ISUZU");
        }
        public void Sport_Car()
        {
            comboBox2.Items.Add("Mercedes-Benz");
            comboBox2.Items.Add("BMW");
            comboBox2.Items.Add("Subaru");
        }
        public void Super_Car()
        {
            comboBox2.Items.Add("Lamborghini");
            comboBox2.Items.Add("Ferrari");
            comboBox2.Items.Add("NISSAN");
        }
       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowCarSegmentInformation();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            General_Car();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ShowCarSportInformation();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            Sport_Car();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowCarSuperInformation();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            Super_Car();
        }
    }
}
