using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace Billing_Software
{
    public partial class ApprovedList : Form
    {
        SqlConnection con;
        private SqlConnection Connection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            return con;
        }
        public ApprovedList()
        {
            InitializeComponent();
            GridViewApprovedList();
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Width = 100;
            btnDelete.Name = "btnDelete";
            btnDelete.Text = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            ApprovedListGrid.Columns.Insert(7, btnDelete);
        }
        private void GridViewApprovedList()
        {
            DataTable dtApprovedLGrid = new DataTable();
            using (con = Connection())
            {
                con.Open();
                var ParamenterApprovedGrid = new DynamicParameters();
                ParamenterApprovedGrid.Add("@StatusID",2);
                var ReaderApprovedLGrid = con.ExecuteReader("usp_viewtable", ParamenterApprovedGrid,commandType:CommandType.StoredProcedure);
                dtApprovedLGrid.Load(ReaderApprovedLGrid);
                ApprovedListGrid.AutoGenerateColumns = false;
                ApprovedListGrid.DataSource = dtApprovedLGrid;
            }
        }
        private void ApprovedListGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                DataGridViewRow ApprovedRow = ApprovedListGrid.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Do you want to Delete this User"+ ApprovedRow.Cells["FirstName"].Value.ToString()),"Conformation",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (con = Connection())
                    {
                        int count = ApprovedListGrid.Rows.Count;
                        con.Open();
                        if ((count == e.RowIndex + 1))
                        {
                            MessageBox.Show("Please Select valid Data Row");
                        }
                        else
                        {
                            Guid UniqueEmpID = new Guid(ApprovedRow.Cells["UniqueEmpID"].Value.ToString().Trim());
                            var ParameterDelete = new DynamicParameters();
                            ParameterDelete.Add("@UniqueEmpID", UniqueEmpID);
                            ParameterDelete.Add("@StatusID", 3);
                            var ReaderDelete = con.Execute("ApproveRejectUser", ParameterDelete, commandType: CommandType.StoredProcedure);
                            MessageBox.Show("User Deleted Successfully");
                            GridViewApprovedList();
                        }
                    }
                }
            }
        }
        private void txt_ApprovedSearchName_TextChanged(object sender, EventArgs e)
        {
            DataTable dtSearch = new DataTable();
            using (con = Connection())
            {
                con.Open();
                string SearchValue = txt_ApprovedSearchName.Text.ToString().Trim();
                var ParaemeterSearch = new DynamicParameters();
                ParaemeterSearch.Add("@SearchValue", SearchValue + "%");
                ParaemeterSearch.Add("@StatusID", 2);
                var ReaderSearch = con.ExecuteReader("SearchGridview", ParaemeterSearch, commandType: CommandType.StoredProcedure);
                dtSearch.Load(ReaderSearch);
                dtSearch.Columns.Add("EmployeeID", typeof(string));
                foreach (DataRow dr in dtSearch.Rows)
                {
                    dr["EmployeeID"] = "Emp " + dr["EmpID"].ToString().Trim();
                }
                ApprovedListGrid.AutoGenerateColumns = false;
                ApprovedListGrid.DataSource = dtSearch;

            }
        }
    }
}
