using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmLogin : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수

        #endregion

        #region 생성자
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion


        #region 메서드
        ///// <summary>
        ///// 로그인정보를 저장하는 메서드 -OJH
        ///// </summary>
        ///// <param name="loginCustomerVO">고객정보</param>
        //private void SetLoginInfo(mem list)
        //{
        //    if (list == null)
        //        return;
        //    LoginInfo.UserInfo.LI_ID = list.MANAGER_ID;
        //    LoginInfo.UserInfo.LI_NAME = list.MANAGER_NAME;
        //    LoginInfo.UserInfo.LI_DEPT = list.CUSTOMER_PHN_NBR;
        //}

        #endregion

        #region 이벤트

        /// <summary>
        /// 로그인 정보를 확인하고 로그인기능을 수행하는 이벤트 -OJH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string userID = ptxtID.Text.Trim();
            string password = ptxtPswd.Text.Trim();

            //로그인 정보 유효성확인
            bool bISIDValid = ValidCheck.VaildText(ValidCheck.ContentTypes.ID, userID);
            bool bISPswdValid = ValidCheck.VaildText(ValidCheck.ContentTypes.Password, password);

            if (!(bISIDValid && bISPswdValid))
            {
                MessageBox.Show("ID와 비밀번호 형식을 확인하세요.", "로그인 정보 입력", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ptxtID.Clear();
                ptxtPswd.Clear();
                return;
            }

            //DB확인
            LoginService service = new LoginService();
            if (!service.CheckLoginInfo(userID, password))
            {
                MessageBox.Show("존재하지 않는 사용자입니다. 로그인정보를 확인하세요.", "로그인 정보 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ptxtID.Clear();
                ptxtPswd.Clear();
                return;
            }
            else //로그인정보 일치
            {
                //관리자 정보 가져오기
                SaveLoginUserInfo(userID, service);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            ////로그인 정보 저장 (userConfig)
            //SaveUserConfig(userID, password, ckbLoginSave);
            ////로그인 정보 저장  (전역변수)
            //if (loginType == 0) //고객
            //    SetLoginInfo(service.GetCustomerInfo(userID));
            //else
            //    SetLoginInfo(service.GetManagerInfo(userID));
        }


        void SaveLoginUserInfo(string userID, LoginService service)
        {
            var userinfo = service.GetLoginUserInfo(userID);
            LoginInfo.UserInfo.LI_ID = userinfo.MANAGER_ID;
            LoginInfo.UserInfo.LI_NAME = userinfo.MANAGER_NAME;
            LoginInfo.UserInfo.LI_EML = userinfo.MANAGER_EML;
            LoginInfo.UserInfo.LI_SignDate = userinfo.MANAGER_PSWD;
            LoginInfo.UserInfo.LI_DEP = userinfo.MANAGER_DEP;
        }

        /// <summary>
        /// 프로그램을 종료하는 이벤트 -OJH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //프로그램 종료
            Environment.Exit(0);
        }

        /// <summary>
        /// 비밀번호 입력시  암호마스크문자로  변경하는 이벤트 -OJH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptxtPswd_TextChanged(object sender, EventArgs e)
        {
            if (ptxtPswd.Text.Length > 0)
            {
                ptxtPswd.PasswordChar = '*';
            }
        }

        /// <summary>
        /// 비밀번호 입력후 지울시 암호마스크 문자 초기화하는 이벤트 -OJH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptxtPswd_Leave(object sender, EventArgs e)
        {
            if (ptxtPswd.Text.Length == 0)
            {
                ptxtPswd.PasswordChar = '\0';
            }
        }

        /// <summary>
        /// 회원가입 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignup_Click(object sender, EventArgs e)
        {
            //회원가입 버튼클릭

            FrmSignup frm = new FrmSignup();
            frm.ShowDialog();
        }

        #endregion

        private void ptxtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                ptxtPswd.Focus();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ptxtID.Focus();
#if DEBUG
            ptxtID.PlaceHolderText = "";
            ptxtPswd.PlaceHolderText = "";
            ptxtID.Text = "master999";
            ptxtPswd.Text = "Asdf1234@";
#endif

        }

        private void ptxtPswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }
    }
}
