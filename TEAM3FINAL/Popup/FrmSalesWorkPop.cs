using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmSalesWorkPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string WOCode { get; set; }
        #endregion
        #region 생성자
        public FrmSalesWorkPop()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            var facList = service.GetFacilitiesCode();
            var itemList = service.GetItemCode();
            var woList = service.GetWOCode();
            var planList = service.GetPlanID();
            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboFC, facList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, itemList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboWO, woList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboPlanID, planList, "COMMON_CODE", "COMMON_NAME");
        }
        #endregion

        private void FrmSalesWorkPop_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();

            //초기값
            txtMDFDate.Text = DateTime.Now.ToShortDateString();
            cboWO.SelectedIndex = 0;
            cboItem.SelectedIndex = 0;
            cboFC.SelectedIndex = 0;
            cboPlanID.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효값 확인
            bool bWO =txtWOcode.Text.Trim().Length > 0;
            bool bQTY = txtPlanQTY.Text.Trim().Length >0;
            bool bWorkSEQ = txtWorkSEQ.Text.Trim().Length > 0;

            if (!(bWO || bQTY || bWorkSEQ))
            {
                MessageBox.Show("필수값을 입력해주세요.", "필수값 입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //전달 vo 생성
            WORKORDERInsert_VO vo = new WORKORDERInsert_VO();
            vo.WO_Code = txtWOcode.Text;
            vo.ITEM_CODE = cboItem.SelectedValue.ToString();
            vo.FCLTS_CODE = cboFC.SelectedValue.ToString();
            vo.WO_PLAN_DATE = dtpPlanDate.Value.ToShortDateString();
            vo.WO_PLAN_STARTTIME = dtpPlanStart.Value.ToShortDateString();
            vo.WO_PLAN_ENDTIME = dtpPlanEnd.Value.ToShortDateString();
            vo.WO_PLAN_QTY =int.Parse( txtPlanQTY.Text.Trim());
            vo.WO_WORK_SEQ = int.Parse(txtWorkSEQ.Text.Trim());
            vo.WO_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
            vo.WO_LAST_MDFY = DateTime.Now.ToShortDateString();
            vo.SALES_WORK_ORDER_ID = cboWO.Text;
            vo.PLAN_ID = cboPlanID.Text;
            vo.WO_REMARK = txtRemark.Text.Trim();

            //서비스호출
         WorkOrderINService service = new WorkOrderINService();
           if(service.InsertWorkOrder(vo))
            {
                MessageBox.Show("등록되었습니다.", "등록 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("등록에 실패하였습니다.", "등록 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlanQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
