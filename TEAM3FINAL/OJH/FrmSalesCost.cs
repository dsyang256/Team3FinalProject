using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmSalesCost : TEAM3FINAL.baseForm2, CommonBtn
    {
        public FrmSalesCost()
        {
            InitializeComponent();
        }

        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Insert(object sender, EventArgs e)
        {
            FrmSalesCostPop frm = new FrmSalesCostPop();
            frm.ShowDialog();
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
