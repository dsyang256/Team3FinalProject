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
    public partial class FrmSalesWorkList : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        List<WORKORDERSearch_VO> AllList;
        CheckBox headerChk;
        #endregion
        #region 생성자
        public FrmSalesWorkList()
        {
            InitializeComponent();
        }
        #endregion
        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvWork);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "투입시간", "WO_PLAN_STARTTIME", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "지시일", "WO_PLAN_DATE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비코드", "FCLTS_CODE", true, 120, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비명", "FCLTS_Name", true, 150, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "우선순위", "WO_WORK_SEQ", true, 100, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "상태", "WO_WORK_STATE", true, 120, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품목", "ITEM_CODE", true, 120, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품명", "ITEM_NAME", true, 150, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "소진창고", "FCLTS_WRHS_EXHST", true, 120, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "양품창고", "FCLTS_WRHS_GOOD", true, 120, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "불량창고", "FCLTS_WRHS_BAD", true, 120, DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "지시량", "WO_PLAN_QTY", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "양품량", "WO_QTY_GOOD", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "불량", "WO_QTY_BAD", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "작업지시번호", "WO_Code", false, 150, DataGridViewContentAlignment.MiddleCenter);
            dgvWork.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWork.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvWork);

        }
        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private void LoadSalesWork()
        {
            //서비스호출
            WorkOrderINService service = new WorkOrderINService();
            AllList = service.GetWorkOrderList();
            dgvWork.DataSource = null;
            dgvWork.DataSource = AllList;
        }
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var factoryList = service.GetFactoryCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboWarehouse, factoryList, "COMMON_CODE", "COMMON_NAME", "");
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
                List<WORKORDERSearch_VO> list = AllList;

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
                if (AllList.Count > 0 && cboWarehouse.SelectedIndex > 0)
                {
                    list = (from item in AllList select item).Where
                        (p => p.FCLTS_WRHS_EXHST.Contains(cboWarehouse.Text)).ToList();
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
                cboWarehouse.SelectedIndex = 0;
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
            //사용안함
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
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvWork[j, i].Value.ToString();
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

        private void FrmSalesWorkList_Load(object sender, EventArgs e)
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

        private void FrmSalesWorkList_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
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
    }
}
