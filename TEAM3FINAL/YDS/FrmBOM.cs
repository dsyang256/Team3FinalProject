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
    public partial class FrmBOM : TEAM3FINAL.baseForm2, CommonBtn
    {
        public FrmBOM()
        {
            InitializeComponent();
        }
        private void FrmBOM_Load(object sender, EventArgs e)
        {
            BtnSet();
            DataGridViewColumnSet();
            DataGridViewBinding();
        }
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                
            }
        }

        public void Insert(object sender, EventArgs e)
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

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        /// <summary>
        /// 버튼 이벤트 셋
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
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var listCOM_REORDER = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_REORDER, listCOM_REORDER, "COMMON_CODE", "COMMON_NAME", "");



        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            Util.InitSettingGridView(dgvBOM);
            Util.AddNewColumnToDataGridView(dgvBOM, "no", "idx", true, 30);
            Util.DataGridViewCheckBoxSet(dgvBOM, "all");
            Util.AddNewColumnToDataGridView(dgvBOM, "품목유형", "ITEM_TYP", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "품목", "ITEM_CODE", true, 200);
            Util.AddNewColumnToDataGridView(dgvBOM, "품명", "ITEM_NAME", true, 200);
            Util.AddNewColumnToDataGridView(dgvBOM, "규격", "ITEM_STND", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "단위", "ITEM_UNIT", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "단위수량", "ITEM_QTY_UNIT", true, 80);
            Util.AddNewColumnToDataGridView(dgvBOM, "환산단위", "ITEM_UNIT_CNVR", true, 80);
            Util.AddNewColumnToDataGridView(dgvBOM, "환산수량", "ITEM_QTY_CNVR", true, 80);
            Util.AddNewColumnToDataGridView(dgvBOM, "수입검사여부", "ITEM_INCOME_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "공정검사여부", "ITEM_PROCS_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "출하검사여부", "ITEM_XPORT_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "단종유무", "ITEM_DSCN_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "유무상구분", "ITEM_FREE_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "납품업체", "ITEM_COM_DLVR", true, 140);
            Util.AddNewColumnToDataGridView(dgvBOM, "발주업체", "ITEM_COM_REORDER", true, 140);


        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            dgvBOM.DataSource = null;
        }

    }
}
