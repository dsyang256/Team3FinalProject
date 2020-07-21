using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class MyDataGridView : DataGridView
    {
        private Color bounderyColor = Color.FromArgb(52, 52, 52);
        public MyDataGridView()
        {
            InitializeComponent();

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.RowHeadersWidth = 30;
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ColumnHeadersHeight = 50;
            
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.DefaultCellStyle.BackColor = Color.White;
            this.DefaultCellStyle.ForeColor = Color.FromArgb(52, 52, 52);
            this.DefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.BackgroundColor = Color.White;

            this.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
