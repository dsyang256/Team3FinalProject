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
    public partial class FrmFacilityGroupPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region Property
        public bool Update { get; set; }
        public string FACG_CODE { get; set; } //시설군코드
        public string FACG_NAME { get; set; } //설비군명
        public string FACG_USE_YN { get; set; } //사용유무
        public string FACG_LAST_MDFR { get; set; } //수정자
        public string FACG_LAST_MDFY { get; set; } //최종수정날짜
        public string FACG_DESC { get; set; } //시설설명

        #endregion

        public FrmFacilityGroupPopUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 설비군 등록&수정

            if(txtFACGCODE.Text == "" || txtFACGNAME.Text == "" || cboFACGUseYN.Text == "")
            {
                MessageBox.Show("필수정보 입력 필요");
                return;
            }

            FACILITY_GROUP vo = new FACILITY_GROUP();
            vo.FACG_CODE = txtFACGCODE.Text;
            vo.FACG_NAME = txtFACGNAME.Text;
            vo.FACG_USE_YN = cboFACGUseYN.Text;
            vo.FACG_LAST_MDFR = txtModifier.Text;
            vo.FACG_LAST_MDFY = txtModifyDate.Text;
            vo.FACG_DESC = txtDesc.Text;

            if(!Update) //설비군 등록
            {
                FacilityService service = new FacilityService();
                Message msg = service.InsertFacilityGroup(vo, Update);
                if(msg.IsSuccess)
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
            else //설비군 수정
            {
                FacilityService service = new FacilityService();
                Message msg = service.UpdateFacilityGroup(vo, Update);
                if (msg.IsSuccess)
                {
                    MessageBox.Show("성공");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(msg.ResultMessage);
                    return;
                }
            }

            #endregion
        }

        private void FrmFacilityGroupPopUp_Load(object sender, EventArgs e)
        {
            //등록시 수정자, 수정시간 변경하지 못하도록 enable = false;
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            txtModifier.Text = FACG_LAST_MDFR;
            txtModifyDate.Text = FACG_LAST_MDFY;

            ComboBinding();
            if (Update)
            {
                txtFACGCODE.Enabled = false;
                txtModifier.Enabled = false;
                txtModifyDate.Enabled = false;
                txtFACGCODE.Text = FACG_CODE;
                txtFACGNAME.Text = FACG_NAME;
                cboFACGUseYN.Text = FACG_USE_YN;                
                txtDesc.Text = FACG_DESC;
            }
        }

        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listUse_YN = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFACGUseYN, listUse_YN, "COMMON_CODE", "COMMON_NAME", "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }
    }
}
