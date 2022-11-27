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
using System.Text.RegularExpressions;

namespace WindowsFormsApp6
{
    public partial class Form13 : Form
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public Form13()
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Please complete all fields.");
            }
            else
            {
                try
                {
                    if (this.textBox9.Text != this.textBox10.Text)
                    {
                        MessageBox.Show("The password does not match the confirmation password.");
                    }
                    else
                    {
                        try
                        {
                            Regex r = new Regex(@"^[0-9]{10}$");
                            if (r.IsMatch(textBox7.Text))
                            {
                                try
                                {
                                    Regex r2 = new Regex(@"^[0-9]{13}$");
                                    if (r2.IsMatch(textBox4.Text))
                                    {
                                        try
                                        {
                                            Regex r3 = new Regex(@"^[0-9]{8}$");
                                            if (r3.IsMatch(textBox5.Text))
                                            {

                                                try
                                                {
                                                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                                                    if (Regex.IsMatch(textBox8.Text, pattern))
                                                    {
                                                        errorProvider1.Clear();

                                                        string insert_data_customer = "INSERT INTO cartis.customer_data(Username,Firstname,Surname,IDcard,Driverslicence,Birthate,Sex,County,Phone,Email,Password) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "')";
                                                        executeQuery(insert_data_customer);
                                                        this.Hide();
                                                    }
                                                    else
                                                    {
                                                        errorProvider1.SetError(this.textBox8, "Please provide valid Email address");
                                                        MessageBox.Show("Please provide valid Email address");
                                                        return;

                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please enter a valid 8 digit driver's license number.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please enter a valid 13 digit ID card number.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid 10 digit phone number.");
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }


        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        private void textBox8_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(textBox8.Text, pattern))
            {
                errorProvider1.Clear();
            }
            else
            {

                errorProvider1.SetError(this.textBox8, "Please provide valid Email address");
                MessageBox.Show("Please provide valid Email address");
                return;
            }
        }
        private void Form13_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
