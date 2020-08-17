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
    public partial class FrmWarehousingWait : baseForm2 , CommonBtn
    {
        CheckBox headerChk;
        CheckBox headerChk1;
        public FrmWarehousingWait()
        {
            InitializeComponent();
        }

        private void FrmWarehousingWait_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
            DataGridViewBinding2();
            DataGridViewBinding1();
            BtnSet();
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

        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv1, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주일자", "REORDER_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납품업체", "REORDER_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단위", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "검사여부", "ITEM_INCOME_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주량", "REORDER_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입고량", "REORDER_QTY1", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "잔량", "REORDER_QTY2", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납기일자", "REORDER_DATE_IN", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주유형", "REORDER_TYP", true, 100);
            DataGridViewCheckBoxAllCheck1();
        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주코드", "REORDER_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "ITEM_STND", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "단위", "ITEM_UNIT", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발수수량", "REORDER_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "잔여수량", "REORDER_QTY1", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고수량", "", true, 80,readOnly:false);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주상태", "REORDER_STATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품일자", "REORDER_DATE_IN", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주일자", "REORDER_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "검사유무", "ITEM_INCOME_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고창고", "ITEM_WRHS_IN", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "작업번호", "SALES_WORK_ORDER_ID", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "비고", "", true, 100);
            DataGridViewCheckBoxAllCheck2();
        }
        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;
            ReorderService service = new ReorderService();
            dgv1.DataSource = service.GetWarehousingWait2();
        }
        private void DataGridViewBinding2()
        {
            dgv2.DataSource = null;
            ReorderService service = new ReorderService();
            dgv2.DataSource = service.GetWarehousingWait(); 
        }
        #endregion
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck1()
        {
            headerChk = new CheckBox();
            Point headerCell = dgv1.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked1;
            dgv1.Controls.Add(headerChk);
        }
        private void DataGridViewCheckBoxAllCheck2()
        {
            headerChk1= new CheckBox();
            Point headerCell = dgv2.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk1.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk1.Size = new Size(18, 18);
            headerChk1.BackColor = Color.FromArgb(245, 245, 246);
            headerChk1.Click += HeaderChk_Clicked2;
            dgv2.Controls.Add(headerChk1);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked1(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgv2.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk1.Checked;
            }
        }
        /// <summary>
        /// 데이터 그리드뷰 이벤트
        /// </summary>
        private void dgv2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 9)
            {
                dgv2.EndEdit();
                int a = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[8].Value);
                int b = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[9].Value);
                if (a< b)
                {
                    MessageBox.Show("입고량이 발주량보다 많을수없습니다.");
                    dgv2.Rows[e.RowIndex].Cells[9].Value = 0;
                }
            }
        }

        private void dgv2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgv2.CurrentCell.ColumnIndex == 9)
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
        /// <summary>
        /// 버튼 이벤트
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            dgv2.EndEdit();
            StringBuilder sb = new StringBuilder();
            int cnt = 0;
            //품목 선택후 List를 전달
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value))
                {
                    if (item.Cells[10].Value.ToString() != "발주")
                    {
                        MessageBox.Show("발주 상태만 취소 가능합니다.");
                        return;
                    }
                    sb.Append(item.Cells[2].Value.ToString() + "@");
                    cnt++;
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("취소할 항목을 선택하여 주십시오.");
                return;
            }
            sb.Remove(sb.Length - 1, 1);
            if (MessageBox.Show($"총 {cnt}개의 항목의 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ReorderService item = new ReorderService();
                if (item.DeleteREORDER(sb.ToString()));
                {
                    MessageBox.Show($"총 {cnt}개 발주가 삭제되었습니다.");
                    DataGridViewBinding2();
                }


            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            dgv2.EndEdit();
            ReorderService service = new ReorderService();
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                    a++;
                    if (item.Cells[9].Value == null)
                    {
                        MessageBox.Show("입고할 품목의 수량을 입력해주세요");
                        return;
                    }
                }
            }
            if (a == 0)
            {
                MessageBox.Show("입고할 품목을 선택해주세요");
                return;
            }
            REORDERDETATILS_VO vo = new REORDERDETATILS_VO();
            ITEM_VO vo2 = new ITEM_VO();
            int su = 0;
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                    vo2.ITEM_QTY_UNIT = Convert.ToInt32(item.Cells[8].Value);
                    vo2.ITEM_CODE = item.Cells[3].Value.ToString();
                    vo2.ITEM_INCOME_YN = item.Cells[13].Value.ToString();
                    vo2.ITEM_WRHS_IN = (item.Cells[14].Value == null) ? "R-01" : item.Cells[14].Value.ToString();
                    vo.REORDER_DETAIL_QTY_GOOD = Convert.ToInt32(item.Cells[9].Value);
                    vo.REORDER = Convert.ToInt32(item.Cells[2].Value);
                    string id = item.Cells[15].Value.ToString();
                    if (service.insertREORDERDETATILS(vo, vo2,id)) ;
                    {
                        su++;
                    }
                }
            }
            if (su > 0)
            {
                DataGridViewBinding2();
                MessageBox.Show("입고대기가 완료 되었습니다.");
            }
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
                string day1 = sday.Value.ToShortDateString();
                string day2 = eday.Value.ToShortDateString();
                string code1 = COM_CODE_OUT.Text;
                string name = textBox1.Text;
                string reorder = REORDER_CODE.Text;
                string cod2 = COM_CODE_IN.Text;
                ReorderService service = new ReorderService();
                dgv1.DataSource = service.SPGetWarehousingWait(day1, day2, code1, name, reorder, cod2);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                DataGridViewBinding2();
                DataGridViewBinding1();
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
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }
    }
}
