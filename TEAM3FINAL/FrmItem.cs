using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmItem : TEAM3FINAL.baseForm2
    {
        ItemServicecs item = new ItemServicecs();
        CheckBox headerChk;
        public FrmItem()
        {
            InitializeComponent();
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            //FrmMain frm = (FrmMain)this.MdiParent;
            //frm.eSave += Save;
            //frm.eReset += Reset;
            //frm.eDelete += Delete;
            //frm.eUpdate += Update;
            DataGridViewColumnSet();
            dgvitem.DataSource = item.AllITEM();

        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            Util.InitSettingGridView(dgvitem);
            Util.AddNewColumnToDataGridView(dgvitem, "no", "idx", true, 30);
            Util.DataGridViewCheckBoxSet(dgvitem,"all");
            Util.AddNewColumnToDataGridView(dgvitem, "품목유형", "ITEM_TYP", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "품목", "ITEM_CODE", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "품명", "ITEM_NAME", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "규격", "ITEM_STND", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "단위", "ITEM_UNIT", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "단위수량", "ITEM_QTY_UNIT", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "환산단위", "ITEM_UNIT_CNVR", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "환산수량", "ITEM_QTY_CNVR", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "수입검사여부", "ITEM_INCOME_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvitem, "공정검사여부", "ITEM_PROCS_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvitem, "출하검사여부", "ITEM_XPORT_YN", true, 120);
            Util.AddNewColumnToDataGridView(dgvitem, "단종유무", "ITEM_DSCN_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "유무상구분", "ITEM_FREE_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "납품업체", "ITEM_COM_DLVR", true, 100);
            Util.AddNewColumnToDataGridView(dgvitem, "발주업체", "ITEM_COM_REORDER", true, 100);
            DataGridViewCheckBoxAllCheck();

        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvitem.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(52, 52, 52);
            headerChk.Click += HeaderChk_Clicked;
            dgvitem.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvitem.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvitem.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                ITEM_VO vo = new ITEM_VO();
                vo.ITEM_NAME = ITEM_NAME.Text;
                vo.ITEM_STND = ITEM_STND.Text;
                vo.ITEM_COM_REORDER = ITEM_COM_REORDER.Text;
                vo.ITEM_COM_DLVR = ITEM_COM_DLVR.Text;
                vo.ITEM_WRHS_IN = ITEM_WRHS_IN.Text;
                vo.ITEM_WRHS_OUT = ITEM_WRHS_OUT.Text;
                vo.ITEM_MANAGER = ITEM_MANAGER.Text;
                vo.ITEM_TYP = ITEM_TYP.Text;
                vo.ITEM_USE_YN = ITEM_USE_YN.Text;

                dgvitem.DataSource = null;
                dgvitem.DataSource = item.GetSearchItem(vo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ITEM_VO vo = new ITEM_VO();
            vo.ITEM_NAME = ITEM_NAME.Text;
            vo.ITEM_STND = ITEM_STND.Text;
            vo.ITEM_COM_REORDER = ITEM_COM_REORDER.Text;
            vo.ITEM_COM_DLVR = ITEM_COM_DLVR.Text;
            vo.ITEM_WRHS_IN = ITEM_WRHS_IN.Text;
            vo.ITEM_WRHS_OUT = ITEM_WRHS_OUT.Text;
            vo.ITEM_MANAGER = ITEM_MANAGER.Text;
            vo.ITEM_TYP = ITEM_TYP.Text;
            vo.ITEM_USE_YN = ITEM_USE_YN.Text;

            dgvitem.DataSource = null;
            dgvitem.DataSource = item.GetSearchItem(vo);
        }
    }
}
