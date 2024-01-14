using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Management
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the username, password, and confirm password fields are empty
                if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text) || string.IsNullOrWhiteSpace(txtConform.Text))
                {
                    MessageBox.Show("Please fill all the required fields.");
                    return; // Exit the method without performing the insert
                }

                // Check if the password and confirm password fields match
                if (txtPass.Text != txtConform.Text)
                {
                    MessageBox.Show("Password and Confirm Password must match.");
                    return; // Exit the method without performing the insert
                }

                // Check if the Terms and Conditions checkbox is checked
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("Please check the Terms and Conditions box.");
                    return; // Exit the method without performing the insert
                }

                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";
                SqlConnection cn = new SqlConnection(connectionstring);

                string query = "insert into Registertable(UserName, Password, ConformPassword) values (@UserName, @Password, @ConformPassword)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                cmd.Parameters.AddWithValue("@ConformPassword", txtConform.Text);

                cmd.ExecuteNonQuery();

                cn.Close();

                MessageBox.Show("Registration Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void txtConform_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
