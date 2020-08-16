using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Popup;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmDemandPlan : TEAM3FINAL.baseForm2, CommonBtn
    {
        public FrmDemandPlan()
        {
            InitializeComponent();
        }
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPlan.AutoGenerateColumns = true;
            dgvPlan.AllowUserToAddRows = false;
            dgvPlan.MultiSelect = false;
            dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlan.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            dgvPlan.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            if (dgvPlan.Rows.Count > 0)
            {
                DataGridViewColumn column = dgvPlan.Columns[0];
                dgvPlan.Columns[0].Frozen = true;
                column.Width = 200;

                column = dgvPlan.Columns[1];
                dgvPlan.Columns[1].Frozen = true;
                column.Width = 200;

                column = dgvPlan.Columns[2];
                dgvPlan.Columns[2].Frozen = true;
                column.Width = 150;

                column = dgvPlan.Columns[3];
                dgvPlan.Columns[3].Frozen = true;
                column.Width = 150;

                foreach (DataGridViewColumn item in dgvPlan.Columns)
                {
                    item.ReadOnly = true;
                }

                //행번호 추가
                DataGridViewUtil.DataGridViewRowNumSet(dgvPlan);
            }
        }
        private void BindingComboBox()
        {
            ////서비스호출
            ComboItemService service = new ComboItemService();

            var planlist = service.GetPlanID();
            CommonUtil.ComboBinding<ComboItemVO>(cboPlan, planlist, "COMMON_CODE", "COMMON_NAME");
        }
        #region 공통버튼 적용
        /// <summary>
        /// 공통버튼 이벤트 추가 메서드
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


        public void Insert(object sender, EventArgs e)
        {
            //사용하지않음
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //데이터 조회
                LoadDemandPlan();
                //그리드 초기화
                DataGridViewColumnSet();
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                cboPlan.SelectedIndex = 0;
                dtpToDate.Value = DateTime.Now.AddMonths(1);
                dtpFrom.Value = DateTime.Now;
                //데이터 조회
                LoadDemandPlan();
                //그리드 초기화
                DataGridViewColumnSet();
            }
        }

        public void Update(object sender, EventArgs e)
        {
            //사용하지않음
        }

        public void Delete(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgvPlan.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                    try
                    {
                        int i, j;
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.InitialDirectory = "C:";
                        saveFileDialog1.Title = "SaveDemandPlan";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvPlan.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvPlan.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvPlan.RowCount; i++)
                            {
                                for (j = 0; j < dgvPlan.ColumnCount - 1; j++)
                                {
                                    if (dgvPlan[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvPlan[j, i].Value.ToString();
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

        #endregion

        private void FrmDemandPlan_Load(object sender, EventArgs e)
        {
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();

            dtpToDate.Value = DateTime.Now.AddMonths(1);
            dtpFrom.Value = DateTime.Now;
            Search(null, null);
        }

        private void LoadDemandPlan()
        {
            string fromDate = dtpFrom.Value.ToShortDateString();
            string toDate = dtpToDate.Value.ToShortDateString();
            //서비스호출
            PlanService service = new PlanService();
            DataTable dt = service.GetDemandPlan(fromDate, toDate, cboPlan.Text);
            dgvPlan.DataSource = null;
            dgvPlan.DataSource = dt;
        }

        private void FrmDemandPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }

        private void btnProductPlan_Click(object sender, EventArgs e)
        {
            //생산계획 생성
            //생성 가능 여부 확인
            FrmDemandPlanPop frm = new FrmDemandPlanPop();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //작업지시 생성 여부 확인
                PlanService service = new PlanService();
                if (service.CheckWOCreate(frm.PlanID)) //생성가능
                {
                    //작업지시 생성
                    PlanService service1 = new PlanService();
                    if(service1.InsertWorkOrders(frm.PlanID))
                    {
                        MessageBox.Show("생산계획이 생성되었습니다.", "생산계획 생성확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("생산계획이 생성에 실패하였습니다.", "생산계획 생성실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //생성불가
                {
                    MessageBox.Show("생산계획을 생성할 수 없습니다. 이미 생성된 계획입니다.", "생산계획 생성확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //확인여부 출력

            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpToDate.Value)
            {
                MessageBox.Show("시작일은 종료일보다 늦을 수 없습니다.");
                dtpToDate.Value = dtpFrom.Value;
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Value < dtpFrom.Value)
            {
                MessageBox.Show("종료일은 시작일보다 빠를 수 없습니다.");
                dtpFrom.Value = dtpToDate.Value;
            }
        }
    }
}
