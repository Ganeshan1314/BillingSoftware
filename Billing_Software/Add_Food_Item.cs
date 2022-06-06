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
    public partial class Add_Food_Item : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public Add_Food_Item()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql_Insert = "insert into Food_Item_List(Item_Name,Item_Price) values (N'" + txt_Itemname.Text + "','" + txt_itemprice.Text + "')";
            //string sql_Insert = "insert into Food_Item_List([Item_Name],[Item_Price]) values(N'அஆஅ', '1')";
            SqlCommand cmd = new SqlCommand(sql_Insert,con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Food Item Inserted Successfully");
            txt_Itemname.Text = "";
            txt_itemprice.Text = "";
            con.Close();
        }

        
    }
}
