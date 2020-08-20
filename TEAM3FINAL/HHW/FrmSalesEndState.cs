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
            DataGridViewColumn dc = dgvSalesEndState.Columns[0];
            dc.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객주문번호", "SALES_WORK_ORDER_ID", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객사", "SALES_COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "고객사명", "COM_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "품명", "ITEM_NAME", true, 110);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "납기일", "SALES_DUEDATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "주문수량", "SALES_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "판매액", "SALES_TTL", true, 90, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "마감일", "SALES_ENDDATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEndState, "마감취소일", "SALES_CANCELDATE", true, 110);
            dgvSalesEndState.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesEndState.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
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
            
        }

        public void Search(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string item = txtITEM.Text;
            string company = txtCompany.Text;

            SalesEndService service = new SalesEndService();
            dgvSalesEndState.DataSource = null;
            dgvSalesEndState.DataSource = service.SearchSalesEndState(id, item, company);
        }

        public void Reset(object sender, EventArgs e)
        {
            txtCompany.Text = "";
            txtID.Text = "";
            txtITEM.Text = "";
            GetSalesEndState();
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

        private void btnSalesCancel_Click(object sender, EventArgs e)
        {
            dgvSalesEndState.EndEdit();
            int cnt = 0;
            foreach (DataGridViewRow item in dgvSalesEndState.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1)
            {
                if (MessageBox.Show("마감취소 하시겠습니까?", "마감취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SalesEndState_VO vo = new SalesEndState_VO();
                    vo.SALES_WORK_ORDER_ID = dgvSalesEndState.CurrentRow.Cells[1].Value.ToString();
                    vo.ITEM_CODE = dgvSalesEndState.CurrentRow.Cells[4].Value.ToString();
                    
                    SalesEndService service = new SalesEndService();
                    Message msg = service.SalesCancel(vo, LoginInfo.UserInfo.LI_NAME);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        this.DialogResult = DialogResult.OK;
                        GetSalesEndState();
                    }
                    else
                    {
                        MessageBox.Show(msg.ResultMessage);
                        return;
                    }
                }    
            }
            else
            {
                MessageBox.Show("하나의 항목씩만 가능합니다.");
                return;
            }
        }
    }
}
