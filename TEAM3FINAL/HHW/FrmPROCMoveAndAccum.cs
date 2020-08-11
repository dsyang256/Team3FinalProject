using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;
using System.Linq;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmPROCMoveAndAccum : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmPROCMoveAndAccum()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvList, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "창고코드", "INS_WRHS", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "창고", "FAC_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "TYPE", "INS_TYP", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "품목", "ITEM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "품명", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "품목타입", "ITEM_TYP", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "규격", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "재고량", "INS_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "단위", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "날짜", "INS_DATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvList, "작업번호", "WO_CODE", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvList);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvList.Controls.Add(headerChk);
        }
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        #endregion

        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset; //입력필요
            frm.ePrint += Print; //입력필요
        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listFAC = (from item in commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboWHouse, listFAC, "COMMON_CODE", "COMMON_NAME", "");

        }

        private void FrmPROCMoveAndAccum_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            MOVEList();
        }

        private void MOVEList()
        {
            WorkOrderService service = new WorkOrderService();
            dgvList.DataSource = null;
            dgvList.DataSource = service.MOVEList();
        }

        private void FrmPROCMoveAndAccum_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset;
            frm.ePrint -= Print;
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {

        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                WorkOrderService service = new WorkOrderService();
                dgvList.DataSource = null;
                dgvList.DataSource = service.SearchMOVELIST((cboWHouse.SelectedValue == null) ? "" : cboWHouse.SelectedValue.ToString(), cboType.Text, txtITEM_CODE.Text);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            txtITEM_CODE.Text = "";
            cboWHouse.SelectedIndex = 0;
            cboType.SelectedIndex = -1;
        }

        public void Update(object sender, EventArgs e)
        {

        }

        public void Delete(object sender, EventArgs e)
        {

        }

        public void Print(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
