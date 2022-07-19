using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace Billing_Software
{
    public partial class FoodBillItemTest : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

        public FoodBillItemTest()
        {
            InitializeComponent();
            AutoComplete();
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

        private void gv_Food_List_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                con.Close();
                con.Open();
                int Row_count1 = gv_Food_List.Rows.Count;
                int colum_index = gv_Food_List.CurrentCell.ColumnIndex;
                string titleText = gv_Food_List.Columns[1].HeaderText;
                string title_quantity = gv_Food_List.Columns[2].HeaderText;
                string sql_autocomplete = "select Item_Name from Food_Item_List";
                SqlCommand cmd_autocomplete = new SqlCommand(sql_autocomplete, con);
                SqlDataReader dr = cmd_autocomplete.ExecuteReader();
                AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
                TextBox autoText = e.Control as TextBox;
                if (colum_index == 1)
                {
                    while (dr.Read())
                    {
                        mycollection.Add(dr.GetString(0));
                    }
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    autoText.AutoCompleteCustomSource = mycollection;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                if (colum_index != 1)
                {
                    mycollection.Clear();
                    autoText.Text = "";
                }
                if (title_quantity.Equals("Quantity"))
                {
                    int Row_count = gv_Food_List.Rows.Count;
                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
