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
    public partial class FrmReorder : TEAM3FINAL.baseForm2
    {
        public FrmReorder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnSet();
            ComboBinding();
            DataGridViewColumnSet();
        }
        /// <summary>
        /// 버튼 이벤트 델리게이트 추가
        /// </summary>
        private void BtnSet()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eUpdate += Update;
            frm.eDelete += Delete;
            frm.ePrint += Print;
            frm.eReset += Reset;
        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgvReorder);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "no", "idx", true, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품목", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품목명", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품목유형", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "항목", "ITEM_STND", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "단위", "ITEM_UNIT", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "단위수량", "ITEM_QTY_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "환산단위", "ITEM_UNIT_CNVR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "환산수량", "ITEM_QTY_CNVR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "수입검사여부", "ITEM_INCOME_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "공정검사여부", "ITEM_PROCS_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "출하검사여부", "ITEM_XPORT_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "단종유무", "ITEM_DSCN_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "유무상구분", "ITEM_FREE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "납품업체", "ITEM_COM_DLVR", true, 140);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주업체", "ITEM_COM_REORDER", true, 140);


        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //PLAN_ID
            var listPLAN_ID = (from item in Commonlist where item.COMMON_PARENT == "PLAN_ID" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(PLAN_ID, listPLAN_ID, "COMMON_CODE", "COMMON_NAME", "");

            //업체코드
            var listCOM_CODE = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE, listCOM_CODE, "COMMON_CODE", "COMMON_NAME", "");

            //창고
            var listFACILITY_TYPE = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(FACILITY_TYPE, listFACILITY_TYPE, "COMMON_CODE", "COMMON_NAME", "");

            //품목형태
            var listITEM_TYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listITEM_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //담당자
            var listMANAGER = (from item in Commonlist where item.COMMON_PARENT == "담당자" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(MANAGER, listMANAGER, "COMMON_CODE", "COMMON_NAME", "");

            //사용여부
            var listYN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(USE_YN, listYN, "COMMON_CODE", "COMMON_NAME", "");

            //발주유형
            var listREORDER_TYP = (from item in Commonlist where item.COMMON_PARENT == "발주방식" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(REORDER_TYP, listREORDER_TYP, "COMMON_CODE", "COMMON_NAME", "");




        }
        /// <summary>
        /// 입력 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmReorderPopUp frm = new FrmReorderPopUp();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Search(null, null);
                }
            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                
            }
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            ITEM_STND.Text = "";
            PLAN_ID.SelectedIndex = -1;
            COM_CODE.SelectedIndex = -1;
            FACILITY_TYPE.SelectedIndex = -1;
            ITEM_TYP.SelectedIndex = -1;
            USE_YN.SelectedIndex = -1;
            ITEM_TYP.SelectedIndex = -1;
            USE_YN.SelectedIndex = -1;
            //DataGridViewBinding();
        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 삭제 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                
            }
        }
        /// <summary>
        /// 프린트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }
    }
}
