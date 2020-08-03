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
    public partial class FrmSalesMasterPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string SalesID { get; set; }
        #endregion

        #region 생성자
        public FrmSalesMasterPop(InsertOrUpdate iu)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
        }
        public FrmSalesMasterPop(InsertOrUpdate iu, string id)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
            SalesID = id;
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
            var Itemlist = service.GetItemCode();
            var ComList = service.GetCompanyCode();

            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM, Itemlist, "COMMON_NAME", "COMMON_CODE");
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM2, Itemlist, "COMMON_NAME", "COMMON_CODE");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, Itemlist, "COMMON_NAME", "COMMON_CODE");
        }
        #endregion

        private void FrmSalesMasterPop_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();

            ////초기값
            //txtMDFDate.Text = DateTime.Now.ToShortDateString();
            //cboShift.SelectedIndex = 0;
            //cboShiftUseYN.SelectedIndex = 0;
            //cboFcltsCode.SelectedIndex = 1;

            //if (InsertOrUpdate == 2) //수정
            //{
            //    //서비스 호출
            //    ShiftService service = new ShiftService();
            //    var vo = service.GetShiftInfo(ShiftCode);
            //    cboFcltsCode.SelectedIndex = cboFcltsCode.FindStringExact(vo.FCLTS_CODE);
            //    txtFcltsName.Text = vo.FCLTS_NAME;
            //    cboShift.SelectedIndex = cboShift.FindStringExact(vo.SHIFT_TYP);
            //    cboShiftUseYN.SelectedIndex = cboShiftUseYN.FindStringExact(vo.SHIFT_USE_YN);
            //    txtSTARTTIME.Text = vo.SHIFT_STARTTIME.ToString().PadLeft(6, '0'); ;
            //    txtENDTIME.Text = vo.SHIFT_ENDTIME.ToString().PadLeft(6, '0');
            //    dtpApplyStartTime.Value = Convert.ToDateTime(vo.SHIFT_APPLY_STARTTIME);
            //    dtpApplyEndTime.Value = Convert.ToDateTime(vo.SHIFT_APPLY_ENDTIME);
            //    txtPersonDirect.Text = vo.SHIFT_PERSON_DIR.ToString();
            //    txtShiftCode.Text = vo.SHIFT_CODE.ToString();
            //    txtRemark.Text = vo.SHIFT_REMARK;
            //}

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ////유효값 확인
            //bool bStartTime = txtSTARTTIME.Text.Length == 6;
            //bool bEndTime = txtENDTIME.Text.Length == 6;
            //bool bPerson = txtPersonDirect.Text.Length > 0 && int.Parse(txtPersonDirect.Text) > 0;

            //if (!(bStartTime || bEndTime || bPerson))
            //{
            //    MessageBox.Show("필수값을 입력해주세요.", "필수값 입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ////전달 vo 생성
            //SHIFT_VO vo = new SHIFT_VO();
            //vo.SHIFT_CODE = 0; //등록
            //if (InsertOrUpdate == 2)
            //    vo.SHIFT_CODE = int.Parse(txtShiftCode.Text); //수정
            //vo.SHIFT_TYP = cboShift.Text;
            //vo.SHIFT_STARTTIME = int.Parse(txtSTARTTIME.Text);
            //vo.SHIFT_ENDTIME = int.Parse(txtENDTIME.Text);
            //vo.SHIFT_APPLY_STARTTIME = dtpApplyStartTime.Value.ToShortDateString();
            //vo.SHIFT_APPLY_ENDTIME = dtpApplyEndTime.Value.ToShortDateString();
            //vo.SHIFT_PERSON_DIR = int.Parse(txtPersonDirect.Text);
            //vo.SHIFT_USE_YN = cboShiftUseYN.Text;
            //vo.SHIFT_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
            //vo.SHIFT_LAST_MDFY = DateTime.Now.ToShortDateString();
            //vo.SHIFT_REMARK = txtRemark.Text;
            //vo.FCLTS_CODE = cboFcltsCode.Text;

            ////서비스호출
            //ShiftService service = new ShiftService();
            //Message msg = service.InsertOrUpdateShift(vo);
            //if (msg.IsSuccess)
            //{
            //    MessageBox.Show(msg.ResultMessage);
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show(msg.ResultMessage);
            //    return;
            //}

        }

        /// <summary>
        /// 입력값 숫자처리 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
