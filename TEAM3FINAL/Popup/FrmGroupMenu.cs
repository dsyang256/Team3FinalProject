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
    public partial class FrmGroupMenu : TEAM3FINAL.baseFormPopUP
    {
        CheckBox chkbox1;
        List<MANAGERMENU_VO> menulist = null;
        List<MANAGERMENU_VO> rightmenulist = null;
        List<Right_VO> rightlist = null;
        string rightID = "";
        public FrmGroupMenu()
        {
            InitializeComponent();
        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvGroups);
            //데이터그리드뷰 컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "그룹코드", "RIGHT_ID", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "그룹", "RIGHT_GROUP", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "그룹명", "RIGHT_NAME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "그룹설명", "RIGHT_DESC", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "사용여부", "RIGHT_FIRST_MDFR", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "1", "RIGHT_USE", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "1", "RIGHT_FIRST_MDFY", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "1", "RIGHT_LAST_MDFR", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvGroups, "1", "RIGHT_LAST_MDFY", false, 100);
            dgvGroups.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGroups.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvMenus);
            ////데이터그리드뷰 체크박스, 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvMenus, "    ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "메뉴id", "MENU_ID", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "메뉴명", "MENU_NAME", true, 200, DataGridViewContentAlignment.MiddleCenter);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "1", "A", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "1", "B", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "1", "C", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "1", "D", false, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMenus, "1", "E", false, 80);
            DataGridViewColumn col = this.dgvMenus.Columns[1];
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMenus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMenus.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewCheckBox();
        }

        private void DataGridViewCheckBox()
        {
            chkbox1 = new CheckBox();
            Point headerCell = dgvMenus.GetCellDisplayRectangle(1, -1, true).Location;
            chkbox1.Name = $"box{1}";
            chkbox1.Location = new Point(headerCell.X + 35, headerCell.Y + 17);
            chkbox1.Size = new Size(18, 18);
            chkbox1.BackColor = Color.FromArgb(245, 245, 246);
            chkbox1.Click += HeaderChk_Clicked;
            dgvMenus.Controls.Add(chkbox1);
        }
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvMenus.EndEdit();
            CheckBox checkBox = (CheckBox)sender;
            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvMenus.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (checkBox == chkbox1)
                    chk.Value = chkbox1.Checked;
            }
        }


        /// <summary>
        /// 전체메뉴를 가져오는 메서드
        /// </summary>
        private void LoadMenuList(string rightID)
        {
            AuthService service = new AuthService();
            menulist = service.GetAllMenuList();
            dgvMenus.DataSource = null;
            dgvMenus.DataSource = menulist;
            rightmenulist = service.GetRightMenuList(rightID);
            CheckMenuRight();
            dgvMenus.ClearSelection();
        }
        private void CheckMenuRight()
        {
            foreach (DataGridViewRow row in dgvMenus.Rows)
            {
                foreach (MANAGERMENU_VO item in rightmenulist)
                {
                    if (row.Cells[1].Value.ToString() == item.MENU_ID.ToString())
                    {
                        row.Cells[0].Value = true;
                    }
                }

            }
            rightmenulist.Clear();
        }
        private void LoadGroupList(string userID)
        {
            AuthService service = new AuthService();
            rightlist = service.GetALLRightList();
            dgvGroups.DataSource = null;
            dgvGroups.DataSource = rightlist;
            //managermenulist = service.GetManagerMenuList(userID);
            //CheckMenuRight();
            dgvGroups.ClearSelection();
        }

        /// <summary>
        /// 권한 추가 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRightAdd_Click(object sender, EventArgs e)
        {
            FrmGroupPop frm = new FrmGroupPop();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadGroupList("");
            }
        }

        /// <summary>
        /// 권한 삭제 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRightRemove_Click(object sender, EventArgs e)
        {
            if (dgvGroups.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("삭제하시겠습니까?.", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    AuthService service = new AuthService();
                    if (service.DeleteGroup(rightID))
                    {
                        MessageBox.Show("삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("삭제에 실패하였습니다.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            LoadGroupList("");
        }

        /// <summary>
        /// 관리자별 권한 등록 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvMenus.Rows.Count > 0)
            {
                //저장
                dgvMenus.EndEdit();
                //저장할 값 가져오기
                List<RightMenus_VO> list = GetMenuValues();
                //서비스호출
                AuthService service = new AuthService();
                if (service.SaveRightMenu(list, rightID))
                {
                    MessageBox.Show("저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("저장에 실패하였습니다.", "저장 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private List<RightMenus_VO> GetMenuValues()
        {
            dgvMenus.EndEdit();
            List<RightMenus_VO> list = new List<RightMenus_VO>();
            foreach (DataGridViewRow row in dgvMenus.Rows)
            {
                if (row.Index > -1)
                {
                    RightMenus_VO vo = new RightMenus_VO();
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value)
                        {
                            vo.RIGHT_ID = Convert.ToInt32(rightID);
                            vo.MENU_ID = Convert.ToInt32(row.Cells[1].Value);
                            list.Add(vo);
                        }
                    }

                }
            }
            return list;

        }

        /// <summary>
        /// 폼 로드 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGroupMenu_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();
            LoadGroupList("");
        }

        private void btnCancels_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvGroups.EndEdit();
            if (dgvGroups.SelectedRows.Count > 0)
            {
                rightID = dgvGroups[0, e.RowIndex].Value.ToString();
                LoadMenuList(rightID);
            }
        }
    }
}
