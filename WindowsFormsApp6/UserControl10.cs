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
    public partial class UserControl10 : UserControl
    {

        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();

        public UserControl10()
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

        private void UserControl10_Load(object sender, EventArgs e)
        {
            Userlabel.Text = Program.message;
            ShowRentalCarInformation();
            HisData1Me(Userlabel.Text);

            Profile();
        }
        public void HisData1Me(string valueToFind) //เรียกดาต้าตามUser
        {
            string hisQuery = "SELECT * FROM cartis.rental_data WHERE CONCAT(Username) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(hisQuery, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public void Profile()
        {
            string ConString = "SELECT * FROM cartis.customer_data WHERE Username = '" + Userlabel.Text + "' ";
            
            MySqlCommand command = new MySqlCommand(ConString, conn);
            try
            {
                openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    IDlabel.Text = reader.GetValue(0).ToString();
                    Userlabel.Text = reader.GetValue(1).ToString();
                    Namelabel.Text = reader.GetValue(2).ToString();
                    SurNlabel.Text = reader.GetValue(3).ToString();
                    IDClabel.Text = reader.GetValue(4).ToString();
                    DVLlabel.Text = reader.GetValue(5).ToString();
                    Phonelabel.Text = reader.GetValue(10).ToString();
                    Addrlabel.Text = reader.GetValue(9).ToString();

                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        public void cancelRented_Gene()
        {
            string updata_status_car = "UPDATE car_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Ready";
            command.Parameters["@carid"].Value = label2.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Ready");
                this.Hide();
            }

            closeConnection();
        }
        public void cancelRented_Sopo()
        {
            string updata_status_car = "UPDATE car_sport_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Ready";
            command.Parameters["@carid"].Value = label2.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Ready");
                this.Hide();
            }

            closeConnection();
        }
        public void cancelRented_Super()
        {
            string updata_status_car = "UPDATE car_super_data SET Status=@status WHERE CarID =@carid";
            openConnection();

            MySqlCommand command = new MySqlCommand(updata_status_car, conn);


            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Ready";
            command.Parameters["@carid"].Value = label2.Text;


            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Ready");
                this.Hide();
            }

            closeConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string updataQuery = "UPDATE rental_data SET Status=@status WHERE CarID =@carid";
            conn.Open();

            MySqlCommand command = new MySqlCommand(updataQuery, conn);
  
            command.Parameters.Add("@status", MySqlDbType.VarChar);
            command.Parameters.Add("@carid", MySqlDbType.VarChar);

            command.Parameters["@status"].Value = "Cancel reservation";      //เปลี่ยนสถานะ
            command.Parameters["@carid"].Value = label2.Text;

            if (command.ExecuteNonQuery() >= 1)
            {
                MessageBox.Show("Canceled successfully");
                HisData1Me(Userlabel.Text);
            }

            conn.Close();

            if (label3.Text == "Geeneral Car")
            {
                cancelRented_Gene();
            }
            else if (label3.Text == "Sports Car")
            {
                cancelRented_Sopo();
            }
            else if (label3.Text == "Super Car")
            {
                cancelRented_Super();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HisData1Me(Userlabel.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            label3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Statuslabel.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            IDRlabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Brandlabel.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Modellabel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            Colorlabel.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            NPlabel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            Datelabel.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            DueDatelabel.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            Pircelabel.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();

            if (Statuslabel.Text == "Cancel reservation")
            {
                button2.Enabled = false;
            }
            else if (Statuslabel.Text == "Paid")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }


            if (Statuslabel.Text == "Cancel reservation")
            {
                button5.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form18 frm18 = new Form18();
            Program.message = Userlabel.Text;
            Program.CarID = label2.Text;
            frm18.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("VIPsportcar", new Font("supermarket", 24, FontStyle.Bold), Brushes.Black, new Point(40, 50));
            e.Graphics.DrawString("ใบแจ้งยอดการชำระค่าเช่ารถ", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(40, 90));
            e.Graphics.DrawString("Car rental payment statement", new Font("supermarket", 16, FontStyle.Bold), Brushes.Black, new Point(40, 120));
            e.Graphics.DrawString("พิมพ์เมื่อ " + System.DateTime.Now.ToString("dd/MM/yyyy HH : mm : ss น."), new Font("FC Lamoon", 18, FontStyle.Regular), Brushes.Black, new PointF(500, 170));
            e.Graphics.DrawString("ข้อมูลร้าน : VIPsportcar.Thailand", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(40, 170));
            e.Graphics.DrawString("VIPsportcar  เลขที่ 899/39  หมู่ 16 ถนนมิตรภาพ", new Font("supermarket", 10, FontStyle.Regular), Brushes.Black, new Point(143, 205));
            e.Graphics.DrawString("ตำบลในเมือง อำเภอเมืองขอนแก่น จังหวัดขอนแก่น 40002", new Font("supermarket", 10, FontStyle.Regular), Brushes.Black, new Point(143, 225));

            e.Graphics.DrawString("Tenant Information", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 280));

            e.Graphics.DrawString("========================================================", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 310));
            e.Graphics.DrawString("ID       Name        Surname         ID Card         Drivers licens      Phone ", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(82, 330));
            e.Graphics.DrawString("========================================================", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 350));
            e.Graphics.DrawString(IDlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(84, 380));
            e.Graphics.DrawString(Namelabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(149, 380));
            e.Graphics.DrawString(SurNlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(256, 380));
            e.Graphics.DrawString(IDClabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(380, 380));
            e.Graphics.DrawString(DVLlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(550, 380));
            e.Graphics.DrawString(Phonelabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(680, 380));

            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 420));

            e.Graphics.DrawString("Car Rental Information", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 450));
            e.Graphics.DrawString("========================================================", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 480));
            e.Graphics.DrawString("Car ID   Brand        Model          Color     N.B Plate    Price    Deposit ", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(82, 500));
            e.Graphics.DrawString("========================================================", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 520));
            e.Graphics.DrawString(label2.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(84, 550));
            e.Graphics.DrawString(Brandlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(165, 550));
            e.Graphics.DrawString(Modellabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(271, 550));
            e.Graphics.DrawString(Colorlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(394, 550));
            e.Graphics.DrawString(NPlabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(476, 550));
            e.Graphics.DrawString(Modellabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(593, 550));
            e.Graphics.DrawString(Modellabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(668, 550));

            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 580));
            e.Graphics.DrawString("Date : " + Datelabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(80, 600));
            e.Graphics.DrawString("Due Date : " + DueDatelabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(270, 600));
           
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 610));
            e.Graphics.DrawString(Pircelabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(500, 650));
            e.Graphics.DrawString("Payment status :: " + Statuslabel.Text, new Font("supermarket", 12, FontStyle.Regular), Brushes.Black, new Point(500, 680));

            e.Graphics.DrawString("--------------------------------------------------------------------------------------------------", new Font("supermarket", 16, FontStyle.Regular), Brushes.Black, new Point(50, 710));
          
        }
    }
        

}
