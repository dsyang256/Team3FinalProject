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
    public partial class FrmAuthSet : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        List<MANAGER_VO> managerlist = null;
        List<MANAGER_VO> menulist = null;
        List<MANAGER_VO> rightlist = null;
        List<ComboItemVO> commonlist = null;
        #endregion
        public FrmAuthSet()
        {
            InitializeComponent();
        }

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            commonlist = service.GetCmCode();
            //콤보박스 바인딩 - 부서명
            var codelist = (from item in commonlist where item.COMMON_PARENT == "DEP" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboDept, codelist, "COMMON_CODE", "COMMON_NAME");

        }


        /// <summary>
        /// 그리드뷰 컬럼 생성 메서드
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정

            //관리자 검색
            DataGridViewUtil.InitSettingGridView(dgvUsers);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvUsers, "관리자 ID", "MANAGER_ID", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvUsers, "이름", "MANAGER_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvUsers, "부서", "MANAGER_DEP", true, 100);

            //권한 설정
            DataGridViewUtil.InitSettingGridView(dgvRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvRight, "메뉴ID", "MENU_ID", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvRight, "메뉴명", "MENU_NAME", true, 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "등록","등록",100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "읽기", "읽기",100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "수정", "수정",100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "삭제", "삭제",100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "인쇄", "인쇄", 100);

            //그룹 설정
            DataGridViewUtil.InitSettingGridView(dgvGroup);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvGroup,"    ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹코드", "RIGHT_ID", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹", "RIGHT_GROUP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹명", "RIGHT_NAME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "상세설명", "RIGHT_DESC", true, 300);
        }

        #endregion

        private void FrmAuthSet_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();
            //그리드뷰 설정
            DataGridViewColumnSet();

            //관리자목록 가져오기
            LoadManagers();

            dgvUsers.ClearSelection();
            dgvRight.ClearSelection(); 
            dgvGroup.ClearSelection();
        }

        /// <summary>
        /// 관리자목록을 가져오는 메서드
        /// </summary>
        private void LoadManagers()
        {
            AuthService service = new AuthService();
            managerlist = service.GetManagers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = managerlist;
        }

        /// <summary>
        /// 전체메뉴를 가져오는 메서드
        /// </summary>
        private void LoadMenuList(string userID)
        {
            
            AuthService service = new AuthService();
            menulist = service.GetMenuList(userID);
            dgvRight.DataSource = null;
            dgvRight.DataSource = menulist;
        }

        /// <summary>
        /// 전체그룹을 가져오는 메서드
        /// </summary>
        private void LoadRightList(string userID)
        {

            AuthService service = new AuthService();
            rightlist = service.GetRightList(userID);
            dgvRight.DataSource = null;
            dgvRight.DataSource = rightlist;
        }

        /// <summary>
        /// 탭페이지 인덱스 변경시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 셀 더블클릭시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.SelectedRows.Count>0 && e.RowIndex > 0)
            {
                LoadMenuList(dgvUsers[e.ColumnIndex,e.RowIndex].Value.ToString());
                LoadRightList(dgvUsers[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
