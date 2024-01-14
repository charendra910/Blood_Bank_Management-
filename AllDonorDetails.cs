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
    public partial class AllDonorDetails : Form
    {
        public AllDonorDetails()
        {
            InitializeComponent();
        }

        private void AllDonorDetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm=new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
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
                    string query = "SELECT * FROM AddNewDonor";
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

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
