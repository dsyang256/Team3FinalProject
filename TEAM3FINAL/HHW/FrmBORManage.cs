using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmBORManage : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmBORManage()
        {
            InitializeComponent();
        }

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvBORList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvBORList, "");
            DataGridViewColumn dc = dgvBORList.Columns[0];
            dc.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "PK", "BOR_CODE", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "품목", "ITEM_CODE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "품명", "ITEM_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정", "BOR_PROCS_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정명", "COMMON_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "설비", "FCLTS_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "설비명", "FCLTS_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "Tack Time", "BOR_PROCS_TIME", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "우선순위", "BOR_PRIORT", true, 100, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "공정선행일", "BOR_PROCS_LEADTIME", true, 200, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "수율", "BOR_YIELD", true, 80, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "사용유무", "BOR_USE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "비고", "BOR_REMARK", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "수정자", "BOR_LAST_MDFR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBORList, "최종수정날짜", "BOR_LAST_MDFY", true, 200);
            dgvBORList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBORList.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvBORList);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvBORList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvBORList.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvBORList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvBORList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        private void FrmBORManage_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetBORList();
            ((FrmMAIN)this.MdiParent).Readed += Readed_BarCode;
        }
       
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            try
            {
                if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
                {
                    string msg = e.ReadMsg.Replace("0", "").Trim();
                    ((FrmMAIN)this.MdiParent).ClearStrings();

                    int i = 0;
                    foreach (DataGridViewRow item in dgvBORList.Rows)
                    {
                        if (item.Cells[1].Value.ToString() == msg)
                        {
                            item.Cells[0].Value = true;
                            item.Selected = true;
                            i++;
                        }
                    }
                    if (i < 1)
                    {
                        MessageBox.Show("항목이 없습니다 다시 확인해주세요.");
                        return;
                    }
                    if (MessageBox.Show("해당을 수정하시겠습니까?", "수정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Update(null, null);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset;
            frm.ePrint += Print;
        }
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonList = service.GetITEMCmCode();

            var listTool = (from item in commonList where item.COMMON_PARENT == "PROC_TOOL" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboPROC, listTool, "COMMON_CODE", "COMMON_NAME", "");
        }

        private void GetBORList()
        {
            BORService service = new BORService();
            //dgvBORList.DataSource = null;
            dgvBORList.DataSource = service.GetBORList();
        }

        #region ****메인 버튼 이벤트****
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmBORPopUp frm = new FrmBORPopUp();
                frm.BOR_LAST_MDFR = LoginInfo.UserInfo.LI_ID;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    GetBORList();
                }
            }
        }

        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                BORService service = new BORService();
                dgvBORList.DataSource = null;
                dgvBORList.DataSource = service.SearchBOR(txtITEMCODE.Text, cboPROC.Text, txtFacility.Text);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            txtITEMCODE.Text = "";
            cboPROC.Text = "";
            txtFacility.Text = "";
            GetBORList();
        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //수정 시 여러개의 체크박스를 선택하는것을 막음
                dgvBORList.EndEdit();
                string sb = string.Empty;
                int cnt = 0;
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvBORList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        sb = item.Cells[1].Value.ToString();
                        cnt++;
                    }
                }
                if (cnt == 1) //하나일 경우 PopUp창 띄움 ************************
                {
                    FrmBORPopUp frm = new FrmBORPopUp();
                    frm.Update = true;
                    frm.BOR_CODE = Convert.ToInt32(dgvBORList.CurrentRow.Cells[1].Value);
                    frm.ITEM_CODE = dgvBORList.CurrentRow.Cells[2].Value.ToString();
                    frm.BOR_PROCS_CODE = dgvBORList.CurrentRow.Cells[4].Value.ToString();
                    frm.FCLTS_CODE = dgvBORList.CurrentRow.Cells[6].Value.ToString();
                    frm.BOR_PROCS_TIME = Convert.ToInt32(dgvBORList.CurrentRow.Cells[8].Value);
                    frm.BOR_PRIORT = Convert.ToInt32(dgvBORList.CurrentRow.Cells[9].Value);
                    frm.BOR_PROCS_LEADTIME = Convert.ToInt32(dgvBORList.CurrentRow.Cells[10].Value);
                    frm.BOR_YIELD = Convert.ToDecimal(dgvBORList.CurrentRow.Cells[11].Value);
                    frm.BOR_USE_YN = dgvBORList.CurrentRow.Cells[12].Value.ToString();
                    frm.BOR_REMARK = dgvBORList.CurrentRow.Cells[13].Value.ToString();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        GetBORList();
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
                dgvBORList.EndEdit();
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                //품목 선택후 List를 전달
                foreach (DataGridViewRow item in dgvBORList.Rows)
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

                    Message msg = service.DeleteFactory("BOR", "BOR_CODE", sb);
                    if (msg.IsSuccess)
                    {
                        MessageBox.Show(msg.ResultMessage);
                        GetBORList();
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
            
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvBORList.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvBORList.Rows[i].Cells[0].EditedFormattedValue;
                if (isCellChecked)
                {
                    chkList.Add(dgvBORList.Rows[i].Cells[1].Value.ToString()); 
                }
            }
            if (chkList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }

            string strChkBarCodes = string.Join(",", chkList);

            BORService service = new BORService();
            XtraBORList rpt = new XtraBORList();

            DataTable dt = service.GetBaCodeBORList(strChkBarCodes);

            rpt.Parameters["uName"].Value = LoginInfo.UserInfo.LI_NAME;
            rpt.DataSource = dt;
            rpt.CreateDocument();
            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void FrmBORManage_FormClosing(object sender, FormClosingEventArgs e)
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
