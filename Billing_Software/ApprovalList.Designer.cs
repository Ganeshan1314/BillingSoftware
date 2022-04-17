namespace Billing_Software
{
    partial class ApprovalList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Gridview1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.UniqueID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // Gridview1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gridview1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gridview1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Gridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gridview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UniqueID,
            this.Emp_id,
            this.First_Name,
            this.Last_Name,
            this.UserType,
            this.Status,
            this.Department});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Gridview1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Gridview1.Location = new System.Drawing.Point(160, 175);
            this.Gridview1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Gridview1.Name = "Gridview1";
            this.Gridview1.RowHeadersWidth = 51;
            this.Gridview1.Size = new System.Drawing.Size(1556, 382);
            this.Gridview1.TabIndex = 0;
            this.Gridview1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Gridview1_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(705, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pending Approval";
            // 
            // UniqueID
            // 
            this.UniqueID.DataPropertyName = "UniqueEmpID";
            this.UniqueID.HeaderText = "UniqueID";
            this.UniqueID.MinimumWidth = 6;
            this.UniqueID.Name = "UniqueID";
            this.UniqueID.Visible = false;
            this.UniqueID.Width = 125;
            // 
            // Emp_id
            // 
            this.Emp_id.DataPropertyName = "EmployeeID";
            this.Emp_id.HeaderText = "Employee Id";
            this.Emp_id.MinimumWidth = 6;
            this.Emp_id.Name = "Emp_id";
            this.Emp_id.Width = 150;
            // 
            // First_Name
            // 
            this.First_Name.DataPropertyName = "First_Name";
            this.First_Name.HeaderText = "First Name";
            this.First_Name.MinimumWidth = 6;
            this.First_Name.Name = "First_Name";
            this.First_Name.Width = 200;
            // 
            // Last_Name
            // 
            this.Last_Name.DataPropertyName = "Last_Name";
            this.Last_Name.HeaderText = "Last Name";
            this.Last_Name.MinimumWidth = 6;
            this.Last_Name.Name = "Last_Name";
            this.Last_Name.Width = 200;
            // 
            // UserType
            // 
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "UserType";
            this.UserType.MinimumWidth = 6;
            this.UserType.Name = "UserType";
            this.UserType.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.Width = 125;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "DepartmentName";
            this.Department.HeaderText = "Department";
            this.Department.MinimumWidth = 6;
            this.Department.Name = "Department";
            this.Department.Width = 125;
            // 
            // userdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Billing_Software.Properties.Resources._1900901;
            this.ClientSize = new System.Drawing.Size(1729, 651);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Gridview1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "userdetails";
            this.Text = "userdetails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.Gridview1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Gridview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Gridview1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniqueID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
    }
}