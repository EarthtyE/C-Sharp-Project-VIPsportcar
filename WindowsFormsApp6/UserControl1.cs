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
    public partial class UserControl1 : UserControl
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public UserControl1()
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
            da = new MySqlDataAdapter("SELECT * FROM car_data", conn);
            dt = new DataTable();
            da.Fill(dt);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            closeConnection();
        }
        


        private void UserControl1_Load(object sender, EventArgs e)
        {
            ShowCarSegmentInformation();
        }
        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            byte[] img = (byte[])dataGridView1.CurrentRow.Cells[10].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);

            dataGridView1.CurrentRow.Selected = true;
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtCarid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtModel.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtColor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPlate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtHis.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDepos.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }
        public void executeQuery(String query)
        {
            //ดัก Error
            try
            {
                openConnection();
                MySqlCommand command = new MySqlCommand(query, conn);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Save data successfully");
                }
                else
                {
                    MessageBox.Show("Failed to save data");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceed error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                closeConnection();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox3.Text == "" || txtCarid.Text == "" || comboBox1.Text == "" || txtBrand.Text == "" || txtModel.Text == "" || txtColor.Text == "" || txtPlate.Text == "" || txtHis.Text == "" || txtPrice.Text == "" || txtDepos.Text == "")
            {
                MessageBox.Show("Please complete all fields.");
            }
            else
            {

                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] img = ms.ToArray();

                string insertQuery = "INSERT INTO cartis.car_data(CarID, Status, Brand, CarModel, Color, NumberPlate, Type, History, Pirce, Deposit, Image) VALUES (@carid,@status,@brand,@carmodel,@color,@nbplate,@type,@his,@pirce,@depos,@image)";
                conn.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, conn);


                command.Parameters.Add("@carid", MySqlDbType.VarChar);
                command.Parameters.Add("@status", MySqlDbType.VarChar);
                command.Parameters.Add("@brand", MySqlDbType.VarChar);
                command.Parameters.Add("@carmodel", MySqlDbType.VarChar);
                command.Parameters.Add("@color", MySqlDbType.VarChar);
                command.Parameters.Add("@nbplate", MySqlDbType.VarChar);
                command.Parameters.Add("@type", MySqlDbType.VarChar);
                command.Parameters.Add("@his", MySqlDbType.Text);
                command.Parameters.Add("@pirce", MySqlDbType.Int32);
                command.Parameters.Add("@depos", MySqlDbType.Int32);
                command.Parameters.Add("@image", MySqlDbType.LongBlob);

                command.Parameters["@carid"].Value = txtCarid.Text;
                command.Parameters["@status"].Value = comboBox1.Text;
                command.Parameters["@brand"].Value = txtBrand.Text;
                command.Parameters["@carmodel"].Value = txtModel.Text;
                command.Parameters["@color"].Value = txtColor.Text;
                command.Parameters["@nbplate"].Value = txtPlate.Text;
                command.Parameters["@type"].Value = textBox3.Text;
                command.Parameters["@his"].Value = txtHis.Text;
                command.Parameters["@pirce"].Value = txtPrice.Text;
                command.Parameters["@depos"].Value = txtDepos.Text;
                command.Parameters["@image"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data inserted");
                }

                conn.Close();
           

            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtDepos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txtCarid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        public void FillDGV()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM car_data", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();

            string updataQuery = "UPDATE car_data SET CarID=@carid, Status=@status, Brand=@brand, CarModel=@carmodel, Color=@color, NumberPlate=@nbplate, Type=@type, History=@his, Pirce=@pirce, Deposit=@depos, Image=@image WHERE Carid=@carid";
            conn.Open();

            MySqlCommand command = new MySqlCommand(updataQuery, conn);


            command.Parameters.Add("@carid", MySqlDbType.VarChar);
            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@brand", MySqlDbType.VarChar);
            command.Parameters.Add("@carmodel", MySqlDbType.VarChar);
            command.Parameters.Add("@color", MySqlDbType.VarChar);
            command.Parameters.Add("@nbplate", MySqlDbType.VarChar);
            command.Parameters.Add("@type", MySqlDbType.VarChar);
            command.Parameters.Add("@his", MySqlDbType.Text);
            command.Parameters.Add("@pirce", MySqlDbType.Int32);
            command.Parameters.Add("@depos", MySqlDbType.Int32);
            command.Parameters.Add("@image", MySqlDbType.LongBlob);

            command.Parameters["@carid"].Value = txtCarid.Text;
            command.Parameters["@status"].Value = comboBox1.Text;
            command.Parameters["@brand"].Value = txtBrand.Text;
            command.Parameters["@carmodel"].Value = txtModel.Text;
            command.Parameters["@color"].Value = txtColor.Text;
            command.Parameters["@nbplate"].Value = txtPlate.Text;
            command.Parameters["@type"].Value = textBox3.Text;
            command.Parameters["@his"].Value = txtHis.Text;
            command.Parameters["@pirce"].Value = txtPrice.Text;
            command.Parameters["@depos"].Value = txtDepos.Text;
            command.Parameters["@image"].Value = img;


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Updated");
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM car_data WHERE Carid=@carid";
            conn.Open();

            MySqlCommand command = new MySqlCommand(deleteQuery, conn);

            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@carid"].Value = txtCarid.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Deleted");
            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

