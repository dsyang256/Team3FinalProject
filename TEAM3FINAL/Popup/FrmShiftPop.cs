using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmShiftPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string ShiftCode { get; set; }
        #endregion

        #region 생성자
        public FrmShiftPop(InsertOrUpdate iu)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
        }
        public FrmShiftPop(InsertOrUpdate iu, string id)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
            ShiftCode = id;
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
            var Commonlist = service.GetFacilitiesCode();
            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboFcltsCode, Commonlist, "COMMON_NAME", "COMMON_CODE");
        }
        #endregion

        #region 이벤트
        private void ShiftPop_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();

            //초기값
            txtMDFDate.Text = DateTime.Now.ToShortDateString();
            cboShift.SelectedIndex = 0;
            cboShiftUseYN.SelectedIndex = 0;
            cboFcltsCode.SelectedIndex = 1;

            if (InsertOrUpdate == 2) //수정
            {
                //서비스 호출
                ShiftService service = new ShiftService();
                var vo = service.GetShiftInfo(ShiftCode);
                cboFcltsCode.SelectedIndex = cboFcltsCode.FindStringExact(vo.FCLTS_CODE);
                txtFcltsName.Text = vo.FCLTS_NAME;
                cboShift.SelectedIndex = cboShift.FindStringExact(vo.SHIFT_TYP);
                cboShiftUseYN.SelectedIndex = cboShiftUseYN.FindStringExact(vo.SHIFT_USE_YN);
                txtSTARTTIME.Text = vo.SHIFT_STARTTIME.ToString().PadLeft(6, '0'); ;
                txtENDTIME.Text = vo.SHIFT_ENDTIME.ToString().PadLeft(6, '0');
                dtpApplyStartTime.Value = Convert.ToDateTime(vo.SHIFT_APPLY_STARTTIME);
                dtpApplyEndTime.Value = Convert.ToDateTime(vo.SHIFT_APPLY_ENDTIME);
                txtPersonDirect.Text = vo.SHIFT_PERSON_DIR.ToString();
                txtShiftCode.Text = vo.SHIFT_CODE.ToString();
                txtRemark.Text = vo.SHIFT_REMARK;
            }

        }

        /// <summary>
        /// Shift 저장버튼 클릭시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효값 확인
            bool bStartTime = txtSTARTTIME.Text.Length == 6;
            bool bEndTime = txtENDTIME.Text.Length == 6;
            bool bPerson = txtPersonDirect.Text.Length > 0 && int.Parse(txtPersonDirect.Text) > 0;

            if (!(bStartTime || bEndTime || bPerson))
            {
                MessageBox.Show("필수값을 입력해주세요.", "필수값 입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //전달 vo 생성
            SHIFT_VO vo = new SHIFT_VO();
            vo.SHIFT_CODE = 0; //등록
            if (InsertOrUpdate == 2)
                vo.SHIFT_CODE = int.Parse(txtShiftCode.Text); //수정
            vo.SHIFT_TYP = cboShift.Text;
            vo.SHIFT_STARTTIME = int.Parse(txtSTARTTIME.Text);
            vo.SHIFT_ENDTIME = int.Parse(txtENDTIME.Text);
            vo.SHIFT_APPLY_STARTTIME = dtpApplyStartTime.Value.ToShortDateString();
            vo.SHIFT_APPLY_ENDTIME = dtpApplyEndTime.Value.ToShortDateString();
            vo.SHIFT_PERSON_DIR = int.Parse(txtPersonDirect.Text);
            vo.SHIFT_USE_YN = cboShiftUseYN.Text;
            vo.SHIFT_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
            vo.SHIFT_LAST_MDFY = DateTime.Now.ToShortDateString();
            vo.SHIFT_REMARK = txtRemark.Text;
            vo.FCLTS_CODE = cboFcltsCode.Text;

            //서비스호출
            ShiftService service = new ShiftService();
            Message msg = service.InsertOrUpdateShift(vo);
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

        /// <summary>
        /// 직접투입인원 입력값 숫자처리 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPersonDirect_KeyPress(object sender, KeyPressEventArgs e)
        {   //숫자만 입력받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// DateTime Picker 값 변경시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpApplyStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpApplyStartTime.Value > dtpApplyEndTime.Value)
            {
                MessageBox.Show("시작일이 종료일보다 늦을수없습니다.");
                dtpApplyStartTime.Value = dtpApplyEndTime.Value.AddDays(-7);
            }
        }

        /// <summary>
        /// DateTime Picker 값 변경시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpApplyEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpApplyEndTime.Value < dtpApplyStartTime.Value)
            {
                MessageBox.Show("종료일이 시작일보다 빠를수없습니다.");
                dtpApplyEndTime.Value = dtpApplyStartTime.Value.AddDays(7);
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
        /// 설비코드 변경시 설비명 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboFcltsCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFcltsCode.Items.Count > 0)
                txtFcltsName.Text = cboFcltsCode.SelectedValue.ToString();
        }

        /// <summary>
        /// Leave시 시간 입력값 확인 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSTARTTIME_Leave(object sender, EventArgs e)
        {
            if ((txtSTARTTIME.Text.Trim()).Length < 1)
            {
                MessageBox.Show("시간값을 입력하세요.", "필수 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(txtSTARTTIME.Text.Trim()) > 240000)
            {
                txtSTARTTIME.Clear();
                MessageBox.Show("시간은 24시(240000)을 넘을 수 없습니다.", "시간 범위 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSTARTTIME.Text.Trim().Length < 6 || txtSTARTTIME.Text.Trim().Length > 6)
            {
                txtSTARTTIME.Clear();
                MessageBox.Show("시간-분-초 형식(HHMMSS)에 맞게 입력하세요.", "시간 범위 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
    }
}
