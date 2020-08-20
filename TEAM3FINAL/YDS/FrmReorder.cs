using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmReorder : TEAM3FINAL.baseForm2
    {
        public FrmReorder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-5);
            dateTimePicker2.Value = DateTime.Now.AddDays(5);
            BtnSet();
            ComboBinding();
            cboPlan.SelectedIndex = 1;
            DataGridViewColumnSet();
            
            Search(null, null);
           

        }
       
       
        /// <summary>
        /// 버튼 이벤트 델리게이트 추가
        /// </summary>
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
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            dgvReorder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvReorder.AutoGenerateColumns = true;
            dgvReorder.AllowUserToAddRows = false;
            dgvReorder.MultiSelect = false;
            dgvReorder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReorder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReorder.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            dgvReorder.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            if (dgvReorder.Rows.Count > 0)
            {
                DataGridViewColumn column = dgvReorder.Columns[0];
                dgvReorder.Columns[0].Frozen = true;
                column.Width = 200;

                column = dgvReorder.Columns[1];
                dgvReorder.Columns[1].Frozen = true;
                column.Width = 200;

                column = dgvReorder.Columns[2];
                dgvReorder.Columns[2].Frozen = true;
                column.Width = 150;

                column = dgvReorder.Columns[3];
                dgvReorder.Columns[3].Frozen = true;
                column.Width = 150;

                column = dgvReorder.Columns[4];
                column.Visible = false;

                foreach (DataGridViewColumn item in dgvReorder.Columns)
                {
                    item.ReadOnly = true;
                }

                //행번호 추가
                DataGridViewUtil.DataGridViewRowNumSet(dgvReorder);
            }
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //PLAN_ID
            var listPLAN_ID = (from item in Commonlist where item.COMMON_PARENT == "PLAN_ID" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboPlan, listPLAN_ID, "COMMON_CODE", "COMMON_NAME", "");

           


        }
        /// <summary>
        /// 입력 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmReorderPopUp frm = new FrmReorderPopUp();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Search(null, null);
                }
            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //데이터 조회
                LoadDemandPlan();
                //그리드 초기화
                DataGridViewColumnSet();

                DataGridViewNullToZero();
                DataGridViewColor();
               
            }
        }
        private void LoadDemandPlan()
        {
            string fromDate = dateTimePicker1.Value.ToShortDateString();
            string toDate = dateTimePicker2.Value.ToShortDateString();
            //서비스호출
            PlanService service = new PlanService();
            DataTable dt = service.GetMaterialDemandPlan(fromDate, toDate, cboPlan.Text);
            dgvReorder.DataSource = null;
            dgvReorder.DataSource = dt;
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                cboPlan.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now.AddMonths(1);
                dateTimePicker2.Value = DateTime.Now;
                //데이터 조회
                LoadDemandPlan();
                //그리드 초기화
                DataGridViewColumnSet();
            }

        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 삭제 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                
            }
        }
        /// <summary>
        /// 프린트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }
        private void DataGridViewNullToZero()
        {
            //grid의 null값 => 0
            foreach (DataGridViewRow row in dgvReorder.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 5)
                    {
                        if (cell.Value == null || cell.Value.ToString() == string.Empty)
                        {
                            cell.Value = "0";
                        }
                    }
                }
            }
        }
        private void DataGridViewColor()
        {
            foreach (DataGridViewRow row in dgvReorder.Rows)
            {
                if (row.Cells[3].Value.ToString() == "발주제안")
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex > 5)
                        {
                            if (cell.Value.ToString() != "0")
                            {
                                cell.Style.BackColor = Color.Khaki;
                            }
                        }
                    }
                }
            }

        }
    }
}
