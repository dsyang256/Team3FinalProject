using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmDemandPlan : TEAM3FINAL.baseForm2 , CommonBtn
    {
        public FrmDemandPlan()
        {
            InitializeComponent();
        }
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            dgvPlan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPlan.AutoGenerateColumns = true;
            dgvPlan.AllowUserToAddRows = false;
            dgvPlan.MultiSelect = false;
            dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlan.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            dgvPlan.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn column = dgvPlan.Columns[0];
            column.Width = 200;
            column = dgvPlan.Columns[1];
            column.Width = 200;
            column = dgvPlan.Columns[2];
            column.Width = 150;
            column = dgvPlan.Columns[3];
            column.Width = 150;




            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvPlan);
        }
        private void BindingComboBox()
        {
            ////서비스호출
            //ComboItemService service = new ComboItemService();

            //var commonlist = service.GetCmCode();
            //var statelist = (from item in commonlist select item).Where(p => p.COMMON_PARENT == "ORDER_STATE").ToList();
            //var companylist = service.GetCompanyCode();
            //var com2list = service.GetCompanyCode();
            //CommonUtil.ComboBinding<ComboItemVO>(cboState, statelist, "COMMON_CODE", "COMMON_NAME", "");
            //CommonUtil.ComboBinding<ComboItemVO>(cboCom, companylist, "COMMON_CODE", "COMMON_NAME", "");
            //CommonUtil.ComboBinding<ComboItemVO>(cboCom2, com2list, "COMMON_CODE", "COMMON_NAME", "");
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
                //FrmSalesMasterPop frm = new FrmSalesMasterPop(InsertOrUpdate.insert);
                //frm.ShowDialog();
                //Reset(null, null);
            }
        }

        public void Search(object sender, EventArgs e)
        {

        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //LoadSalesWorkList();
                //cboState.SelectedIndex = 0;
                //cboCom.SelectedIndex = 0;
                //cboCom2.SelectedIndex = 0;
                //cboOrderGubun.SelectedIndex = 0;
            }

        }

        public void Update(object sender, EventArgs e)
        {
            //if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            //{
            //    string uid = CheckedList();
            //    if (uid.Length < 1)
            //        return;
            //    if (uid.Contains("@"))
            //    {
            //        MessageBox.Show("수정할 품목 하나를 선택하세요.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    FrmSalesMasterPop frm = new FrmSalesMasterPop(InsertOrUpdate.update, uid);
            //    frm.ShowDialog();
            //    Reset(null, null);
            //}

        }

        public void Delete(object sender, EventArgs e)
        {
            //string lists = CheckedList();
            //if (lists.Length > 0)
            //{
            //    if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        //서비스 호출
            //        SalesService service = new SalesService();
            //        if (service.DeleteSalesWorkList(lists, "@"))
            //        {
            //            MessageBox.Show("삭제되었습니다.", "삭제 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        else
            //        {
            //            MessageBox.Show("삭제 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //Reset(null, null);

        }

        public void Print(object sender, EventArgs e)
        {
            //미구현
        }

        #endregion

        private void FrmDemandPlan_Load(object sender, EventArgs e)
        {
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadDemandPlan();
            //그리드 초기화
            DataGridViewColumnSet();
        }

        private void LoadDemandPlan()
        {
            //서비스호출
            PlanService service = new PlanService();
            DataTable dt = service.GetDemandPlan("2020-08-01","2020-08-31","");
            dgvPlan.DataSource = null;
            dgvPlan.DataSource = dt;
        }

        private void FrmDemandPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
