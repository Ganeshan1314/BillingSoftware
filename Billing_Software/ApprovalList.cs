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
using Dapper;


namespace Billing_Software
{
    public partial class ApprovalList : MasterForm
    {
        public static string Emp_id_public;
        public static string Command;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        SqlConnection con_String;
        public SqlConnection Connection()
        {
            con_String = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            return con_String;
        }
        public ApprovalList()
        {
            InitializeComponent();
            gridview();
            //Add the Button Column.
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Width = 100;
            buttonColumn.Name = "btnApprove";
            buttonColumn.Text = "Approve";
            buttonColumn.HeaderText = "Approve";
            buttonColumn.UseColumnTextForButtonValue = true;
            Gridview1.Columns.Insert(7, buttonColumn);

            //Edit button
            DataGridViewButtonColumn buttoncolumn1 = new DataGridViewButtonColumn();
            buttoncolumn1.HeaderText = "Reject";
            buttoncolumn1.Width = 100;
            buttoncolumn1.Name = "btnReject";
            buttoncolumn1.Text = "Reject";
            buttoncolumn1.UseColumnTextForButtonValue = true;
            Gridview1.Columns.Insert(8, buttoncolumn1);
        }
        private void gridview()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_viewtable";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@StatusID",1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();
            adp.Fill(dt);
            dt.Columns.Add("EmployeeID",typeof(string));
            foreach(DataRow dr in dt.Rows)
            {
                dr["EmployeeID"] = "Emp " + dr["EmpID"].ToString().Trim();
            }
            Gridview1.AutoGenerateColumns = false;
            Gridview1.DataSource = dt;
            con.Close();
        }
        private void Gridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int count= Gridview1.Rows.Count;
            if ((count == e.RowIndex + 1))
            {
                MessageBox.Show("Please Select valid Data Row");
            }
            else
            {
                if (e.ColumnIndex == 7)
                {
                    using(con = Connection())
                    {
                        DataGridViewRow row = Gridview1.Rows[e.RowIndex];
                        //if (MessageBox.Show(string.Format("Do you want to Approve this record:"+row.Cells["Emp_id"].Value), "Conformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //{
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "ApproveRejectUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        Guid UniqueEmpID = new Guid(row.Cells["UniqueID"].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@UniqueEmpID", UniqueEmpID);
                        cmd.Parameters.AddWithValue("@StatusID", 2);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Employee Approved Successfully");
                        gridview();
                        //}
                    }

                }
                if (e.ColumnIndex == 8)
                {
                    using(con=Connection())
                    {
                        DataGridViewRow row = Gridview1.Rows[e.RowIndex];
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "ApproveRejectUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        Guid UniqueEmpID = new Guid(row.Cells["UniqueID"].Value.ToString().Trim());
                        cmd.Parameters.AddWithValue("@UniqueEmpID", UniqueEmpID);
                        cmd.Parameters.AddWithValue("@StatusID", 3);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Employee Rejected Successfully");
                        gridview();
                    }
                }
            }
            
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();
            using (con = Connection())
            {
                con.Open();
                string SearchValue = txt_SearchName.Text.ToString().Trim();
                var ParaemeterSearch = new DynamicParameters();
                ParaemeterSearch.Add("@SearchValue", SearchValue+ "%");
                ParaemeterSearch.Add("@StatusID", 1);
                var ReaderSearch = con.ExecuteReader("SearchGridview", ParaemeterSearch,commandType:CommandType.StoredProcedure);
                dtSearch.Load(ReaderSearch);
                dtSearch.Columns.Add("EmployeeID", typeof(string));
                foreach (DataRow dr in dtSearch.Rows)
                {
                    dr["EmployeeID"] = "Emp " + dr["EmpID"].ToString().Trim();
                }
                Gridview1.AutoGenerateColumns = false;
                Gridview1.DataSource = dtSearch;

            }
        }
    }
}
