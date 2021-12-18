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
    public partial class userdetails : MasterForm
    {
        public static string Emp_id_public;
        public static string Command;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public userdetails()
        {
            InitializeComponent();
            gridview();
            //Add the Button Column.
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Width = 60;
            buttonColumn.Name = "Delete_Btn";
            buttonColumn.Text = "Delete";
            buttonColumn.HeaderText = "Delete";
            buttonColumn.UseColumnTextForButtonValue = true;
            Gridview1.Columns.Insert(3, buttonColumn);

            //Edit button
            DataGridViewButtonColumn buttoncolumn1 = new DataGridViewButtonColumn();
            buttoncolumn1.HeaderText = "Edit";
            buttoncolumn1.Width = 60;
            buttoncolumn1.Name = "Edit_Btn";
            buttoncolumn1.Text = "Edit";
            buttoncolumn1.UseColumnTextForButtonValue = true;
            Gridview1.Columns.Insert(4, buttoncolumn1);
        }
        private void gridview()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "usp_viewtable";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new System.Data.DataTable();
            adp.Fill(dt);
            Gridview1.AutoGenerateColumns = false;
            Gridview1.DataSource = dt;
            con.Close();
        }
        private void Gridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow row = Gridview1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Do you want to Delete this record:"+row.Cells["Emp_id"].Value), "Conformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "usp_delete_user";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    string Emp_Id=row.Cells["Emp_id"].Value.ToString().Trim();
                    cmd.Parameters.AddWithValue("@Employee_Id", Emp_Id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Employee Deleted Successfully");
                    gridview();
                }
            }
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow row = Gridview1.Rows[e.RowIndex];
                string Emp_id = row.Cells["Emp_Id"].Value.ToString().Trim();
                Emp_id_public = Emp_id;
                Command = "Edit";
                this.Close();
                Registration reg = new Registration();
                reg.Show();
            }
        }
    }
}
