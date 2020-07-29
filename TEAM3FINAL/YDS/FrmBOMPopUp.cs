﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmBOMPopUp : TEAM3FINAL.baseFormPopUP
    {
        int code = 0;
        public FrmBOMPopUp()
        {
            InitializeComponent();
        }
        private void FrmBOMPopUp_Load(object sender, EventArgs e)
        {
            ComboBinding();
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //상위품목
            var list1 = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_PARENT_CODE, list1, "COMMON_CODE", "COMMON_NAME", "-");
            //품목
            var list2 = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_CODE, list2, "COMMON_CODE", "COMMON_NAME", "");
            //사용유무
            var listYN1 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_USE_YN, listYN1, "COMMON_CODE", "COMMON_NAME", "");
            //자동차감
            var listYN2 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_AUTOREDUCE_YN, listYN2, "COMMON_CODE", "COMMON_NAME", "");
            //소요계획
            var listYN3 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_PLAN_YN, listYN3, "COMMON_CODE", "COMMON_NAME", "");



        }
        /// <summary>
        /// 텍스트 박스 숫자만 입력 가능 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력하도록 하는 이벤트
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            if (ITEM_CODE.Text.Length < 1 || BOM_QTY.Text.Length < 1 || BOM_USE_YN.Text.Length < 1 || BOM_AUTOREDUCE_YN.Text.Length < 1 || BOM_PLAN_YN.Text.Length < 1 )
            {
                MessageBox.Show("필수 입력사항을 입력해주세요.");
                return;
            }
            BOM_VO vo = new BOM_VO();
            vo.BOM_CODE = code;
            //vo.ITEM_LEADTIME = (ITEM_LEADTIME.Text.Length < 1) ? 0 : int.Parse(ITEM_LEADTIME.Text);
            vo.BOM_PARENT_CODE = (BOM_PARENT_CODE.Text =="-") ? "-" : BOM_PARENT_CODE.SelectedValue.ToString();
            vo.ITEM_CODE = ITEM_CODE.SelectedValue.ToString();
            vo.BOM_QTY = int.Parse(BOM_QTY.Text);
            vo.BOM_STARTDATE = BOM_STARTDATE.Value.ToShortDateString();
            vo.BOM_ENDDATE = BOM_ENDDATE.Value.ToShortDateString();
            vo.BOM_USE_YN = BOM_USE_YN.Text;
            vo.BOM_LAST_MDFR = BOM_LAST_MDFR.Text;
            vo.BOM_LAST_MDFY = BOM_LAST_MDFY.Value.ToShortDateString();
            vo.BOM_AUTOREDUCE_YN = BOM_AUTOREDUCE_YN.Text;
            vo.BOM_PLAN_YN = BOM_PLAN_YN.Text;
            vo.BOM_REMARK = BOM_REMARK.Text;
            BOMService item = new BOMService();
            string result = item.SaveBOM(vo);
            if (result == "C200")
            {
                MessageBox.Show("성공적으로 입력되었습니다.");
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
            else if (result == "C201")
            {
                MessageBox.Show("BOM이 중복되었습니다. 다시 입력해주세요");
            }
        }
    }
}