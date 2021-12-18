namespace Billing_Software
{
    partial class Sales_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Fromdate = new System.Windows.Forms.DateTimePicker();
            this.todate1 = new System.Windows.Forms.DateTimePicker();
            this.btn_get_details = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Total_Count = new System.Windows.Forms.TextBox();
            this.gv_Report = new System.Windows.Forms.DataGridView();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // Fromdate
            // 
            this.Fromdate.Location = new System.Drawing.Point(281, 87);
            this.Fromdate.Name = "Fromdate";
            this.Fromdate.Size = new System.Drawing.Size(146, 20);
            this.Fromdate.TabIndex = 0;
            this.Fromdate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // todate1
            // 
            this.todate1.Location = new System.Drawing.Point(624, 87);
            this.todate1.Name = "todate1";
            this.todate1.Size = new System.Drawing.Size(146, 20);
            this.todate1.TabIndex = 1;
            // 
            // btn_get_details
            // 
            this.btn_get_details.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_get_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_get_details.Location = new System.Drawing.Point(851, 87);
            this.btn_get_details.Name = "btn_get_details";
            this.btn_get_details.Size = new System.Drawing.Size(94, 34);
            this.btn_get_details.TabIndex = 3;
            this.btn_get_details.Text = "Get Details";
            this.btn_get_details.UseVisualStyleBackColor = false;
            this.btn_get_details.Click += new System.EventHandler(this.btn_get_details_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "From Date";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(539, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(577, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "SALES REPORT";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1006, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Amount";
            // 
            // Total_Count
            // 
            this.Total_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_Count.Location = new System.Drawing.Point(997, 164);
            this.Total_Count.Multiline = true;
            this.Total_Count.Name = "Total_Count";
            this.Total_Count.ReadOnly = true;
            this.Total_Count.Size = new System.Drawing.Size(172, 45);
            this.Total_Count.TabIndex = 11;
            this.Total_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gv_Report
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_Report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_Report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item,
            this.qty,
            this.price,
            this.datetime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_Report.DefaultCellStyle = dataGridViewCellStyle2;
            this.gv_Report.EnableHeadersVisualStyles = false;
            this.gv_Report.Location = new System.Drawing.Point(171, 145);
            this.gv_Report.Name = "gv_Report";
            this.gv_Report.ReadOnly = true;
            this.gv_Report.Size = new System.Drawing.Size(697, 415);
            this.gv_Report.TabIndex = 12;
            // 
            // item
            // 
            this.item.DataPropertyName = "Item_name";
            this.item.HeaderText = "Item Name";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.Width = 200;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "Quantity";
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 150;
            // 
            // price
            // 
            this.price.DataPropertyName = "Price";
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "Date_Time";
            this.datetime.HeaderText = "DateTime";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            this.datetime.Width = 200;
            // 
            // Sales_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billing_Software.Properties.Resources._19009011;
            this.ClientSize = new System.Drawing.Size(1212, 538);
            this.Controls.Add(this.gv_Report);
            this.Controls.Add(this.Total_Count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_get_details);
            this.Controls.Add(this.todate1);
            this.Controls.Add(this.Fromdate);
            this.Name = "Sales_Report";
            this.Text = "Sales_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.Fromdate, 0);
            this.Controls.SetChildIndex(this.todate1, 0);
            this.Controls.SetChildIndex(this.btn_get_details, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.Total_Count, 0);
            this.Controls.SetChildIndex(this.gv_Report, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Fromdate;
        private System.Windows.Forms.DateTimePicker todate1;
        private System.Windows.Forms.Button btn_get_details;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Total_Count;
        private System.Windows.Forms.DataGridView gv_Report;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
    }
}