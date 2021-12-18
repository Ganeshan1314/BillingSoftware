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
    public partial class Registration : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        string value = string.Empty;
        public Registration()
        {
            InitializeComponent();
            txt_empid.ReadOnly = true;
            if (userdetails.Emp_id_public == null)
            {

                Employee_Id();
            }
            else
            {

                txt_empid.Text = userdetails.Emp_id_public;
                Select_Employee();
                

            }
            
        }

        private void Employee_Id()
        {
            con.Open();
            string sql = "select max(Emp_id) as Emp_Id from tbl_Registration";
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            int Emp_id;
            if (dt.Rows.Count < 1)
            {
                Emp_id = 1;
                String Id = "Emp" + Emp_id.ToString();
                txt_empid.Text = Id.ToString();
            }
            else
            {
                string sub_value;
                sub_value = dt.Rows[0]["Emp_Id"].ToString().Substring(3);
                Emp_id = Convert.ToInt32(sub_value.Trim()) + 1;
                String Id = "Emp" + Emp_id.ToString();
                txt_empid.Text = Id.ToString();
            }
            

        }

        private void Select_Employee()
        {
            string sql_select = "select * from tbl_Registration where Emp_id='"+userdetails.Emp_id_public+"'";
            SqlCommand cmd = new SqlCommand(sql_select, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt_select = new DataTable();
            con.Open();
            adp.Fill(dt_select);
            con.Close();
            txt_Firstname.Text = dt_select.Rows[0]["First_Name"].ToString().Trim();
            txt_Lastname.Text = dt_select.Rows[0]["Last_Name"].ToString().Trim();
            txt_Mobileno.Text = dt_select.Rows[0]["Mobile_No"].ToString().Trim();
            txt_Department.Text = dt_select.Rows[0]["Department"].ToString().Trim();
            txt_Username.Text = dt_select.Rows[0]["Username"].ToString().Trim();
            txt_Password.Text = dt_select.Rows[0]["Password"].ToString().Trim();
            txt_Address.Text = dt_select.Rows[0]["Address"].ToString().Trim();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckNull();
            if (value != "Error")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "usp_Registration";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                if(userdetails.Emp_id_public == null)
                {
                    cmd.Parameters.AddWithValue("@Emp_id_public", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Emp_id_public", userdetails.Emp_id_public);
                }
                cmd.Parameters.AddWithValue("@Emp_id", txt_empid.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@First_Name", txt_Firstname.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Last_Name", txt_Lastname.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Mobile_No", txt_Mobileno.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Department", txt_Department.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@username", txt_Username.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@password", txt_Password.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@Address", txt_Address.Text.ToString().Trim());
                if(userdetails.Emp_id_public == "")
                {
                    cmd.Parameters.AddWithValue("@Request_Status", "Pending");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Request_Status", "Approved");
                }
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Inserted Successfully");
                ClearData();
                Employee_Id();
                userdetails.Emp_id_public = "";
            }
            
        }
        private void CheckNull()
        {
            string result = "Please Enter";
            if (txt_Firstname.Text == string.Empty)
            {
                result =result+ "Firstname,";
            }
            if (txt_Lastname.Text == string.Empty)
            {
                result = result + "Lastname,";
            }
            if (txt_Mobileno.Text == string.Empty)
            {
                result = result + "Mobile Number,";
            }
            if (txt_Department.Text == string.Empty)
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
            if (result != "Please Enter")
            {
                MessageBox.Show(result);
                value = "Error";
            }
        }
        private void ClearData()
        {

            txt_empid.Text = "";
            txt_Firstname.Text = "";
            txt_Lastname.Text = "";
            txt_Mobileno.Text = "";
            txt_Department.Text = "";
            txt_Username.Text = "";
            txt_Password.Text = "";
            txt_Address.Text = "";
            
        }
    }
}
