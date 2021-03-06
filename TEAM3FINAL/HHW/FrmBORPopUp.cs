﻿using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmBORPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region Property        

        public bool Update { get; set; }
        public int BOR_CODE { get; set; }
        public string ITEM_CODE { get; set; }
        //public string ITEM_NAME { get; set; }
        public string BOR_PROCS_CODE { get; set; }
        //public string COMMON_CODE { get; set; }
        public string FCLTS_CODE { get; set; }
        //public string FCLTS_NAME { get; set; }
        public int BOR_PROCS_TIME { get; set; }
        public int BOR_PRIORT { get; set; }
        public int BOR_PROCS_LEADTIME { get; set; }
        public decimal BOR_YIELD { get; set; }
        public string BOR_USE_YN { get; set; }
        public string BOR_REMARK { get; set; }
        public string BOR_LAST_MDFR { get; set; }
        public string BOR_LAST_MDFY { get; set; }

        #endregion 

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public FrmBORPopUp()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                #region BOR등록 & 수정
                if (cboItemCode.Text == "" || cboPROC.Text == "" || cboFacil.Text == "" || txtTime.Text == "" ||
                    txtPrio.Text == "" || cboUseYN.Text == "")
                {
                    MessageBox.Show("필수정보 입력 필요");
                    return;
                }

                BOR_VO vo = new BOR_VO();
                vo.BOR_CODE = BOR_CODE;
                vo.ITEM_CODE = cboItemCode.Text;
                vo.BOR_PROCS_CODE = cboPROC.Text;
                vo.FCLTS_CODE = cboFacil.Text;
                vo.BOR_PROCS_TIME = int.Parse(txtTime.Text);
                vo.BOR_PRIORT = int.Parse(txtPrio.Text);
                if (int.TryParse(txtLead.Text, out int plzNull1))
                    vo.BOR_PROCS_LEADTIME = plzNull1;
                else
                    vo.BOR_PROCS_LEADTIME = null;
                try
                {
                    vo.BOR_YIELD = Convert.ToDecimal(txtYIELD.Text);
                }
                catch
                {
                    MessageBox.Show("err수율 : 올바른 소수점의 형태가 아닙니다.");
                    return;
                }

                vo.BOR_USE_YN = cboUseYN.Text;
                vo.BOR_REMARK = txtREMARK.Text;
                vo.BOR_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                vo.BOR_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                BORService service = new BORService();
                Message msg = service.SaveBOR(vo, Update);
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
            catch(Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }

        private void FrmBORPopUp_Load(object sender, EventArgs e)
        {
            ComboBinding();
            if(Update)
            {
                cboItemCode.Enabled = false;
                cboPROC.Enabled = false;
                cboFacil.Enabled = false;
                cboItemCode.Text = ITEM_CODE;
                cboPROC.Text = BOR_PROCS_CODE;
                cboFacil.Text = FCLTS_CODE;
                txtTime.Text = BOR_PROCS_TIME.ToString();
                txtLead.Text = (BOR_PROCS_LEADTIME ==0) ? "": BOR_PROCS_LEADTIME.ToString();
                txtPrio.Text = BOR_PRIORT.ToString();
                txtYIELD.Text = BOR_YIELD.ToString();
                cboUseYN.Text = BOR_USE_YN;
                txtREMARK.Text = BOR_REMARK;                
            }
        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            ComboItemService service1 = new ComboItemService();
            List<ComboItemVO> commonList = service.GetITEMCmCode();
            List<ComboItemVO> facList = service1.GetFacilitiesCode();
            CommonUtil.ComboBinding<ComboItemVO>(cboFacil, facList, "COMMON_CODE", "COMMON_NAME", "");
            var listITEM = (from item in commonList where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboItemCode, listITEM, "COMMON_NAME", "COMMON_CODE", "");
            var listTool = (from item in commonList where item.COMMON_PARENT == "PROC_TOOL" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboPROC, listTool, "COMMON_CODE", "COMMON_NAME", "");
            var listYN = (from item in commonList where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboUseYN, listYN, "COMMON_CODE", "COMMON_NAME", "");
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || txtLead.Text == ""))
            {
                e.Handled = true;
            }
        }

        private void txtYIELD_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46 || txtYIELD.Text == ""))
            {
                e.Handled = true;
            }
        }
    }
}
