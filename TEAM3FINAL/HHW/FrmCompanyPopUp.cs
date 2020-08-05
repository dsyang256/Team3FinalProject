using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            dtpEnd.Checked = false;
            dtpStart.Checked = false;//datetimepicker 기본 null값
            dtpEnd_ValueChanged(null, null);
            dtpStart_ValueChanged(null, null);

            ComboBinding();
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            txtModifier.Text = COM_LAST_MDFR;
            txtModifyDate.Text = COM_LAST_MDFY;

            if (Update)
            {
                txtComCode.Text = COM_CODE;
                txtComName.Text = COM_NAME;
                txtComType.Text = COM_TYP_INDSTRY;
                txtOwnerName.Text = COM_CEO;
                txtRegNum.Text = COM_REG_NUM;
                cboComType.Text = COM_TYP;
                txtTypeTEA.Text = COM_TYP_BSNS;
                txtManager.Text = COM_MANAGER;
                txtEmail.Text = COM_EML;
                txtTell.Text = COM_TEL;
                try 
                {
                    dtpStart.Value = Convert.ToDateTime(COM_STR_DATE);
                }
                catch
                {
                    dtpStart.Checked = false;
                }
                try
                {
                    dtpEnd.Value = Convert.ToDateTime(COM_END_DATE);
                }
                catch
                {
                    dtpEnd.Checked = false;
                }
                
                cboTradeYN.Text = COM_TRAD_YN;
                txtFAX.Text = COM_FAX;
                cboAutoYN.Text = COM_AUTOIN_YN;
                cboStartYN.Text = COM_START_YN;
                cboUseYN.Text = COM_USE_YN;
                txtComDesc.Text = COM_INFO;
            }

        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listYN = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboTradeYN, listYN, "COMMON_CODE", "COMMON_NAME", "");

            var listYN2 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboAutoYN, listYN2, "COMMON_CODE", "COMMON_NAME", "");

            var listYN3 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboStartYN, listYN3, "COMMON_CODE", "COMMON_NAME", "");

            var listYN4 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboUseYN, listYN4, "COMMON_CODE", "COMMON_NAME", "");

            var listVENDOR_TYP = (from item in commonlist where item.COMMON_PARENT == "VENDOR_TYP" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboComType, listVENDOR_TYP, "COMMON_CODE", "COMMON_NAME", "");
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
            vo.COM_CODE = txtComCode.Text;
            vo.COM_NAME = txtComName.Text;
            vo.COM_TYP = cboComType.Text;
            vo.COM_CEO = txtOwnerName.Text;
            vo.COM_REG_NUM = txtRegNum.Text;
            vo.COM_TYP_INDSTRY = txtComType.Text;
            vo.COM_TYP_BSNS = txtTypeTEA.Text;
            vo.COM_MANAGER = txtManager.Text;
            vo.COM_EML = txtEmail.Text;
            vo.COM_TEL = txtTell.Text;
            if (dtpStart.Checked)
                vo.COM_STR_DATE = dtpStart.Value.ToString("yyyy-MM-dd");
            else
                vo.COM_STR_DATE = null;
            if (dtpEnd.Checked)
                vo.COM_END_DATE = dtpEnd.Value.ToString("yyyy-MM-dd");
            else
                vo.COM_END_DATE = null;
            vo.COM_TRAD_YN = cboTradeYN.Text;
            vo.COM_FAX = txtFAX.Text;
            vo.COM_AUTOIN_YN = cboAutoYN.Text;
            vo.COM_START_YN = cboStartYN.Text;
            vo.COM_USE_YN = cboUseYN.Text;
            vo.COM_INFO = txtComDesc.Text;
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

        //등록화면시 거래종료날짜 null
        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {            
            if (!dtpEnd.Checked)
            {                
                dtpEnd.CustomFormat = " ";
                dtpEnd.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpEnd.CustomFormat = null;
                dtpEnd.Format = DateTimePickerFormat.Long;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpStart.Checked)
            {
                dtpStart.CustomFormat = " ";
                dtpStart.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpStart.CustomFormat = null;
                dtpStart.Format = DateTimePickerFormat.Long;
            }
        }
    }
}
