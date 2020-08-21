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
    public partial class FrmReceivingSearch : baseForm2, CommonBtn
    {
        private CheckBox headerChk;

        public FrmReceivingSearch()
        {
            InitializeComponent();
        }

        private void FrmReceivingSearch_Load(object sender, EventArgs e)
        {
            
            ComboBinding();
            DataGridViewColumnSet();
            DataGridViewBinding();
            BtnSet();
        }
        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //품목유형
            var listITEM_TYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listITEM_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //창고
            var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");

            //관리등급
            var listLEVEL = (from item in Commonlist where item.COMMON_PARENT == "관리등급" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGE_LEVEL, listLEVEL, "COMMON_CODE", "COMMON_NAME", "");

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv1, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "창고이름", "FAC_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "창고코드", "INS_WRHS", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명유형", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "현재고", "현재고", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_STND", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "개수", "ITEM_UNIT", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "관리등급", "ITEM_MANAGE_LEVEL", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "비고", "", true, 400);



            DataGridViewCheckBoxAllCheck();

        }
       
        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            dgv1.DataSource = null;
            INSTACKService service = new INSTACKService();
            dgv1.DataSource = service.ReceivingSearch();
        }
        
        #endregion

        #region 데이터 그리드뷰 올체크 체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgv1.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgv1.Controls.Add(headerChk);
        }
       
        #endregion

        #region 올체크 이벤트

        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        #endregion

        #region 버튼 이벤트

        /// <summary>
        /// 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string day = sday.Value.ToShortDateString();
                string name = ITEMENAME.Text;
                string typ = ITEM_TYP.Text;
                string wrhs = (WRHS.Text.Length < 1) ? "": WRHS.SelectedValue.ToString();
                string qty = QTY.Text;
                string level = ITEM_MANAGE_LEVEL.Text;
                INSTACKService service = new INSTACKService();
                dgv1.DataSource = null;
                dgv1.DataSource = service.SP_ReceivingSearch(day, name, typ, wrhs, qty, level);
            }
        }

        public void Reset(object sender, EventArgs e) 
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                DataGridViewBinding();
                sday.Value = DateTime.Now;
                ITEMENAME.Text = "";
                ITEM_TYP.SelectedIndex = -1;
                WRHS.SelectedIndex = -1;
                QTY.Text = "";
                ITEM_MANAGE_LEVEL.SelectedIndex = -1;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
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
                        saveFileDialog1.Title = "SaveReceivingSearch";
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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmReceivingSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
