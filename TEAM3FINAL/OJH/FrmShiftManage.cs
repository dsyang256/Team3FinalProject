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
        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            dgvShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvShift.AutoGenerateColumns = true;
            dgvShift.AllowUserToAddRows = false;
            dgvShift.MultiSelect = false;
            dgvShift.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShift.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvShift.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            dgvShift.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn column = dgvShift.Columns[0];
            dgvShift.Columns[0].Frozen = true;
            column.Width = 150;

            column = dgvShift.Columns[1];
            dgvShift.Columns[1].Frozen = true;
            column.Width = 150;

            column = dgvShift.Columns[2];
            dgvShift.Columns[2].Frozen = true;
            column.Width = 150;

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvShift);
        }
        private void BindingComboBox()
        {
            //서비스호출
            //ComboItemService service = new ComboItemService();

            //var commonlist = service.GetCmCode();
            //var statelist = (from item in commonlist select item).Where(p => p.COMMON_PARENT == "ORDER_STATE").ToList();
            //var companylist = service.GetCompanyCode();
            //var com2list = service.GetCompanyCode();
            //CommonUtil.ComboBinding<ComboItemVO>(cboState, statelist, "COMMON_CODE", "COMMON_NAME", "");
            //CommonUtil.ComboBinding<ComboItemVO>(cboCom, companylist, "COMMON_CODE", "COMMON_NAME", "");
            //CommonUtil.ComboBinding<ComboItemVO>(cboCom2, com2list, "COMMON_CODE", "COMMON_NAME", "");
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
        #endregion

        #region 이벤트
        private void FrmShiftManage_Load(object sender, EventArgs e)
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
        private void FrmShiftManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }

        #endregion
    }
}
