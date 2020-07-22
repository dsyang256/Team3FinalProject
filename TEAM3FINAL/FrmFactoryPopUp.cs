using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using TEAM3FINAL.Services;

namespace TEAM3FINAL
{
    //유효성검사 필요
    public partial class FrmFactoryPopUp : TEAM3FINAL.BaseForm.baseFormPopUP
    {
        public FrmFactoryPopUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(cboCategory.Text == "" || txtCode.Text == "" || cboType.Text == "" || cboParent.Text == "" ||
                txtName.Text == "" || cboUseYN.Text == "")
            {
                MessageBox.Show("필수값 입력 필요");
                return;
            }

            //공통코드 완성 후 콤보박스 바인딩하고 수정이 필요
            FACTORY_VO vo = new FACTORY_VO();
            vo.FAC_CODE = txtCode.Text;
            vo.FAC_FCLTY = cboCategory.Text;
            vo.FAC_FCLTY_PARENT = cboParent.Text;
            vo.FAC_NAME = txtName.Text;
            vo.FAC_TYP = cboType.Text;
            vo.FAC_FREE_YN = cboFreeYN.Text;
            
            //순서 텍스트에 null, 숫자 외 입력시 null 값 입력
            if (int.TryParse(txtSort.Text, out int plzNull))
                vo.FAC_TYP_SORT = plzNull;
            else
                vo.FAC_TYP_SORT = null;
            vo.FAC_DEMAND_YN = cboDemandYN.Text;
            vo.FAC_PROCS_YN = cboProcYN.Text;
            vo.FAC_MTRL_YN = cboMtrlYN.Text;
            vo.FAC_LAST_MDFR = "황현우"; //로그인 작업 후 입력 수정필요
            vo.FAC_USE_YN = cboUseYN.Text;
            vo.FAC_DESC = txtDesc.Text;
            vo.COM_CODE = cboCom.Text;

            FactoryService service = new FactoryService();
            bool result = service.InsertFactory(vo);
            if (result)
                MessageBox.Show("성공");
            else
            {
                MessageBox.Show("실패");
                return;
            }
        }
    }
}
