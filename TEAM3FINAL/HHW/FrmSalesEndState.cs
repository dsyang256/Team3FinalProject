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
using TEAM3FINAL;

namespace TEAM3FINAL
{
    public partial class FrmSalesEndState : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmSalesEndState()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvSalesEndState);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvSalesEndState, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객주문번호", "SALES_WORK_ORDER_ID", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객사", "SALES_COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객사명", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "품목", "ITEM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "품명", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "납기일", "SALES_DUEDATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "주문수량", "SALES_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "납품수량", "SALES_TTL", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "마감일", "SALES_ENDDATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "마감취소일", "SALES_CANCELDATE", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvSalesEndState);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvSalesEndState.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvSalesEndState.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvSalesEndState.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvSalesEndState.Rows)
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
            frm.eReset += Reset;
            frm.ePrint += Print;
        }

        private void FrmSalesEndState_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();
            btnset();
            GetSalesEndState();
        }

        private void GetSalesEndState()
        {
            SalesEndService service = new SalesEndService();
            dgvSalesEndState.DataSource = null;
            dgvSalesEndState.DataSource = service.GetSalesEndState();
        }

        private void FrmSalesEndState_FormClosing(object sender, FormClosingEventArgs e)
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
            throw new NotImplementedException();
        }

        public void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void btnSalesCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
