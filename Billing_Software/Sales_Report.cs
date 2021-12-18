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
using System.Globalization;

namespace Billing_Software
{
    public partial class Sales_Report : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public Sales_Report()
        {
            InitializeComponent();
            
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            todate1.MinDate = Convert.ToDateTime(Fromdate.Text);
        }

        private void btn_get_details_Click(object sender, EventArgs e)
        {
            string fromdDate = DateTime.Parse(Fromdate.Text.Trim()).ToString("yyyy-MM-dd")+" 00:00:00";
            string todate = DateTime.Parse(todate1.Text.Trim()).ToString("yyyy - MM - dd")+" 23:59:59";
            SqlCommand cmd_select_report = new SqlCommand();
            cmd_select_report.CommandText = "usp_select_report";
            cmd_select_report.CommandType = CommandType.StoredProcedure;
            cmd_select_report.Connection = con;
            cmd_select_report.Parameters.AddWithValue("@fromdate", fromdDate);
            cmd_select_report.Parameters.AddWithValue("@todate", todate);
            DataTable dt_select = new DataTable();
            SqlDataAdapter adp_select = new SqlDataAdapter(cmd_select_report);
            con.Open();
            adp_select.Fill(dt_select);
            con.Close();
            DataTable dtCloned = dt_select.Clone();
            dtCloned.Columns[0].DataType = typeof(string);
            dtCloned.Columns[1].DataType = typeof(string);
            dtCloned.Columns[2].DataType = typeof(string);
            dtCloned.Columns[3].DataType = typeof(string);
            dtCloned.Columns[4].DataType = typeof(string);
            //dtCloned = dt_select.Copy();
            foreach (DataRow row in dt_select.Rows)
            {
                dtCloned.ImportRow(row);
            }
            for(int i=0;i < dt_select.Rows.Count;i++)
            {
                dtCloned.Rows[i]["Price"] = "₹" + dtCloned.Rows[i]["Price"];
            }
            Total_Count.Text = "₹ "+dt_select.Compute("Sum(Price)", "").ToString()+".00";
            
            gv_Report.AutoGenerateColumns = false;
            gv_Report.DataSource = dtCloned;
        }
    }
}
