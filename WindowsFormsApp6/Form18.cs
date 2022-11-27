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
    public partial class Form18 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public Form18()
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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Enabled = true;
                label2.Enabled = true;
                dateTimePicker1.Enabled = true;
                pictureBox1.Enabled = true;
            }
            else if (radioButton1.Checked == false)
            {
                button1.Enabled = false;
                label2.Enabled = false;
                dateTimePicker1.Enabled = false;
                pictureBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //โหลดสลิป
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            
            string updataQuery = "UPDATE rental_data SET Payment_Method=@payment_method, Time_Payment=@time_payment, Photo_T_P=@photo_t_p WHERE CarID=@carid";
            conn.Open();

            MySqlCommand command = new MySqlCommand(updataQuery, conn);*/
            if (dateTimePicker1.Text == "" )
            {
                MessageBox.Show("Please complete all fields.");
            }
            else
            {
                try
                {
                    if (radioButton1.Checked)
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();

                        string updataQuery = "UPDATE rental_data SET Status=@status, Payment_Method=@payment_method, Time_Payment=@time_payment, Photo_T_P=@photo_t_p WHERE CarID=@carid";
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(updataQuery, conn);

                        command.Parameters.Add("@carid", MySqlDbType.VarChar);
                        command.Parameters.Add("@status", MySqlDbType.VarChar);
                        command.Parameters.Add("@payment_method", MySqlDbType.VarChar);
                        command.Parameters.Add("@time_payment", MySqlDbType.VarChar);
                        command.Parameters.Add("@photo_t_p", MySqlDbType.LongBlob);

                        command.Parameters["@carid"].Value = label4.Text;
                        command.Parameters["@status"].Value = "Paid";
                        command.Parameters["@payment_method"].Value = radioButton1.Text;
                        command.Parameters["@time_payment"].Value = dateTimePicker1.Text;
                        command.Parameters["@photo_t_p"].Value = img;

                        if (command.ExecuteNonQuery() >= 1)
                        {
                            MessageBox.Show("You have paid for the rental car.");
                            this.Hide();
                        }

                        conn.Close();
                    }
                    else if (radioButton2.Checked)
                    {
                        string updataQuery = "UPDATE rental_data SET Status=@status, Payment_Method=@payment_method, Time_Payment=@time_payment, Photo_T_P=@photo_t_p WHERE CarID=@carid";
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(updataQuery, conn);

                        command.Parameters.Add("@carid", MySqlDbType.VarChar);
                        command.Parameters.Add("@status", MySqlDbType.VarChar);
                        command.Parameters.Add("@payment_method", MySqlDbType.VarChar);
                        command.Parameters.Add("@time_payment", MySqlDbType.VarChar);
                        command.Parameters.Add("@photo_t_p", MySqlDbType.VarChar);

                        command.Parameters["@carid"].Value = label4.Text;
                        command.Parameters["@status"].Value = "Unpaid";
                        command.Parameters["@payment_method"].Value = "Service center";
                        command.Parameters["@time_payment"].Value = "-";
                        command.Parameters["@photo_t_p"].Value = "-";

                        if (command.ExecuteNonQuery() >= 1)
                        {
                            MessageBox.Show("Pay at the company.");
                            this.Hide();
                            
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
                /*
            if (radioButton1.Checked)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                string updataQuery = "UPDATE rental_data SET Payment_Method=@payment_method, Time_Payment=@time_payment, Photo_T_P=@photo_t_p WHERE CarID=@carid";
                conn.Open();

                MySqlCommand command = new MySqlCommand(updataQuery, conn);

                command.Parameters.Add("@carid", MySqlDbType.VarChar);
                command.Parameters.Add("@payment_method", MySqlDbType.VarChar);
                command.Parameters.Add("@time_payment", MySqlDbType.VarChar);
                command.Parameters.Add("@photo_t_p", MySqlDbType.LongBlob);

                command.Parameters["@carid"].Value = label4.Text;
                command.Parameters["@payment_method"].Value = radioButton1.Text;
                command.Parameters["@time_payment"].Value = dateTimePicker1.Text;
                command.Parameters["@photo_t_p"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Updated");
                }

                conn.Close();
                
            }
            else if (radioButton2.Checked)
            {
                string updataQuery = "UPDATE rental_data SET Payment_Method=@payment_method, Time_Payment=@time_payment, Photo_T_P=@photo_t_p WHERE CarID=@carid";
                conn.Open();

                MySqlCommand command = new MySqlCommand(updataQuery, conn);

                command.Parameters.Add("@carid", MySqlDbType.VarChar);
                command.Parameters.Add("@payment_method", MySqlDbType.VarChar);
                command.Parameters.Add("@time_payment", MySqlDbType.VarChar);
                command.Parameters.Add("@photo_t_p", MySqlDbType.VarChar);

                command.Parameters["@carid"].Value = label4.Text;
                command.Parameters["@payment_method"].Value = "Service center";
                command.Parameters["@time_payment"].Value = "-";
                command.Parameters["@photo_t_p"].Value = "-";

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Updated");
                }

                conn.Close();
                
            }
            /*
            command.Parameters.Add("@payment_method", MySqlDbType.VarChar);
            command.Parameters.Add("@time_payment", MySqlDbType.VarChar);
            command.Parameters.Add("@photo_t_p", MySqlDbType.LongBlob);

            command.Parameters["@payment_method"].Value = .Text;
            command.Parameters["@time_payment"].Value = comboBox1.Text;
            command.Parameters["@photo_t_p"].Value = img;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Updated");
            }

            conn.Close();
            */
            
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            label3.Text = Program.message;
            label4.Text = Program.CarID;
        }
    }
}
