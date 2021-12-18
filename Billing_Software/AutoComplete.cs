using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing_Software
{
    public partial class AutoComplete : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public AutoComplete()
        {
            InitializeComponent();
        }

        private void AutoComplete_Load(object sender, EventArgs e)
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
            textBox1.AutoCompleteCustomSource = mycollection;
            con.Close();
        }
    }
}
