using DevExpress.XtraReports.UI;
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
    public partial class FrmSalesWork : TEAM3FINAL.baseForm2 , CommonBtn
    {
        #region 멤버변수
        List<WORKORDERCREATE_VO> AllList;
        CheckBox headerChk;
        #endregion
        #region 생성자
        public FrmSalesWork()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvWork.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvWork.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvWork.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvWork.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }


        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvWork);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvWork, "  ");
            DataGridViewColumn dc = dgvWork.Columns[0];
            dc.Frozen = true;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품목", "ITEM_CODE", true, 200, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품명", "ITEM_NAME", true, 200, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "규격", "ITEM_STND", true, 100, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "상태", "WO_WORK_STATE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비코드", "FCLTS_CODE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비명", "FCLTS_NAME", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획수량", "WO_PLAN_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "지시수량", "WO_QTY_PROD", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획시작일", "WO_PLAN_STARTTIME", true, 100, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "소요시간(Min.)", "Tacminute", true, 150, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획완료일", "WO_PLAN_ENDTIME", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "작업지시번호", "WO_Code", true, 150, DataGridViewContentAlignment.MiddleCenter);
            dgvWork.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWork.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);




            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvWork);

            //체크박스추가
            DataGridViewCheckBoxAllCheck();
        }
        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private string CheckedList()
        {
            dgvWork.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvWork.Rows)
            {
                if (item is DataGridViewRow)
                {
                    DataGridViewRow row = item as DataGridViewRow;
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        sb.Append(row.Cells[12].Value.ToString() + "@");
                    }
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("작업지시를 선택해주십시오.", "작업지시 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            sb.Remove(sb.Length - 1, 1);

            //체크 목록을 string으로 만듬
            return sb.ToString();
        }
        private void LoadSalesWork()
        {
            //서비스호출
            WorkOrderINService service = new WorkOrderINService();
            AllList = service.GetWorkList();
            dgvWork.DataSource = null;
            dgvWork.DataSource = AllList;
        }
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var FcltsList = service.GetFacilitiesCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboFclts, FcltsList, "COMMON_CODE", "COMMON_NAME", "");
        }
        #endregion
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
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmSalesWorkPop frm = new FrmSalesWorkPop();
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                List<WORKORDERCREATE_VO> list = AllList;

                if (AllList.Count > 0 && cboSearchDate.SelectedIndex > 0)
                {
                    list = (from item in AllList select item).Where
                        (p => DateTime.Parse(p.WO_PLAN_STARTTIME) >= DateTime.Parse(dtpFrom.Value.ToShortDateString())
                        && DateTime.Parse(p.WO_PLAN_STARTTIME) <= DateTime.Parse(dtpTo.Value.ToShortDateString())).ToList();
                }
                if (AllList.Count > 0 && cboWOITEM.SelectedIndex == 1)
                {
                    list = (from item in AllList select item).Where
                        (p => p.WO_Code.Contains(txtItem.Text.Trim())).ToList();
                }
                if (AllList.Count > 0 && cboWOITEM.SelectedIndex == 2)
                {
                    list = (from item in AllList select item).Where
                        (p => p.ITEM_CODE.Contains(txtItem.Text.Trim())).ToList();
                }
                if (AllList.Count > 0 && cboFclts.SelectedIndex > 0)
                {
                    list = (from item in AllList select item).Where
                        (p => p.FCLTS_Name.Contains(cboFclts.Text)).ToList();
                }
                if (AllList.Count > 0 && cboState.SelectedIndex > 0)
                {
                    list = (from item in AllList select item).Where
                        (p => p.WO_WORK_STATE.Contains(cboState.Text)).ToList();
                }
                dgvWork.DataSource = null;
                dgvWork.DataSource = list;
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadSalesWork();
                cboFclts.SelectedIndex = 0;
                cboSearchDate.SelectedIndex = 0;
                cboState.SelectedIndex = 0;
                cboWOITEM.SelectedIndex = 0;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //작업지시확정
                string lists = CheckedWorkDeleteList();
                if (lists.Length > 0)
                {
                    //서비스 호출
                    WorkOrderINService service = new WorkOrderINService();
                    if (service.DeleteWorkList(lists, "@"))
                    {
                        MessageBox.Show("작업취소되었습니다.", "작업취소 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("작업취소 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "작업취소 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Reset(null, null);
            }
        }
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgvWork.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                    try
                    {
                        int i, j;
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.InitialDirectory = "C:";
                        saveFileDialog1.Title = "SaveWorkOrder";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvWork.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvWork.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvWork.RowCount; i++)
                            {
                                for (j = 0; j < dgvWork.ColumnCount - 1; j++)
                                {
                                    //if (j == 3)
                                    //    continue;
                                    if (dgvWork[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 1, j + 1] = dgvWork[j, i].Value.ToString();
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
        private void FrmSalesWork_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadSalesWork();
        }
        private void FrmSalesWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
        private void btnUpdateState_Click(object sender, EventArgs e)
        {
            //작업지시확정
            string lists = CheckedWorkList();
            if (lists.Length > 0)
            {
                //서비스 호출
                WorkOrderINService service = new WorkOrderINService();
                if (service.UpdateWorkList(lists, "@"))
                {
                    MessageBox.Show("작업확정되었습니다.", "작업지시 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("작업확정 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "작업지시 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Reset(null, null);
        }
        private string CheckedWorkList()
        {
            int iCnt = 0;
            //작업지시만 업데이트
            dgvWork.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvWork.EndEdit();
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvWork.Rows)
            {
                if (item is DataGridViewRow)
                {
                    DataGridViewRow row = item as DataGridViewRow;
                    if (row.Cells[4].Value.ToString() == "작업생성")
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            sb.Append(row.Cells[12].Value.ToString() + "@");
                        }
                    }
                    else
                    {
                        iCnt++;
                    }
                }
            }

            if (sb.Length < 1 && iCnt > 0)
            {
                MessageBox.Show("작업생성상태의 작업지시만 확정할 수 있습니다.", "작업지시 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            sb.Remove(sb.Length - 1, 1);
            iCnt = 0;
            //체크 목록을 string으로 만듬
            return sb.ToString();
        }
        private string CheckedWorkDeleteList()
        {
            if (dgvWork.Rows.Count > 0)
            {
                int iCnt = 0;
                //작업지시만 업데이트
                dgvWork.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvWork.EndEdit();
                StringBuilder sb = new StringBuilder();
                //품목 선택후 List를 전달
                foreach (var item in dgvWork.Rows)
                {
                    if (item is DataGridViewRow)
                    {
                        DataGridViewRow row = item as DataGridViewRow;
                        if (row.Cells[4].Value.ToString() == "작업생성")
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                sb.Append(row.Cells[12].Value.ToString() + "@");
                            }
                        }
                        else
                        {
                            iCnt++;
                        }
                    }
                }

                if (sb.Length < 1 && iCnt > 0)
                {
                    MessageBox.Show("작업생성상태의 작업지시만 취소할 수 있습니다.", "작업지시 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "";
                }

                sb.Remove(sb.Length - 1, 1);
                iCnt = 0;
                //체크 목록을 string으로 만듬
                return sb.ToString();
            }
            else return "";
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("시작일은 종료일보다 늦을 수 없습니다.");
                dtpTo.Value = dtpFrom.Value;
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value < dtpFrom.Value)
            {
                MessageBox.Show("종료일은 시작일보다 빠를 수 없습니다.");
                dtpFrom.Value = dtpTo.Value;
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            SalesService service = new SalesService();
            XtraWorkOrder rpt = new XtraWorkOrder();
            DataTable dt = service.GetBaCodeWorkOrderList();
            rpt.Parameters["uName"].Value = LoginInfo.UserInfo.LI_NAME;
            rpt.DataSource = dt;
            rpt.CreateDocument();
            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }

        }
    }
}
