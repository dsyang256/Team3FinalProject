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
        public FrmShiftPop()
        {
            InitializeComponent();
        }

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            var Commonlist = service.GetFacilitiesCode();
            //콤보박스 바인딩 - 부서명
            CommonUtil.ComboBinding<ComboItemVO>(cboFcltsCode, Commonlist, "COMMON_CODE", "COMMON_NAME");
        }

        #endregion


        #region 이벤트
        /// <summary>
        /// Shift 저장버튼 클릭시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtShiftCode.Text.Length < 1) //등록인경우
            {
                bool bFclts = cboFcltsCode.Text.Length > 0;
                bool bShift = cboShift.Text.Length > 0;
                bool bUse = cboShiftUseYN.Text.Length > 0;
                bool bStartTime = txtSTARTTIME.Text.Length == 6;
                bool bEndTime = txtENDTIME.Text.Length == 6;
                bool bPerson = txtPersonDirect.Text.Length > 0 && int.Parse(txtPersonDirect.Text) > 0;

                if (!(bFclts || bShift || bUse || bStartTime || bEndTime || bPerson))
                {
                    MessageBox.Show("필수값을 입력해주세요.", "필수값 입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //전달 vo 생성
                SHIFT_VO vo = new SHIFT_VO();
                vo.SHIFT_STARTTIME = int.Parse(txtSTARTTIME.Text);
                vo.SHIFT_ENDTIME = int.Parse(txtENDTIME.Text);
                vo.SHIFT_APPLY_STARTTIME = dtpApplyStartTime.Value.ToShortDateString();
                vo.SHIFT_APPLY_ENDTIME = dtpApplyEndTime.Value.ToShortDateString();
                vo.SHIFT_PERSON_DIR = int.Parse(txtPersonDirect.Text);
                vo.SHIFT_USE_YN = cboShiftUseYN.Text;
                vo.SHIFT_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                vo.SHIFT_LAST_MDFY = DateTime.Now;
                vo.SHIFT_REMARK = txtRemark.Text;
                vo.FCLTS_CODE = cboFcltsCode.Text;
                vo.SHIFT_TYP = cboShift.Text;

                //서비스호출
                ShiftService service = new ShiftService();
                Message msg = service.SaveShiftInfo(vo);
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
            else //수정인경우
            {

            }
        }

        private void ShiftPop_Load(object sender, EventArgs e)
        {
            //수정일 입력
            txtMDFDate.Text = DateTime.Now.ToShortDateString();

            //콤보박스 바인딩
            BindingComboBox();
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
        #endregion
    }
}
