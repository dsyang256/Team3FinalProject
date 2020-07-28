using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmShiftManage : TEAM3FINAL.baseForm2
    {
        public FrmShiftManage()
        {
            InitializeComponent();
        }

        private void FrmShiftManage_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();

            LoadShiftInfo();
        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvShift);
            Util.DataGridViewCheckBoxSet(dgvShift, "선택");
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

        private void LoadShiftInfo()
        {
            //서비스호출
            ShiftService service = new ShiftService();
            var list = service.GetAllShiftList();
            dgvShift.DataSource = list;
        }

    }
}
