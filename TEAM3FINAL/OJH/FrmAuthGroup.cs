using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmAuthGroup : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        List<ManagerRightInfo_VO> AllList;
        #endregion
        #region 생성자
        public FrmAuthGroup()
        {
            InitializeComponent();
        }
        #endregion
        #region 메서드
        /// <summary>
        /// 그리드뷰 컬럼 생성 메소드
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvGroup);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "관리자 ID", "MANAGER_ID", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "이름", "MANAGER_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "부서", "MANAGER_DEP", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "권한명", "RIGHT_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "권한그룹", "RIGHT_GROUP", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "권한그룹설명", "RIGHT_DESC", true, 500);
            dgvGroup.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroup.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvGroup);
        }

        private void LoadManagerRightList()
        {
            //서비스호출
            AuthService service = new AuthService();
            AllList = service.GetManagerRightInfo();
            dgvGroup.DataSource = null;
            dgvGroup.DataSource = AllList;
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
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                List<ManagerRightInfo_VO> list = new List<ManagerRightInfo_VO>();
            if (AllList.Count > 0 && txtName.Text.Trim().Length> 0)
            {
                list = (from item in AllList select item).Where
                    (p => p.MANAGER_NAME.Contains(txtName.Text.Trim())).ToList();
            }
            dgvGroup.DataSource = null;
            dgvGroup.DataSource = list;
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadManagerRightList();
                txtName.Clear();
            }
        }

        public void Update(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Delete(object sender, EventArgs e)
        {
            //사용안함
        }

        public void Print(object sender, EventArgs e)
        {
            //사용안함
        }
        #endregion

        #endregion
        #region 이벤트

        /// <summary>
        /// 폼 로드 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAuthGroup_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //데이터 조회
            LoadManagerRightList();
        }


        private void btnGroup_Click(object sender, EventArgs e)
        {
            FrmGroupMenu frm = new FrmGroupMenu();
            frm.ShowDialog();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            FrmAuthSet frm = new FrmAuthSet();
            frm.ShowDialog();
        }
        #endregion

        private void FrmAuthGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
