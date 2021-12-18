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
using System.Windows.Forms.DataVisualization.Charting;

namespace Billing_Software
{
    public partial class Dashboard : MasterForm
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        public Dashboard()
        {
            InitializeComponent();
            Drop_Down.Items.Add("--Select--");
            Drop_Down.Items.Add("Date");
            Drop_Down.Items.Add("Month ");
            Drop_Down.Items.Add("--Select--");
        }

        private void user_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration reg = new Registration();
            reg.Show();
        }

        private void Billing_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Food_Items_Bill Billing = new Food_Items_Bill();
            Billing.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Load_graph_Click(object sender, EventArgs e)
        {

            

            this.chart1.Series["Age"].Points.AddXY("Max",33);
            this.chart1.Series["Age"].Points.AddXY("Carl",20);
            this.chart1.Series["Age"].Points.AddXY("Mark",50);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
            this.chart1.Series["Age"].Points.AddXY("Alli",40);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            chart1.Series["Sales"].Points.Clear();
            TimeSpan Tot_Days = Convert.ToDateTime(From_Date.Text.Trim()) - Convert.ToDateTime(To_Date.Text.Trim());
            for (DateTime From = DateTime.Parse(From_Date.Text.Trim()); From <= DateTime.Parse(To_Date.Text.Trim()); From = From.AddDays(1))
            {
                string from_date = DateTime.Parse(From_Date.Text.Trim()).ToString("yyyy- MM - dd") + " 00:00:00";
                string to_date = DateTime.Parse(To_Date.Text.Trim()).AddDays(1).ToString("yyyy-MM-dd") + " 23:59:59";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_select_data";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@From_date", From);
                cmd.Parameters.AddWithValue("@To_date", From.AddDays(1));
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                int Total;
                if (Convert.ToString(result) != "")
                {
                    Total = Convert.ToInt16(result);
                }
                else
                {
                    Total = 30;
                }
                this.chart1.Series["Sales"].Points.AddXY(From.ToString("yyyy- MM - dd"), Total);
                chart1.Series["Sales"].IsValueShownAsLabel = true;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
                //chart1.AxisX.ScrollBar.Enabled = true;

            }
            chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            

        }

        private void From_Date_ValueChanged(object sender, EventArgs e)
        {
            To_Date.MinDate = Convert.ToDateTime(From_Date.Text);
        }
        //DataPoint _prevPoint;
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

            
        }
    }
}
