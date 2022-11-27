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
    public partial class Form15 : Form
    {
        MySqlConnection conn = new MySqlConnection("host=localhost;port=3306;username=root;password=;database=cartis");
        DataSet ds = new DataSet();
        public Form15()
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
            string delete_data_customer = "DELETE FROM cartis.customer_data WHERE ID= '" + textBox1.Text + "' ";
            executeQuery(delete_data_customer);
            this.Hide();
        }
    }
}
