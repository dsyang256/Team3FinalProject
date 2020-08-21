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
            
            //Search(null, null);
           

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
                if(cboPlan.Text.Length <1)
                {
                    MessageBox.Show("PlanID를 선택해주세요");
                    return;
                }
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
                dgvReorder.DataSource = null;
                cboPlan.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now.AddDays(-5);
                dateTimePicker2.Value = DateTime.Now.AddDays(5);
             
            }

        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                MessageBox.Show("사용안해요");
            }
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
                MessageBox.Show("사용안해요");
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
                if (dgvReorder.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                    try
                    {
                        int i, j;
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.InitialDirectory = "C:";
                        saveFileDialog1.Title = "SaveReorder";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvReorder.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvReorder.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvReorder.RowCount; i++)
                            {
                                for (j = 0; j < dgvReorder.ColumnCount - 1; j++)
                                {
                                    if (dgvReorder[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvReorder[j, i].Value.ToString();
                                }
                            }

                            xlWorkBook.SaveAs(saveFileDialog1.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                            xlWorkBook.Close(true);
                            xlApp.Quit();
                            MessageBox.Show("출력되었습니다.", "출력 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("출력에 실패하였습니다.", "출력 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (xlApp != null)
                        {
                            releaseObject(xlWorkSheet);
                            releaseObject(xlWorkBook);
                            releaseObject(xlApp);
                        }
                    }
                }

            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
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


        private void FrmReorder_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eUpdate -= Update;
            frm.eDelete -= Delete;
            frm.ePrint -= Print;
            frm.eReset -= Reset;
           
        }
    }
}
