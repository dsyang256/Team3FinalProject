﻿using System;
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

            //this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 52, 52);
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 246);
            //this.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.Info;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 246);
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            this.DefaultCellStyle.BackColor = Color.White;
            //this.DefaultCellStyle.ForeColor = Color.FromArgb(245, 245, 246);
            this.DefaultCellStyle.ForeColor = Color.Black;
            this.DefaultCellStyle.SelectionBackColor = SystemColors.Menu;
            //this.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText
            //this.DefaultCellStyle.SelectionForeColor = SystemColors.MenuHighlight;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;;

            this.BackgroundColor = Color.White;

            this.RowHeadersDefaultCellStyle.SelectionBackColor = SystemColors.ControlDark;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
