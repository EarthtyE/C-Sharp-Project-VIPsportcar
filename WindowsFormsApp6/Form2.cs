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
using System.IO;


namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //กลับไปหน้า Sing in
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e) //BTN Register
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

                                                string insert_data_customer = "INSERT INTO cartis.customer_data(Username,Firstname,Surname,IDcard,Driverslicence,card,Birthate,Sex,County,Phone,Email,Password,Photo_Doc_IDC,Photo_Doc_Driv,Photo_Doc_card) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox11.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "',@photo_doc_idc, @photo_doc_driv, @photo_doc_card)";
                                                conn.Open();
                                                MySqlCommand command = new MySqlCommand(insert_data_customer, conn);

                                                MemoryStream ms = new MemoryStream();
                                                pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
                                                byte[] img = ms.ToArray();

                                                pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
                                                byte[] img2 = ms.ToArray();

                                                pictureBox5.Image.Save(ms, pictureBox5.Image.RawFormat);
                                                byte[] img3 = ms.ToArray();

                                                command.Parameters.Add("@photo_doc_idc", MySqlDbType.LongBlob);
                                                command.Parameters.Add("@photo_doc_driv", MySqlDbType.LongBlob);
                                                command.Parameters.Add("@photo_doc_card", MySqlDbType.LongBlob);

                                                command.Parameters["@photo_doc_idc"].Value = img;
                                                command.Parameters["@photo_doc_driv"].Value = img2;
                                                command.Parameters["@photo_doc_card"].Value = img3;
                                                
                                                try
                                                {
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
                                                    conn.Close();
                                                    this.Hide();
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show("Please enter a valid Drivers license number.");
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please enter a valid ID card number.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid phone number.");
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e) // กรอกได้แค่ตตัวเลขสำหรับช่องกรองเลขบัตรต่างๆ เบอร์โทร
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
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox8_Leave(object sender, EventArgs e) //เช็คแพทดทิ้ลเมล
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e) 
        {

            if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                button1.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox11.Enabled = true;
                button4.Enabled = true;
            }
            else if (radioButton1.Checked == false)
            {
                textBox11.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                
                button4.Enabled = true;
            }
            else if (radioButton1.Checked == false)
            {
                textBox11.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                textBox11.Enabled = true;
                button4.Enabled = true;
            }
            else if (radioButton1.Checked == false)
            {
                textBox11.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                label17.Text = opf.FileName;
                pictureBox3.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                label18.Text = opf.FileName;
                pictureBox4.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                label19.Text = opf.FileName;
                pictureBox5.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
