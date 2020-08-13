using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmFacilityGroup : TEAM3FINAL.ProjectBaseForm, CommonBtn
    {
        CheckBox headerChk;
        CheckBox headerChk2;
        
        /// <summary>
        /// true : 설비군 입력/수정/삭제 , false : 설비 입력/수정/삭제
        /// </summary>

        public FrmFacilityGroup()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //설비군
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvFacilityGroupList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvFacilityGroupList, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "설비군 코드", "FACG_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "설비군명", "FACG_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "사용유무", "FACG_USE_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "수정자", "FACG_LAST_MDFR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "최종수정날짜", "FACG_LAST_MDFY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityGroupList, "시설설명", "FACG_DESC", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvFacilityGroupList);
            DataGridViewCheckBoxAllCheck();


            //설비
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvFacilityList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvFacilityList, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "설비군코드", "FACG_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "설비코드", "FCLTS_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "설비명", "FCLTS_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "소진창고", "FCLTS_WRHS_EXHST", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "양품창고", "FCLTS_WRHS_GOOD", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "불량창고", "FCLTS_WRHS_BAD", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "사용유무", "FCLTS_USE_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "외주여부", "FCLTS_EXTRL_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "수정자", "FCLTS_LAST_MDFR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "최종수정일", "FCLTS_LAST_MDFY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "특이사항", "FCLTS_NOTE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvFacilityList, "비고", "FCLTS_REMARK", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvFacilityList);
            DataGridViewCheckBoxAllCheck2();
        }

        //설비군
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvFacilityGroupList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvFacilityGroupList.Controls.Add(headerChk);
        }

        //설비
        private void DataGridViewCheckBoxAllCheck2()
        {
            headerChk2 = new CheckBox();
            Point headerCell = dgvFacilityList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk2.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk2.Size = new Size(18, 18);
            headerChk2.BackColor = Color.FromArgb(245, 245, 246);
            headerChk2.Click += HeaderChk_Clicked2;
            dgvFacilityList.Controls.Add(headerChk2);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvFacilityGroupList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvFacilityGroupList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgvFacilityList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvFacilityList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk2.Checked;
            }
        }

        #endregion

        //설비군 로드
        private void FrmFacilityGroup_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetFacilityGroupList();
            GetFacilityList();
        }

        private void GetFacilityGroupList()
        {
            FacilityService service = new FacilityService();            
            dgvFacilityGroupList.DataSource = null;
            dgvFacilityGroupList.DataSource = service.GetFacilityGroupInfo();
        }

        private void GetFacilityList()
        {
            FacilityService service = new FacilityService();
            dgvFacilityList.DataSource = null;
            dgvFacilityList.DataSource = service.GetFacilityInfo();
        }

        // 버튼 이벤트 추가 메서드
        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset;
            frm.ePrint += Print; //입력필요
        }

        //콤보박스 바인딩
        private void ComboBinding()
        {

        }

        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            if(((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmFacilityChoice form = new FrmFacilityChoice();
                form.ShowDialog();
                if (form.FacilityAndGroup) //true : 설비군 팝업창 입력
                {
                    FrmFacilityGroupPopUp frm = new FrmFacilityGroupPopUp();
                    frm.FACG_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                    frm.FACG_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetFacilityGroupList();
                    }
                }
                else //false : 설비 팝업창 입력
                {
                    FrmFacilityPopUp frm = new FrmFacilityPopUp();
                    frm.FCLTS_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                    frm.FCLTS_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetFacilityList();
                    }
                }
            }
        }

        public void Search(object sender, EventArgs e)
        {
            
        }

        public void Reset(object sender, EventArgs e)
        {
            GetFacilityGroupList();
            GetFacilityList();
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

                dgvFacilityGroupList.EndEdit();
                dgvFacilityList.EndEdit();

                FrmFacilityChoice form = new FrmFacilityChoice();
                form.ShowDialog();
                if (form.FacilityAndGroup) //설비군 수정
                {
                    string sb = string.Empty;
                    int cnt = 0;
                    foreach (DataGridViewRow item in dgvFacilityGroupList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb = item.Cells[1].Value.ToString(); //PK = 설비군코드
                            cnt++;
                        }
                    }
                    if (cnt == 1) //하나일 경우 PopUp창 띄움
                    {
                        FrmFacilityGroupPopUp frm = new FrmFacilityGroupPopUp();
                        frm.Update = true;
                        frm.FACG_CODE = dgvFacilityGroupList.CurrentRow.Cells[1].Value.ToString();
                        frm.FACG_NAME = dgvFacilityGroupList.CurrentRow.Cells[2].Value.ToString();
                        frm.FACG_USE_YN = dgvFacilityGroupList.CurrentRow.Cells[3].Value.ToString();
                        frm.FACG_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                        frm.FACG_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        frm.FACG_DESC = dgvFacilityGroupList.CurrentRow.Cells[6].Value.ToString();
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            GetFacilityGroupList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("하나의 항복씩만 수정 가능");
                        return;
                    }
                }
                else //설비 수정
                {
                    string sb = string.Empty;
                    int cnt = 0;
                    foreach (DataGridViewRow item in dgvFacilityList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb = item.Cells[2].Value.ToString(); //PK = 설비코드
                            cnt++;
                        }
                    }
                    if(cnt == 1)
                    {
                        FrmFacilityPopUp frm = new FrmFacilityPopUp();
                        frm.Update = true;
                        frm.FACG_CODE = dgvFacilityList.CurrentRow.Cells[1].Value.ToString();
                        frm.FCLTS_CODE = dgvFacilityList.CurrentRow.Cells[2].Value.ToString();
                        frm.FCLTS_NAME = dgvFacilityList.CurrentRow.Cells[3].Value.ToString();
                        frm.FCLTS_WRHS_EXHST = dgvFacilityList.CurrentRow.Cells[4].Value.ToString();
                        frm.FCLTS_WRHS_GOOD = dgvFacilityList.CurrentRow.Cells[5].Value.ToString();
                        frm.FCLTS_WRHS_BAD = dgvFacilityList.CurrentRow.Cells[6].Value.ToString();
                        frm.FCLTS_USE_YN = dgvFacilityList.CurrentRow.Cells[7].Value.ToString();
                        frm.FCLTS_EXTRL_YN = dgvFacilityList.CurrentRow.Cells[8].Value.ToString();
                        frm.FCLTS_LAST_MDFR = dgvFacilityList.CurrentRow.Cells[9].Value.ToString();
                        frm.FCLTS_LAST_MDFY = dgvFacilityList.CurrentRow.Cells[10].Value.ToString();
                        frm.FCLTS_NOTE = dgvFacilityList.CurrentRow.Cells[11].Value.ToString();
                        frm.FCLTS_REMARK = dgvFacilityList.CurrentRow.Cells[12].Value.ToString();
                        frm.ShowDialog();
                        if(frm.DialogResult == DialogResult.OK)
                        {
                            GetFacilityList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("하나의 항복씩만 수정 가능");
                        return;
                    }
                }
            }            
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvFacilityGroupList.EndEdit();
                dgvFacilityList.EndEdit();

                FrmFacilityChoice form = new FrmFacilityChoice();
                form.ShowDialog();
                if (form.FacilityAndGroup)
                {
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvFacilityGroupList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb.Append(item.Cells[1].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("삭제할 항목을 선택하여 주십시오.");
                        return;
                    }
                    if(cnt == 2)
                    {
                        MessageBox.Show("설비군 데이터는 하나의 항목씩만 삭제 가능합니다.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"관련된 설비 데이터도 모두 삭제 됩니다. \n 총 {cnt}개의 항목을 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        FacilityService service = new FacilityService();
                        Message msg = service.DeleteFacilityGroup(dgvFacilityGroupList.CurrentRow.Cells[1].Value.ToString());
                        if(msg.IsSuccess)
                        {
                            MessageBox.Show(msg.ResultMessage);
                            GetFacilityGroupList();
                            GetFacilityList();
                        }
                        else
                        {
                            MessageBox.Show(msg.ResultMessage);
                            return;
                        }
                    }
                }
                else //설비 삭제
                {
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvFacilityList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb.Append(item.Cells[2].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("삭제할 항목을 선택하여 주십시오.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"총 {cnt}개의 항목을 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        FactoryService service = new FactoryService();
                        Message msg = service.DeleteFactory("FACILITY", "FCLTS_CODE", sb);
                        if (msg.IsSuccess)
                        {
                            MessageBox.Show(msg.ResultMessage);
                            GetFacilityList();
                        }
                        else
                        {
                            MessageBox.Show(msg.ResultMessage);
                            return;
                        }
                    }
                }                
            }
        }

        public void Print(object sender, EventArgs e)
        {
            
        }


        #endregion

        //설비군 더블클릭하여 설비군을 모로 하는 설비리스트 찾기
        private void dgvFacilityGroupList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFacilityList.DataSource = null;
            string code = dgvFacilityGroupList.SelectedRows[0].Cells[1].Value.ToString();
            FacilityService service = new FacilityService();
            dgvFacilityList.DataSource = service.SearchFacilityInfo(code);
        }

        private void FrmFacilityGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset;
            frm.ePrint -= Print;
        }
    }
}
