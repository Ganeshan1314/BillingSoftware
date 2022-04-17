using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Billing_Software
{
    public partial class Login : Form
    {

        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@username", txt_username.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txt_password.Text.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                int StatusID = Convert.ToInt32(dt.Rows[0]["StatusID"]);
                if(StatusID == 1)
                {
                    MessageBox.Show("You Have Already Requested, Pending for Admin Approval");
                }
                if(StatusID == 2)
                {
                    this.Hide();
                    Dashboard Dashboard = new Dashboard();
                    Dashboard.Show();
                }
            }
            else
            {
                MessageBox.Show("You Dont Have The access Please click register button");
            }
            con.Close();
        }
        private void btn_Register_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration reg = new Registration();
            reg.Show();
        }
    }
}
