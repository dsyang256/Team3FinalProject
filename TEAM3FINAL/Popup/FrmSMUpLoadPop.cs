using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Excel = Microsoft.Office.Interop.Excel;

namespace TEAM3FINAL
{
    public partial class FrmSMUpLoadPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        string openFileName = string.Empty;

        private List<SALES_WORK_VO> list = new List<SALES_WORK_VO>();

        public List<SALES_WORK_VO> SalesMasterList
        {
            get { return list; }
            set { list = value; }
        }


        #endregion

        #region 생성자
        public FrmSMUpLoadPop()
        {
            InitializeComponent();
        }
        #endregion

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            //파일 선택
            ofdExcel.Filter = "Excel Files (*.xls)|*.xls";

            if (this.ofdExcel.ShowDialog() == DialogResult.OK)
            {
                openFileName = ofdExcel.FileName;
                txtFileName.Text = ofdExcel.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            using (frmWaitAsyncForm frm = new frmWaitAsyncForm(GetExcelFile))
            {
                frm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 엑셀 파일 읽어와서 등록하는 메서드
        /// </summary>
        private void GetExcelFile()
        {
            if (openFileName.Length > 1)
            {
                Excel.Application xlApp = null;
                Excel.Workbook xlWorkBook = null;
                Excel.Worksheet xlWorkSheet = null;
                DataTable dt = new DataTable();
                try
                {
                    list.Clear();

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
                            if (c == 1)
                                dr[c - 1] = r - 1;
                            else
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
                            //전달 vo 생성
                            SALES_WORK_VO vo = new SALES_WORK_VO();
                            vo.SALES_ID = 0; //등록
                            vo.SALES_Work_Order_ID = (dt.Rows[i][1] != null) ? dt.Rows[i][1].ToString() : "";
                            vo.SO_PurchaseOrder = "";
                            vo.COM_CODE = (dt.Rows[i][2] != null) ? dt.Rows[i][2].ToString() : "";
                            vo.SALES_COM_CODE = (dt.Rows[i][3] != null) ? dt.Rows[i][3].ToString() : "";
                            vo.SALES_DUEDATE = (dt.Rows[i][8] != null) ? DateTime.ParseExact(dt.Rows[i][8].ToString(), "yyyy-MM-dd tt hh:mm:ss", null, System.Globalization.DateTimeStyles.AssumeLocal).ToString("yyyy-MM-dd HH:mm:ss") : "";
                            vo.ITEM_CODE = (dt.Rows[i][6] != null) ? dt.Rows[i][6].ToString() : "";
                            vo.SALES_QTY = (dt.Rows[i][7] != null) ? Convert.ToInt32(dt.Rows[i][7]) : 0;
                            vo.SALES_Out_QTY = 0;
                            vo.SALES_NO_QTY = 0;
                            vo.SALES_MKT = (dt.Rows[i][4] != null) ? dt.Rows[i][4].ToString() : "";
                            vo.SALES_Order_TYPE = (dt.Rows[i][5] != null) ? dt.Rows[i][5].ToString() : "";
                            vo.SALES_REMARK = "";

                            list.Add(vo);
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
                        ReleaseExcelObject(xlWorkSheet);
                        ReleaseExcelObject(xlWorkBook);
                        ReleaseExcelObject(xlApp);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        private void dtpApplyStartTime_ValueChanged(object sender, EventArgs e)
        {
            txtPlanID.Text = dtpApplyStartTime.Value.ToString("yyyyMMdd") + "_P";
        }

        private void FrmSMUpLoadPop_Load(object sender, EventArgs e)
        {
            //초기값
            dtpApplyStartTime.Value = DateTime.Now;
        }
    }
}
