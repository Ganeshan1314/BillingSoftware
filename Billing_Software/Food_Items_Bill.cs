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
using CrystalDecisions.Windows.Forms;

namespace Billing_Software
{
    public partial class s : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        SqlConnection DapperCon;
        int col = 0;
        int row =0;
        public SqlConnection Connection()
        {
            DapperCon = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            return DapperCon;
        }
        public s()
        {
            try
            {
                InitializeComponent();
                gv_Food_List.CurrentCell = gv_Food_List.Rows[0].Cells[1];
                gv_Food_List.CurrentCell.Selected = true;
                AutoComplete();
                TxtItemName.Focus();
            }
            catch (Exception ex)
            {

            }
        }
        private void Food_Items_Bill_Load(object sender, EventArgs e)
        {
            AutoComplete();
            TxtItemName.Focus();
        }
        int TotalPage = 0;
        private void Btn_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                string Item_Name = string.Empty;
                string Item_Quantity = string.Empty;
                string Item_Price = string.Empty;
                double CGST;
                double SGST;
                char c = 'A';
                int index = char.ToUpper(c) - 64;
                string CustomerBillID = string.Empty;
                int BillSeries = 0;
                int MaxBillIDCount = 1;
                int CustomerBillIdIntValue = 1;
                using (DapperCon = Connection())
                {
                    DapperCon.Open();
                    var ParameterSelectMaxID = new DynamicParameters();
                    ParameterSelectMaxID.Add("@BillDate", DateTime.Today);
                    var ReaderMaxID = con.ExecuteReader("SelectBillID", ParameterSelectMaxID, commandType: CommandType.StoredProcedure);
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
                    if (id == 1)
                    {
                        BillSeries = 1;
                        CustomerBillID = "A" + id+"-"+"1";
                    }
                    else
                    {
                        var ParameterMaxBillIDSeries = new DynamicParameters();
                        ParameterMaxBillIDSeries.Add("@Date", DateTime.Today);
                        var MaxBillIDSeries = con.QuerySingle("SelectMaxBillIDSeries", commandType: CommandType.StoredProcedure);
                        BillSeries = MaxBillIDSeries.BillIDSeries;
                        var ParameterCountBillIDSeries = new DynamicParameters();
                        ParameterCountBillIDSeries.Add("@BillSeries", BillSeries);
                        ParameterCountBillIDSeries.Add("@BillDate", DateTime.Today);
                        var ReaderCountBillIDSeries = con.ExecuteReader("CountBillIDSeries", ParameterCountBillIDSeries, commandType: CommandType.StoredProcedure);
                        DataTable DtCountBillIDSeries = new DataTable();
                        DtCountBillIDSeries.Load(ReaderCountBillIDSeries);
                        int CountBillIDSeries = 1;
                        var ReaderCustomerBillIdIntValue = con.ExecuteReader("selectCustomerBillIDIntValue", commandType: CommandType.StoredProcedure);
                        DataTable DtCustomerBillIdIntValue = new DataTable();
                        DtCustomerBillIdIntValue.Load(ReaderCustomerBillIdIntValue);
                        CustomerBillIdIntValue = Convert.ToInt32(DtCustomerBillIdIntValue.Rows[0]["CustomerBillIDInt"])+1;
                        if (DtCountBillIDSeries.Rows.Count > 0)
                        {
                            CountBillIDSeries = Convert.ToInt32(DtCountBillIDSeries.Rows[0]["CountBillIDSeries"]);
                        }
                        int Length = BillSeries.ToString().Length;
                        if (CountBillIDSeries == 10000)
                        {
                            BillSeries = BillSeries + 1;
                            CustomerBillID = "A" + BillSeries + "-" + "1";
                            CustomerBillIdIntValue =  1;
                        }
                        if (CountBillIDSeries < 10000)
                        {
                            if (Convert.ToString(DtCustomerBillIdIntValue.Rows[0]["CustomerBillIDInt"]) != "")
                            {
                                CustomerBillID = "A"+ BillSeries+"-" + Convert.ToInt32(CustomerBillIdIntValue);
                            }
                        }
                    }
                    var ParameterMaxTodayBillIDCount = new DynamicParameters();
                    ParameterMaxTodayBillIDCount.Add("@BillDate", DateTime.Today);
                    var ReaderBillIDCount = DapperCon.ExecuteReader("SelectMaxTodayBillIDCount", ParameterMaxTodayBillIDCount, commandType: CommandType.StoredProcedure);
                    DataTable DtBillIDCount = new DataTable();
                    DtBillIDCount.Load(ReaderBillIDCount);
                    if (DtBillIDCount.Rows.Count > 0)
                    {
                        string BillIDCount = Convert.ToString(DtBillIDCount.Rows[0]["BillIDCountToday"]);
                        if (BillIDCount != "")
                        {
                            MaxBillIDCount = Convert.ToInt32(DtBillIDCount.Rows[0]["BillIDCountToday"]) + 1;
                        }
                    }
                }
                double GST = (double)18 / 100;
                double GST1 = (GST * Convert.ToInt32(txt_Total.Text)) / 2;
                var ParameterBillIDDetails = new DynamicParameters();
                Guid UniqueBillID = Guid.NewGuid();
                ParameterBillIDDetails.Add("@UniqueBillID", UniqueBillID);
                ParameterBillIDDetails.Add("@CustomerBillID", CustomerBillID);
                ParameterBillIDDetails.Add("@CustomerBillIDIntValue", CustomerBillIdIntValue);
                ParameterBillIDDetails.Add("@BillIDSeries", BillSeries);
                ParameterBillIDDetails.Add("@BillIDCount", MaxBillIDCount);
                ParameterBillIDDetails.Add("@CGST", GST1 );
                ParameterBillIDDetails.Add("@SGST", GST1 );
                ParameterBillIDDetails.Add("@TotalAmount", Convert.ToInt32(txt_Total.Text));
                ParameterBillIDDetails.Add("@BillDate", DateTime.Today);
                ParameterBillIDDetails.Add("@CreatedDate", DateTime.Now);
                ParameterBillIDDetails.Add("@CreatedBy", new Guid(SessionValue.UniqueEmpID));
                con.Execute("insertBillIDDetails", ParameterBillIDDetails,commandType:CommandType.StoredProcedure);
                for (int i=0;i<gv_Food_List.Rows.Count-1;i++)
                {
                    Item_Name = Convert.ToString(gv_Food_List.Rows[i].Cells[1].Value).Trim();
                    Item_Quantity = Convert.ToString(gv_Food_List.Rows[i].Cells[2].Value).Trim();
                    Item_Price = Convert.ToString(gv_Food_List.Rows[i].Cells[3].Value).Trim();
                    CGST = Convert.ToDouble(gv_Food_List.Rows[i].Cells[4].Value);
                    SGST = Convert.ToDouble(gv_Food_List.Rows[i].Cells[4].Value);
                    int TotalPrice = Convert.ToInt32(gv_Food_List.Rows[i].Cells[5].Value);
                    using (DapperCon = Connection())
                    {
                        DapperCon.Open();
                        Guid BillID = Guid.NewGuid();
                        DateTime BillDate = DateTime.Today;
                        var ParameterTotalFoodBilling = new DynamicParameters();
                        ParameterTotalFoodBilling.Add("@Bill_Id", BillID);
                        ParameterTotalFoodBilling.Add("@UniqueBillID", UniqueBillID);
                        ParameterTotalFoodBilling.Add("@CustomerBillID", CustomerBillID);
                        ParameterTotalFoodBilling.Add("@BillIDSeries", BillSeries);
                        ParameterTotalFoodBilling.Add("@BillIDCount", MaxBillIDCount);
                        //ParameterTotalFoodBilling.Add("@Item_name", Item_Name);
                        ParameterTotalFoodBilling.Add("@Item_name", Item_Name);
                        ParameterTotalFoodBilling.Add("@Quantity", Item_Quantity);
                        ParameterTotalFoodBilling.Add("@Quality", "1");
                        ParameterTotalFoodBilling.Add("@Price", Item_Price);
                        ParameterTotalFoodBilling.Add("@CGST", CGST);
                        ParameterTotalFoodBilling.Add("@SGST", SGST);
                        ParameterTotalFoodBilling.Add("@TotalPrice", TotalPrice);
                        ParameterTotalFoodBilling.Add("@BillDate", DateTime.Today);
                        ParameterTotalFoodBilling.Add("@CreatedDate", DateTime.Now);
                        ParameterTotalFoodBilling.Add("@CreatedBy", new Guid(SessionValue.UniqueEmpID));
                        DapperCon.Execute("InsertTotalFoodBilling", ParameterTotalFoodBilling, commandType: CommandType.StoredProcedure);
                    }
                }
                DataTable DtPrintBill = new DataTable();
                using (DapperCon = Connection())
                {
                    DapperCon.Open();
                    var ParameterPrintBill = new DynamicParameters();
                    ParameterPrintBill.Add("@UniqueBillID", UniqueBillID);
                    var ReaderPrintBill = DapperCon.ExecuteReader("selectRecordPrintBill", ParameterPrintBill,commandType:CommandType.StoredProcedure);
                    DtPrintBill.Load(ReaderPrintBill);
                }
                Invoice BillInvoice = new Invoice();
                int CrystalReportHeight = 100;
                TextObject Date = (TextObject)BillInvoice.ReportDefinition.ReportObjects["Date"];
                Date.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt").Trim();
                BillInvoice.SetDataSource(DtPrintBill);
                crystalReportViewer2.ReportSource = BillInvoice;
                var printerSettings = new System.Drawing.Printing.PrinterSettings();
                var pageSettings = new System.Drawing.Printing.PageSettings(printerSettings);
                pageSettings.PaperSize = new System.Drawing.Printing.PaperSize("newsize", 230, CrystalReportHeight); // Custom size (100=1 inch)
                pageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                BillInvoice.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
                BillInvoice.PrintOptions.CopyFrom(printerSettings, pageSettings);
                BillInvoice.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                BillInvoice.PrintOptions.PaperSize = PaperSize.PaperA3;
                crystalReportViewer2.ShowLastPage();
                TotalPage = crystalReportViewer2.GetCurrentPageNumber();
                while (TotalPage>1 || TotalPage == 0)
                {
                    if (DtPrintBill.Rows.Count > 0)
                    {
                        BillInvoice.SetDataSource(DtPrintBill);
                        crystalReportViewer2.ReportSource = BillInvoice;
                        printerSettings = new System.Drawing.Printing.PrinterSettings();
                        pageSettings = new System.Drawing.Printing.PageSettings(printerSettings);
                        pageSettings.PaperSize = new System.Drawing.Printing.PaperSize("newsize", 230, CrystalReportHeight); // Custom size (100=1 inch)
                        pageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                        BillInvoice.PrintOptions.DissociatePageSizeAndPrinterPaperSize = true;
                        BillInvoice.PrintOptions.CopyFrom(printerSettings, pageSettings);
                        BillInvoice.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                        BillInvoice.PrintOptions.PaperSize = PaperSize.PaperA3;
                        crystalReportViewer2.ShowLastPage();
                        TotalPage = crystalReportViewer2.GetCurrentPageNumber();
                        if(TotalPage > 2)
                        {
                            CrystalReportHeight += 200;
                        }
                        if (TotalPage <= 2)
                        {
                            CrystalReportHeight += 50;
                        }
                    }
                    if(TotalPage > 2)
                    {
                        TotalPage--;
                    }
                    
                }
                BillInvoice.PrintToPrinter(1, false, 0, 0);
                //report.Load(repName);
                //report.PrintToPrinter(1, false, 0, 0);
                //crystalReportViewer2.ReportSource = crystal_report;
                //con.Open();
                //int Bill_id = 0;
                //if (gv_Food_List.Rows.Count > 1)
                //{
                //    SqlCommand cmd_Max_Id = new SqlCommand();
                //    cmd_Max_Id.Connection = con;
                //    cmd_Max_Id.CommandType = CommandType.StoredProcedure;
                //    cmd_Max_Id.CommandText = "usp_Max_Bill_id";
                //    string Max_Id = Convert.ToString(cmd_Max_Id.ExecuteScalar()).Trim();
                //    if(Max_Id != "")
                //    {
                //        Bill_id = Convert.ToInt32(Max_Id)+1;
                //    }
                //    else
                //    {
                //        Bill_id = 1;
                //    }
                //    Guid Bill_Id = Guid.NewGuid();
                //    var ParameterBillMaster = new DynamicParameters();
                //    ParameterBillMaster.Add("@Bill_Id", Bill_Id);
                //    ParameterBillMaster.Add("@CreatedBy","Admin");
                //    ParameterBillMaster.Add("@CreatedDate",DateTime.Now);
                //    con.Execute("insertBillMaster", ParameterBillMaster,commandType:CommandType.StoredProcedure);
                //    for (int j = 0; j < gv_Food_List.Rows.Count - 1; j++)
                //    {
                //        SqlCommand cmd_Insert = new SqlCommand();
                //        cmd_Insert.Connection = con;
                //        cmd_Insert.CommandType = CommandType.StoredProcedure;
                //        cmd_Insert.CommandText = "usp_insert_Food_Bill";
                //        cmd_Insert.Parameters.AddWithValue("@BillNo", Convert.ToInt32(Bill_id));
                //        cmd_Insert.Parameters.AddWithValue("@Item_Name", Item_Name);
                //        cmd_Insert.Parameters.AddWithValue("@Item_Quantity", Convert.ToInt32(Item_Quantity));
                //        cmd_Insert.Parameters.AddWithValue("@Item_Price", Convert.ToInt32(Item_Price));
                //        cmd_Insert.Parameters.AddWithValue("@Date_Time", DateTime.Now);
                //        cmd_Insert.ExecuteNonQuery();
                //    }
                //}
                //Bill_Invoice crystal_report = new Bill_Invoice();
                ////crystal_report.SetParameterValue("Text4", 1);
                //string sql = "select * from Total_Food_Billing where Bill_Id='" + Bill_id + "'";
                //SqlCommand cmd = new SqlCommand(sql, con);
                //SqlDataAdapter adp = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //adp.Fill(dt);
                //TextObject text_Date = (TextObject)crystal_report.ReportDefinition.Sections["Section1"].ReportObjects["Date"];
                //text_Date.Text = DateTime.Now.ToString("dd/MMM/yyyy HH:mm tt");
                //crystal_report.SetDataSource(dt);
                //crystalReportViewer2.ReportSource = crystal_report;
                //crystal_report.PrintToPrinter(1, false, 0, 0);
                //gv_Food_List.Rows.Clear();
                //con.Close();
                //txt_Billamount.Text = "";
                //txt_Cgst.Text = "";
                //txt_sgst.Text = "";
                //txt_Total.Text = "";
                //gv_Food_List.Focus();
                //gv_Food_List.CurrentCell = gv_Food_List.Rows[0].Cells[1];
                //gv_Food_List.CurrentCell.Selected = true;
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
                MessageBox.Show("Error While Inserting the Data");
            }
        }
        private void Gridview()
        {
            try
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
            catch (Exception)
            {

            }
        }
        private void gv_Food_List_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (gv_Food_List.Rows.Count == 1)
                {
                    MessageBox.Show("Please Add the items table!");
                }
                else
                {
                    int ID = Convert.ToInt32(gv_Food_List.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                    string Item_Name = gv_Food_List.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                    string Quantity = gv_Food_List.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                    txt_Quantity.Text = Quantity;
                    
                }
            }
            catch (Exception)
            {

            }
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
            TxtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            TxtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            TxtItemName.AutoCompleteCustomSource = mycollection;
            con.Close();
        }
        Control CtrolQuantity;
        private void txt_Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            CtrolQuantity = (Control)sender;
            try
            {
                if ((e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 97 && e.KeyValue <= 105))
                {

                }
                else if (e.KeyCode == Keys.Enter)
                {
                    //MessageBox.Show(txt_Quantity.Text.ToString());
                    string Value = txt_Quantity.Text.ToString().Trim();
                    txt_Quantity.Text = "";
                    txt_Quantity.Text = Value.Trim();
                    btnAdd.Focus();
                }
                else
                {
                    MessageBox.Show("Please Enter Numbers Only");
                    txt_Quantity.Text = "";
                }
                
            }
            catch (Exception)
            {

            }
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
                Item_quantity();
            }
            catch (Exception)
            {

            }
        }
        private void Item_quantity()
        {
            int Row_count = gv_Food_List.Rows.Count;
        }
        private void gv_Food_List_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                calGridview();
            }
            catch (Exception)
            {
            }
        }
        private void gv_Food_List_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                calGridview();
            }
            catch (Exception)
            {
            }
        }
        private void calGridview()
        {
            try
            {
                txt_Total.Text = "0";
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
                        string sql_Item_price = "select Item_Price from Food_Item_List where Item_Name=N'" + Item_name + "'";
                        SqlCommand cmd_price = new SqlCommand(sql_Item_price, con);
                        SqlDataAdapter adp_price = new SqlDataAdapter(cmd_price);
                        DataTable dt_price = new DataTable();
                        adp_price.Fill(dt_price);
                        int Total_price;
                        if (dt_price.Rows.Count > 0)
                        {
                            string Item_price = cmd_price.ExecuteScalar().ToString().Trim();
                            Total_price = Convert.ToInt32(Item_quantity) * Convert.ToInt32(Item_price);
                            cal = cal + Total_price;
                            double GST = (double)18 / 100;
                            double GST1 = (GST * Total_price) / 2;
                            gv_Food_List.Rows[i].Cells[4].Value = GST1;
                            gv_Food_List.Rows[i].Cells[3].Value = Total_price - GST1;
                            gv_Food_List.Rows[i].Cells[5].Value = Total_price;
                            if (txt_Total.Text != "")
                            {
                                txt_Total.Text = Convert.ToString(Convert.ToInt32(txt_Total.Text) + Convert.ToInt32(gv_Food_List.Rows[i].Cells[5].Value));
                            }
                            if (txt_Total.Text == "")
                            {
                                txt_Total.Text = Convert.ToString(Convert.ToInt32(txt_Total.Text) + Convert.ToInt32(gv_Food_List.Rows[i].Cells[5].Value));
                            }
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
                    con.Close();
                }
            }
            catch(Exception)
            {
            }
        }
        private void gv_Food_List_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2) // 1 should be your column index
                {
                    int i;
                    if (!int.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        if (Convert.ToString(e.FormattedValue) != "")
                        {
                            MessageBox.Show("Enter numbers only");
                        }
                        int row = gv_Food_List.CurrentCell.RowIndex;
                        gv_Food_List.Rows[row].Cells[2].Value = 0;
                        gv_Food_List.Update();
                        gv_Food_List.Refresh();

                    }
                }
                if (e.ColumnIndex == 1)
                {
                    int i;
                    if (int.TryParse(Convert.ToString(e.FormattedValue), out i))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Enter valid Item Value");
                        int row = gv_Food_List.CurrentCell.RowIndex;
                        gv_Food_List.Update();
                        gv_Food_List.Refresh();
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void gv_Food_List_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = gv_Food_List.CurrentCell.RowIndex;
                col = gv_Food_List.CurrentCell.ColumnIndex;
                if (col == 1)
                {
                    KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
                    gv_Food_List_KeyDown(gv_Food_List, forKeyDown);
                }
                if (col == 2)
                {
                    try
                    {
                        gv_Food_List.CurrentCell = gv_Food_List[1, row + 1];
                        gv_Food_List.Focus();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception)
            {
            }
        }
        int gridvalue = 0;
        private void gv_Food_List_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && col == 1)
                {
                    int columnIndex = gv_Food_List.CurrentCell.ColumnIndex;
                    if (columnIndex == 2 && gridvalue == 0)
                    {
                        SendKeys.Send("{left}");
                        SendKeys.Send("{down}");
                        gridvalue++;
                    }
                    else
                    {
                        SendKeys.Send("{up}");
                        SendKeys.Send("{right}");
                    }
                }
                if (e.KeyCode == Keys.Enter && col == 2)
                {
                    SendKeys.Send("{up}");
                    SendKeys.Send("{left}");
                }
                
                if (e.KeyCode == Keys.Tab)
                {
                    SendKeys.Send("{up}");
                    SendKeys.Send("{right}");
                }
            }
            catch(Exception ex)
            {
            }
        }
        private void gv_Food_List_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void addItems(AutoCompleteStringCollection col)
        {
        }
        private void gv_Food_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow row_index = gv_Food_List.Rows[e.RowIndex];
                    if (gv_Food_List.Rows.Count > 1)
                    {
                        int row = gv_Food_List.CurrentCell.RowIndex;
                        if (row < gv_Food_List.Rows.Count - 1)
                        {
                            gv_Food_List.Rows.RemoveAt(row);
                            gv_Food_List.CurrentCell = gv_Food_List.Rows[row].Cells[1];
                            gv_Food_List.CurrentCell.Selected = true;
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
            catch(Exception)
            {
            }
        }
        Control Ctrol;
        private void TxtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            Ctrol = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(Ctrol,true,true,true,true);
            }
            return;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int Count = 0;
            for (int i = 0; i < gv_Food_List.Rows.Count; i++)
            {
                Count++;
            }
            gv_Food_List.Rows.Add(Count, TxtItemName.Text.ToString().Trim(),Convert.ToInt32(txt_Quantity.Text.ToString().Trim()));
            TxtItemName.Text = "";
            txt_Quantity.Text = "";
            TxtItemName.Focus();
        }
        private void TxtItemName_Enter(object sender, EventArgs e)
        {
            TxtItemName.BackColor = System.Drawing.Color.Yellow;
        }
        private void TxtItemName_Leave(object sender, EventArgs e)
        {
            TxtItemName.BackColor = System.Drawing.Color.White;
        }
        private void txt_Quantity_Leave(object sender, EventArgs e)
        {
            txt_Quantity.BackColor = System.Drawing.Color.White;
        }
        private void txt_Quantity_Enter(object sender, EventArgs e)
        {
            txt_Quantity.BackColor = System.Drawing.Color.Yellow;
        }
        private void btnAdd_Enter(object sender, EventArgs e)
        {
            btnAdd.BackColor = System.Drawing.Color.Yellow;
        }
        private void btnAdd_Leave(object sender, EventArgs e)
        {
            btnAdd.BackColor = System.Drawing.Color.White;
        }
    }
}