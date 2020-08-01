using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public enum InsertOrUpdate
    {
        insert = 1, update = 2
    }

    public partial class FrmMaterialCostPop : TEAM3FINAL.baseFormPopUP
    {

        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string MCCode { get; set; }
        #endregion

        #region 생성자
        public FrmMaterialCostPop(InsertOrUpdate iu)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
        }
        public FrmMaterialCostPop(InsertOrUpdate iu, string id)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
            MCCode = id;
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var ComList = service.GetCompanyCode();
            var ItemList = service.GetItemCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboCompany, ComList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, ItemList, "COMMON_CODE", "COMMON_NAME");
        }
        #endregion

        #region 이벤트
        /// <summary>
        /// 시작시간 KeyPress 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSTARTTIME_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 폼 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 저장이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            //유효성 검사
            if (!(txtNowPrice.Text.Trim().Length > 0))
            {
                MessageBox.Show("현재단가는 입력 필수값입니다.", "필수 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(txtExPrice.Text.Trim().Length > 0))
            {
                MessageBox.Show("이전단가는 입력 필수값입니다.", "필수 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //전달할 VO
            MaterialCost_VO vo = new MaterialCost_VO();
            vo.COM_Code = cboCompany.SelectedValue.ToString();
            vo.ITEM_Code = cboItem.SelectedValue.ToString();
            vo.MC_UNITPRICE_CUR = int.Parse(txtNowPrice.Text);
            vo.MC_UNITPRICE_EX = int.Parse(txtExPrice.Text);
            vo.MC_STARTDATE = dtpStartDate.Value.ToShortDateString();
            vo.MC_ENDDATE = Convert.ToDateTime(txtEndDate.Text).ToShortDateString();
            vo.MC_USE_YN = cboUseYN.Text;
            vo.MC_Code = 0; //등록
            if (InsertOrUpdate == 2)
                vo.MC_Code = int.Parse(txtCode.Text); //수정
            vo.MC_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
            vo.MC_LAST_MDFY = txtMDFDate.Text;
            vo.MC_REMARK = txtRemark.Text.Trim();

            //서비스호출
            CostService service = new CostService();
            var msg = service.InsertOrUpdateMaterialCost(vo);
            if (msg.IsSuccess)
            {
                MessageBox.Show(msg.ResultMessage);
                this.Close();
            }
            else
            {
                MessageBox.Show(msg.ResultMessage);
                return;
            }
        }


        private void FrmMaterialCostPop_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();

            cboUseYN.SelectedIndex = 0;
            txtMDFDate.Text = DateTime.Now.ToShortDateString();
            if (InsertOrUpdate == 1) //등록
            {
                txtExPrice.ReadOnly = false;
            }
            else //수정
            {
                txtExPrice.ReadOnly = true;

                //서비스 호출
                CostService service = new CostService();
                var vo = service.GetCostInfo(MCCode);
                cboCompany.SelectedIndex = cboCompany.FindStringExact(vo.COM_NAME);
                cboItem.SelectedIndex = cboItem.FindStringExact(vo.ITEM_NAME);
                cboUseYN.SelectedIndex = cboUseYN.FindStringExact(vo.MC_USE_YN);
                txtNowPrice.Text = vo.MC_UNITPRICE_CUR.ToString();
                txtExPrice.Text = vo.MC_UNITPRICE_EX.ToString();
                dtpStartDate.Value = Convert.ToDateTime(vo.MC_STARTDATE);
                txtEndDate.Text = vo.MC_ENDDATE;
                txtRemark.Text = vo.MC_REMARK;
                txtCode.Text = vo.MC_Code.ToString();
            }

        }

        #endregion


    }
}
