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
        #region Property
        public bool Update { get; set; }
        public string FAC_CODE { get; set; } //시설코드*
        public string FAC_FCLTY { get; set; } //시설군*
        public string FAC_FCLTY_PARENT { get; set; } //상위시설*
        public string FAC_NAME { get; set; } //시설명*
        public string FAC_TYP { get; set; } //시설구분*
        public string FAC_FREE_YN { get; set; } //유무상구분
        public int? FAC_TYP_SORT { get; set; } //순서
        public string FAC_DEMAND_YN { get; set; } //수요차감
        public string FAC_PROCS_YN { get; set; } //공정차감
        public string FAC_MTRL_YN { get; set; } //자재차감
        public string FAC_LAST_MDFR { get; set; } //수정자
        public string FAC_LAST_MDFY { get; set; } //수정날짜 DB getdate 사용
        public string FAC_USE_YN { get; set; } //사용유무*
        public string FAC_DESC { get; set; } //시설설명
        public string COM_CODE { get; set; } //업체코드
        #endregion
        public FrmFactoryPopUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 공장등록
            if (cboCategory.Text == "" || txtCode.Text == "" || cboType.Text == "" || cboParent.Text == "" ||
                txtName.Text == "" || cboUseYN.Text == "")
            {
                MessageBox.Show("필수정보 입력 필요");
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
            string result = service.InsertFactory(vo);
            if (result == "C200")
            {
                MessageBox.Show("성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("실패");
                return;
            }
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }

        private void FrmFactoryPopUp_Load(object sender, EventArgs e)
        {
            if(Update)
            {
                txtCode.Enabled = false;
                cboCategory.Text = FAC_FCLTY;
                txtCode.Text = FAC_CODE;
                cboType.Text = FAC_TYP;
                txtSort.Text = FAC_TYP_SORT.ToString();
                cboDemandYN.Text = FAC_DEMAND_YN;
                cboMtrlYN.Text = FAC_MTRL_YN;
                txtDesc.Text = FAC_DESC;
                cboParent.Text = FAC_FCLTY_PARENT;
            }
        }
    }
}
