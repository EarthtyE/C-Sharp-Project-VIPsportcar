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
    public partial class Form6 : Form
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis;convert zero datetime=True");
        DataSet ds = new DataSet();
        
        public Form6()
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
        private void ShowEmployeeInformation()
        {
            
            openConnection();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM employee_data";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            closeConnection();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();


        }
        private void Form6_Load(object sender, EventArgs e)
        {
            ShowEmployeeInformation();
            searchData("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form9 frm5 = new Form9();
            frm5.Show();
        }

        public void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM cartis.employee_data WHERE CONCAT(ID,Firstname,Surname) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e) //ปุ่ม Upgrade
        {
            /*
            string update_data_empolyee = "UPDATE cartis.employee_data SET Firstname='" + textBox11.Text + "', Surname='" + textBox3.Text + "',IDcard='" + textBox4.Text + "',Driverslicence='" + textBox5.Text + "', Birthate='" + dateTimePicker1.Text + "',Sex='" + comboBox1.Text + "',County='" + textBox6.Text + "',Phone='" + textBox7.Text + "',Email='" + textBox8.Text + "',Password='" + textBox10.Text + "' WHERE ID='" + textBox2.Text +"'";
            executeQuery(update_data_empolyee);
            */
            if (textBox11.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || dateTimePicker1.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox10.Text == "")
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

                                                        string update_data_empolyee = "UPDATE cartis.employee_data SET Firstname='" + textBox11.Text + "', Surname='" + textBox3.Text + "',IDcard='" + textBox4.Text + "',Driverslicence='" + textBox5.Text + "', Birthate='" + dateTimePicker1.Text + "',Sex='" + comboBox1.Text + "',County='" + textBox6.Text + "',Phone='" + textBox7.Text + "',Email='" + textBox8.Text + "',Password='" + textBox10.Text + "' WHERE ID='" + textBox2.Text + "'";
                                                        executeQuery(update_data_empolyee);
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
                                                /*
                                                string update_data_empolyee = "UPDATE cartis.employee_data SET Firstname='" + textBox11.Text + "', Surname='" + textBox3.Text + "',IDcard='" + textBox4.Text + "',Driverslicence='" + textBox5.Text + "', Birthate='" + dateTimePicker1.Text + "',Sex='" + comboBox1.Text + "',County='" + textBox6.Text + "',Phone='" + textBox7.Text + "',Email='" + textBox8.Text + "',Password='" + textBox10.Text + "' WHERE ID='" + textBox2.Text + "'";
                                                executeQuery(update_data_empolyee);
                                                */
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }


        //ทำช่องค้นหามีคำหลักให้การค้น
                //อย่าลืมไปใส่Poppoty
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID, Firstname, Surname")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ID, Firstname, Surname";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        //สุด
    }
}