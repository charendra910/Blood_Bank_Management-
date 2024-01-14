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
    public partial class StockDecrease : Form
    {
        public StockDecrease()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
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

                int unitsToDecrease;
                if (!int.TryParse(comboUnits.Text, out unitsToDecrease))
                {
                    MessageBox.Show("Invalid input for Units.");
                    return;
                }

                string connectionstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Blood Bank Management System(C#)\\Blood_Management\\register.mdf\";Integrated Security=True";

                using (SqlConnection cn = new SqlConnection(connectionstring))
                {
                    cn.Open();

                    // Define the SQL query to update the Quantity in BloodQuantity table
                    string query = "UPDATE BloodQuantity SET Quantity = Quantity - @UnitsToDecrease WHERE BloodGroup = @BloodGroup";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    // Decrease parameters to the query
                    cmd.Parameters.AddWithValue("@UnitsToDecrease", unitsToDecrease);
                    cmd.Parameters.AddWithValue("@BloodGroup", comboBloodGroup.Text);

                    cmd.ExecuteNonQuery();

                    cn.Close();
                }

                // Reload the DataGridView to reflect the updated data
                StockDecrease_Load(this, EventArgs.Empty);

                MessageBox.Show("Stock decreased successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void StockDecrease_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
