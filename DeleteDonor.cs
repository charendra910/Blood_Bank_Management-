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
    public partial class DeleteDonor : Form
    {
        public DeleteDonor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        
                    }

                 
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDonorID.Text))
                {
                    MessageBox.Show("Please enter a Donor ID to delete.");
                    return;
                }

                int id;
                if (!int.TryParse(txtDonorID.Text, out id))
                {
                    MessageBox.Show("Please enter a valid numeric Donor ID.");
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                    using (SqlConnection cn = new SqlConnection(connectionstring))
                    {
                        cn.Open();

                        // Define the SQL query to delete the record based on the ID
                        string query = "DELETE FROM AddNewDonor WHERE ID = @ID";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");
                            // Clear the fields
                            txtName.Clear();
                            txtFather.Clear();
                            txtMother.Clear();
                            txtDOB.Value = DateTime.Now; // Reset the Date of Birth
                            txtMobile.Clear();
                            txtGender.SelectedIndex = -1; // Clear Gender selection
                            txtEmail.Clear();
                            txtBlood.SelectedIndex = -1; // Clear Blood Group selection
                            txtCity.Clear();
                            txtAddress.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No records found for the given Donor ID.");
                        }

                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
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

        private void DeleteDonor_Load(object sender, EventArgs e)
        {

        }

        private void txtGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMother_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFather_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDonorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBlood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
