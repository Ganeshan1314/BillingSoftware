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
using System.Globalization;
using Dapper;

namespace Billing_Software
{
    public partial class Food_Items_Bill : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        SqlConnection DapperCon;
        public SqlConnection Connection()
        {
            DapperCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            return DapperCon;
        }
        public Food_Items_Bill()
        {
            InitializeComponent();
            gv_Food_List.CurrentCell = gv_Food_List.Rows[0].Cells[1];
            gv_Food_List.CurrentCell.Selected = true;
            
        }
        private void Food_Items_Bill_Load(object sender, EventArgs e)
        {
            //Auto Complete Code
            con.Open();
            //string titleText = gv_Food_List.Columns[6].HeaderText;
            //if (titleText.Equals("Column1"))
            //{
            //TextBox autoText = e.Control as TextBox;
            string sql_autocomplete = "select Item_Name from Food_Item_List";
            SqlCommand cmd_autocomplete = new SqlCommand(sql_autocomplete, con);
            SqlDataReader dr = cmd_autocomplete.ExecuteReader();
            AutoCompleteStringCollection mycollection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                mycollection.Add(dr.GetString(0));
            }

            txt_ItemId.AutoCompleteCustomSource = mycollection;
            //autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
            //autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            //mycollection(DataCollection);
            //autoText.AutoCompleteCustomSource = DataCollection;
            //}
            con.Close();
        }
        int Total_quntity, exit_quantity, Total_Amount;
        private void Add_Click(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (ddl_Item_Name.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Food Item Name");
                value = "Error";
            }
            else if (txt_Quantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity of Food Item");
                value = "Error";
            }
            if (value != "Error")
            {
                con.Open();
                string Item_Id = ddl_Item_Name.SelectedIndex.ToString().Trim();
                int Item_Quantity = int.Parse(txt_Quantity.Text.ToString().Trim());
                string sql_select_item = "select * from Food_Item_List where Food_Id='" + Item_Id + "'";
                SqlDataAdapter adp = new SqlDataAdapter(sql_select_item, con);
                DataTable dt_item = new DataTable();
                adp.Fill(dt_item);
                string Item_Name = dt_item.Rows[0]["Item_Name"].ToString().Trim();
                string Item_Price = dt_item.Rows[0]["Item_Price"].ToString().Trim();
                int Item_Price_Int = int.Parse(Item_Price);

                string sql_select_exits_Item = "select * from Food_Item_Bill where Item_name='" + Item_Name + "'";
                SqlDataAdapter adp_exits = new SqlDataAdapter(sql_select_exits_Item, con);
                DataTable dt_item_exits = new DataTable();
                adp_exits.Fill(dt_item_exits);


                if (dt_item_exits.Rows.Count > 0)
                {
                    exit_quantity = int.Parse(dt_item_exits.Rows[0]["Quantity"].ToString().Trim());
                    Total_quntity = exit_quantity + Item_Quantity;
                    Total_Amount = Total_quntity * Item_Price_Int;
                    string sql_Item_Update = "update Food_Item_Bill set Quantity='" + Total_quntity + "',Price='" + Total_Amount + "' where Bill_Id ='" + dt_item_exits.Rows[0]["Bill_Id"].ToString().Trim() + "'";
                    SqlCommand cmd = new SqlCommand(sql_Item_Update, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    exit_quantity = 0;
                    Total_Amount = Item_Quantity * Item_Price_Int;
                    string sql_Item_Insert = "insert into Food_Item_Bill(Item_name,Quantity,Quality,Price)values('" + Item_Name + "','" + Item_Quantity + "','1','" + Total_Amount + "')";
                    SqlCommand cmd = new SqlCommand(sql_Item_Insert, con);
                    cmd.ExecuteNonQuery();
                }


                Gridview();
                txt_Quantity.Text = "";
                if (txt_Billamount.Text.Trim() != "")
                {
                    Total_Amount = (Item_Quantity * Item_Price_Int) + int.Parse(txt_Billamount.Text.Trim());
                }

                ddl_Item_Name.SelectedIndex = 0;
                double GST = (double)18 / 100;
                double GST1 = (GST * Total_Amount) / 2;
                txt_Billamount.Text = Total_Amount.ToString().Trim();
                txt_Cgst.Text = GST1.ToString("00.00").Trim();
                txt_sgst.Text = GST1.ToString("00.00").Trim();
                double add_double_value = GST1 + GST1;
                int Total_Amount1 = Total_Amount + Convert.ToInt32(add_double_value);
                txt_Total.Text = Total_Amount1.ToString().Trim();

                con.Close();

            }

        }
        private void Btn_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                char c = 'A';
                int index = char.ToUpper(c) - 64;
                string Item_Name = Convert.ToString(gv_Food_List.Rows[0].Cells[1].Value).Trim();
                string Item_Quantity = Convert.ToString(gv_Food_List.Rows[0].Cells[2].Value).Trim();
                string Item_Price = Convert.ToString(gv_Food_List.Rows[0].Cells[3].Value).Trim();
                string BillSeries = string.Empty;
                string CustomerBillID = string.Empty;
                using (DapperCon=Connection())
                {
                    DapperCon.Open();
                    var ParameterSelectMaxID = new DynamicParameters();
                    ParameterSelectMaxID.Add("@BillDate", DateTime.Today);
                    var ReaderMaxID = con.ExecuteReader("SelectBillID", ParameterSelectMaxID,commandType:CommandType.StoredProcedure);
                    DataTable dtBillCount = new DataTable();
                    dtBillCount.Load(ReaderMaxID);
                    string value = Convert.ToString(dtBillCount.Rows[0]["BillIDCount"]);
                    int id = 0;
                    if (value != "")
                    {
                        id = Convert.ToInt32(value);
                        id = id + 1;
                    }
                    else
                    {
                        id = 0;
                        id = id + 1;
                    }
                    if(id < 1000)
                    {
                        BillSeries = "A";
                        CustomerBillID = "A"+id;
                    }
                    else
                    {

                    }
                    Guid BillID = Guid.NewGuid();
                    DateTime BillDate = DateTime.Today;
                    
                }
                con.Open();
                int Bill_id = 0;
                if (gv_Food_List.Rows.Count > 1)
                {
                    SqlCommand cmd_Max_Id = new SqlCommand();
                    cmd_Max_Id.Connection = con;
                    cmd_Max_Id.CommandType = CommandType.StoredProcedure;
                    cmd_Max_Id.CommandText = "usp_Max_Bill_id";
                    string Max_Id = Convert.ToString(cmd_Max_Id.ExecuteScalar()).Trim();
                    if(Max_Id != "")
                    {
                        Bill_id = Convert.ToInt32(Max_Id)+1;
                    }
                    else
                    {
                        Bill_id = 1;
                    }
                    Guid Bill_Id = Guid.NewGuid();
                    var ParameterBillMaster = new DynamicParameters();
                    ParameterBillMaster.Add("@Bill_Id", Bill_Id);
                    ParameterBillMaster.Add("@CreatedBy","Admin");
                    ParameterBillMaster.Add("@CreatedDate",DateTime.Now);
                    con.Execute("insertBillMaster", ParameterBillMaster,commandType:CommandType.StoredProcedure);
                    for (int j = 0; j < gv_Food_List.Rows.Count - 1; j++)
                    {
                        
                        SqlCommand cmd_Insert = new SqlCommand();
                        cmd_Insert.Connection = con;
                        cmd_Insert.CommandType = CommandType.StoredProcedure;
                        cmd_Insert.CommandText = "usp_insert_Food_Bill";
                        cmd_Insert.Parameters.AddWithValue("@BillNo", Convert.ToInt32(Bill_id));
                        cmd_Insert.Parameters.AddWithValue("@Item_Name", Item_Name);
                        cmd_Insert.Parameters.AddWithValue("@Item_Quantity", Convert.ToInt32(Item_Quantity));
                        cmd_Insert.Parameters.AddWithValue("@Item_Price", Convert.ToInt32(Item_Price));
                        cmd_Insert.Parameters.AddWithValue("@Date_Time", DateTime.Now);
                        cmd_Insert.ExecuteNonQuery();
                    }
                }
                Bill_Invoice crystal_report = new Bill_Invoice();
                //crystal_report.SetParameterValue("Text4", 1);
                string sql = "select * from Total_Food_Billing where Bill_Id='" + Bill_id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                TextObject text_Date = (TextObject)crystal_report.ReportDefinition.Sections["Section1"].ReportObjects["Date"];
                text_Date.Text = DateTime.Now.ToString("dd/MMM/yyyy HH:mm tt");
                crystal_report.SetDataSource(dt);
                crystalReportViewer2.ReportSource = crystal_report;
                crystal_report.PrintToPrinter(1, false, 0, 0);
                gv_Food_List.Rows.Clear();
                con.Close();
                txt_Billamount.Text = "";
                txt_Cgst.Text = "";
                txt_sgst.Text = "";
                txt_Total.Text = "";
                gv_Food_List.Focus();
                gv_Food_List.CurrentCell = gv_Food_List.Rows[0].Cells[1];
                gv_Food_List.CurrentCell.Selected = true;

                //string sql_Get_current_list = "select * from Food_Item_Bill";
                //SqlCommand cmd_get_list = new SqlCommand(sql_Get_current_list, con);
                //DataTable dt_insert = new DataTable();
                //SqlDataAdapter adp_get_list = new SqlDataAdapter(cmd_get_list);
                //adp_get_list.Fill(dt_insert);

                //string sql_Bill_Id = "select max(Bill_Id) as Bill_Id from Total_Food_Billing";
                //SqlCommand cmd_Bill_Id = new SqlCommand(sql_Bill_Id, con);
                //DataTable dt_Bill_Id = new DataTable();
                //SqlDataAdapter adp_Bill_Id = new SqlDataAdapter(cmd_Bill_Id);
                //adp_Bill_Id.Fill(dt_Bill_Id);
                //int last_Bill_id;

                //if (dt_Bill_Id.Rows[0]["Bill_Id"].ToString().Trim() != "")
                //{
                //    last_Bill_id = int.Parse(dt_Bill_Id.Rows[0]["Bill_Id"].ToString().Trim()) + 1;
                //}
                //else
                //{
                //    last_Bill_id = 1;
                //}
                //if (dt_insert.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt_insert.Rows.Count; i++)
                //    {
                //        SqlCommand cmd_insert = new SqlCommand();
                //        cmd_insert.CommandText = "usp_insert_Total";
                //        cmd_insert.CommandType = CommandType.StoredProcedure;
                //        cmd_insert.Connection = con;
                //        cmd_insert.Parameters.AddWithValue("@Item_name", dt_insert.Rows[i]["Item_name"].ToString().Trim());
                //        cmd_insert.Parameters.AddWithValue("@Quantity", dt_insert.Rows[i]["Quantity"].ToString().Trim());
                //        cmd_insert.Parameters.AddWithValue("@Quality", dt_insert.Rows[i]["Quality"].ToString().Trim());
                //        cmd_insert.Parameters.AddWithValue("@Price", Convert.ToInt32(dt_insert.Rows[i]["Price"]));
                //        cmd_insert.Parameters.AddWithValue("@Date_Time", DateTime.Now);
                //        cmd_insert.Parameters.AddWithValue("@Bill_id", last_Bill_id);
                //        cmd_insert.ExecuteNonQuery();

                //    }
                //}

                //Gridview();
            }
            catch (Exception ex)
            {

            }



        }
        private void Gridview()
        {
            con.Close();
            con.Open();

            string sql_Food_Item_List = "select * from Food_Item_Bill";
            SqlCommand cmd_List = new SqlCommand(sql_Food_Item_List, con);
            SqlDataAdapter adp_List = new SqlDataAdapter(cmd_List);
            DataTable dt_List = new DataTable();
            adp_List.Fill(dt_List);
            gv_Food_List.AutoGenerateColumns = false;
            gv_Food_List.DataSource = dt_List;

            gv_Food_List.ReadOnly = false;
            gv_Food_List.Columns[1].ReadOnly = true;
            gv_Food_List.Columns[2].ReadOnly = true;
            con.Close();
        }
        private void gv_Food_List_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if(gv_Food_List.Rows.Count == 1)
            {
                MessageBox.Show("Please Add the items table!");
            }
            else
            {
                int ID = Convert.ToInt32(gv_Food_List.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                string Item_Name = gv_Food_List.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                string Quantity = gv_Food_List.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                txt_Quantity.Text = Quantity;
                ddl_Item_Name.SelectedIndex = ddl_Item_Name.FindStringExact(Item_Name);
                txt_ItemId.Text = gv_Food_List.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                
                
                Add.Visible = false;

            }
            
        }
        private void txt_Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 97 && e.KeyValue <= 105))
            {

            }
            else
            {
                MessageBox.Show("Please Enter Numbers Only");
                txt_Quantity.Text = "";
            }
        }
        private void gv_Food_List_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            con.Close();
            con.Open();
            //e.Control.KeyPress = new KeyPressEventHandler();
            int Row_count1 = gv_Food_List.Rows.Count;
            int colum_index = gv_Food_List.CurrentCell.ColumnIndex;
            string titleText = gv_Food_List.Columns[1].HeaderText;
            string title_quantity= gv_Food_List.Columns[2].HeaderText;
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
            if(colum_index != 1)
            {
                mycollection.Clear();
                autoText.Text = "";
            }
            
            if (title_quantity.Equals("Quantity"))
            {
                int Row_count = gv_Food_List.Rows.Count;
            }
            con.Close();
            Item_quantity();


        }
        private void Item_quantity()
        {
            int Row_count = gv_Food_List.Rows.Count;
        }
        private void gv_Food_List_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            calGridview();
        }
        private void gv_Food_List_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            calGridview();
        }
        private void calGridview()
        {
            int cal = 0;
            int count = 1;
            for (int i = 0; i < gv_Food_List.Rows.Count; i++)
            {
                try
                {
                    string Item_name = Convert.ToString(gv_Food_List.Rows[i].Cells[1].Value);
                    var arg = new DataGridViewCellEventArgs(4, 0);
                    gv_Food_List.Rows[i].Cells[0].Value = count;
                    count++;
                    string Item_quantity = Convert.ToString(gv_Food_List.Rows[i].Cells[2].Value);
                    con.Open();
                    string sql_Item_price = "select Item_Price from Food_Item_List where Item_Name='" + Item_name + "'";
                    SqlCommand cmd_price = new SqlCommand(sql_Item_price, con);
                    SqlDataAdapter adp_price = new SqlDataAdapter(cmd_price);
                    DataTable dt_price = new DataTable();
                    adp_price.Fill(dt_price);
                    int Total_price;
                    if (dt_price.Rows.Count > 0)
                    {
                        string Item_price = cmd_price.ExecuteScalar().ToString().Trim();
                        Total_price = Convert.ToInt32(Item_quantity) * Convert.ToInt32(Item_price);
                        gv_Food_List.Rows[i].Cells[3].Value = Total_price;
                        cal = cal + Total_price;
                    }
                    else
                    {
                        if (Convert.ToString(gv_Food_List.Rows[i].Cells[3].Value) != "")
                        {
                            Total_price = Convert.ToInt32(gv_Food_List.Rows[i].Cells[3].Value);
                            cal = cal + Total_price;
                        }
                    }
                }
                catch (Exception)
                {

                }
                txt_Billamount.Text = cal.ToString().Trim();
                int Total = Convert.ToInt32(txt_Billamount.Text);
                double GST = (double)18 / 100;
                double GST1 = (GST * Total) / 2;
                txt_Cgst.Text = Convert.ToString(GST1);
                txt_sgst.Text = Convert.ToString(GST1);
                txt_Total.Text = Convert.ToString(Total + (GST1 * 2));
                con.Close();
            }
        }
        private void gv_Food_List_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2) // 1 should be your column index
            {
                int i;
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Enter numbers only");
                    int row = gv_Food_List.CurrentCell.RowIndex;
                    gv_Food_List.Rows[row].Cells[2].Value = 0;
                    gv_Food_List.Update();
                    gv_Food_List.Refresh();
                }
            }
            if(e.ColumnIndex == 1)
            {
                int i;
                if(int.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Enter valid Item Value");
                    int row = gv_Food_List.CurrentCell.RowIndex;
                    gv_Food_List.Update();
                    gv_Food_List.Refresh();
                }
            }
        }
        private void gv_Food_List_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = gv_Food_List.CurrentCell.RowIndex;
            int col = gv_Food_List.CurrentCell.ColumnIndex;
            if (col == 1)
            {
                KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
                gv_Food_List_KeyDown(gv_Food_List, forKeyDown);
            }
            if (col == 2)
            {
                gv_Food_List.CurrentCell = gv_Food_List[1, row+1];
                gv_Food_List.Focus();


            }
        }
        private void gv_Food_List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
        }
        public void addItems(AutoCompleteStringCollection col)
        {

        }
        private void gv_Food_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow row_index = gv_Food_List.Rows[e.RowIndex];
                if (gv_Food_List.Rows.Count > 1)
                {
                    int row= gv_Food_List.CurrentCell.RowIndex;
                    if(row < gv_Food_List.Rows.Count-1)
                    {
                        gv_Food_List.Rows.RemoveAt(row);
                        gv_Food_List.CurrentCell = gv_Food_List.Rows[row].Cells[1];
                        gv_Food_List.CurrentCell.Selected = true;
                        //con.Open();
                        //string bill_id = Convert.ToString(row_index.Cells[0].Value).Trim();
                        //string Item_Price = Convert.ToString(row_index.Cells[3].Value).Trim();
                        //string sql_Delete = "delete from Food_Item_Bill where Bill_Id='" + bill_id + "'";
                        //SqlCommand cmd = new SqlCommand(sql_Delete, con);
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        //Gridview();
                        //int Total_value = int.Parse(txt_Billamount.Text.Trim());
                        //int value = Total_value - int.Parse(Item_Price);
                        //txt_Billamount.Text = value.ToString().Trim();
                        //double GST = (double)18 / 100;
                        //double GST1 = (GST * value) / 2;
                        //txt_Cgst.Text = GST1.ToString("00.00").Trim();
                        //txt_sgst.Text = GST1.ToString("00.00").Trim();
                        //double add_double_value = GST1 + GST1;
                        //int Total_Amount1 = value + Convert.ToInt32(add_double_value);
                        //txt_Total.Text = Convert.ToString(Total_Amount1).Trim();
                    }
                    else
                    {
                        MessageBox.Show("You cannot delete this row");
                    }
                 }
                else
                {
                    MessageBox.Show("Please Add the Item");
                }

            }
        }
    }
}
