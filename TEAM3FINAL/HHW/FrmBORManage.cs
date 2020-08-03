using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmBORManage : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmBORManage()
        {
            InitializeComponent();
        }

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvBORList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvBORList, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "PK", "BOR_CODE", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "품목", "ITEM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "품명", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정", "BOR_PROCS_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정명", "COMMON_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "설비", "FCLTS_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "설비명", "FCLTS_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "Tack Time", "BOR_PROCS_TIME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "우선순위", "BOR_PRIORT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정선행일", "BOR_PROCS_LEADTIME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "수율", "BOR_YIELD", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "사용유무", "BOR_USE_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "비고", "BOR_REMARK", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "수정자", "BOR_LAST_MDFR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "최종수정날짜", "BOR_LAST_MDFY", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvBORList);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvBORList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvBORList.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvBORList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvBORList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                chk.Value = headerChk.Checked;
            }
        }

        private void FrmBORManage_Load(object sender, EventArgs e)
        {
            btnset();
            DataGridViewColumnSet();
            GetBORList();
            if(dgvBORList.RowCount>0)
            MessageBox.Show(dgvBORList.Rows[1].Cells[1].Value.ToString());
        }

        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset;
            frm.ePrint += Print;
        }

        private void GetBORList()
        {
            BORService service = new BORService();
            dgvBORList.DataSource = null;
            dgvBORList.DataSource = service.GetBORList();
        }

        #region ****메인 버튼 이벤트****
        public void Insert(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                BORService service = new BORService();
                dgvBORList.DataSource = null;
                dgvBORList.DataSource = service.SearchBOR(txtITEMCODE.Text, cboPROC.Text, txtFacility.Text);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            txtITEMCODE.Text = "";
            cboPROC.Text = "";
            txtFacility.Text = "";
            GetBORList();
        }

        public void Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
