using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmReorderSearchPopUp : TEAM3FINAL.baseFormPopUP
    {
        public string day {get; set; }

        public FrmReorderSearchPopUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            day= dateTimePicker1.Value.ToShortDateString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
