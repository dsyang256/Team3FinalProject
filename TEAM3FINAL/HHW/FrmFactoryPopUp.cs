using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using TEAM3FINAL.Services;
using System.Linq;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    //유효성검사 필요
    public partial class FrmFactoryPopUp : TEAM3FINAL.baseFormPopUP
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
            #region 공장등록 & 수정
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
            vo.FAC_LAST_MDFR = txtModifier.Text;
            vo.FAC_LAST_MDFY = txtModifyDate.Text;
            vo.FAC_USE_YN = cboUseYN.Text;
            vo.FAC_DESC = txtDesc.Text;
            vo.COM_CODE = cboCom.Text;


            FactoryService service = new FactoryService();
            Message msg = service.SaveFactory(vo, Update);
            if (msg.IsSuccess)
            {
                MessageBox.Show(msg.ResultMessage);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(msg.ResultMessage);
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
            ComboBinding();
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            txtModifier.Text = FAC_LAST_MDFR;
            txtModifyDate.Text = FAC_LAST_MDFY;
            if (Update)
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
                txtName.Text = FAC_NAME;
                cboFreeYN.Text = FAC_FREE_YN;
                cboCom.Text = COM_CODE;
                cboProcYN.Text = FAC_PROCS_YN;
                cboUseYN.Text = FAC_USE_YN;
            }
        }

        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listCOMPANY_TYP = (from item in commonlist where item.COMMON_PARENT == "COMPANY_TYP" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboCategory, listCOMPANY_TYP, "COMMON_CODE", "COMMON_NAME", "");

            var listFACILITY_TYPE = (from item in commonlist where item.COMMON_PARENT == "FACILITY_TYPE" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboType, listFACILITY_TYPE, "COMMON_CODE", "COMMON_NAME", "");

            var listYN1 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboDemandYN, listYN1, "COMMON_CODE", "COMMON_NAME", "");
            var listYN2 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboMtrlYN, listYN2, "COMMON_CODE", "COMMON_NAME");
            var listYN3 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFreeYN, listYN3, "COMMON_CODE", "COMMON_NAME");
            var listYN4 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboProcYN, listYN4, "COMMON_CODE", "COMMON_NAME");
            var listYN5 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboUseYN, listYN5, "COMMON_CODE", "COMMON_NAME");
        }
    }
}
