using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmSMUpLoadPop : TEAM3FINAL.baseFormPopUP
    {
        public FrmSMUpLoadPop()
        {
            InitializeComponent();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            ofdExcel.Filter = "Excel File (*.xlsx)|*.xlsx|Excel File 97~2003 (*.xls)|*.xls|All Files (*.*)|*.*";

            if (this.ofdExcel.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofdExcel.FileName;
            }
        }
    }
}
