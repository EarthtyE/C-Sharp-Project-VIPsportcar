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
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp6
{
    public partial class Form10 : Form
    {

        string OTPCode;
        public static string to;
        public Form10()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            OTPCode = (rand.Next(999999).ToString());

            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "drg";
            pass = "rgsg";
            messageBody = "your reset code is " + OTPCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            messageBody = message.Body;
            message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from,pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("code send successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OTPCode == (textBox2.Text).ToString())
            {
                to = textBox1.Text;
                Form11 f1 = new Form11();
                this.Hide();
                f1.Show();

            }
            else
            {
                MessageBox.Show("Wrong code");
            }
            
        }
    }
}
