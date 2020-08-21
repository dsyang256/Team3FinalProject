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

    public partial class FrmReleaseSearch : baseForm2, CommonBtn
    {
        
        public FrmReleaseSearch()
        {
            InitializeComponent();
        }

        private void FrmReleaseSearch_Load(object sender, EventArgs e)
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

            //발주창고
            var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");

            //입고유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "입고유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");


            //품목유형
            var listITEM_TYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listITEM_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //관리등급
            var listITEM_MANAGER = (from item in Commonlist where item.COMMON_PARENT == "관리등급" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listITEM_MANAGER, "COMMON_CODE", "COMMON_NAME", "");


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
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입출고일", "INS_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "구분", "INS_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "창고", "FAC_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_STND", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목형태", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "관리등급", "ITEM_MANAGE_LEVEL", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "수불량", "INS_QTY", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단가", "MC_UNITPRICE_CUR", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "금액", "price", true, 200);


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
            dgv1.DataSource = service.INSTACDataTable();


        }

        #endregion

        #region 버튼이벤트
        /// <summary>
        /// 버튼이벤트
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
                string day1 = sday.Value.ToShortDateString();
                string day2 = eday.Value.ToShortDateString();
                string wrhs = (WRHS.Text.Length < 1) ? "": WRHS.SelectedValue.ToString();
                string name = ITEM.Text;
                string typ = TYP.Text;
                string level = ITEM_MANAGER.Text;
                string itemtyp = ITEM_TYP.Text;
                INSTACKService service = new INSTACKService();
                dgv1.DataSource = service.INSTACDataTable(day1, day2,wrhs,name,typ, level, itemtyp);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                sday.Value = DateTime.Now;
                eday.Value = DateTime.Now;
                WRHS.SelectedIndex  = -1;
                ITEM.Text = "";
                TYP.Text = "";
                ITEM_MANAGER.Text = "";
                ITEM_TYP.Text = "";
                DataGridViewBinding();
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                MessageBox.Show("사용안해요");
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                MessageBox.Show("사용안해요");
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
                        saveFileDialog1.Title = "SaveReleaseSearch";
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
    }
}
