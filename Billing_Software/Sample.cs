using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billing_Software
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
        }

        private void Sample_Load(object sender, EventArgs e)
        {
            
        }
        
       
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int col = dataGridView1.CurrentCell.ColumnIndex;
            if (col == 0 || col == 1)
            {
                KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
                dataGridView1_KeyDown(dataGridView1, forKeyDown);
            }
            if(col == 2)
            {
                SendKeys.Send("{home}");
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
            
        }
    }
}
