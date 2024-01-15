using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace Blood_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please check the Terms and Conditions box.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Registertable WHERE UserName = @UserName AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                    int count = (int)cmd.ExecuteScalar();
                    if (count != 1)
                    {
                        MessageBox.Show("Incorrect UserName or Password!");
                    }
                    else
                    {
                        // Authentication successful, open the Dashboard form
                        Dashboard dashboardForm = new Dashboard();
                        dashboardForm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill the required fields!");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
