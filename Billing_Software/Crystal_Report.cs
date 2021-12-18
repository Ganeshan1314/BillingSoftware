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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Billing_Software
{
    public partial class Crystal_Report : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public Crystal_Report()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Billing_Crystal_Report cr = new Billing_Crystal_Report();
            con.Open();
            string sql = "select * from Food_Item_Bill";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            cr.SetDataSource(dt);
            con.Close();
            //TextObject text=(TextObject)cr.ReportDefinition.Sections[""]
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
