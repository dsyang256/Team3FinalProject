﻿using DevExpress.Data.Mask;
using log4net.Core;
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
    public partial class FrmReleaseRequest : baseForm2, CommonBtn
    {
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public CheckBox headerChk;

        public FrmReleaseRequest()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void FrmReleaseRequest_Load(object sender, EventArgs e)
        {
            try
            {
                ComboBinding();
                DataGridViewColumnSet1();
                DataGridViewColumnSet2();
                DataGridViewBinding1();
                BtnSet();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            try
            {
                CommonService service = new CommonService();
                List<ComboItemVO> Commonlist = service.GetITEMCmCode();

                //설비
                var listFACILITY = (from item in Commonlist where item.COMMON_PARENT == "설비" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(FACILITY, listFACILITY, "COMMON_CODE", "COMMON_NAME", "");
                //작업지시id
                var listid = (from item in Commonlist where item.COMMON_PARENT == "작업지시" select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(WORKORDER, listid, "COMMON_CODE", "COMMON_NAME", "");
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet1()
        {
            try
            {
                DataGridViewUtil.InitSettingGridView(dgv1);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "계획시작일자", "WO_PLAN_DATE", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "작업지시ID", "WO_Code", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "설비명", "FCLTS_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "소진창고", "FAC_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "지시수량", "WO_PLAN_QTY", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단위", "ITEM_UNIT", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "상태명", "WO_WORK_STATE", true, 200);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }




        }
        private void DataGridViewColumnSet2()
        {
            try
            {
                DataGridViewUtil.InitSettingGridView(dgv2);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
                DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "ITEM_CODE", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "ITEM_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "ITEM_STND", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청창고", "FAC_NAME", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청일", "Date", true, 200);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "재고량", "현재고", true, 100);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "표준불출수량", "표준불출수량", true, 150);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "계획요청수량", "WO_PLAN_QTY", true, 150);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "요청수량", "", true, 100, readOnly: false);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "출고수량", "출고", true, 140);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "잔량", "잔량", true, 140);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고창고", "FCLTS_WRHS_EXHST", false, 125);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "작업번호", "SALES_WORK_ORDER_ID", false, 125);
                DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "출고창고", "ITEM_WRHS_IN", false, 125);
                DataGridViewCheckBoxAllCheck();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            try
            {
                dgv1.DataSource = null;
                WorkOrderDSService service = new WorkOrderDSService();
                dgv1.DataSource = service.GetWorkOrder();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        #endregion
        private void DataGridViewCheckBoxAllCheck()
        {
            try
            {
                headerChk = new CheckBox();
                Point headerCell = dgv2.GetCellDisplayRectangle(1, -1, true).Location;
                headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
                headerChk.Size = new Size(18, 18);
                headerChk.BackColor = Color.FromArgb(245, 245, 246);
                headerChk.Click += HeaderChk_Clicked;
                dgv2.Controls.Add(headerChk);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            try
            {
                dgv2.EndEdit();

                //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
                foreach (DataGridViewRow row in dgv2.Rows)
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

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                string code = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string id = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dgv2.DataSource = null;
                WorkOrderDSService service = new WorkOrderDSService();
                dgv2.DataSource = service.GetWorkOrder2(code, id);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void dgv2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgv2.CurrentCell.ColumnIndex == 10)
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
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
                return;
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    e.Handled = true;
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void dgv2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 10)
                {
                    dgv2.EndEdit();
                    int a = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[7].Value);
                    int b = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[12].Value);
                    int c = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[10].Value);
                    if (c > a)
                    {
                        MessageBox.Show("요청량이 재고보다 많습니다.");
                        dgv2.Rows[e.RowIndex].Cells[10].Value = null;
                        return;
                    }
                    if (c > b)
                    {
                        MessageBox.Show("요청량이 잔량보다 많습니다.");
                        dgv2.Rows[e.RowIndex].Cells[10].Value = null;
                        return;
                    }
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dgv2.EndEdit();
                INSTACKService service = new INSTACKService();
                foreach (DataGridViewRow item in dgv2.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value) && item.Cells[10].Value != null)
                    {
                        int qty = Convert.ToInt32(item.Cells[10].Value);
                        string code = item.Cells[2].Value.ToString();
                        string wrhsin = item.Cells[13].Value.ToString();
                        string id = item.Cells[14].Value.ToString();
                        string wrhsout = item.Cells[15].Value.ToString();
                        service.INSERT_instack(qty, wrhsin, wrhsout, code, id);
                        MessageBox.Show("자재가 불출되었습니다.");
                    }
                }
                dgv2.DataSource = null;
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }


        }
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

        public void Insert(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    MessageBox.Show("사용안해요");
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        public void Search(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    string day1 = sday.Value.ToShortDateString();
                    string day2 = eday.Value.ToShortDateString();
                    string item = ITEMNAME.Text;
                    string id = WORKORDER.Text;
                    string name = FACILITY.Text;
                    WorkOrderDSService service = new WorkOrderDSService();
                    dgv1.DataSource = service.SP_GetWorkOrder(day1, day2, id, item, name);
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    DataGridViewBinding1();
                    dgv2.DataSource = null;
                    sday.Value = DateTime.Now;
                    eday.Value = DateTime.Now;
                    ITEMNAME.Text = "";
                    WORKORDER.Text = "";
                    FACILITY.Text = "";
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        public void Update(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    MessageBox.Show("사용안해요");
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    MessageBox.Show("사용안해요");
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        public void Print(object sender, EventArgs e)
        {

            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if (dgv1.Rows.Count > 0)
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
                        saveFileDialog1.Title = "SaveReleaseRequest";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgv1.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgv1.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgv1.RowCount; i++)
                            {
                                for (j = 0; j < dgv1.ColumnCount - 1; j++)
                                {
                                    if (dgv1[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgv1[j, i].Value.ToString();
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
        private void FrmReleaseRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }

      
    }
}
