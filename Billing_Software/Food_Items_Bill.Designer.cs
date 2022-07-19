namespace Billing_Software
{
    partial class s
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.gv_Food_List = new System.Windows.Forms.DataGridView();
            this.SNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Btn_checkout = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Food_List)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(810, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = " Billing";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(468, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(601, 184);
            this.txt_Quantity.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Quantity.Multiline = true;
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(120, 29);
            this.txt_Quantity.TabIndex = 5;
            this.txt_Quantity.Enter += new System.EventHandler(this.txt_Quantity_Enter);
            this.txt_Quantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Quantity_KeyDown);
            this.txt_Quantity.Leave += new System.EventHandler(this.txt_Quantity_Leave);
            // 
            // gv_Food_List
            // 
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_Food_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.gv_Food_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Food_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNO,
            this.Item_name,
            this.Quantity,
            this.Item_Id,
            this.Tax,
            this.Total,
            this.Delete});
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_Food_List.DefaultCellStyle = dataGridViewCellStyle51;
            this.gv_Food_List.EnableHeadersVisualStyles = false;
            this.gv_Food_List.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gv_Food_List.Location = new System.Drawing.Point(63, 329);
            this.gv_Food_List.Margin = new System.Windows.Forms.Padding(4);
            this.gv_Food_List.Name = "gv_Food_List";
            this.gv_Food_List.RowHeadersWidth = 51;
            this.gv_Food_List.Size = new System.Drawing.Size(1317, 489);
            this.gv_Food_List.TabIndex = 7;
            this.gv_Food_List.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellClick);
            this.gv_Food_List.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellContentClick);
            this.gv_Food_List.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellEndEdit);
            this.gv_Food_List.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellEnter);
            this.gv_Food_List.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellLeave);
            this.gv_Food_List.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gv_Food_List_CellValidating);
            this.gv_Food_List.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gv_Food_List_EditingControlShowing);
            this.gv_Food_List.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Food_List_RowHeaderMouseClick);
            this.gv_Food_List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_Food_List_KeyDown);
            // 
            // SNO
            // 
            this.SNO.HeaderText = "SNO";
            this.SNO.MinimumWidth = 6;
            this.SNO.Name = "SNO";
            this.SNO.Width = 125;
            // 
            // Item_name
            // 
            this.Item_name.DataPropertyName = "Item_name";
            this.Item_name.HeaderText = "Item Name";
            this.Item_name.MinimumWidth = 6;
            this.Item_name.Name = "Item_name";
            this.Item_name.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Bill_Id";
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Id.DefaultCellStyle = dataGridViewCellStyle50;
            this.Item_Id.HeaderText = "Taxable";
            this.Item_Id.MinimumWidth = 6;
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.ReadOnly = true;
            this.Item_Id.Width = 125;
            // 
            // Tax
            // 
            this.Tax.HeaderText = "Tax";
            this.Tax.MinimumWidth = 6;
            this.Tax.Name = "Tax";
            this.Tax.ReadOnly = true;
            this.Tax.Width = 125;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Price";
            this.Total.HeaderText = "Amount";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 125;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Bill_Id";
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 125;
            // 
            // Btn_checkout
            // 
            this.Btn_checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_checkout.Location = new System.Drawing.Point(1400, 827);
            this.Btn_checkout.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_checkout.Name = "Btn_checkout";
            this.Btn_checkout.Size = new System.Drawing.Size(137, 54);
            this.Btn_checkout.TabIndex = 12;
            this.Btn_checkout.Text = "Print Bill";
            this.Btn_checkout.UseVisualStyleBackColor = true;
            this.Btn_checkout.Click += new System.EventHandler(this.Btn_checkout_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(1096, 855);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 26);
            this.label8.TabIndex = 17;
            this.label8.Text = "Total";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(1212, 841);
            this.txt_Total.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Total.Multiline = true;
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(168, 40);
            this.txt_Total.TabIndex = 18;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(689, 173);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(137, 125);
            this.crystalReportViewer1.TabIndex = 19;
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 614);
            this.crystalReportViewer2.Margin = new System.Windows.Forms.Padding(4);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(292, 297);
            this.crystalReportViewer2.TabIndex = 19;
            this.crystalReportViewer2.ToolPanelWidth = 267;
            this.crystalReportViewer2.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(414, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 34);
            this.label2.TabIndex = 20;
            this.label2.Text = "Item Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(815, 184);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 35);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.Enter += new System.EventHandler(this.btnAdd_Enter);
            this.btnAdd.Leave += new System.EventHandler(this.btnAdd_Leave);
            // 
            // TxtItemName
            // 
            this.TxtItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtItemName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.TxtItemName.Location = new System.Drawing.Point(601, 104);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(435, 34);
            this.TxtItemName.TabIndex = 23;
            this.TxtItemName.Enter += new System.EventHandler(this.TxtItemName_Enter);
            this.TxtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtItemName_KeyDown);
            this.TxtItemName.Leave += new System.EventHandler(this.TxtItemName_Leave);
            // 
            // s
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billing_Software.Properties.Resources._1900901;
            this.ClientSize = new System.Drawing.Size(1669, 911);
            this.Controls.Add(this.TxtItemName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Btn_checkout);
            this.Controls.Add(this.gv_Food_List);
            this.Controls.Add(this.txt_Quantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "s";
            this.Text = "Food_Items_Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Food_Items_Bill_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_Quantity, 0);
            this.Controls.SetChildIndex(this.gv_Food_List, 0);
            this.Controls.SetChildIndex(this.Btn_checkout, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txt_Total, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.TxtItemName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Food_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.DataGridView gv_Food_List;
        private System.Windows.Forms.Button Btn_checkout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Total;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox TxtItemName;
    }
}