﻿using System;
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
    public partial class FrmReorderSearch : baseForm2, CommonBtn
    {
        CheckBox headerChk;
        public FrmReorderSearch()
        {
            InitializeComponent();
        }

        private void FrmReorderSearch_Load(object sender, EventArgs e)
        {
            BtnSet();
            DataGridViewColumnSet();
            ComboBinding();
            DataGridViewBinding();
        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            ReorderService item = new ReorderService();
            dgvReorder.DataSource = item.SelectREORDER();
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var listCOM_CODE_OUT = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_OUT, listCOM_CODE_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            var listCOM_CODE_IN = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_IN, listCOM_CODE_IN, "COMMON_CODE", "COMMON_NAME", "");

            //품목
            var listITEM_CODE = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_CODE, listITEM_CODE, "COMMON_CODE", "COMMON_NAME", "");

            //발주상태
            var listREORDER_STATE = (from item in Commonlist where item.COMMON_PARENT == "발주상태" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(REORDER_STATE, listREORDER_STATE, "COMMON_CODE", "COMMON_NAME", "");
        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgvReorder);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvReorder, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주번호", "REORDER_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "협렵사", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "납품업체", "REORDER_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "주문상태", "REORDER_STATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "규격", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "단위", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "납기일", "REORDER_DATE_IN", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주량", "REORDER_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "입고량", "REORDER_DETAIL_QTY_GOOD", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주일", "REORDER_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvReorder, "발주자", "MANAGER_NAME", true, 100);
            DataGridViewCheckBoxAllCheck();
        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvReorder.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvReorder.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvReorder.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvReorder.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        /// <summary>
        /// 버튼 이벤트 델리게이트 추가
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
        /// <summary>
        /// 저장 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                ReorderService service = new ReorderService();
                dgvReorder.DataSource = null;
                dgvReorder.DataSource = service.GetSearchREORDER(
                    sday.Value.ToShortDateString()
                    , eday.Value.ToShortDateString()
                    , (COM_CODE_OUT.Text.Length < 1) ? "" : COM_CODE_OUT.Text
                    , (ITEM_CODE.Text.Length < 1) ? "" : ITEM_CODE.SelectedValue.ToString()
                    , REORDER_STATE.Text
                    , REORDER_CODE.Text
                    , (COM_CODE_IN.Text.Length < 1) ? "": COM_CODE_IN.Text);;
            }
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                DataGridViewBinding();
            }
        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        /// <summary>
        /// 삭제 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

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
                if (dgvReorder.Rows.Count > 0)
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
                        saveFileDialog1.Title = "SaveReorderSearch";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            xlApp = new Microsoft.Office.Interop.Excel.Application();
                            xlWorkBook = xlApp.Workbooks.Add();
                            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                            for (int k = 1; k < dgvReorder.ColumnCount; k++)
                            {
                                xlWorkSheet.Cells[1, k] = dgvReorder.Columns[k].HeaderText.ToString();
                            }

                            for (i = 0; i < dgvReorder.RowCount; i++)
                            {
                                for (j = 0; j < dgvReorder.ColumnCount - 1; j++)
                                {
                                    if (dgvReorder[j, i].Value != null)
                                        xlWorkSheet.Cells[i + 2, j + 1] = dgvReorder[j, i].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            dgvReorder.EndEdit();
            StringBuilder sb = new StringBuilder();
            int cnt = 0;
            //품목 선택후 List를 전달
            foreach (DataGridViewRow item in dgvReorder.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value))
                {
                    sb.Append(item.Cells[2].Value.ToString() + "@");
                    cnt++;
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("납기일을 변경할 항목을 선택하여 주십시오.");
                return;
            }
            sb.Remove(sb.Length - 1, 1);
            if (MessageBox.Show($"총 {cnt}개의 항목의 납기일을 변경 하시겠습니까?", "변경", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FrmReorderSearchPopUp frm = new FrmReorderSearchPopUp();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ReorderService item = new ReorderService();
                    if(item.UpDateREORDER(frm.day, LoginInfo.UserInfo.LI_ID, sb.ToString()));
                    {
                        MessageBox.Show($"총 {cnt}개 의 납기일이 변경되었습니다.");
                        DataGridViewBinding();
                    }
                    
                }
            }

        }

        private void menuPanel1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvReorder.EndEdit();
            StringBuilder sb = new StringBuilder();
            int cnt = 0;
            //품목 선택후 List를 전달
            foreach (DataGridViewRow item in dgvReorder.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value))
                {
                    if(item.Cells[5].Value.ToString() != "발주")
                    {
                        MessageBox.Show("발주 상태만 취소 가능합니다.");
                        return;
                    }
                    sb.Append(item.Cells[2].Value.ToString() + "@");
                    cnt++;
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("취소할 항목을 선택하여 주십시오.");
                return;
            }
            sb.Remove(sb.Length - 1, 1);
            if (MessageBox.Show($"총 {cnt}개의 항목의 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ReorderService item = new ReorderService();
                if (item.DeleteREORDER(sb.ToString())) ;
                {
                    MessageBox.Show($"총 {cnt}개 발주가 삭제되었습니다.");
                    DataGridViewBinding();
                }


            }
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
        private void FrmReorderSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
