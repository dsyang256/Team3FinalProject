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
        CheckBox headerChk;
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
                FrmBOMPopUp frm = new FrmBOMPopUp();
                if(frm.ShowDialog() == DialogResult.OK)
                {

                }
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
            Util.AddNewColumnToDataGridView(dgvBOM, "품목", "ITEM_CODE", true, 200);
            Util.AddNewColumnToDataGridView(dgvBOM, "품명", "ITEM_NAME", true, 200);
            Util.AddNewColumnToDataGridView(dgvBOM, "품목유형", "ITEM_TYP", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "단위", "ITEM_UNIT", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "소요량", "BOM_QTY", true, 80);
            Util.AddNewColumnToDataGridView(dgvBOM, "BOM레벨", "Lvl", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "시작일", "BOM_STARTDATE", true, 80);
            Util.AddNewColumnToDataGridView(dgvBOM, "종료일", "BOM_ENDDATE", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "사용여부", "BOM_USE_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "소요계획", "BOM_PLAN_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvBOM, "자동차감", "BOM_AUTOREDUCE_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "설비", "FCLTS_CODE", true, 100);
            Util.AddNewColumnToDataGridView(dgvBOM, "설비명", "FCLTS_NAME", true, 140);
            Util.AddNewColumnToDataGridView(dgvBOM, "규격", "ITEM_STND", true, 140);
            DataGridViewCheckBoxAllCheck();

        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            dgvBOM.DataSource = null;
        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvBOM.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvBOM.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvBOM.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvBOM.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
    }
}
