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
using TEAM3FINAL.HHW;
using log4net.Core;

namespace TEAM3FINAL
{
    public partial class FrmProductOUTState : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public FrmProductOUTState()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvProductOUTState);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvProductOUTState, "");
            DataGridViewColumn dc = dgvProductOUTState.Columns[0];
            dc.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "고객주문번호", "SALES_WORK_ORDER_ID", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "납기일", "SALES_DUEDATE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "고객사코드", "COM_CODE", true, 250);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "고객사", "COM_NAME", true, 250);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "도착지코드", "SALES_COM_CODE", true, 250);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "주문수량", "WO_PLAN_QTY", true, 150, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUTState, "출고된수량", "OUTed_QTY", true, 150, DataGridViewContentAlignment.MiddleRight);
            dgvProductOUTState.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductOUTState.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvProductOUTState);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvProductOUTState.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvProductOUTState.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvProductOUTState.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvProductOUTState.Rows)
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

        private void FrmProductOUTState_Load(object sender, EventArgs e)
        {
            btnset();
            DataGridViewColumnSet();
            GetProductOUTStateList();
        }

        private void GetProductOUTStateList()
        {
            ProductOUTService service = new ProductOUTService();
            dgvProductOUTState.DataSource = null;
            dgvProductOUTState.DataSource = service.GetProductOUTStateList();
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            
        }

        public void Search(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text;
                string item = txtITEM.Text;
                string company = txtCompany.Text;

                ProductOUTService service = new ProductOUTService();
                dgvProductOUTState.DataSource = null;
                dgvProductOUTState.DataSource = service.SearchProductOUTState(id, item, company);
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            txtCompany.Text = "";
            txtID.Text = "";
            txtITEM.Text = "";
            GetProductOUTStateList();
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

        private void FrmProductOUTState_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset;
            frm.ePrint -= Print;
        }

        private void btnProductOUTCancel_Click(object sender, EventArgs e)
        {
            dgvProductOUTState.EndEdit();
            int cnt = 0;
            foreach (DataGridViewRow item in dgvProductOUTState.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1)
            {
                ProductOUT_VO vo = new ProductOUT_VO();
                vo.SALES_WORK_ORDER_ID = dgvProductOUTState.CurrentRow.Cells[1].Value.ToString();
                vo.SALES_COM_CODE = dgvProductOUTState.CurrentRow.Cells[5].Value.ToString(); //고객사 창고
                vo.ITEM_CODE = dgvProductOUTState.CurrentRow.Cells[6].Value.ToString();
                vo.WO_PLAN_QTY = Convert.ToInt32(dgvProductOUTState.CurrentRow.Cells[8].Value); //주문수량
                vo.OUTed_QTY = Convert.ToInt32(dgvProductOUTState.CurrentRow.Cells[9].Value); //출고된 수량

                if(vo.WO_PLAN_QTY == vo.OUTed_QTY)
                {
                    MessageBox.Show("이미 출고 완료된 상태입니다.");
                    return;
                }
                if(MessageBox.Show($"{vo.SALES_WORK_ORDER_ID} 출하 취소 하시겠습니까?", "출하취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProductOUTService service = new ProductOUTService();
                    Message msg = service.ProductOUTCancel(vo, LoginInfo.UserInfo.LI_NAME);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        this.DialogResult = DialogResult.OK;
                        GetProductOUTStateList();
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
                MessageBox.Show("하나의 항목씩만 가능");
                return;
            }
        }
    }
}
