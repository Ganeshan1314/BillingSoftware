using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing_Software
{
    public partial class MasterForm : Form
    {
        string FormID = string.Empty;
        public MasterForm()
        {
            InitializeComponent();
        }
        public MasterForm(string id)
        {
            this.FormID = id;
            InitializeComponent();
        }
        private void Masterform_Load(object sender,EventArgs e)
        {

        }

       

        private void Editfooditem_Click(object sender, EventArgs e)
        {

            this.Hide();
            Add_Food_Item ad = new Add_Food_Item();
            ad.Show();
        }

        private void fooditembill_Click(object sender, EventArgs e)
        {
            this.Hide();
            Food_Items_Bill food_item = new Food_Items_Bill();
            food_item.Show();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            userdetails user = new userdetails();
            user.Show();
        }

        private void userRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.Show();
        }

        private void salesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales_Report sales = new Sales_Report();
            sales.Show();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dash = new Dashboard();
            dash.Show();
        }
    }
}
