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
    public partial class Form8 : Form
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis;convert zero datetime=True");
        DataSet ds = new DataSet();

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ShowCustomInformation();
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

        public void executeQuery(String query)
        {

            try
            {
                openConnection();
                MySqlCommand command = new MySqlCommand(query, conn);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Update data successfully");


                }
                else
                {
                    MessageBox.Show("Failed to Update data");
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
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox11.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "")
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

                                                        string update_data_customer = "UPDATE cartis.customer_data SET Username='" + textBox2.Text + "', Firstname='" + textBox11.Text + "', Surname='" + textBox3.Text + "',IDcard='" + textBox4.Text + "',Driverslicence='" + textBox5.Text + "', Birthate='" + dateTimePicker1.Text + "',Sex='" + comboBox1.Text + "',County='" + textBox6.Text + "',Phone='" + textBox7.Text + "',Email='" + textBox8.Text + "',Password='" + textBox10.Text + "' WHERE Username='" + textBox2.Text + "'";
                                                        executeQuery(update_data_customer);
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
        //ข้างบนคือกรอกได้แค่ตัวเลข
        //ข้างล่างนี่คือกรอกได้เฉพาะอิ้ง
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
                MessageBox.Show("Please fill out the information in English.");
            }
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}