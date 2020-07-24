using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using System.Linq;
using TEAM3FINALDAC;
using System.Diagnostics;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmSignup : TEAM3FINAL.BaseForm.baseFormPopUP
    {
        #region 멤버변수
        List<ComboItemVO> Commonlist = null;
        bool bIDCheck = false;
        #endregion

        #region 생성자

        public FrmSignup()
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
            Commonlist = service.GetCmCode();
            //콤보박스 바인딩 - 부서명
            var codelist = (from item in Commonlist where item.COMMON_PARENT == "DEP" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboDept, codelist, "COMMON_CODE", "COMMON_NAME");
        }

        #endregion

        #region 이벤트
        private void FrmSignup_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();
        }


        /// <summary>
        /// DB에 아이디 중복 조회하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStdCheck_Click(object sender, EventArgs e)
        {
            //유효값확인
            if (!ValidCheck.VaildText(ValidCheck.ContentTypes.ID, txtID.Text.Trim())) //유효값이 아닌경우
            {
                txtID.Clear();
                MessageBox.Show("아이디 형식을 확인해주세요.", "ID 형식 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //DB확인
            LoginService service = new LoginService();
            if (!service.CheckIDExist(txtID.Text.Trim()))
            {
                bIDCheck = true;
                MessageBox.Show("가입이 가능한 ID입니다.");
            }
            else
            {
                MessageBox.Show("이미 존재하는 ID입니다.");
                txtID.Clear();
            }

        }

        /// <summary>
        /// 회원 등록 버튼 클릭시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //ID중복검사여부 확인
            if (!bIDCheck)
            {
                MessageBox.Show("ID의 유효성 검사는 필수입니다.", "ID 중복검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //값 입력 확인
            bool isemptyTextExist = false;
            StringBuilder sb = new StringBuilder();
            foreach (var item in pnlContents.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = item as TextBox;
                    if (tb.Text.Trim().Length < 1)
                    {
                        isemptyTextExist = true;
                        sb.AppendFormat($"<{tb.Tag.ToString()}>");
                    }
                }
            }
            if (isemptyTextExist)
            {
                MessageBox.Show(sb.ToString() + "항목을 입력해주세요.");
                return;
            }


            bool bPwdCheck = ValidCheck.VaildText(ValidCheck.ContentTypes.Password, txtPwd.Text.Trim());
            bool bPwd2Check = (txtPwd.Text == txtPwdCheck.Text);
            bool bNameCheck = ValidCheck.VaildText(ValidCheck.ContentTypes.이름, txtName.Text.Trim());
            bool bEMLCheck = ValidCheck.VaildText(ValidCheck.ContentTypes.Email, txtEML.Text.Trim());

            if (bIDCheck && bPwdCheck && bPwd2Check && bNameCheck && bEMLCheck)
            {
                MANAGER_VO mv = new MANAGER_VO
                {

                    MANAGER_ID = txtID.Text.Trim()
                    ,
                    MANAGER_NAME = txtName.Text.Trim()
                    ,
                    MANAGER_PSWD = txtPwd.Text.Trim()
                    ,
                    MANAGER_EML = txtEML.Text.Trim()
                    ,
                    MANAGER_DEP = cboDept.Text
                };

                //서비스호출
                LoginService service = new LoginService();
                Message msg = service.InsertOrUpdateManager(mv);
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
            else
            {
                MessageBox.Show("유효한 값이 아닙니다. 입력항목들을 확인해주세요.", "입력값 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        /// <summary>
        /// ID입력값 변화시 ID중복확인을 초기화하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            bIDCheck = false;
        }


        #endregion


    }
}
