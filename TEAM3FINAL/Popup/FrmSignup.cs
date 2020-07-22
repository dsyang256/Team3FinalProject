using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using System.Linq;

namespace TEAM3FINAL
{
    public partial class FrmSignup : TEAM3FINAL.BaseForm.baseFormPopUP
    {
        #region 멤버변수
        List<ComboItemVO> Commonlist = null;
        #endregion

        #region 생성자

        public FrmSignup()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드

        #endregion

        #region 이벤트
        private void FrmSignup_Load(object sender, EventArgs e)
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            Commonlist = service.GetCmCode();
            //콤보박스 바인딩
            var codelist = (from item in Commonlist where item.COMMON_PARENT == "DEPT" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboDept, codelist, "COMMON_CODE", "COMMON_CODE_NAME", "");
        }
        private void btnStdCheck_Click(object sender, EventArgs e)
        {
            ////수강생ID 중복확인
            //Util pu = new PersonUtil();
            //if (!pu.VaildText(1, ptxtID.Text))
            //{
            //    ptxtID.Clear();
            //    MessageBox.Show("회원ID는 11자 이내의 영문소문자 및 숫자로 입력하세요.");
            //    return;
            //}
            ////DB확인
            //PersonDB pdb = new PersonDB();
            //if (!pdb.CheckID(ptxtID.Text.Trim(), 1))
            //{
            //    validID = ptxtID.Text.Trim();
            //    IDState = true;
            //    MessageBox.Show("가입이 가능한 ID입니다.");
            //}
            //else
            //{
            //    MessageBox.Show("이미 존재하는 ID입니다.");
            //}
            //
        }



        #endregion



    }
}
