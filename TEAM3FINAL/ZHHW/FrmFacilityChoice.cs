using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    
    public partial class FrmFacilityChoice : TEAM3FINAL.baseFormPopUP
    {
        /// <summary>
        /// true : 설비군 입력/수정/삭제 , false : 설비 입력/수정/삭제
        /// </summary>
        public bool FacilityAndGroup { get; set; } 

        public FrmFacilityChoice()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FacilityAndGroup = true; 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FacilityAndGroup = false;
            this.Close();
        }
    }
}
