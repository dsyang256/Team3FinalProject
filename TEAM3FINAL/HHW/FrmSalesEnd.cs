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
    public partial class FrmSalesEnd : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmSalesEnd()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvSalesEnd);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvSalesEnd, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "고객주문번호", "SALES_WORK_ORDER_ID", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "고객사", "COM_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "도착지명", "SALES_COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "품명", "ITEM_NAME", true, 110);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "납기일", "SALES_DUEDATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "주문수량", "WO_PLAN_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "출하수량", "OUTed_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "마감수량", "WO_PLAN_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesEnd, "매출확정금액", "EndPrice", true, 120, DataGridViewContentAlignment.MiddleRight);
            dgvSalesEnd.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSalesEnd.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvSalesEnd);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvSalesEnd.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvSalesEnd.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvSalesEnd.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvSalesEnd.Rows)
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

        private void FrmSalesEnd_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();
            btnset();
            GetSalesEnd();
        }

        private void GetSalesEnd()
        {
            SalesEndService service = new SalesEndService();
            dgvSalesEnd.DataSource = null;
            dgvSalesEnd.DataSource = service.GetSalesEnd();
        }

        private void FrmSalesEnd_FormClosing(object sender, FormClosingEventArgs e)
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
            dgvSalesEnd.DataSource = null;
            dgvSalesEnd.DataSource = service.SearchSalesEnd(id, item, company);

        }

        public void Reset(object sender, EventArgs e)
        {
            txtCompany.Text = "";
            txtID.Text = "";
            txtITEM.Text = "";
            GetSalesEnd();
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

        private void btnMOVE_Click(object sender, EventArgs e)
        {
            dgvSalesEnd.EndEdit();
            int cnt = 0;
            //체크가 되었는지 확인
            foreach (DataGridViewRow item in dgvSalesEnd.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1)
            {
                if (MessageBox.Show("마감처리 하시겠습니까?", "매출마감", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SalesEndState_VO vo = new SalesEndState_VO();
                    vo.SALES_WORK_ORDER_ID = dgvSalesEnd.CurrentRow.Cells[1].Value.ToString();
                    vo.SALES_COM_CODE = dgvSalesEnd.CurrentRow.Cells[3].Value.ToString();
                    vo.ITEM_CODE = dgvSalesEnd.CurrentRow.Cells[4].Value.ToString();
                    vo.SALES_DUEDATE = dgvSalesEnd.CurrentRow.Cells[6].Value.ToString();
                    vo.SALES_QTY = Convert.ToInt32(dgvSalesEnd.CurrentRow.Cells[7].Value);
                    vo.SALES_TTL = Convert.ToInt32(dgvSalesEnd.CurrentRow.Cells[10].Value);

                    SalesEndService service = new SalesEndService();
                    Message msg = service.SalesRecord(vo, LoginInfo.UserInfo.LI_NAME);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        this.DialogResult = DialogResult.OK;
                        GetSalesEnd();
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
