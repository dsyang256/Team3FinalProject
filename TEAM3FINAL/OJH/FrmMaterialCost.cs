using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmMaterialCost : TEAM3FINAL.baseForm2, CommonBtn
    {
        public FrmMaterialCost()
        {
            InitializeComponent();
        }

        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Insert(object sender, EventArgs e)
        {
            FrmMaterialCostPop frm = new FrmMaterialCostPop();
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
