using log4net.Core;
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
    public partial class FrmBOM : baseForm2, CommonBtn
    {
        /// <summary>
        /// 그리드뷰 체크 박스 
        /// </summary>
        CheckBox headerChk;
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public FrmBOM()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            try
            {
                BtnSet();
                DataGridViewColumnSet();
                DataGridViewBinding();
                ComboBinding();
            }
            catch(Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 삭제 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    dgvBOM.EndEdit();
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvBOM.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value))
                        {
                            sb.Append(item.Cells[2].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("미사용 항목을 선택하여 주십시오.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"총 {cnt}개의 항목을 미사용 하겠습니까?? 하위항목도 미사용됨니다. ", "미사용", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BOMService service = new BOMService();
                        if (service.DeleteBOM(sb))
                        {
                            MessageBox.Show("미사용 완료");
                            DataGridViewBinding();
                        }
                    }
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }

            }

        }
        /// <summary>
        /// 등록 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    FrmBOMPopUp frm = new FrmBOMPopUp();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewBinding();
                    }
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }

            }
        }
        /// <summary>
        /// 프린트 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    if (dgvBOM.Rows.Count > 0)
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
                            saveFileDialog1.Title = "SaveBOM";
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                xlApp = new Microsoft.Office.Interop.Excel.Application();
                                xlWorkBook = xlApp.Workbooks.Add();
                                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                                for (int k = 1; k < dgvBOM.ColumnCount; k++)
                                {
                                    xlWorkSheet.Cells[1, k] = dgvBOM.Columns[k].HeaderText.ToString();
                                }

                                for (i = 0; i < dgvBOM.RowCount; i++)
                                {
                                    for (j = 0; j < dgvBOM.ColumnCount - 1; j++)
                                    {
                                        if (dgvBOM[j, i].Value != null)
                                            xlWorkSheet.Cells[i + 2, j + 1] = dgvBOM[j, i].Value.ToString();
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
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
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
            catch (Exception err)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + err.ToString());
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// 리셋 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    DataGridViewBinding();
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }
            }
        }
        /// <summary>
        /// 조회 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    if (ITEM_NAEM.Text.Length < 1)
                    {
                        MessageBox.Show("검색하실 품목명을 입력해주세요");
                        return;
                    }
                    BOMService bom = new BOMService();
                    dgvBOM.DataSource = bom.SearchBOM(day.Value.ToShortDateString(), ITEM_NAEM.Text, BOM_USE_YN.Text);
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }
            }
        }
        /// <summary>
        /// 업데이트 버튼 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    dgvBOM.EndEdit();
                    int cnt = 0;
                    int code = 0;
                    //체크가 되었는지 확인
                    foreach (DataGridViewRow item in dgvBOM.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value))
                        {
                            //MessageBox.Show(item.Cells[2].ToString());
                            code = Convert.ToInt32(item.Cells[2].Value);
                            cnt++;
                        }
                    }
                    if (cnt < 1)
                    {
                        MessageBox.Show("수정할 항목을 선택해주세요.");
                        return;
                    }
                    if (cnt != 1)
                    {
                        MessageBox.Show("하나의 항목씩만 수정 가능 합니다.");
                        return;
                    }
                    else if (cnt == 1)
                    {
                        FrmBOMPopUp frm = new FrmBOMPopUp(code);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Reset(null, null);
                        }
                    }
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }


            }
        }
        /// <summary>
        /// 버튼 이벤트 셋
        /// </summary>
        private void BtnSet()
        {
            try
            {
                FrmMAIN frm = (FrmMAIN)this.MdiParent;
                frm.eSearch += Search;
                frm.eInsert += Insert;
                frm.eUpdate += Update;
                frm.eDelete += Delete;
                frm.ePrint += Print;
                frm.eReset += Reset;
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            try
            {
                CommonService service = new CommonService();
                List<ComboItemVO> Commonlist = service.GetITEMCmCode();


                //발주업체
                var listCOM_USE_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(BOM_USE_YN, listCOM_USE_YN, "COMMON_CODE", "COMMON_NAME", "");
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            try
            {
                DataGridViewUtil.InitSettingGridView(dgvBOM);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "no", "idx", true, 30);
                DataGridViewUtil.DataGridViewCheckBoxSet(dgvBOM, "all");
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "BOM_CODE", "BOM_CODE", false, 30);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품목", "ITEM_CODE", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품명", "ITEM_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품목유형", "ITEM_TYP", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "단위", "ITEM_UNIT", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "소요량", "BOM_QTY", true, 80);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "BOM레벨", "Lvl", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "시작일", "BOM_STARTDATE", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "종료일", "BOM_ENDDATE", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "사용여부", "BOM_USE_YN", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "소요계획", "BOM_PLAN_YN", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "자동차감", "BOM_AUTOREDUCE_YN", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "설비", "FCLTS_CODE", true, 140);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "설비명", "FCLTS_NAME", true, 140);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "규격", "ITEM_STND", true, 140);
                DataGridViewCheckBoxAllCheck();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {   try
            {
                dgvBOM.DataSource = null;
                BOMService bom = new BOMService();
                dgvBOM.DataSource = bom.SelectBOM();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            try
            {
                headerChk = new CheckBox();
                Point headerCell = dgvBOM.GetCellDisplayRectangle(1, -1, true).Location;
                headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
                headerChk.Size = new Size(18, 18);
                headerChk.BackColor = Color.FromArgb(245, 245, 246);
                headerChk.Click += HeaderChk_Clicked;
                dgvBOM.Controls.Add(headerChk);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            try
            {
                dgvBOM.EndEdit();

                //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
                foreach (DataGridViewRow row in dgvBOM.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                    chk.Value = headerChk.Checked;
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        private void BtnUnSet()
        {
            try
            {
                FrmMAIN frm = (FrmMAIN)this.MdiParent;
                frm.eSearch -= Search;
                frm.eInsert -= Insert;
                frm.eUpdate -= Update;
                frm.eDelete -= Delete;
                frm.ePrint -= Print;
                frm.eReset -= Reset;
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        private void FrmBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
