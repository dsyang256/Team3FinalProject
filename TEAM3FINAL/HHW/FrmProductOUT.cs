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

namespace TEAM3FINAL
{
    public partial class FrmProductOUT : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public FrmProductOUT()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvProductOUT);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvProductOUT, "");
            DataGridViewColumn dc = dgvProductOUT.Columns[0];
            dc.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객주문번호", "SALES_WORK_ORDER_ID", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "납기일", "SALES_DUEDATE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객사코드", "COM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객사", "COM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "도착지코드", "SALES_COM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "주문수량", "WO_PLAN_QTY", true, 120, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "현재고량", "INS_QTY", true, 110, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "출고된수량", "OUTed_QTY", true, 110, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "출고할수량", "OUTing_QTY", true, 110, readOnly: false);
            dgvProductOUT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductOUT.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvProductOUT);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvProductOUT.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvProductOUT.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvProductOUT.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvProductOUT.Rows)
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

        private void FrmProductOUT_Load(object sender, EventArgs e)
        {
            btnset();
            DataGridViewColumnSet();
            GetProductOUT();
        }


        #region 그리드뷰 로우 내용 수정

        private void dgvProductOUT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        #endregion


        private void GetProductOUT()
        {
            ProductOUTService service = new ProductOUTService();
            dgvProductOUT.DataSource = null;
            dgvProductOUT.DataSource = service.GetProductOUTList();
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
                dgvProductOUT.DataSource = null;
                dgvProductOUT.DataSource = service.SearchProductOUT(id, item, company);
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
            GetProductOUT();
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
            dgvProductOUT.EndEdit();
            int cnt = 0;
            //체크가 되었는지 확인
            foreach (DataGridViewRow item in dgvProductOUT.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1)
            {
                ProductOUT_VO vo = new ProductOUT_VO();
                vo.SALES_WORK_ORDER_ID = dgvProductOUT.CurrentRow.Cells[1].Value.ToString();
                vo.SALES_COM_CODE = dgvProductOUT.CurrentRow.Cells[5].Value.ToString();
                vo.ITEM_CODE = dgvProductOUT.CurrentRow.Cells[6].Value.ToString();
                vo.WO_PLAN_QTY = Convert.ToInt32(dgvProductOUT.CurrentRow.Cells[8].Value);
                vo.INS_QTY = Convert.ToInt32(dgvProductOUT.CurrentRow.Cells[9].Value); //현재 창고 안의 재고수량
                vo.OUTed_QTY = Convert.ToInt32(dgvProductOUT.CurrentRow.Cells[10].Value);
                vo.OUTing_QTY = Convert.ToInt32(dgvProductOUT.CurrentRow.Cells[11].Value);
                if (vo.INS_QTY < vo.OUTing_QTY)
                {
                    MessageBox.Show("출고수량이 현 창고의 재고수량보다 많을 수 없습니다.");
                    return;
                }
                if(vo.WO_PLAN_QTY < vo.OUTed_QTY + vo.OUTing_QTY)
                {
                    MessageBox.Show("출고 수량이 주문수량을 초과합니다.");
                    return;
                }
                if(vo.OUTing_QTY == 0)
                {
                    MessageBox.Show("출고할 수량을 입력하여 주십시오.");
                    return;
                }

                ProductOUTService service = new ProductOUTService();
                Message msg = service.ProductOUT(vo, LoginInfo.UserInfo.LI_NAME);
                if (msg.IsSuccess)
                {
                    MessageBox.Show(msg.ResultMessage);
                    this.DialogResult = DialogResult.OK;
                    GetProductOUT();
                }
                else
                {
                    MessageBox.Show(msg.ResultMessage);
                    return;
                }
            }
            else
            {
                MessageBox.Show("하나의 항목씩만 가능");
                return;
            }
        }

        private void FrmProductOUT_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset;
            frm.ePrint -= Print;
        }
    }
}
