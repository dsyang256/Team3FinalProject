using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;
using System.Linq;
using DevExpress.XtraReports.UI;
using log4net.Core;

namespace TEAM3FINAL
{
    public partial class FrmItem : TEAM3FINAL.baseForm2  ,CommonBtn
    {
        
        CheckBox headerChk;
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public FrmItem()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            try
            {
                BtnSet();
                ComboBinding();
                DataGridViewColumnSet();
                DataGridViewBinding();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                try
                {
                    string msg = e.ReadMsg.Replace("%O", "_").Trim();
                    ((FrmMAIN)this.MdiParent).ClearStrings();

                    string name = "";
                    foreach (DataGridViewRow item in dgvitem.Rows)
                    {
                        if (item.Cells[3].Value.ToString() == msg)
                        {
                            item.Cells[1].Value = true;
                            item.Selected = true;
                            name = item.Cells[4].Value.ToString();
                        }
                    }
                    if (name.Length < 1)
                    {
                        MessageBox.Show("항목이 없습니다 다시 확인해주세요.");
                        return;
                    }
                    if (MessageBox.Show($"{name} - 품목을 수정하시겠습니까?", "수정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Update(null, null);
                }
                catch (Exception err)
                {
                    this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                }
            }
        }


        /// <summary>
        /// 버튼 이벤트 델리게이트 추가
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
                frm.Readed += Readed_BarCode;
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
                var listCOM_REORDER = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_REORDER, listCOM_REORDER, "COMMON_CODE", "COMMON_NAME", "");

                //납품유형
                var listCOM_DLVR = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_DLVR, listCOM_DLVR, "COMMON_CODE", "COMMON_NAME", "");

                //입고창고
                var listWRHS_IN = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_IN, listWRHS_IN, "COMMON_CODE", "COMMON_NAME", "");

                //출고창고
                var listWRHS_OUT = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_OUT, listWRHS_OUT, "COMMON_CODE", "COMMON_NAME", "");

                //담당자
                var listMANAGER = (from item in Commonlist where item.COMMON_PARENT == "담당자" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listMANAGER, "COMMON_CODE", "COMMON_NAME", "");

                //사용여부
                var listYN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_USE_YN, listYN, "COMMON_CODE", "COMMON_NAME", "");

                //품목유형
                var listTYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");

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
                DataGridViewUtil.InitSettingGridView(dgvitem);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "no", "idx", true, 30);
                DataGridViewUtil.DataGridViewCheckBoxSet(dgvitem, "all");
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품목유형", "ITEM_TYP", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품목", "ITEM_CODE", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품명", "ITEM_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "규격", "ITEM_STND", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단위", "ITEM_UNIT", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단위수량", "ITEM_QTY_UNIT", true, 80);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "환산단위", "ITEM_UNIT_CNVR", true, 80);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "환산수량", "ITEM_QTY_CNVR", true, 80);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "수입검사여부", "ITEM_INCOME_YN", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "공정검사여부", "ITEM_PROCS_YN", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "출하검사여부", "ITEM_XPORT_YN", true, 120);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단종유무", "ITEM_DSCN_YN", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "유무상구분", "ITEM_FREE_YN", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "납품업체", "ITEM_COM_DLVR", true, 140);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "발주업체", "ITEM_COM_REORDER", true, 140);
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
        {
            try
            {
                ItemService item = new ItemService();
                dgvitem.DataSource = item.AllITEM();
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
                Point headerCell = dgvitem.GetCellDisplayRectangle(1, -1, true).Location;
                headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
                headerChk.Size = new Size(18, 18);
                headerChk.BackColor = Color.FromArgb(245, 245, 246);
                headerChk.Click += HeaderChk_Clicked;
                dgvitem.Controls.Add(headerChk);
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
                dgvitem.EndEdit();

                //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
                foreach (DataGridViewRow row in dgvitem.Rows)
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
        /// <summary>
        /// 입력 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    FrmItemPopUp frm = new FrmItemPopUp();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Search(null, null);
                    }
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    ITEM_VO vo = new ITEM_VO();
                    vo.ITEM_NAME = ITEM_NAME.Text;
                    vo.ITEM_STND = ITEM_STND.Text;
                    vo.ITEM_COM_REORDER = ITEM_COM_REORDER.Text;
                    vo.ITEM_COM_DLVR = ITEM_COM_DLVR.Text;
                    vo.ITEM_WRHS_IN = ITEM_WRHS_IN.Text;
                    vo.ITEM_WRHS_OUT = ITEM_WRHS_OUT.Text;
                    vo.ITEM_MANAGER = ITEM_MANAGER.Text;
                    vo.ITEM_TYP = ITEM_TYP.Text;
                    vo.ITEM_USE_YN = ITEM_USE_YN.Text;

                    dgvitem.DataSource = null;
                    ItemService item = new ItemService();
                    dgvitem.DataSource = item.GetSearchItem(vo);
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    ITEM_NAME.Text = "";
                    ITEM_STND.Text = "";
                    ITEM_COM_REORDER.SelectedIndex = -1;
                    ITEM_COM_DLVR.SelectedIndex = -1;
                    ITEM_WRHS_IN.SelectedIndex = -1;
                    ITEM_WRHS_OUT.SelectedIndex = -1;
                    ITEM_MANAGER.SelectedIndex = -1;
                    ITEM_TYP.SelectedIndex = -1;
                    ITEM_USE_YN.SelectedIndex = -1;
                    DataGridViewBinding();
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    dgvitem.EndEdit();
                    int cnt = 0;
                    string code = "";
                    //체크가 되었는지 확인
                    foreach (DataGridViewRow item in dgvitem.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value))
                        {
                            code = item.Cells[3].Value.ToString();
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
                        FrmItemPopUp frm = new FrmItemPopUp(code);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            Search(null, null);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        /// <summary>
        /// 삭제 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    dgvitem.EndEdit();
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvitem.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[1].Value))
                        {
                            sb.Append(item.Cells[3].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("삭제할 항목을 선택하여 주십시오.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"총 {cnt}개의 항목을 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ItemService service = new ItemService();
                        if (service.DeleteItem(sb))
                        {
                            MessageBox.Show("삭제 완료");
                            DataGridViewBinding();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
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
                if (dgvitem.Rows.Count > 0)
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
                        saveFileDialog1.Title = "SaveITEM";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvitem.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvitem.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvitem.RowCount; i++)
                            {
                                for (j = 0; j < dgvitem.ColumnCount - 1; j++)
                                {
                                    if (dgvitem[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvitem[j, i].Value.ToString();
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

                        this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
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


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> chkList = new List<string>();

                for (int i = 0; i < dgvitem.Rows.Count; i++)
                {
                    bool isCellChecked = (bool)dgvitem.Rows[i].Cells[1].EditedFormattedValue;
                    if (isCellChecked)
                    {
                        chkList.Add("'" + dgvitem.Rows[i].Cells[3].Value.ToString() + "'"); ;
                    }
                }
                if (chkList.Count == 0)
                {
                    MessageBox.Show("출력할 바코드를 선택해주세요.");
                    return;
                }

                string strChkBarCodes = string.Join(",", chkList);

                ItemService service = new ItemService();
                XtraItemList rpt = new XtraItemList();
                DataTable dt = service.GetBaCodeItemList(strChkBarCodes);
                rpt.Parameters["uName"].Value = LoginInfo.UserInfo.LI_NAME;
                rpt.DataSource = dt;
                rpt.CreateDocument();
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void dgvitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                frm.Readed -= Readed_BarCode;
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void FrmItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
