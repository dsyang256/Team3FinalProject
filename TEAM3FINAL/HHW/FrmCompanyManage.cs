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
    public partial class FrmCompanyManage : TEAM3FINAL.baseForm2, CommonBtn
    {
        CheckBox headerChk;

        public FrmCompanyManage()
        {
            InitializeComponent();
        }

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvCompanyList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvCompanyList, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업체코드", "COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업체명", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업체타입명", "COM_TYP", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "대표자명", "COM_CEO", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "사업자등록번호", "COM_REG_NUM", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업종", "COM_TYP_INDSTRY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업태", "COM_TYP_BSNS", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "담당자명", "COM_MANAGER", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "이메일", "COM_EML", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "전화번호", "COM_TEL", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "팩스", "COM_FAX", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "출하자동입고유무", "COM_AUTOIN_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "출발유무", "COM_START_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "사용유무", "COM_USE_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "수정자", "COM_LAST_MDFR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "최종수정시간", "COM_LAST_MDFY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "거래유무", "COM_TRAD_YN", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "거래시작일", "COM_STR_DATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "거래종료일", "COM_END_DATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCompanyList, "업체정보", "COM_INFO", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvCompanyList);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvCompanyList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvCompanyList.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvCompanyList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvCompanyList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        private void FrmCompanyManage_Load(object sender, EventArgs e)
        {
            btnset();
            ComboBinding();
            DataGridViewColumnSet();
            GetCompanyList();
        }

        private void GetCompanyList()
        {
            CompanyService service = new CompanyService();
            dgvCompanyList.DataSource = null;
            dgvCompanyList.DataSource = service.GetCompanyList();
        }

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
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmCompanyPopUp frm = new FrmCompanyPopUp();
                frm.COM_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                frm.COM_LAST_MDFY = DateTime.Now.ToString("yyyy-MM-dd");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    GetCompanyList();
                }
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                CompanyService service = new CompanyService();
                dgvCompanyList.DataSource = null;
                dgvCompanyList.DataSource = service.SearchCompany(txtComCode.Text, txtComName.Text, cboComType.Text, txtNum.Text);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            txtComCode.Text = "";
            txtComName.Text = "";
            txtNum.Text = "";
            cboComType.Text = "";
            GetCompanyList();
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvCompanyList.EndEdit();
            
                string sb = string.Empty;
                int cnt = 0;
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvCompanyList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        sb = item.Cells[1].Value.ToString();
                        cnt++;
                    }
                }
                if (cnt == 1) //하나일 경우 PopUp창 띄움
                {
                    FrmCompanyPopUp frm = new FrmCompanyPopUp();
                    frm.Update = true;
                    frm.COM_CODE = dgvCompanyList.CurrentRow.Cells[1].Value.ToString();
                    frm.COM_NAME = dgvCompanyList.CurrentRow.Cells[2].Value.ToString();
                    frm.COM_TYP = dgvCompanyList.CurrentRow.Cells[3].Value.ToString();
                    frm.COM_CEO = dgvCompanyList.CurrentRow.Cells[4].Value.ToString();
                    frm.COM_REG_NUM = dgvCompanyList.CurrentRow.Cells[5].Value.ToString();
                    frm.COM_TYP_INDSTRY = dgvCompanyList.CurrentRow.Cells[6].Value.ToString();
                    frm.COM_TYP_BSNS = dgvCompanyList.CurrentRow.Cells[7].Value.ToString();
                    frm.COM_MANAGER = dgvCompanyList.CurrentRow.Cells[8].Value.ToString();
                    frm.COM_EML = dgvCompanyList.CurrentRow.Cells[9].Value.ToString();
                    frm.COM_TEL = dgvCompanyList.CurrentRow.Cells[10].Value.ToString();
                    frm.COM_FAX = dgvCompanyList.CurrentRow.Cells[11].Value.ToString();
                    frm.COM_AUTOIN_YN = dgvCompanyList.CurrentRow.Cells[12].Value.ToString();
                    frm.COM_START_YN = dgvCompanyList.CurrentRow.Cells[13].Value.ToString();
                    frm.COM_USE_YN = dgvCompanyList.CurrentRow.Cells[14].Value.ToString();
                    frm.COM_LAST_MDFR = dgvCompanyList.CurrentRow.Cells[15].Value.ToString();
                    frm.COM_LAST_MDFY = dgvCompanyList.CurrentRow.Cells[16].Value.ToString();
                    frm.COM_STR_DATE = dgvCompanyList.CurrentRow.Cells[17].Value.ToString();
                    frm.COM_END_DATE = dgvCompanyList.CurrentRow.Cells[18].Value.ToString();
                    frm.COM_INFO = dgvCompanyList.CurrentRow.Cells[19].Value.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetCompanyList();
                    }
                }
            }
            else
            {
                MessageBox.Show("하나의 항목씩만 수정 가능");
                return;
            }
        }

        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvCompanyList.EndEdit();
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                //품목 선택후 List를 전달
                foreach (DataGridViewRow item in dgvCompanyList.Rows)
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

                    Message msg = service.DeleteFactory("COMPANY", "COM_CODE", sb);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        GetCompanyList();
                    }
                    else
                    {
                        MessageBox.Show(msg.ResultMessage);
                        return;
                    }
                }
            }
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
