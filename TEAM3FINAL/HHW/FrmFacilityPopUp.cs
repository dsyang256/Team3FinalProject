﻿using System;
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
using log4net.Core;

namespace TEAM3FINAL
{
    public partial class FrmFacilityPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region Property
        public bool Update { get; set; }
        public string FACG_CODE { get; set; } //설비군코드
        public string FCLTS_CODE { get; set; } //설비코드
        public string FCLTS_NAME { get; set; } //설비명
        public string FCLTS_WRHS_EXHST { get; set; } //소진창고
        public string FCLTS_WRHS_GOOD { get; set; } //양품창고
        public string FCLTS_WRHS_BAD { get; set; } //불량창고
        public string FCLTS_USE_YN { get; set; } //사용유무
        public string FCLTS_EXTRL_YN { get; set; } //외주여부
        public string FCLTS_LAST_MDFR { get; set; } //수정자
        public string FCLTS_LAST_MDFY { get; set; } //최종수정일
        public string FCLTS_NOTE { get; set; } //특이사항
        public string FCLTS_REMARK { get; set; } //비고


        #endregion
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public FrmFacilityPopUp()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                #region 설비군 등록&수정

                if (txtFACGCODE.Text == "" || txtFACCODE.Text == "" || txtFACNAME.Text == "" ||
                    cboFACEXHST.Text == "" || cboFACGOOD.Text == "" || cboFACUseYN.Text == "")
                {
                    MessageBox.Show("필수정보 입력 필요");
                    return;
                }

                FACILITY_VO vo = new FACILITY_VO();
                vo.FACG_CODE = txtFACGCODE.Text;
                vo.FCLTS_CODE = txtFACCODE.Text;
                vo.FCLTS_NAME = txtFACNAME.Text;
                vo.FCLTS_WRHS_EXHST = cboFACEXHST.SelectedValue.ToString();
                vo.FCLTS_WRHS_GOOD = cboFACGOOD.SelectedValue.ToString();
                vo.FCLTS_WRHS_BAD = (cboFACBAD.SelectedValue == null) ? "" : cboFACBAD.SelectedValue.ToString();
                vo.FCLTS_USE_YN = cboFACUseYN.Text;
                vo.FCLTS_EXTRL_YN = cboEXTRLYN.Text;
                vo.FCLTS_LAST_MDFR = FCLTS_LAST_MDFR;
                vo.FCLTS_LAST_MDFY = FCLTS_LAST_MDFY;
                vo.FCLTS_NOTE = txtNote.Text;
                vo.FCLTS_REMARK = txtREMARK.Text;

                if (!Update) //설비 등록
                {
                    FacilityService service = new FacilityService();
                    Message msg = service.InsertFacility(vo, Update);
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
                else //설비 수정
                {
                    FacilityService service = new FacilityService();
                    Message msg = service.UpdateFacility(vo, Update);
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

                #endregion
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }

        private void FrmFacilityPopUp_Load(object sender, EventArgs e)
        {
            txtModifier.Enabled = false;
            txtModifyDate.Enabled = false;
            ComboBinding();
            if (Update)
            {
                txtFACCODE.Enabled = false;
                txtFACGCODE.Text = FACG_CODE;
                txtFACCODE.Text = FCLTS_CODE;
                txtFACNAME.Text = FCLTS_NAME;
                cboFACEXHST.SelectedIndex = cboFACEXHST.FindStringExact(FCLTS_WRHS_EXHST);
                cboFACGOOD.SelectedIndex = cboFACEXHST.FindStringExact(FCLTS_WRHS_GOOD);
                cboFACBAD.Text = FCLTS_WRHS_BAD;
                cboFACUseYN.Text = FCLTS_USE_YN;
                cboEXTRLYN.Text = FCLTS_EXTRL_YN;
                txtModifier.Text = FCLTS_LAST_MDFR;
                txtModifyDate.Text = FCLTS_LAST_MDFY;
                txtNote.Text = FCLTS_NOTE;
                txtREMARK.Text = FCLTS_REMARK;
            }
        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listYN = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFACUseYN, listYN, "COMMON_CODE", "COMMON_NAME", "");

            var listYN2 = (from item in commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboEXTRLYN, listYN2, "COMMON_CODE", "COMMON_NAME", "");

            var listFAC1 = (from item in commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFACEXHST, listFAC1, "COMMON_CODE", "COMMON_NAME", "");

            var listFAC2 = (from item in commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFACGOOD, listFAC2, "COMMON_CODE", "COMMON_NAME", "");

            var listFAC3 = (from item in commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboFACBAD, listFAC3, "COMMON_CODE", "COMMON_NAME", "");
        }
    }
}
