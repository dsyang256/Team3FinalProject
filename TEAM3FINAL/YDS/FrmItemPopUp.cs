using System;
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
    public partial class FrmItemPopUp : TEAM3FINAL.baseFormPopUP
    {
        int update;
        public FrmItemPopUp()
        {
            InitializeComponent();
            ComboBinding();
            update = 1;
        }
        public FrmItemPopUp(string code)
        {
            InitializeComponent();
            ComboBinding();
            update = 0;
            GetItem(code);
        }
        private void GetItem(string code)
        {
            ItemServicecs item = new ItemServicecs();
            ITEM_VO vo = item.GetItem(code);
            ITEM_CODE.Text = vo.ITEM_CODE;
            ITEM_CODE.Enabled = false;
            ITEM_NAME.Text =vo.ITEM_NAME;
            ITEM_STND.Text =vo.ITEM_STND;
            ITEM_UNIT.Text =vo.ITEM_UNIT;
            ITEM_QTY_UNIT.Text =vo.ITEM_QTY_UNIT.ToString();
            ITEM_TYP.Text =vo.ITEM_TYP;
            ITEM_INCOME_YN.Text =vo.ITEM_INCOME_YN;
            ITEM_PROCS_YN.Text = vo.ITEM_PROCS_YN;
            ITEM_XPORT_YN.Text = vo.ITEM_XPORT_YN;
            ITEM_FREE_YN.Text = vo.ITEM_FREE_YN;
            ITEM_COM_DLVR.Text = vo.ITEM_COM_DLVR;
            ITEM_COM_REORDER.Text = vo.ITEM_COM_REORDER;
            ITEM_WRHS_IN.Text = vo.ITEM_WRHS_IN;
            ITEM_WRHS_OUT.Text =vo.ITEM_WRHS_OUT;
            ITEM_LEADTIME.Text =vo.ITEM_LEADTIME.ToString();
            ITEM_QTY_REORDER_MIN.Text = vo.ITEM_QTY_REORDER_MIN.ToString();
            ITEM_QTY_STND.Text =vo.ITEM_QTY_STND.ToString();
            ITEM_QTY_SAFE.Text =vo.ITEM_QTY_SAFE.ToString();
            ITEM_MANAGE_LEVEL.Text = vo.ITEM_MANAGE_LEVEL;
            ITEM_MANAGER.Text =vo.ITEM_MANAGER;
            ITEM_UNIT_CNVR.Text =vo.ITEM_UNIT_CNVR;
            ITEM_QTY_CNVR.Text =vo.ITEM_QTY_CNVR.ToString();
            ITEM_USE_YN.Text =vo.ITEM_USE_YN;
            ITEM_DSCN_YN.Text =vo.ITEM_DSCN_YN;
            ITEM_REORDER_TYP.Text = vo.ITEM_REORDER_TYP;
            ITEM_REMARK.Text = vo.ITEM_REMARK;

        }

        private void FrmItemPopUp_Load(object sender, EventArgs e)
        {
            
        }
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //단위
            var listUNIT = (from item in Commonlist where item.COMMON_PARENT == "ITEM_UNIT" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_UNIT, listUNIT, "COMMON_CODE", "COMMON_NAME", "");

            //품목유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");

            //수입검사여부
            var listINCOME_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_INCOME_YN, listINCOME_YN, "COMMON_CODE", "COMMON_NAME", "");

            //공정검사여부
            var listPROCS_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_PROCS_YN, listPROCS_YN, "COMMON_CODE", "COMMON_NAME", "");

            //출하검사여부
            var listXPORT_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_XPORT_YN, listXPORT_YN, "COMMON_CODE", "COMMON_NAME", "");

            //유무상구분
            var listFREE_YN = (from item in Commonlist where item.COMMON_PARENT == "유무상구분" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_FREE_YN, listFREE_YN, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            var listCOM_DLVR = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_DLVR, listCOM_DLVR, "COMMON_CODE", "COMMON_NAME", "");

            //발주업체
            var listCOM_REORDER = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_REORDER, listCOM_REORDER, "COMMON_CODE", "COMMON_NAME", "");

            //입고창고
            var listWRHS_IN = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_IN, listWRHS_IN, "COMMON_CODE", "COMMON_NAME", "");

            //출고창고
            var listWRHS_OUT = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_OUT, listWRHS_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //관리등급
            var listMANAGE_LEVEL = (from item in Commonlist where item.COMMON_PARENT == "관리등급" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGE_LEVEL, listMANAGE_LEVEL, "COMMON_CODE", "COMMON_NAME", "");

            //담당자
            var listMANAGER = (from item in Commonlist where item.COMMON_PARENT == "담당자" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listMANAGER, "COMMON_CODE", "COMMON_NAME", "");

            //환산단위
            var listUNIT_CNVR = (from item in Commonlist where item.COMMON_PARENT == "ITEM_UNIT" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_UNIT_CNVR, listUNIT_CNVR, "COMMON_CODE", "COMMON_NAME", "");

            //사용유무
            var listUSE_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_USE_YN, listUSE_YN, "COMMON_CODE", "COMMON_NAME", "");

            //발주방식
            var listLAST_REORDER_TYP = (from item in Commonlist where item.COMMON_PARENT == "발주방식" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_REORDER_TYP, listLAST_REORDER_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //단종유무
            var listDSCN_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_DSCN_YN, listDSCN_YN, "COMMON_CODE", "COMMON_NAME", "");


        }
        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력하도록 하는 이벤트
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(ITEM_CODE.Text.Length < 4)
            {
                MessageBox.Show("품목은 4자리 이상 입력해주세여야 됨니다.");
                return;
            }
            if(ITEM_NAME.Text.Length <1 || ITEM_UNIT.Text.Length<1|| ITEM_TYP.Text.Length<1|| ITEM_INCOME_YN.Text.Length<1|| ITEM_PROCS_YN.Text.Length<1|| ITEM_XPORT_YN.Text.Length<1|| ITEM_USE_YN.Text.Length<1)
            {
                MessageBox.Show("필수 입력사항을 입력해주세요.");
                return;
            }
            ITEM_VO vo = new ITEM_VO();
            vo.ITEM_CODE = ITEM_CODE.Text;
            vo.ITEM_NAME = ITEM_NAME.Text;
            vo.ITEM_STND = ITEM_STND.Text;
            vo.ITEM_UNIT = ITEM_UNIT.Text;
            vo.ITEM_QTY_UNIT = (ITEM_QTY_UNIT.Text.Length < 1) ? 0 : int.Parse(ITEM_QTY_UNIT.Text);
            vo.ITEM_TYP = ITEM_TYP.Text;
            vo.ITEM_INCOME_YN = ITEM_INCOME_YN.Text;
            vo.ITEM_PROCS_YN = ITEM_PROCS_YN.Text;
            vo.ITEM_XPORT_YN = ITEM_XPORT_YN.Text;
            vo.ITEM_FREE_YN = ITEM_FREE_YN.Text;
            vo.ITEM_COM_DLVR = ITEM_COM_DLVR.Text;
            vo.ITEM_COM_REORDER = ITEM_COM_REORDER.Text;
            vo.ITEM_WRHS_IN = ITEM_WRHS_IN.Text;
            vo.ITEM_WRHS_OUT = ITEM_WRHS_OUT.Text;
            vo.ITEM_LEADTIME = (ITEM_LEADTIME.Text.Length < 1) ? 0 : int.Parse(ITEM_LEADTIME.Text);
            vo.ITEM_QTY_REORDER_MIN = (ITEM_QTY_REORDER_MIN.Text.Length < 1) ? 0 : int.Parse(ITEM_QTY_REORDER_MIN.Text);
            vo.ITEM_QTY_STND = (ITEM_QTY_STND.Text.Length < 1) ? 0 : int.Parse(ITEM_QTY_STND.Text);
            vo.ITEM_QTY_SAFE = (ITEM_QTY_SAFE.Text.Length < 1) ? 0 : int.Parse(ITEM_QTY_SAFE.Text);
            vo.ITEM_MANAGE_LEVEL = ITEM_MANAGE_LEVEL.Text;
            vo.ITEM_MANAGER = ITEM_MANAGER.Text;
            vo.ITEM_UNIT_CNVR = ITEM_UNIT_CNVR.Text;
            vo.ITEM_QTY_CNVR = (ITEM_QTY_CNVR.Text.Length < 1) ? 0 : int.Parse(ITEM_QTY_CNVR.Text);
            vo.ITEM_LAST_MDFR = ITEM_LAST_MDFR.Text;
            vo.ITEM_LAST_MDFY = ITEM_LAST_MDFY.Value.ToShortDateString();
            vo.ITEM_USE_YN = ITEM_USE_YN.Text;
            vo.ITEM_DSCN_YN = ITEM_DSCN_YN.Text;
            vo.ITEM_REORDER_TYP = ITEM_REORDER_TYP.Text;
            vo.ITEM_REMARK = ITEM_REMARK.Text;
            ItemServicecs item = new ItemServicecs();
            string result = item.SaveItem(vo, update);
            if (result == "C200")
            {
                MessageBox.Show("성공적으로 입력되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if(result == "C201")
            {
                MessageBox.Show("품목이 중복되었습니다. 다시 입력해주세요");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
