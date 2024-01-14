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
    public partial class UpdateDonor : Form
    {
        //UpdateDonor fn = new UpdateDonor();
        public UpdateDonor()
        {
            InitializeComponent();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtCity.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the username, password, and confirm password fields are empty
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtFather.Text) || string.IsNullOrWhiteSpace(txtMother.Text)
                    || string.IsNullOrWhiteSpace(txtDOB.Text) || string.IsNullOrWhiteSpace(txtMobile.Text)
                    || string.IsNullOrWhiteSpace(txtGender.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtBlood.Text)
                    || string.IsNullOrWhiteSpace(txtCity.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    MessageBox.Show("Please fill all the required fields.");
                    return; // Exit the method without performing the insert
                }


                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";
                SqlConnection cn = new SqlConnection(connectionstring);

                string query = "UPDATE AddNewDonor SET Name = @Name, FatherName = @FatherName, MotherName = @MotherName, DOB = @DOB, Mobile = @Mobile, Gender = @Gender, Email = @Email, BloodGroup = @BloodGroup, City = @City, Address = @Address WHERE  Name = @Name";

                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtFather.Text);
                cmd.Parameters.AddWithValue("@MotherName", txtMother.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@BloodGroup", txtBlood.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                cmd.ExecuteNonQuery();

                cn.Close();

                MessageBox.Show("Donor Updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the Donor ID field is empty
                if (string.IsNullOrWhiteSpace(txtDonorID.Text))
                {
                    MessageBox.Show("Please enter a Donor ID to search.");
                    return;
                }

                int id;
                if (!int.TryParse(txtDonorID.Text, out id))
                {
                    MessageBox.Show("Please enter a valid numeric Donor ID.");
                    return;
                }
                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                // Create a connection to the database
                using (SqlConnection cn = new SqlConnection(connectionstring))
                {
                    cn.Open();

                    // Define the SQL query to select data based on the ID
                    string query = "SELECT * FROM AddNewDonor WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Create a data adapter to fill a dataset with the results
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    // Check if any rows were returned
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // Populate the fields with the fetched data
                        DataRow row = ds.Tables[0].Rows[0];
                        txtName.Text = row["Name"].ToString();
                        txtFather.Text = row["FatherName"].ToString();
                        txtMother.Text = row["MotherName"].ToString();
                        txtDOB.Text = row["DOB"].ToString();
                        txtMobile.Text = row["Mobile"].ToString();
                        txtGender.Text = row["Gender"].ToString();
                        txtEmail.Text = row["Email"].ToString();
                        txtBlood.Text = row["BloodGroup"].ToString();
                        txtCity.Text = row["City"].ToString();
                        txtAddress.Text = row["Address"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No records found for the given Donor ID.");
                       // ClearFields();
                    }

                    // Close the connection
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtDonorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDonor_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
