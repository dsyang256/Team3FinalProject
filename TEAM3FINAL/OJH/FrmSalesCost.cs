using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Excel = Microsoft.Office.Interop.Excel;

namespace TEAM3FINAL
{
    public partial class FrmSalesCost : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        List<SalesCostList_VO> AllList;
        CheckBox headerChk;
        string openFileName = string.Empty;
        #endregion

        #region 생성자
        public FrmSalesCost()
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
            Point headerCell = dgvCost.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvCost.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvCost.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvCost.Rows)
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
            DataGridViewUtil.InitSettingGridView(dgvCost);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvCost, "");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "영업코드", "SC_Code", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "업체", "COM_Code", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "업체명", "COM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "품목", "ITEM_Code", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "규격", "ITEM_STND", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "단위", "ITEM_UNIT", true, 100);
            dgvCost.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "현재단가", "SC_UNITPRICE_CUR", true, 100);
            dgvCost.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "이전단가", "SC_UNITPRICE_EX", true, 100);
            dgvCost.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "시작일", "SC_STARTDATE", true, 120);
            dgvCost.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "종료일", "SC_ENDDATE", true, 120);
            dgvCost.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "비고", "SC_REMARK", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCost, "사용유무", "SC_USE_YN", true, 100);
            dgvCost.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCost.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCost.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvCost);
            //체크박스추가
            DataGridViewCheckBoxAllCheck();
        }

        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private string CheckedList()
        {
            dgvCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvCost.Rows)
            {
                if (item is DataGridViewRow)
                {
                    DataGridViewRow row = item as DataGridViewRow;
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        sb.Append(row.Cells[1].Value.ToString() + "@");
                    }
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("품목을 선택해주십시오.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            sb.Remove(sb.Length - 1, 1);

            //체크 목록을 string으로 만듬
            return sb.ToString();
        }

        private void LoadCostList()
        {
            //서비스 호출
            CostService service = new CostService();
            AllList = service.SalesCostList();
            dgvCost.DataSource = null;
            dgvCost.DataSource = AllList;
        }

        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var ComList = service.GetCompanyCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboCompany, ComList, "COMMON_CODE", "COMMON_NAME", "");
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

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string lists = CheckedList();
                if (lists.Length > 0)
                {
                    if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //서비스 호출
                        CostService service = new CostService();
                        if (service.DeleteSalesCostList(lists, "@"))
                        {
                            MessageBox.Show("삭제되었습니다.", "삭제 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("삭제 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                Reset(null, null);
            }

        }

        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmSalesCostPop frm = new FrmSalesCostPop(InsertOrUpdate.insert);
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgvCost.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                    try
                    {
                        int i, j;
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.InitialDirectory = "C:";
                        saveFileDialog1.Title = "SaveSalesCost";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvCost.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvCost.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvCost.RowCount; i++)
                            {
                                for (j = 0; j < dgvCost.ColumnCount - 1; j++)
                                {
                                    //if (j == 3)
                                    //    continue;
                                    if (dgvCost[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvCost[j, i].Value.ToString();
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

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadCostList();
                txtItemName.Clear();
                cboCompany.SelectedIndex = 0;
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                List<SalesCostList_VO> list = null;
                //기준날짜, 품목 조회
                if (AllList.Count > 0 && dtpDate.Checked)
                {
                    list = (from item in AllList select item).Where
                        (p => Convert.ToDateTime(p.SC_STARTDATE) < dtpDate.Value && Convert.ToDateTime(p.SC_ENDDATE) > dtpDate.Value
                        && p.ITEM_Code.Contains(txtItemName.Text.Trim())).ToList();
                }
                else if (AllList.Count > 0 && !(dtpDate.Checked))
                {
                    list = (from item in AllList select item).Where(p => p.ITEM_Code.Contains(txtItemName.Text.Trim())).ToList();
                }
                //업체명 조회
                if (cboCompany.Text.Length > 0)
                {
                    list = (from item in list select item).Where(p => p.COM_NAME.Contains(cboCompany.Text)).ToList();
                }
                dgvCost.DataSource = null;
                dgvCost.DataSource = list;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string uid = CheckedList();
                if (uid.Length < 1)
                    return;
                if (uid.Contains("@"))
                {
                    MessageBox.Show("수정할 품목 하나를 선택하세요.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmSalesCostPop frm = new FrmSalesCostPop(InsertOrUpdate.update, uid);
                frm.ShowDialog();
                Reset(null, null);
            }
        }
        #endregion

        #endregion

        #region 이벤트
        private void FrmSalesCost_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadCostList();
        }

        /// <summary>
        /// DataGridView 셀 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCost.SelectedRows.Count > 0)
            //{
            //    string str = dgvCost.Rows[e.RowIndex].Cells[3].Value.ToString();
            //}
        }
        #endregion

        private void FrmSalesCost_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }


        /// <summary>
        /// 양식을 다운로드하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYangsic_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            try
            {
                int i, j;

                saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.Title = "SaveSalesCost";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[1, 1] = "업체";
                    xlWorkSheet.Cells[1, 2] = "품목";
                    xlWorkSheet.Cells[1, 3] = "현재단가";
                    xlWorkSheet.Cells[1, 4] = "시작일";
                    xlWorkSheet.Cells[1, 5] = "사용유무";
                    xlWorkSheet.Cells[1, 6] = "비고";

                    xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal);
                    xlWorkBook.Close(true);
                    xlApp.Quit();
                    MessageBox.Show("다운로드되었습니다.", "다운로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("다운로드에 실패하였습니다.", "다운로드 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Reset(null, null);

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

        /// <summary>
        /// 엑셀로 등록하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "OpenSalesCost";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileName = openFileDialog1.FileName;
                if (openFileName.Length > 1)
                {
                    using (frmWaitAsyncForm frm = new frmWaitAsyncForm(GetExcelFile))
                    {
                        frm.ShowDialog(this);
                    }
                }
            }
        }

        /// <summary>
        /// 엑셀 파일 읽어와서 등록하는 메서드
        /// </summary>
        private void GetExcelFile()
        {
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            DataTable dt = new DataTable();
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(openFileName);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                Excel.Range range = xlWorkSheet.UsedRange;

                object[,] data = range.Value;

                for (int i = 1; i <= range.Columns.Count; i++)
                {
                    dt.Columns.Add(data[1, i].ToString(), typeof(string));
                }

                for (int r = 2; r <= range.Rows.Count; r++)
                {
                    DataRow dr = dt.Rows.Add();
                    for (int c = 1; c <= range.Columns.Count; c++)
                    {
                        dr[c - 1] = data[r, c];
                    }
                }

                xlWorkBook.Close(true);
                xlApp.Quit();

                if (dt.Rows.Count > 0)
                {
                    //DB에 저장
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //전달할 VO
                        SalesCost_VO vo = new SalesCost_VO();
                        vo.COM_Code = (dt.Rows[i][0] != null) ? dt.Rows[i][0].ToString() : "";
                        vo.ITEM_Code = (dt.Rows[i][1] != null) ? dt.Rows[i][1].ToString() : "";
                        vo.SC_UNITPRICE_CUR = (dt.Rows[i][2] != null) ? Convert.ToInt32(dt.Rows[i][2]) : 0;
                        vo.SC_UNITPRICE_EX = 0;
                        vo.SC_STARTDATE = (dt.Rows[i][3] != null) ? DateTime.ParseExact(dt.Rows[i][3].ToString(), "yyyy-MM-dd tt hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal).ToString("yyyy-MM-dd HH:mm:ss") : "";
                        vo.SC_ENDDATE = "2099-01-01";
                        vo.SC_USE_YN = (dt.Rows[i][4] != null) ? dt.Rows[i][4].ToString() : "";
                        vo.SC_CODE = 0;
                        vo.SC_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                        vo.SC_LAST_MDFY = DateTime.Now.ToShortDateString();
                        vo.SC_REMARK = (dt.Rows[i][5] != null) ? dt.Rows[i][5].ToString() : "";

                        //서비스호출
                        CostService service = new CostService();
                        var msg = service.InsertOrUpdateSalesCost(vo);
                        if (msg.IsSuccess)
                        {
                            MessageBox.Show(msg.ResultMessage);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(msg.ResultMessage);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (xlApp != null)
                {
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                }
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
