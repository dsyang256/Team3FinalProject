using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmCompanyPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region property
        public bool Update { get; set; }
        public string COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string COM_TYP { get; set; }
        public string COM_CEO { get; set; }
        public string COM_REG_NUM { get; set; }
        public string COM_TYP_INDSTRY { get; set; }
        public string COM_TYP_BSNS { get; set; }
        public string COM_MANAGER { get; set; }
        public string COM_EML { get; set; }
        public string COM_TEL { get; set; }
        public string COM_FAX { get; set; }
        public string COM_AUTOIN_YN { get; set; }
        public string COM_START_YN { get; set; }
        public string COM_USE_YN { get; set; }
        public string COM_LAST_MDFR { get; set; }
        public string COM_LAST_MDFY { get; set; }
        public string COM_STR_DATE { get; set; }
        public string COM_END_DATE { get; set; }
        public string COM_INFO { get; set; }
        public string COM_TRAD_YN { get; set; }

        #endregion

        public FrmCompanyPopUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }

        private void FrmCompanyPopUp_Load(object sender, EventArgs e)
        {
            ComboBinding();
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            txtModifier.Text = COM_LAST_MDFR;
            txtModifyDate.Text = COM_LAST_MDFY;

            if (Update)
            {
                txtComCode.Text = COM_CODE;
                txtComName.Text = COM_NAME;
                txtComType.Text = COM_TYP;
                txtOwnerName.Text = COM_CEO;
                txtRegNum.Text = COM_REG_NUM;
                cboComType.Text = COM_TYP_INDSTRY;
                txtTypeTEA.Text = COM_TYP_BSNS;
                txtManager.Text = COM_MANAGER;
                txtEmail.Text = COM_EML;
                txtTell.Text = COM_TEL;
                dtpStart.Value = Convert.ToDateTime(COM_STR_DATE); //주의
                dtpEnd.Value = Convert.ToDateTime(COM_END_DATE);
                cboTradeYN.Text = COM_TRAD_YN;
                txtFAX.Text = COM_FAX;
                cboAutoYN.Text = COM_AUTOIN_YN;
                cboStartYN.Text = COM_START_YN;
                cboUseYN.Text = COM_USE_YN;
                txtComDesc.Text = COM_INFO;
            }
            else
            {
                //데이터타임 피크에 null값 주기
            }
        }

        private void ComboBinding()
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtComCode.Text == "" || txtComName.Text == "" || cboComType.Text == "" || cboAutoYN.Text == "" ||
                cboStartYN.Text == "" || cboUseYN.Text == "")
            {
                MessageBox.Show("필수정보 입력 필요");
                return;
            }

            COMPANY_VO vo = new COMPANY_VO();
            vo.COM_CODE = COM_CODE;
            vo.COM_NAME = COM_NAME;
            vo.COM_TYP = COM_TYP;
            vo.COM_CEO = COM_CEO;
            vo.COM_REG_NUM = COM_REG_NUM;
            vo.COM_TYP_INDSTRY = COM_TYP_INDSTRY;
            vo.COM_TYP_BSNS = COM_TYP_BSNS;
            vo.COM_MANAGER = COM_MANAGER;
            vo.COM_EML = COM_EML;
            vo.COM_TEL = COM_TEL;
            vo.COM_STR_DATE = COM_STR_DATE;
            vo.COM_END_DATE = COM_END_DATE;
            vo.COM_TRAD_YN = COM_TRAD_YN;
            vo.COM_FAX = COM_FAX;
            vo.COM_AUTOIN_YN = COM_AUTOIN_YN;
            vo.COM_START_YN = COM_START_YN;
            vo.COM_USE_YN = COM_USE_YN;
            vo.COM_INFO = COM_INFO;
            vo.COM_LAST_MDFR = COM_LAST_MDFR;
            vo.COM_LAST_MDFY = COM_LAST_MDFY;

            CompanyService service = new CompanyService();
            Message msg = service.SaveCompany(vo, Update);
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
        }
    }
}
