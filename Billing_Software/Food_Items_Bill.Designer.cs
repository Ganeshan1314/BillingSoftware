namespace Billing_Software
{
    partial class Food_Items_Bill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddl_Item_Name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.gv_Food_List = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_checkout = new System.Windows.Forms.Button();
            this.txt_Cgst = new System.Windows.Forms.TextBox();
            this.txt_Billamount = new System.Windows.Forms.TextBox();
            this.txt_sgst = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txt_ItemId = new System.Windows.Forms.TextBox();
            this.Item_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Food_List)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(423, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Food Item Bill";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item Name";
            this.label2.Visible = false;
            // 
            // ddl_Item_Name
            // 
            this.ddl_Item_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddl_Item_Name.FormattingEnabled = true;
            this.ddl_Item_Name.Location = new System.Drawing.Point(179, 148);
            this.ddl_Item_Name.Name = "ddl_Item_Name";
            this.ddl_Item_Name.Size = new System.Drawing.Size(121, 24);
            this.ddl_Item_Name.TabIndex = 3;
            this.ddl_Item_Name.Text = "--Select--";
            this.ddl_Item_Name.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(327, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity";
            this.label3.Visible = false;
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(476, 151);
            this.txt_Quantity.Multiline = true;
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(91, 24);
            this.txt_Quantity.TabIndex = 5;
            this.txt_Quantity.Visible = false;
            this.txt_Quantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Quantity_KeyDown);
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(600, 153);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 6;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Visible = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // gv_Food_List
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_Food_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv_Food_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Food_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_Id,
            this.Item_name,
            this.Quantity,
            this.Total,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_Food_List.DefaultCellStyle = dataGridViewCellStyle3;
            this.gv_Food_List.EnableHeadersVisualStyles = false;
            this.gv_Food_List.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gv_Food_List.Location = new System.Drawing.Point(72, 124);
            this.gv_Food_List.Name = "gv_Food_List";
            this.gv_Food_List.Size = new System.Drawing.Size(651, 397);
            this.gv_Food_List.TabIndex = 7;
            this.gv_Food_List.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellContentClick);
            this.gv_Food_List.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellEndEdit);
            this.gv_Food_List.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellEnter);
            this.gv_Food_List.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Food_List_CellLeave);
            this.gv_Food_List.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gv_Food_List_CellValidating);
            this.gv_Food_List.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gv_Food_List_EditingControlShowing);
            this.gv_Food_List.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Food_List_RowHeaderMouseClick);
            this.gv_Food_List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_Food_List_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(920, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Total Bill Amount";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(893, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bill";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(864, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "CGST";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(864, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "SGST";
            // 
            // Btn_checkout
            // 
            this.Btn_checkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_checkout.Location = new System.Drawing.Point(963, 455);
            this.Btn_checkout.Name = "Btn_checkout";
            this.Btn_checkout.Size = new System.Drawing.Size(103, 44);
            this.Btn_checkout.TabIndex = 12;
            this.Btn_checkout.Text = "Print Bill";
            this.Btn_checkout.UseVisualStyleBackColor = true;
            this.Btn_checkout.Click += new System.EventHandler(this.Btn_checkout_Click);
            // 
            // txt_Cgst
            // 
            this.txt_Cgst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cgst.Location = new System.Drawing.Point(1020, 215);
            this.txt_Cgst.Multiline = true;
            this.txt_Cgst.Name = "txt_Cgst";
            this.txt_Cgst.ReadOnly = true;
            this.txt_Cgst.Size = new System.Drawing.Size(127, 33);
            this.txt_Cgst.TabIndex = 14;
            // 
            // txt_Billamount
            // 
            this.txt_Billamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Billamount.Location = new System.Drawing.Point(1020, 151);
            this.txt_Billamount.Multiline = true;
            this.txt_Billamount.Name = "txt_Billamount";
            this.txt_Billamount.ReadOnly = true;
            this.txt_Billamount.Size = new System.Drawing.Size(127, 31);
            this.txt_Billamount.TabIndex = 15;
            // 
            // txt_sgst
            // 
            this.txt_sgst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sgst.Location = new System.Drawing.Point(1020, 288);
            this.txt_sgst.Multiline = true;
            this.txt_sgst.Name = "txt_sgst";
            this.txt_sgst.ReadOnly = true;
            this.txt_sgst.Size = new System.Drawing.Size(127, 33);
            this.txt_sgst.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(876, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Total";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(1020, 363);
            this.txt_Total.Multiline = true;
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(127, 33);
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
            this.crystalReportViewer2.Location = new System.Drawing.Point(17, 527);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(615, 192);
            this.crystalReportViewer2.TabIndex = 19;
            this.crystalReportViewer2.Visible = false;
            // 
            // txt_ItemId
            // 
            this.txt_ItemId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_ItemId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_ItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ItemId.Location = new System.Drawing.Point(179, 94);
            this.txt_ItemId.Multiline = true;
            this.txt_ItemId.Name = "txt_ItemId";
            this.txt_ItemId.Size = new System.Drawing.Size(91, 24);
            this.txt_ItemId.TabIndex = 22;
            this.txt_ItemId.Visible = false;
            // 
            // Item_Id
            // 
            this.Item_Id.DataPropertyName = "Bill_Id";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item_Id.DefaultCellStyle = dataGridViewCellStyle2;
            this.Item_Id.HeaderText = "Item Id";
            this.Item_Id.Name = "Item_Id";
            this.Item_Id.ReadOnly = true;
            // 
            // Item_name
            // 
            this.Item_name.DataPropertyName = "Item_name";
            this.Item_name.HeaderText = "Item Name";
            this.Item_name.Name = "Item_name";
            this.Item_name.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Price";
            this.Total.HeaderText = "Price";
            this.Total.Name = "Total";
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Bill_Id";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // Food_Items_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billing_Software.Properties.Resources._1900901;
            this.ClientSize = new System.Drawing.Size(1252, 740);
            this.Controls.Add(this.txt_ItemId);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.txt_Total);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_sgst);
            this.Controls.Add(this.txt_Billamount);
            this.Controls.Add(this.txt_Cgst);
            this.Controls.Add(this.Btn_checkout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gv_Food_List);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.txt_Quantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddl_Item_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Food_Items_Bill";
            this.Text = "Food_Items_Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Food_Items_Bill_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.ddl_Item_Name, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txt_Quantity, 0);
            this.Controls.SetChildIndex(this.Add, 0);
            this.Controls.SetChildIndex(this.gv_Food_List, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.Btn_checkout, 0);
            this.Controls.SetChildIndex(this.txt_Cgst, 0);
            this.Controls.SetChildIndex(this.txt_Billamount, 0);
            this.Controls.SetChildIndex(this.txt_sgst, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txt_Total, 0);
            this.Controls.SetChildIndex(this.crystalReportViewer2, 0);
            this.Controls.SetChildIndex(this.txt_ItemId, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Food_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddl_Item_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView gv_Food_List;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_checkout;
        private System.Windows.Forms.TextBox txt_Cgst;
        private System.Windows.Forms.TextBox txt_Billamount;
        private System.Windows.Forms.TextBox txt_sgst;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Total;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
        private System.Windows.Forms.TextBox txt_ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}