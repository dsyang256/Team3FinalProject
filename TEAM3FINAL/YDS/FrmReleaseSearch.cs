using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{ 

    public partial class FrmReleaseSearch : baseForm2, CommonBtn
    {
        
        public FrmReleaseSearch()
        {
            InitializeComponent();
        }

        private void FrmReleaseSearch_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet();
            DataGridViewBinding();
            BtnSet(); 
        }
        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //발주창고
            var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");

            //입고유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "입고유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");


            //품목유형
            var listITEM_TYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listITEM_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //관리등급
            var listITEM_MANAGER = (from item in Commonlist where item.COMMON_PARENT == "관리등급" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listITEM_MANAGER, "COMMON_CODE", "COMMON_NAME", "");


        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입출고일", "INS_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "구분", "INS_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "창고", "FAC_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_STND", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목형태", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "관리등급", "ITEM_MANAGE_LEVEL", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "수불량", "INS_QTY", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단가", "MC_UNITPRICE_CUR", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "금액", "price", true, 200);


        }

        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            dgv1.DataSource = null;
            INSTACKService service = new INSTACKService();
            dgv1.DataSource = service.INSTACDataTable();


        }

        #endregion

        #region 버튼이벤트
        /// <summary>
        /// 버튼이벤트
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
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string day1 = sday.Value.ToShortDateString();
                string day2 = eday.Value.ToShortDateString();
                string wrhs = (WRHS.Text.Length < 1) ? "": WRHS.SelectedValue.ToString();
                string name = ITEM.Text;
                string typ = TYP.Text;
                string level = ITEM_MANAGER.Text;
                string itemtyp = ITEM_TYP.Text;
                INSTACKService service = new INSTACKService();
                dgv1.DataSource = service.INSTACDataTable(day1, day2,wrhs,name,typ, level, itemtyp);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                sday.Value = DateTime.Now;
                eday.Value = DateTime.Now;
                WRHS.SelectedIndex  = -1;
                ITEM.Text = "";
                TYP.Text = "";
                ITEM_MANAGER.Text = "";
                ITEM_TYP.Text = "";
                DataGridViewBinding();
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        #endregion
    }
}
