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
    public partial class Registration : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        string value = string.Empty;
        public Registration()
        {
            InitializeComponent();
            if (ApprovalList.Emp_id_public == null)
            {
                Employee_Id();
            }
            else
            {
                //txt_empid.Text = userdetails.Emp_id_public;
                Select_Employee();
            }
            DropDownDepartment();
            DropDownUserType();
            AutoComplete();
            AutoCompleteLastName();

        }
        private void AutoComplete()
        {
            con.Open();
            string sql_autocomplete = "select Item_Name from Food_Item_List";
            SqlCommand cmd_autocomplete = new SqlCommand(sql_autocomplete, con);
            SqlDataReader dr = cmd_autocomplete.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            txt_Firstname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Firstname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Firstname.AutoCompleteCustomSource = mycollection;
            con.Close();
        }
        private void AutoCompleteLastName()
        {
            con.Open();
            string sql_autocomplete = "select Item_Name from Food_Item_List";
            SqlCommand cmd_autocomplete = new SqlCommand(sql_autocomplete, con);
            SqlDataReader dr = cmd_autocomplete.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }
            txt_Lastname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_Lastname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Lastname.AutoCompleteCustomSource = mycollection;
            con.Close();
        }
        private void DropDownDepartment()
        {
            var ReadergerDepartment = con.ExecuteReader("getDepartment", commandType: CommandType.StoredProcedure);
            DataTable dtDepartment = new DataTable();
            dtDepartment.Load(ReadergerDepartment);
            DataRow dr = dtDepartment.NewRow();
            dr[0] = 0;
            dr[1] = "--Select--";
            dr[2] = 0;
            dtDepartment.Rows.InsertAt(dr, 0);
            ddlDepartment.DataSource = dtDepartment;
            ddlDepartment.DisplayMember = "DepartmentName";
            ddlDepartment.ValueMember = "DepartmentID";
        }
        private void DropDownUserType()
        {
            var ReaderUserType = con.ExecuteReader("getUserType", commandType:CommandType.StoredProcedure);
            DataTable dtUserType = new DataTable();
            dtUserType.Load(ReaderUserType);
            DataRow dr = dtUserType.NewRow();
            dr[0] = 0;
            dr[1] = "--Select--";
            dtUserType.Rows.InsertAt(dr,0);
            ddlUserType.DataSource = dtUserType;
            ddlUserType.DisplayMember = "UserType";
            ddlUserType.ValueMember = "UserTypeID";
        }
        private void Employee_Id()
        {
            string sql = "select max(EmpID) as EmpID from tbl_Registration";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            adp.Fill(dt);
            con.Close();
            int Emp_id;
            if (dt.Rows.Count > 0)
            {
                Emp_id = Convert.ToInt32(dt.Rows[0]["EmpID"])+1;
                String Id = "Emp" + Emp_id.ToString();
                //txt_empid.Text = Id.ToString();
            }
            else
            {
                Emp_id = 1;
                String Id = "Emp" + Emp_id;
                //txt_empid.Text = Id.ToString();
            }
            
            

        }
        private void Select_Employee()
        {
            string sql_select = "select * from tbl_Registration where Emp_id='"+ApprovalList.Emp_id_public+"'";
            SqlCommand cmd = new SqlCommand(sql_select, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt_select = new DataTable();
            con.Open();
            adp.Fill(dt_select);
            con.Close();
            txt_Firstname.Text = dt_select.Rows[0]["First_Name"].ToString().Trim();
            txt_Lastname.Text = dt_select.Rows[0]["Last_Name"].ToString().Trim();
            txt_Mobileno.Text = dt_select.Rows[0]["Mobile_No"].ToString().Trim();
            //txt_Department.Text = dt_select.Rows[0]["Department"].ToString().Trim();
            txt_Username.Text = dt_select.Rows[0]["Username"].ToString().Trim();
            txt_Password.Text = dt_select.Rows[0]["Password"].ToString().Trim();
            txt_Address.Text = dt_select.Rows[0]["Address"].ToString().Trim();
            
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckNull();
            if (value != "Error")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "usp_Registration";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                if(ApprovalList.Emp_id_public == null)
                {
                    cmd.Parameters.AddWithValue("@Emp_id_public", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Emp_id_public", ApprovalList.Emp_id_public);
                }
                Guid UniqueEmpID = Guid.NewGuid();
                cmd.Parameters.AddWithValue("@UniqueEmpID", UniqueEmpID);
                cmd.Parameters.AddWithValue("@First_Name", txt_Firstname.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Last_Name", txt_Lastname.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Mobile_No", txt_Mobileno.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(ddlDepartment.SelectedValue));
                cmd.Parameters.AddWithValue("@username", txt_Username.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@password", txt_Password.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Address", txt_Address.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@UserTypeID",Convert.ToInt32(ddlUserType.SelectedValue));
                if(ApprovalList.Emp_id_public == null || ApprovalList.Emp_id_public == "")
                {
                    cmd.Parameters.AddWithValue("@StatusID", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StatusID", 2);
                }
                var ParameterExistUsernamePassword = new DynamicParameters();
                ParameterExistUsernamePassword.Add("@username", txt_Username.Text.ToString().Trim());
                ParameterExistUsernamePassword.Add("@password", txt_Password.Text.ToString().Trim());
                var ReaderExistUsernamePassword = con.ExecuteReader("getExistUsernamePassword", ParameterExistUsernamePassword,commandType:CommandType.StoredProcedure);
                DataTable dtExistUsernamePassword = new DataTable();
                dtExistUsernamePassword.Load(ReaderExistUsernamePassword);
                if(dtExistUsernamePassword.Rows.Count == 0)
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Request Inserted Successfully");
                    ClearData();
                    Employee_Id();
                    ApprovalList.Emp_id_public = "";
                }
                else
                {
                    MessageBox.Show("Username and Password is already Exist");
                }
            }
        }
        private void CheckNull()
        {
            string result = "Please Enter";
            if (txt_Firstname.Text == string.Empty)
            {
                result =result+ " Firstname,";
            }
            if (txt_Lastname.Text == string.Empty)
            {
                result = result + "Lastname,";
            }
            if (txt_Mobileno.Text == string.Empty)
            {
                result = result + "Mobile Number,";
            }
            if (Convert.ToInt32(ddlDepartment.SelectedValue) == 0)
            {
                result = result + "Department,";
            }
            if (txt_Username.Text == string.Empty)
            {
                result = result + "Username,";
            }
            if (txt_Password.Text == string.Empty)
            {
                result = result + "Password,";
            }
            if (txt_Address.Text == string.Empty)
            {
                result = result + "Address,";
            }
            if(Convert.ToInt32(ddlDepartment.SelectedValue) == 0)
            {
                result = result + "UserType,";
            }
            if (result != "Please Enter")
            {
                MessageBox.Show(result);
                value = "Error";
            }
            else
            {
                value = "";
            }
        }
        private void ClearData()
        {

            //txt_empid.Text = "";
            txt_Firstname.Text = "";
            txt_Lastname.Text = "";
            txt_Mobileno.Text = "";
            txt_Username.Text = "";
            txt_Password.Text = "";
            txt_Address.Text = "";
            ddlDepartment.SelectedValue = 0;
            ddlUserType.SelectedValue = 0;
        }
        private void txt_Mobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(txt_Mobileno.Text.Length == 10 && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
