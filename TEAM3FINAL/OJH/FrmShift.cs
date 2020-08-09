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
    public partial class FrmShift : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        List<SHIFTList_VO> AllList;
        #endregion

        #region 생성자
        public FrmShift()
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
            DataGridViewUtil.InitSettingGridView(dgvShift);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvShift, "  ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "shiftCode", "SHIFT_CODE", false, 50);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "설비명", "FCLTS_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "설비코드", "FCLTS_CODE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "SHIFT", "SHIFT_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "시작시간", "SHIFT_STARTTIME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "완료시간", "SHIFT_ENDTIME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "적용시간일자", "SHIFT_APPLY_STARTTIME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "적용완료일자", "SHIFT_APPLY_ENDTIME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "투입인원", "SHIFT_PERSON_DIR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "사용유무", "SHIFT_USE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvShift, "비고", "SHIFT_REMARK", true, 300);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvShift);
        }
        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private string CheckedList()
        {
            dgvShift.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvShift.Rows)
            {
                if (item is DataGridViewRow)
                {
                    DataGridViewRow row = item as DataGridViewRow;
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        sb.Append(row.Cells[1].Value.ToString() + "@");
                    }
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("품목을 선택해주십시오.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            sb.Remove(sb.Length - 1, 1);

            //체크 목록을 string으로 만듬
            return sb.ToString();
        }
        private void LoadShiftList()
        {
            //서비스호출
            ShiftService service = new ShiftService();
           AllList = service.GetShiftList();
            dgvShift.DataSource = null;
            dgvShift.DataSource = AllList;
        }
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();

            var CommonList = service.GetCmCode();
            var ShiftList = (from item in CommonList select item).Where(p => p.COMMON_PARENT == "SHIFT").ToList();

            var FcltsList = service.GetFacilitiesCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboShift, ShiftList, "COMMON_CODE", "COMMON_NAME", "");
            CommonUtil.ComboBinding<ComboItemVO>(cboFclts, FcltsList, "COMMON_CODE", "COMMON_NAME", "");
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


        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmShiftPop frm = new FrmShiftPop(InsertOrUpdate.insert);
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Search(object sender, EventArgs e)
        {
            List<SHIFTList_VO> list = null;
            //Shift조회
            if (AllList.Count > 0 && cboShift.SelectedIndex>0)
            {
                list = (from item in AllList select item).Where
                    (p => p.SHIFT_TYP==cboShift.SelectedText).ToList();
            }
            else 
            {
                list = AllList;
            }
            //업체명 조회
            if (cboFclts.Text.Length > 0)
            {
                list = (from item in list select item).Where(p => p.FCLTS_NAME==cboFclts.Text).ToList();
            }
            dgvShift.DataSource = null;
            dgvShift.DataSource = list;

        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadShiftList();
                cboFclts.SelectedIndex = 0;
                cboShift.SelectedIndex = 0;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string uid = CheckedList();
                if (uid.Length < 1)
                    return;
                if (uid.Contains("@"))
                {
                    MessageBox.Show("수정할 품목 하나를 선택하세요.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmShiftPop frm = new FrmShiftPop(InsertOrUpdate.update, uid);
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            string lists = CheckedList();
            if (lists.Length > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //서비스 호출
                    ShiftService service = new ShiftService();
                    if (service.DeleteShiftList(lists, "@"))
                    {
                        MessageBox.Show("삭제되었습니다.", "삭제 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("삭제 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Reset(null, null);
        }

        public void Print(object sender, EventArgs e)
        {
            //미구현
        }
        #endregion
        #endregion 

        #region 이벤트
        private void FrmShift_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadShiftList();
        }
        #endregion

        private void FrmShift_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
