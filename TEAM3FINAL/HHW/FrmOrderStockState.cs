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
    public partial class FrmOrderStockState : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmOrderStockState()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvCustomerOrder);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvCustomerOrder, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "품목", "ITEM_CODE", true, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "품명", "ITEM_NAME", true, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "규격", "ITEM_STND", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "창고", "FAC_CODE", false, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "창고", "FAC_NAME", true, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "이동량", "WO_QTY_OUT", true, 80, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "비고", "WO_REMARK", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "작업지시ID", "SALES_WORK_ORDER_ID", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "제품타입", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCustomerOrder, "이동창고", "ToWHouse", true, 100);
            dgvCustomerOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCustomerOrder.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvCustomerOrder);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvCustomerOrder.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvCustomerOrder.Controls.Add(headerChk);
        }
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvCustomerOrder.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvCustomerOrder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        #endregion

        private void FrmOrderStockState_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetOrderInfo();
        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            //var listCOMPANY_TYP = (from item in commonlist where item.COMMON_PARENT == "COMPANY_TYP" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(cboCategory, listCOMPANY_TYP, "COMMON_CODE", "COMMON_NAME", "");
        }

        private void GetOrderInfo()
        {
            WorkOrderService service = new WorkOrderService();
            dgvCustomerOrder.DataSource = null;
            dgvCustomerOrder.DataSource = service.OrderList();
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



        private void FrmOrderStockState_FormClosing(object sender, FormClosingEventArgs e)
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
            if(dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("시작일이 종료일 보다 클 수 없습니다.");
                return;
            }
            string fromDATE = dtpFrom.Value.ToString("yyyy-MM-dd");
            string fromTO = dtpTo.Value.ToString("yyyy-MM-dd");

            WorkOrderService service = new WorkOrderService();
            dgvCustomerOrder.DataSource = null;
            dgvCustomerOrder.DataSource = service.SearchOrderState(fromDATE, fromTO, txtITEM_CODE.Text);

        }

        public void Reset(object sender, EventArgs e)
        {
            
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

        private void btnWorkCancel_Click(object sender, EventArgs e)
        {
            //수정 시 여러개의 체크박스를 선택하는것을 막음
            dgvCustomerOrder.EndEdit();
            //string sb = string.Empty;
            int cnt = 0;
            //체크가 되었는지 확인
            foreach (DataGridViewRow item in dgvCustomerOrder.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1) //하나일 경우 PopUp창 띄움
            {
                OrderState_VO vo = new OrderState_VO();
                vo.SALES_WORK_ORDER_ID = dgvCustomerOrder.CurrentRow.Cells[8].Value.ToString();
                vo.WO_QTY_OUT = Convert.ToInt32(dgvCustomerOrder.CurrentRow.Cells[6].Value);
                vo.ITEM_CODE = dgvCustomerOrder.CurrentRow.Cells[1].Value.ToString();
                vo.FAC_CODE = dgvCustomerOrder.CurrentRow.Cells[4].Value.ToString();

                if(MessageBox.Show("작업완료 하시겠습니까?", "제품이동", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WorkOrderService service = new WorkOrderService();
                    Message msg = service.OrderMoveFac(vo);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        GetOrderInfo();
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
