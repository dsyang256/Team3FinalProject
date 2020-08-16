using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Excel = Microsoft.Office.Interop.Excel;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmSalesMasterUpLoad : TEAM3FINAL.baseForm2
    {
        #region 멤버변수
        List<SALES_WORK_VO> RList = new List<SALES_WORK_VO>();
        #endregion

        #region 생성자
        public FrmSalesMasterUpLoad()
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
            DataGridViewUtil.InitSettingGridView(dgvSalesMaster);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "SALES_ID", "SALES_ID", false, 160);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "SALES Work Order ID", "SALES_Work_Order_ID", true, 250);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "업체CODE", "COM_CODE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "발주구분", "SALES_Order_TYPE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "납품처", "SALES_COM_CODE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "계획수량합계", "SALES_QTY", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "납기일", "SALES_DUEDATE", true, 300);

            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략", "SO_PurchaseOrder", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략1", "SALES_Out_QTY", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략2", "SALES_NO_QTY", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략3", "SALES_MKT", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략4", "SALES_Order_TYPE", false, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "생략5", "SALES_REMARK", false, 200);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvSalesMaster);
        }



        private void Sales_Master_Upload_Load(object sender, EventArgs e)
        {
        }

        #endregion

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
                saveFileDialog1.Title = "SaveSalesMasterUpLoad";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells[1, 1] = "순번";
                    xlWorkSheet.Cells[1, 2] = "WORK_ORDER_ID";
                    xlWorkSheet.Cells[1, 3] = "업체 CODE";
                    xlWorkSheet.Cells[1, 4] = "납품처";
                    xlWorkSheet.Cells[1, 5] = "MKT";
                    xlWorkSheet.Cells[1, 6] = "발주구분";
                    xlWorkSheet.Cells[1, 7] = "ITEM CODE";
                    xlWorkSheet.Cells[1, 8] = "계획수량합계";
                    xlWorkSheet.Cells[1, 9] = "납기일";

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

        private void FrmSalesMasterUpLoad_Load(object sender, EventArgs e)
        {
            //그리드 설정
            DataGridViewColumnSet();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FrmSMUpLoadPop frm = new FrmSMUpLoadPop();
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                RList = frm.SalesMasterList;
                if (RList.Count > 0)
                {
                    dgvSalesMaster.DataSource = null;
                    dgvSalesMaster.DataSource = RList;
                }
            }
        }

        //영업마스터 생성
        private void btnMaster_Click(object sender, EventArgs e)
        {
            if (dgvSalesMaster.Rows.Count > 0)
            {
                Message msg=new TEAM3FINALVO.Message();
                //DB에 저장
                for (int i = 0; i < RList.Count; i++)
                {
                    //전달 vo 생성
                    SALES_WORK_VO vo1 = new SALES_WORK_VO();
                    vo1.SALES_ID = 0; //등록
                    vo1.SALES_Work_Order_ID = RList[i].SALES_Work_Order_ID;
                    vo1.SO_PurchaseOrder = "";
                    vo1.COM_CODE = RList[i].COM_CODE;
                    vo1.SALES_COM_CODE = RList[i].SALES_COM_CODE;
                    vo1.SALES_DUEDATE = RList[i].SALES_DUEDATE;
                    vo1.ITEM_CODE = RList[i].ITEM_CODE;
                    vo1.SALES_QTY = RList[i].SALES_QTY;
                    vo1.SALES_Out_QTY = 0;
                    vo1.SALES_NO_QTY = 0;
                    vo1.SALES_MKT = RList[i].SALES_MKT;
                    vo1.SALES_Order_TYPE = RList[i].SALES_Order_TYPE;
                    vo1.SALES_REMARK = "";

                    //서비스호출
                    SalesService service = new SalesService();
                    msg = service.InsertOrUpdateSalesWork(vo1);
                }
                if(msg.IsSuccess)
                {
                    MessageBox.Show("생성되었습니다.", "생성 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("생성에 실패하였습니다.", "생성 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
