using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blood_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void addNewDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewDonor adn= new AddNewDonor();
            adn.Show();
        }

        private void updateDonorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDonor updateDonor = new UpdateDonor();
            updateDonor.Show(); 
        }

        private void allDonorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDonorDetails add = new AllDonorDetails();
            add.Show();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDonorDetails sdd = new SearchDonorDetails();
            sdd.Show(); 
        }

        private void bloodGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BloodGroupDetails bgd  = new BloodGroupDetails();
            bgd.Show(); 
        }

        private void increaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockIncrease si = new StockIncrease(); 
            si.Show();
        }

        private void decreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockDecrease sd = new StockDecrease();
            sd.Show();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockDetails sd = new StockDetails();   
            sd.Show();
        }

        private void deleteDonorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteDonor dd = new DeleteDonor();
            dd.Show();  
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void donToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteDonorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
