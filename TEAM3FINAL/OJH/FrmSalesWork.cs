using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmSalesWork : TEAM3FINAL.baseForm2
    {
        #region 멤버변수
        List<WORKORDER_VO> AllList;
        CheckBox headerChk;
        #endregion
        #region 생성자
        public FrmSalesWork()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvWork.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvWork.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvWork.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvWork.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }


        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvWork);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvWork, "  ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품목", "ITEM_CODE", true, 300, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "품명", "ITEM_NAME", true, 300, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "규격", "ITEM_STND", true, 100, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "상태", "WO_WORK_STATE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비코드", "FCLTS_CODE", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "설비명", "FCLTS_NAME", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획수량", "WO_PLAN_QTY", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "지시수량", "WO_QTY_PROD", true, 100, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획시작일", "WO_PLAN_STARTTIME", true, 100, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "소요시간(Min.)", "", true, 250, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "계획완료일", "WO_PLAN_ENDTIME", true, 150, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWork, "작업지시번호", "WO_Code", true, 150, DataGridViewContentAlignment.MiddleCenter);
            dgvWork.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWork.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);




        //행번호 추가
        DataGridViewUtil.DataGridViewRowNumSet(dgvWork);

            //체크박스추가
            DataGridViewCheckBoxAllCheck();
        }
        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private string CheckedList()
        {
            dgvWork.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvWork.Rows)
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
        private void LoadSalesWork()
        {
            //서비스호출
            WorkOrderINService service = new WorkOrderINService();
            //AllList = service.GetShiftList();
            //dgvWork.DataSource = null;
            //dgvWork.DataSource = AllList;
        }
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var FcltsList = service.GetFacilitiesCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboFclts, FcltsList, "COMMON_CODE", "COMMON_NAME", "");
        }
        #endregion
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
            //List<SHIFTList_VO> list = null;
            ////Shift조회
            //if (AllList.Count > 0 && dgvWork.SelectedIndex > 0)
            //{
            //    list = (from item in AllList select item).Where
            //        (p => p.SHIFT_TYP == dgvWork.SelectedText).ToList();
            //}
            //else
            //{
            //    list = AllList;
            //}
            ////업체명 조회
            //if (cboFclts.Text.Length > 0)
            //{
            //    list = (from item in list select item).Where(p => p.FCLTS_NAME == cboFclts.Text).ToList();
            //}
            //dgvWork.DataSource = null;
            //dgvWork.DataSource = list;

        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadSalesWork();
                cboFclts.SelectedIndex = 0;
                cboSearchDate.SelectedIndex = 0;
                cboState.SelectedIndex = 0;
                cboWOITEM.SelectedIndex = 0;
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

        private void FrmSalesWork_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadSalesWork();
        }

        private void FrmSalesWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
        #endregion



    }
}
