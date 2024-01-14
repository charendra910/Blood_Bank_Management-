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
    public partial class StockIncrease : Form
    {
        public StockIncrease()
        {
            InitializeComponent();
        }

        private void StockIncrease_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                using (SqlConnection cn = new SqlConnection(connectionstring))
                {
                    cn.Open();

                    // Define the SQL query to select BloodGroup and Quantity from BloodQuantity table
                    string query = "SELECT BloodGroup, Quantity FROM BloodQuantity";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
        private void PopulateDataGridView()
        {
            try
            {
                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                // Create a connection to the database
                using (SqlConnection cn = new SqlConnection(connectionstring))
                {
                    cn.Open();

                    // Define the SQL query to select all records from the AddNewDonor table
                    string query = "SELECT BloodGroup , Quantity FROM BloodQuantity";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Create a data adapter to fill a DataTable with the results
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Close the connection
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void comboBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input values
                if (string.IsNullOrEmpty(comboBloodGroup.Text) || string.IsNullOrEmpty(comboUnits.Text))
                {
                    MessageBox.Show("Please select both Blood Group and Units.");
                    return;
                }

                int unitsToAdd;
                if (!int.TryParse(comboUnits.Text, out unitsToAdd))
                {
                    MessageBox.Show("Invalid input for Units.");
                    return;
                }

                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                using (SqlConnection cn = new SqlConnection(connectionstring))
                {
                    cn.Open();

                    // Define the SQL query to update the Quantity in BloodQuantity table
                    string query = "UPDATE BloodQuantity SET Quantity = Quantity + @UnitsToAdd WHERE BloodGroup = @BloodGroup";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@UnitsToAdd", unitsToAdd);
                    cmd.Parameters.AddWithValue("@BloodGroup", comboBloodGroup.Text);

                    cmd.ExecuteNonQuery();

                    cn.Close();
                }

                // Reload the DataGridView to reflect the updated data
                StockIncrease_Load(this, EventArgs.Empty);

                MessageBox.Show("Stock increased successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
