using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using System.Linq;


namespace TEAM3FINAL
{
    public partial class FrmShiftManage : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        #endregion

        #region 생성자
        public FrmShiftManage()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드

        #endregion
        private void FrmShiftManage_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();

            LoadShiftList();
        }

        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvShift);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvShift, "선택");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "No.", "RowNumber", true, 50);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "shiftCode", "SHIFT_CODE", false, 50);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "설비명", "FCLTS_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "설비코드", "FCLTS_CODE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "Shift", "SHIFT_TYP", true, 70);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "시작시간", "SHIFT_STARTTIME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "완료시간", "SHIFT_ENDTIME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "적용시간일자", "SHIFT_APPLY_STARTTIME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "적용완료일자", "SHIFT_APPLY_ENDTIME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "투입인원", "SHIFT_PERSON_DIR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "사용유무", "SHIFT_USE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "수정자", "SHIFT_LAST_MDFR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "수정시간", "SHIFT_LAST_MDFY", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "비고", "SHIFT_REMARK", true, 300);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvShift);
        }

        private void LoadShiftList()
        {
            //서비스호출
            ShiftService service = new ShiftService();
            var list = service.GetShiftList();
            dgvShift.DataSource = list;
        }


        #region 공통버튼 적용
        /// <summary>
        /// 공통버튼 이벤트 추가 메서드
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
            throw new NotImplementedException();
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
        #endregion
    }
}
