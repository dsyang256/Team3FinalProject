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
    public partial class FrmItemPopUp : TEAM3FINAL.BaseForm.baseFormPopUP
    {
        public FrmItemPopUp()
        {
            InitializeComponent();
        }

        private void FrmItemPopUp_Load(object sender, EventArgs e)
        {

        }
        private void cboset()
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

            //대그룹
            var listGROUP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_GROUP, listGROUP, "COMMON_CODE", "COMMON_NAME", "");

        }
        private void text_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자만 입력하도록 하는 이벤트
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
