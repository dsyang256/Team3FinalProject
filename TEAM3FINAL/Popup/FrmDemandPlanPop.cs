using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL.Popup
{
    public partial class FrmDemandPlanPop : TEAM3FINAL.baseFormPopUP
    {
        bool IsCheckEnable = false;
        public string PlanID { get; set; }
        public FrmDemandPlanPop()
        {
            InitializeComponent();
        }

        private void BindingComboBox()
        {
            ////서비스호출
            ComboItemService service = new ComboItemService();

            var planlist = service.GetPlanID();
            CommonUtil.ComboBinding<ComboItemVO>(cboPlan, planlist, "COMMON_CODE", "COMMON_NAME");
        }

        private void FrmDemandPlanPop_Load(object sender, EventArgs e)
        {
            BindingComboBox();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //생성가능여부 확인
            PlanService service = new PlanService();
            var result = service.CheckDemandPlan(cboPlan.Text);
            if (result.Length > 0)
            {
                MessageBox.Show($"생산계획을 생성할 수 없습니다. [{result}] SHIFT를 확인하세요.", "생산계획 생성 불가", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"생산계획을 생성할 수 있습니다.", "생산계획 생성 가능", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsCheckEnable = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsCheckEnable)
            {
                PlanID = cboPlan.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"가능 여부를 확인하세요.", "계획 생성 여부 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsCheckEnable = false;
        }
    }
}
