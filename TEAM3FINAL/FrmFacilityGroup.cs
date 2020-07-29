using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;

namespace TEAM3FINAL
{
    public partial class FrmFacilityGroup : TEAM3FINAL.ProjectBaseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmFacilityGroup()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvFacilityGroupList);
            //데이터그리드뷰 체크박스 컬럼 추가
            Util.DataGridViewCheckBoxSet(dgvFacilityGroupList, "");
            //일반컬럼 추가
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "설비군 코드", "FACG_CODE", true, 80);
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "설비군명", "FACG_NAME", true, 80);
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "사용유무", "FACG_USE_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "수정자", "FACG_LAST_MDFR", true, 80);
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "최종수정날짜", "FACG_LAST_MDFY", true, 80);
            Util.AddNewColumnToDataGridView(dgvFacilityGroupList, "시설설명", "FACG_DESC", true, 80);

            DataGridViewCheckBoxAllCheck();
        }
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

        #endregion

        private void FrmFacilityGroup_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetFacilityGroupList();
        }

        private void GetFacilityGroupList()
        {
            FacilityService service = new FacilityService();            
            dgvFacilityGroupList.DataSource = null;
            dgvFacilityGroupList.DataSource = service.GetFacilityGroupInfo();

        }

        // 버튼 이벤트 추가 메서드
        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset; //입력필요
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
                FrmFacilityGroupPopUp frm = new FrmFacilityGroupPopUp();
                frm.FACG_LAST_MDFR = "황현우"; //로그인 성명으로 변경하기
                frm.FACG_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.OK)
                {
                    GetFacilityGroupList();
                }
            }
        }

        public void Search(object sender, EventArgs e)
        {
            
        }

        public void Reset(object sender, EventArgs e)
        {
            
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvFacilityGroupList.EndEdit();
                string sb = string.Empty;
                int cnt = 0;
                foreach (DataGridViewRow item in dgvFacilityGroupList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        sb = item.Cells[1].Value.ToString();
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
                    frm.FACG_LAST_MDFR = "황현우"; //로그인창 수정
                    frm.FACG_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    frm.FACG_DESC = dgvFacilityGroupList.CurrentRow.Cells[6].Value.ToString();
                    frm.ShowDialog();
                    if(frm.DialogResult == DialogResult.OK)
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
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvFacilityGroupList.EndEdit();
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
                sb.Remove(sb.Length - 1, 1);
                if (MessageBox.Show($"총 {cnt}개의 항목을 삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FactoryService service = new FactoryService();
                    if (service.DeleteFactory("FACILITY_GROP", "FACG_CODE", sb) == "C200")
                    {
                        MessageBox.Show("삭제 완료");
                        GetFacilityGroupList();
                    }
                }
            }
        }

        public void Print(object sender, EventArgs e)
        {
            
        }

        #endregion


    }
}
