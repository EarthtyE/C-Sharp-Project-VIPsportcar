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
    public partial class UserControl8 : UserControl
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public UserControl8()
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

        private void UserControl8_Load(object sender, EventArgs e)
        {
            label13.Text = Program.message;

            searchData1("");
            searchData2("");
            searchData3("");

            ShowCarSegmentInformation();
            label23.Text = "Geeneral Car";
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

        private void carSegmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSegmentInformation();
            label23.Text = "Geeneral Car";
        }

        private void sportsCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSportInformation();
            label23.Text = "Sports Car";
        }

        private void superCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCarSuperInformation();
            label23.Text = "Super Car";
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

            if (txtStatus.Text == "Rented")
            {
                MessageBox.Show("This car has been rented Please select a new car.");
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            DateTime d2 = dateTimePicker2.Value;

            TimeSpan t = d2 - d1;
            double dDays = t.TotalDays;
            int days = Convert.ToInt32(dDays);

            textBox2.Text = days.ToString();
        }

        private void Count()
        {
            try
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
                //label21.Text = days + " Day" + " + Deposit " + deposit + " Baht.\n" + "Total Price = " + discount.ToString() + " Baht.";
                label21.Text = days + " Day" + " + Deposit " + deposit + " Baht.";
                label22.Text = "Total Price = " + discount.ToString() + " Baht.";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceed error\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

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

        public void carGstatus()
        {
            string updata_status_car = "UPDATE car_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Rented";
            command.Parameters["@carid"].Value = txtCarid.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Rented");
                this.Hide();
            }

            closeConnection();
        }
        public void carSpstatus()
        {
            string updata_status_car = "UPDATE car_sport_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Rented";
            command.Parameters["@carid"].Value = txtCarid.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Rented");
                this.Hide();
            }

            closeConnection();
        }

        public void checkDate_Duedate()
        {
            MySqlCommand command = new MySqlCommand("SELECT '");
        }

        public void carSustatus()
        {
            string updata_status_car = "UPDATE car_super_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Rented";
            command.Parameters["@carid"].Value = txtCarid.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Rented");
                this.Hide();
            }

            closeConnection();
        }

        public string ID
        {
            get { return label13.Text; }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM rental_data WHERE Status =" + dataGridView1.Rows,conn);          //ทำให้เช่าได้แค่1คันต่อคน
            adapter.Fill(ds,"CommiteeReq");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("เอาเรื่อง");
            }
            else
            {
                MessageBox.Show("อีหยังว่ะ");
            }

            MessageBox.Show("Confirm ?");
            */

            string insert_data_rental = "INSERT INTO cartis.rental_data(Status,Username,Type,CarID,Brand,CarModel,Color,NumberPlate,Date,DueDate,Day,Pirce,Deposit,Payment,Total_pay) VALUES('" + "Waiting for payment" + "','" + label13.Text + "','" + label23.Text + "','" + txtCarid.Text + "','" + txtBrand.Text + "','" + txtModel.Text + "','" + txtColor.Text + "','" + txtPlate.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox2.Text + "','" + txtPirce.Text + "','" + txtDeposit.Text + "','" + label21.Text + "','" + label22.Text + "')";
            executeQuery(insert_data_rental);


            if (label23.Text == "Geeneral Car")
            {
                carGstatus();
            }
            else if (label23.Text == "Sports Car")
            {
                carSpstatus();
            }
            else if (label23.Text == "Super Car")
            {
                carSustatus();
            }




        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button2.Enabled = true;
            }
            else if (checkBox1.Checked == false)
            {
                button2.Enabled = false;
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        public void searchData1(string valueToFind)
        {
            string searchQuery = "SELECT * FROM cartis.car_data WHERE CONCAT(Brand,CarModel,Color) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void searchData2(string valueToFind)
        {
            string searchQuery2 = "SELECT * FROM cartis.car_sport_data WHERE CONCAT(Brand,CarModel,Color) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery2, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public void searchData3(string valueToFind)
        {
            string searchQuery3 = "SELECT * FROM cartis.car_super_data WHERE CONCAT(Brand,CarModel,Color) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(searchQuery3, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (label23.Text == "Geeneral Car")
            {
                searchData1(textBox1.Text);

            }
            else if (label23.Text == "Sports Car")
            {
                searchData2(textBox1.Text);
            }
            else if (label23.Text == "Super Car")
            {

                searchData3(textBox1.Text);
            }

        }

        //ทำช่องค้นหามีคำหลักให้การค้น
        //อย่าลืมไปใส่Poppoty
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Brand, Model, Color")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Brand, Model, Color";
                textBox1.ForeColor = Color.Silver;
            }
        }
        //สุด

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void typeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //private List<Class1> allbook = new List<Class1>();



        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Rented")
            {
                MessageBox.Show("This car has been rented Please select a new car.");
            }
            else
            {
                Count();
            }
            //Count();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Rented")
            {
                MessageBox.Show("This car has been rented Please select a new car.");
            }
            else
            {
                Count();
            }
        }

    }
    
}
