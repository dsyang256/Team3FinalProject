using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmProductionPlan : TEAM3FINAL.baseForm2, CommonBtn
    {
        public FrmProductionPlan()
        {
            InitializeComponent();
        }

        #region 공통버튼
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
        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Insert(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
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
            dgvPlan.Columns[0].Frozen = true;
            column.Width = 200;

            column = dgvPlan.Columns[1];
            dgvPlan.Columns[1].Frozen = true;
            column.Width = 200;

            column = dgvPlan.Columns[2];
            dgvPlan.Columns[2].Frozen = true;
            column.Width = 150;

            column = dgvPlan.Columns[3];
            dgvPlan.Columns[3].Frozen = true;
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
        private void FrmProductionPlan_Load(object sender, EventArgs e)
        {
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회

            //그리드 초기화
            DataGridViewColumnSet();
        }

        private void FrmProductionPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
