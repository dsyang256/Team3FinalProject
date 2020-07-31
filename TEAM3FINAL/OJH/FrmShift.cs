using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmShift : TEAM3FINAL.baseForm2 , CommonBtn
    {
        public FrmShift()
        {
            InitializeComponent();
        }


        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvShift);
            Util.DataGridViewCheckBoxSet(dgvShift,"선택");
            Util.AddNewColumnToDataGridView(dgvShift, "No.", "RowNumber", true, 50);
            Util.AddNewColumnToDataGridView(dgvShift, "shiftCode", "SHIFT_CODE", false, 50);
            Util.AddNewColumnToDataGridView(dgvShift, "설비명", "FCLTS_NAME", true, 120);
            Util.AddNewColumnToDataGridView(dgvShift, "설비코드", "FCLTS_CODE", true, 120);
            Util.AddNewColumnToDataGridView(dgvShift, "Shift", "SHIFT_TYP", true, 70);
            Util.AddNewColumnToDataGridView(dgvShift, "시작시간", "SHIFT_STARTTIME", true, 120);
            Util.AddNewColumnToDataGridView(dgvShift, "완료시간", "SHIFT_ENDTIME", true, 120);
            Util.AddNewColumnToDataGridView(dgvShift, "적용시간일자", "SHIFT_APPLY_STARTTIME", true, 150);
            Util.AddNewColumnToDataGridView(dgvShift, "적용완료일자", "SHIFT_APPLY_ENDTIME", true, 150);
            Util.AddNewColumnToDataGridView(dgvShift, "투입인원", "SHIFT_PERSON_DIR", true, 100);
            Util.AddNewColumnToDataGridView(dgvShift, "사용유무", "SHIFT_USE_YN", true, 100);
            Util.AddNewColumnToDataGridView(dgvShift, "수정자", "SHIFT_LAST_MDFR", true, 100);
            Util.AddNewColumnToDataGridView(dgvShift, "수정시간", "SHIFT_LAST_MDFY", true, 150);
            Util.AddNewColumnToDataGridView(dgvShift, "비고", "SHIFT_REMARK", true, 300);
        }

        private void FrmShift_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();

            LoadShiftInfo();
            BtnSet();
        }

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

        private void LoadShiftInfo()
        {
            //서비스호출
            ShiftService service = new ShiftService();
            var list = service.GetAllShiftList();
            dgvShift.DataSource = list;
        }

        /// <summary>
        /// row넘버 그리기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvShift_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // row header 에 자동 일련번호 넣기
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Red))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font,
                brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }

        public void Insert(object sender, EventArgs e)
        {
            FrmShiftPop frm = new FrmShiftPop();
            frm.ShowDialog();
        }

        public void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
