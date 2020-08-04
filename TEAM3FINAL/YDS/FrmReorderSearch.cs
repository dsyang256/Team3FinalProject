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
    public partial class FrmReorderSearch : baseForm2, CommonBtn
    {
        CheckBox headerChk;
        public FrmReorderSearch()
        {
            InitializeComponent();
        }

        private void FrmReorderSearch_Load(object sender, EventArgs e)
        {
            BtnSet();
            DataGridViewColumnSet();
            ComboBinding();
            DataGridViewBinding();
        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            ReorderService item = new ReorderService();
            dgvReorder.DataSource = item.SelectREORDER();
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var listCOM_CODE_OUT = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_OUT, listCOM_CODE_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            var listCOM_CODE_IN = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_IN, listCOM_CODE_IN, "COMMON_CODE", "COMMON_NAME", "");

            //품목
            var listITEM_CODE = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_CODE, listITEM_CODE, "COMMON_CODE", "COMMON_NAME", "");

            //발주상태
            var listREORDER_STATE = (from item in Commonlist where item.COMMON_PARENT == "발주상태" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(REORDER_STATE, listREORDER_STATE, "COMMON_CODE", "COMMON_NAME", "");
        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgvReorder);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvReorder, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주번호", "REORDER_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "협렵사", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "납품업체", "REORDER_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "주문상태", "REORDER_STATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품명", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "규격", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "단위", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "납기일", "REORDER_DATE_IN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주량", "REORDER_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "입고량", "REORDER_DETAIL_QTY_GOOD", true, 100);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "출발량", "REORDER_DETAIL_QTY_START", true, 100);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "취소량", "ITEM_FREE_YN", true, 100);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "취소가능량", "REORDER_QTY_CANCEL", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주일", "REORDER_DATE", true, 100);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "출발일", "ITEM_COM_REORDER", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주자", "MANAGER_NAME", true, 100);
            DataGridViewCheckBoxAllCheck();
        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvReorder.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvReorder.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvReorder.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvReorder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
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
        /// 저장 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

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
                ReorderService service = new ReorderService();
                dgvReorder.DataSource = null;
                dgvReorder.DataSource = service.GetSearchREORDER(
                    sday.Value.ToShortDateString()
                    , eday.Value.ToShortDateString()
                    , (COM_CODE_OUT.Text.Length < 1) ? "" : COM_CODE_OUT.SelectedValue.ToString()
                    , (ITEM_CODE.Text.Length < 1) ? "" : ITEM_CODE.SelectedValue.ToString()
                    , REORDER_STATE.Text
                    , REORDER_CODE.Text
                    , (COM_CODE_IN.Text.Length < 1) ? "": COM_CODE_IN.SelectedValue.ToString());
            }
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            FrmReorderSearchPopUp frm = new FrmReorderSearchPopUp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(frm.day);
            }
        }

        private void menuPanel1_Load(object sender, EventArgs e)
        {

        }
    }
}
