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
    public partial class FrmReleaseRequest : baseForm2, CommonBtn
    {
        public CheckBox headerChk;

        public FrmReleaseRequest()
        {
            InitializeComponent();
        }

        private void FrmReleaseRequest_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
            DataGridViewBinding1();
            BtnSet();
        }

        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //설비
            var listFACILITY = (from item in Commonlist where item.COMMON_PARENT == "설비" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(FACILITY, listFACILITY, "COMMON_CODE", "COMMON_NAME", "");
            //작업지시id
            var listid = (from item in Commonlist where item.COMMON_PARENT == "작업지시" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WORKORDER, listid, "COMMON_CODE", "COMMON_NAME", "");

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "계획시작일자", "WO_PLAN_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "작업지시ID", "WO_Code", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "설비명", "FCLTS_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "소진창고", "FAC_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "지시수량", "WO_PLAN_QTY", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단위", "ITEM_UNIT", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "상태명", "WO_WORK_STATE", true, 200);


           

        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "ITEM_STND", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청창고", "FAC_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청일", "Date", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "재고량", "현재고", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "표준불출수량", "표준불출수량", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "계획요청수량", "WO_PLAN_QTY", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청수량", "", true, 100, readOnly:false) ;
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "출고수량", "출고", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "잔량", "잔량", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고창고", "FCLTS_WRHS_GOOD", false, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "작업번호", "SALES_WORK_ORDER_ID", false, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "출고창고", "FCLTS_WRHS_EXHST", false, 125);
            DataGridViewCheckBoxAllCheck();

        }
        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;
            WorkOrderDSService service = new WorkOrderDSService();
            dgv1.DataSource = service.GetWorkOrder();
        }

        #endregion
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgv2.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgv2.Controls.Add(headerChk);
        }
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgv2.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string code = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dgv2.DataSource = null;
            WorkOrderDSService service = new WorkOrderDSService();
            dgv2.DataSource = service.GetWorkOrder2(code);
        }

        private void dgv2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgv2.CurrentCell.ColumnIndex == 10)
                {
                    DataGridViewTextBoxEditingControl textBox = e.Control as DataGridViewTextBoxEditingControl;
                    if (textBox != null)
                    {
                        textBox.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
                        textBox.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                    }
                }
            }
            catch (Exception err)
            {
                return;
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void dgv2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                dgv2.EndEdit();
                int a = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[7].Value);
                int b = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[12].Value);
                int c = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[10].Value);
                if (c > a)
                {
                    MessageBox.Show("요청량이 재고보다 많습니다.");
                    dgv2.Rows[e.RowIndex].Cells[10].Value = null;
                    return;
                }
                if (c >b)
                {
                    MessageBox.Show("요청량이 잔량보다 많습니다.");
                    dgv2.Rows[e.RowIndex].Cells[10].Value = null;
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv2.EndEdit();
            INSTACKService service = new INSTACKService();
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) && item.Cells[10].Value != null)
                {
                    int qty = Convert.ToInt32(item.Cells[10].Value);
                    string code = item.Cells[2].Value.ToString();
                    string wrhsin = item.Cells[13].Value.ToString();
                    string id = item.Cells[14].Value.ToString();
                    string wrhsout = item.Cells[15].Value.ToString();
                    service.INSERT_instack(qty, wrhsin, wrhsout, code, id);
                }
            }
            dgv2.DataSource = null;
            
            
        }
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

        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if(((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        private void BtnUnSet()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eUpdate -= Update;
            frm.eDelete -= Delete;
            frm.ePrint -= Print;
            frm.eReset -= Reset;
        }
        private void FrmReleaseRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
