using DevExpress.CodeParser;
using DevExpress.XtraPrinting.Native;
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
        List<MANAGERMENU_VO> menulist = null;
        List<MANAGER_VO> rightlist = null;
        List<ComboItemVO> commonlist = null;
        CheckBox chkbox1;
        CheckBox chkbox2;
        CheckBox chkbox3;
        CheckBox chkbox4;
        CheckBox chkbox5;
        CheckBox chkbox6;
        string selectedUser="";

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
            CommonUtil.ComboBinding<ComboItemVO>(cboDept, codelist, "COMMON_CODE", "COMMON_NAME", "전체");

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
            DataGridViewUtil.AddNewColumnToDataGridView(dgvUsers, "부서", "MANAGER_DEP", true, 80);
            DataGridViewUtil.DataGridViewBtnSet("  ", "설정", dgvUsers, 0, 0);

            //권한 설정
            DataGridViewUtil.InitSettingGridView(dgvRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvRight, "메뉴ID", "MENU_ID", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvRight, "메뉴명", "MENU_NAME", true, 150);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "A", "등록", 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "B", "읽기", 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "C", "수정", 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "D", "삭제", 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "E", "인쇄", 100);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvRight, "F", "리셋", 100);
            DataGridViewColumn col = this.dgvRight.Columns[1];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCheckBoxAllCheck();


            //그룹 설정
            DataGridViewUtil.InitSettingGridView(dgvGroup);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvGroup, "    ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹코드", "RIGHT_ID", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹", "RIGHT_GROUP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "그룹명", "RIGHT_NAME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroup, "상세설명", "RIGHT_DESC", true, 300);
        }


        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            chkbox1 = new CheckBox();
            Point headerCell = dgvRight.GetCellDisplayRectangle(2, -1, true).Location;
            chkbox1.Name = $"box{2}";
            chkbox1.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox1.Size = new Size(18, 18);
            chkbox1.BackColor = Color.FromArgb(245, 245, 246);
            chkbox1.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox1);

            chkbox2 = new CheckBox();
            headerCell = dgvRight.GetCellDisplayRectangle(3, -1, true).Location;
            chkbox2.Name = $"box{3}";
            chkbox2.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox2.Size = new Size(18, 18);
            chkbox2.BackColor = Color.FromArgb(245, 245, 246);
            chkbox2.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox2);

            chkbox3 = new CheckBox();
            headerCell = dgvRight.GetCellDisplayRectangle(4, -1, true).Location;
            chkbox3.Name = $"box{4}";
            chkbox3.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox3.Size = new Size(18, 18);
            chkbox3.BackColor = Color.FromArgb(245, 245, 246);
            chkbox3.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox3);

            chkbox4 = new CheckBox();
            headerCell = dgvRight.GetCellDisplayRectangle(5, -1, true).Location;
            chkbox4.Name = $"box{5}";
            chkbox4.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox4.Size = new Size(18, 18);
            chkbox4.BackColor = Color.FromArgb(245, 245, 246);
            chkbox4.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox4);

            chkbox5 = new CheckBox();
            headerCell = dgvRight.GetCellDisplayRectangle(6, -1, true).Location;
            chkbox5.Name = $"box{6}";
            chkbox5.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox5.Size = new Size(18, 18);
            chkbox5.BackColor = Color.FromArgb(245, 245, 246);
            chkbox5.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox5);

            chkbox6 = new CheckBox();
            headerCell = dgvRight.GetCellDisplayRectangle(7, -1, true).Location;
            chkbox6.Name = $"box{7}";
            chkbox6.Location = new Point(headerCell.X + 10, headerCell.Y + 17);
            chkbox6.Size = new Size(18, 18);
            chkbox6.BackColor = Color.FromArgb(245, 245, 246);
            chkbox6.Click += HeaderChk_Clicked;
            dgvRight.Controls.Add(chkbox6);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvRight.EndEdit();
            CheckBox checkBox = (CheckBox)sender;
            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvRight.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["A"];
                if (checkBox.Name == "box2")
                    chk.Value = chkbox1.Checked;
                chk = (DataGridViewCheckBoxCell)row.Cells["B"];
                if (checkBox == chkbox2)
                    chk.Value = chkbox2.Checked;
                chk = (DataGridViewCheckBoxCell)row.Cells["C"];
                if (checkBox == chkbox3)
                    chk.Value = chkbox3.Checked;
                chk = (DataGridViewCheckBoxCell)row.Cells["D"];
                if (checkBox == chkbox4)
                    chk.Value = chkbox4.Checked;
                chk = (DataGridViewCheckBoxCell)row.Cells["E"];
                if (checkBox == chkbox5)
                    chk.Value = chkbox5.Checked;
                chk = (DataGridViewCheckBoxCell)row.Cells["F"];
                if (checkBox == chkbox6)
                    chk.Value = chkbox6.Checked;
            }
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
            dgvUsers.ClearSelection();
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
            CheckMenuRight();
            dgvRight.ClearSelection();
        }

        private void CheckMenuRight()
        {
            foreach (MANAGERMENU_VO item in menulist)
            {
                foreach (DataGridViewRow row in dgvRight.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(item.MENU_NAME))
                    {
                        if (item.A.Length > 0)
                            row.Cells["A"].Value = true;
                        if (item.B.Length > 0)
                            row.Cells["B"].Value = true;
                        if (item.C.Length > 0)
                            row.Cells["C"].Value = true;
                        if (item.D.Length > 0)
                            row.Cells["D"].Value = true;
                        if (item.E.Length > 0)
                            row.Cells["E"].Value = true;
                        if (item.E.Length > 0)
                            row.Cells["F"].Value = true;
                    }

                }

            }
        }

        /// <summary>
        /// 전체그룹을 가져오는 메서드
        /// </summary>
        private void LoadRightList(string userID)
        {

            AuthService service = new AuthService();
            rightlist = service.GetRightList(userID);
            dgvGroup.DataSource = null;
            dgvGroup.DataSource = rightlist;
            dgvGroup.ClearSelection();
        }

        /// <summary>
        /// 탭페이지 인덱스 변경시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<MANAGER_VO> deptManList;
            if (cboDept.Text.Equals("전체"))
            {
                deptManList = managerlist;
            }
            else
            {
                deptManList = (from item in managerlist where item.MANAGER_DEP == cboDept.Text select item).ToList();
            }

            if (txtName.Text.Trim().Length > 0)
            {
                deptManList = (from item in deptManList where item.MANAGER_NAME.Contains(txtName.Text) select item).ToList();
            }

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = deptManList;
            dgvUsers.ClearSelection();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRight.EndEdit();
            var senderGrid = (DataGridView)sender;
            if (senderGrid[3, e.RowIndex].Value.ToString() == "설정")
            {
                int cnt = 0;
                //수정중인 작업이 있는경우
                foreach (DataGridViewRow row in senderGrid.Rows)
                {
                    if (row.Cells[3].Value.ToString() == "저장")
                        cnt++;
                    if (cnt > 0)
                    {
                        MessageBox.Show("설정중인 내용을 저장해주세요.", "저장되지않은 설정 존재", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    dgvGroup.DataSource = null;
                    dgvRight.DataSource = null;
                    selectedUser = dgvUsers[0, e.RowIndex].Value.ToString();
                    LoadMenuList(selectedUser);
                    LoadRightList(selectedUser);

                    var BtnCell = (DataGridViewButtonCell)dgvUsers.Rows[e.RowIndex].Cells[3];
                    BtnCell.UseColumnTextForButtonValue = false;
                    BtnCell.Value = (string)"저장";
                }
            }
            else
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    dgvRight.EndEdit();
                    //저장할 값 가져오기
                    List<ManagerMenu_VO> list = GetRightValues();
                    string userID = selectedUser;
                    //서비스호출
                    AuthService service = new AuthService();
                    if (service.SaveManagerMenu(list, userID))
                    {
                        MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장에 실패하였습니다.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    var BtnCell = (DataGridViewButtonCell)dgvUsers.Rows[e.RowIndex].Cells[3];
                    BtnCell.UseColumnTextForButtonValue = false;
                    BtnCell.Value = (string)"설정";
                }
            }
        }

        private List<ManagerMenu_VO> GetRightValues()
        {
            List<ManagerMenu_VO> list = new List<ManagerMenu_VO>();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgvRight.Rows)
            {

                if (row.Cells[2].Value != null)
                {
                    if ((bool)row.Cells[2].Value)
                        sb.Append("C");
                }
                if (row.Cells[3].Value != null)
                {
                    if ((bool)row.Cells[3].Value)
                        sb.Append("R");
                }
                if (row.Cells[4].Value != null)
                {
                    if ((bool)row.Cells[4].Value)
                        sb.Append("U");
                }
                if (row.Cells[5].Value != null)
                {
                    if ((bool)row.Cells[5].Value)
                        sb.Append("D");
                }
                if (row.Cells[6].Value != null)
                {

                    if ((bool)row.Cells[6].Value)
                        sb.Append("P");
                }
                if (row.Cells[7].Value != null)
                {
                    if ((bool)row.Cells[7].Value)
                        sb.Append("R");
                }

                ManagerMenu_VO vo = new ManagerMenu_VO();
                vo.MENU_ID = Convert.ToInt32(row.Cells[0].Value);
                vo.CRUDPR = sb.ToString();
                sb.Clear();

                list.Add(vo);
            }
            return list;
        }
    }
}
