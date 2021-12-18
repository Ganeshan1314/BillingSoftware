namespace Billing_Software
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbl_FromDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.From_Date = new System.Windows.Forms.DateTimePicker();
            this.To_Date = new System.Windows.Forms.DateTimePicker();
            this.Details = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Drop_Down = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_FromDate
            // 
            this.lbl_FromDate.AutoSize = true;
            this.lbl_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FromDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FromDate.Location = new System.Drawing.Point(435, 71);
            this.lbl_FromDate.Name = "lbl_FromDate";
            this.lbl_FromDate.Size = new System.Drawing.Size(94, 20);
            this.lbl_FromDate.TabIndex = 3;
            this.lbl_FromDate.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(726, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "To Date";
            // 
            // From_Date
            // 
            this.From_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From_Date.Location = new System.Drawing.Point(535, 69);
            this.From_Date.Name = "From_Date";
            this.From_Date.Size = new System.Drawing.Size(172, 22);
            this.From_Date.TabIndex = 5;
            this.From_Date.ValueChanged += new System.EventHandler(this.From_Date_ValueChanged);
            // 
            // To_Date
            // 
            this.To_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To_Date.Location = new System.Drawing.Point(805, 67);
            this.To_Date.Name = "To_Date";
            this.To_Date.Size = new System.Drawing.Size(169, 22);
            this.To_Date.TabIndex = 6;
            // 
            // Details
            // 
            this.Details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Details.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Details.Location = new System.Drawing.Point(1018, 64);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(117, 23);
            this.Details.TabIndex = 7;
            this.Details.Text = "Get Report";
            this.Details.UseVisualStyleBackColor = true;
            this.Details.Click += new System.EventHandler(this.Search_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(28, 130);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.Color.Yellow;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Sales";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1308, 396);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // Drop_Down
            // 
            this.Drop_Down.FormattingEnabled = true;
            this.Drop_Down.Location = new System.Drawing.Point(277, 73);
            this.Drop_Down.Name = "Drop_Down";
            this.Drop_Down.Size = new System.Drawing.Size(121, 21);
            this.Drop_Down.TabIndex = 9;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billing_Software.Properties.Resources._1900901;
            this.ClientSize = new System.Drawing.Size(1135, 538);
            this.Controls.Add(this.Drop_Down);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.To_Date);
            this.Controls.Add(this.From_Date);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_FromDate);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Controls.SetChildIndex(this.lbl_FromDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.From_Date, 0);
            this.Controls.SetChildIndex(this.To_Date, 0);
            this.Controls.SetChildIndex(this.Details, 0);
            this.Controls.SetChildIndex(this.chart1, 0);
            this.Controls.SetChildIndex(this.Drop_Down, 0);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_FromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker From_Date;
        private System.Windows.Forms.DateTimePicker To_Date;
        private System.Windows.Forms.Button Details;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox Drop_Down;
    }
}