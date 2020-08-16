using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using System.Linq;


namespace TEAM3FINAL
{
    public partial class FrmShiftManage : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        #endregion

        #region 생성자
        public FrmShiftManage()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            dgvShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvShift.AutoGenerateColumns = true;
            dgvShift.AllowUserToAddRows = false;
            dgvShift.MultiSelect = false;
            dgvShift.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShift.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvShift.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            dgvShift.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewUtil.InitSettingGridView(dgvShift);
            if (dgvShift.Rows.Count > 0)
            {
                DataGridViewColumn column = dgvShift.Columns[0];
                dgvShift.Columns[0].Frozen = true;
                column.Width = 150;
                column.HeaderText = "설비명";

                column = dgvShift.Columns[1];
                dgvShift.Columns[1].Frozen = true;
                column.Width = 150;
                column.HeaderText = "Shift";

                column = dgvShift.Columns[2];
                dgvShift.Columns[2].Frozen = true;
                column.Width = 150;
                column.HeaderText = "구분";

                column = dgvShift.Columns[3];
                column.Visible = false;

                foreach (DataGridViewColumn item in dgvShift.Columns)
                {
                    item.ReadOnly = true;
                }

                //행번호 추가
                DataGridViewUtil.DataGridViewRowNumSet(dgvShift);
            }
        }
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();

            var facilist = service.GetFacilitiesCode();


            CommonUtil.ComboBinding<ComboItemVO>(cboFclts, facilist, "COMMON_CODE", "COMMON_NAME", "");
        }
        private void LoadShiftList()
        {
            //서비스호출
            ShiftService service = new ShiftService();
            var list = service.GetShiftManage(dtpFromdate.Value.ToShortDateString(), dtpTodate.Value.ToShortDateString());
            dgvShift.DataSource = null;
            dgvShift.DataSource = list;
            //그리드 초기화
            if (list.Rows.Count > 0)
                DataGridViewColumnSet();
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
            //사용안함
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //서비스호출
                ShiftService service = new ShiftService();
                DataTable list = service.GetShiftManage(dtpFromdate.Value.ToShortDateString(), dtpTodate.Value.ToShortDateString());

                //shift 조회
                if (list.Rows.Count > 0 && cboShift.Text.Length > 0)
                {
                    var rows = (from item in list.AsEnumerable() select item).Where
                    (p => p.Field<string>(1) == cboShift.Text).ToList();
                    var dt = rows.Any() ? rows.CopyToDataTable() : new DataTable();
                    //int A = dt.Rows.Count;
                    list = dt;
                }
                //설비명 조회
                if (list.Rows.Count > 0 && cboFclts.SelectedIndex > 0)
                {
                    var rows = (from item in list.AsEnumerable() select item).Where
                                    (p => p.Field<string>(0) == cboFclts.Text).ToList();
                    var dt = rows.Any() ? rows.CopyToDataTable() : new DataTable();
                    list = dt;
                }
                dgvShift.DataSource = null;
                dgvShift.DataSource = list;
                //그리드 초기화
                DataGridViewColumnSet();
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            LoadShiftList();
            cboFclts.SelectedIndex = 0;
            cboShift.SelectedIndex = 0;
        }

        public void Update(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Delete(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Print(object sender, EventArgs e)
        {
            //엑셀 출력
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgvShift.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp= null;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                    try
                    {
                        int i, j;
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.InitialDirectory = "C:";
                        saveFileDialog1.Title = "Save";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            xlWorkSheet.Cells[1, 1] = "설비명";
                            xlWorkSheet.Cells[1, 2] = "SHIFT";
                            xlWorkSheet.Cells[1, 3] = "구분";
                            //4번 생략
                            for (int k = 5; k < dgvShift.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvShift.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvShift.RowCount; i++)
                            {
                                for (j = 0; j < dgvShift.ColumnCount - 1; j++)
                                {
                                    if (j == 3)
                                        continue;
                                    if (dgvShift[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvShift[j, i].Value.ToString();
                                }
                            }

                            xlWorkBook.SaveAs(saveFileDialog1.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                            xlWorkBook.Close(true);
                            xlApp.Quit();
                            MessageBox.Show("출력되었습니다.","출력 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show("출력에 실패하였습니다.", "출력 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
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

        #endregion

        #region 이벤트
        private void FrmShiftManage_Load(object sender, EventArgs e)
        {
            dtpTodate.Value = DateTime.Now.AddDays(7);
            dtpFromdate.Value = DateTime.Now;

            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadShiftList();
        }
        private void FrmShiftManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }

        #endregion

        private void dtpFromdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromdate.Value > dtpTodate.Value)
            {
                MessageBox.Show("시작일은 종료일보다 늦을 수 없습니다.");
                dtpTodate.Value = dtpFromdate.Value;
            }
        }
        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTodate.Value < dtpFromdate.Value)
            {
                MessageBox.Show("종료일은 시작일보다 빠를 수 없습니다.");
                dtpFromdate.Value = dtpTodate.Value;
            }
        }
    }
}
