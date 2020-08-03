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
    public partial class FrmSalesMaster : TEAM3FINAL.baseForm2, CommonBtn
    {
        #region 멤버변수
        List<SALESWorkList_VO> AllList = default;
        #endregion

        #region 생성자
        public FrmSalesMaster()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvSales);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvSales, "  ");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "code", "SALES_ID", false, 50);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "고객 WO", "SALES_Work_Order_ID", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "고객주문번호", "SO_PurchaseOrder", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "고객사코드", "COM_CODE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "고객사명", "COM_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "도착지코드", "SALES_COM_CODE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "도착지명", "SALES_COM_NAME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "고객주문유형", "SALES_Order_TYPE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "품명", "ITEM_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "생산납기일", "SALES_DUEDATE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "주문수량", "SALES_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "출고수량", "SALES_Out_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "취소수량", "SALES_NO_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSales, "주문상태", "SALES_ORDER_STATE", true, 100);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvSales);
        }

        private string CheckedList()
        {
            dgvSales.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvSales.Rows)
            {
                if (item is DataGridViewRow)
                {
                    DataGridViewRow row = item as DataGridViewRow;
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        sb.Append(row.Cells[1].Value.ToString() + "@");
                    }
                }
            }
            if (sb.Length < 1)
            {
                MessageBox.Show("품목을 선택해주십시오.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            sb.Remove(sb.Length - 1, 1);

            //체크 목록을 string으로 만듬
            return sb.ToString();
        }

        private void LoadSalesWorkList()
        {
            //서비스호출
            SalesService service = new SalesService();
            AllList = service.GetSalesWorkList();
            dgvSales.DataSource = null;
            dgvSales.DataSource = AllList;
        }

        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();

            var commonlist = service.GetCmCode();
            var statelist = (from item in commonlist select item).Where(p => p.COMMON_PARENT == "ORDER_STATE").ToList();
            var companylist = service.GetCompanyCode();
            var com2list = service.GetCompanyCode();
            CommonUtil.ComboBinding<ComboItemVO>(cboState, statelist, "COMMON_CODE", "COMMON_NAME", "");
            CommonUtil.ComboBinding<ComboItemVO>(cboCom, companylist, "COMMON_CODE", "COMMON_NAME", "");
            CommonUtil.ComboBinding<ComboItemVO>(cboCom2, com2list, "COMMON_CODE", "COMMON_NAME", "");
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


        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmSalesMasterPop frm = new FrmSalesMasterPop(InsertOrUpdate.insert);
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Search(object sender, EventArgs e)
        {
            //List<SHIFTList_VO> list = null;
            ////Shift조회
            //if (AllList.Count > 0 && cboShift.SelectedIndex > 0)
            //{
            //    list = (from item in AllList select item).Where
            //        (p => p.SHIFT_TYP == cboShift.SelectedText).ToList();
            //}
            //else
            //{
            //    list = AllList;
            //}
            ////업체명 조회
            //if (cboFclts.Text.Length > 0)
            //{
            //    list = (from item in list select item).Where(p => p.FCLTS_NAME == cboFclts.Text).ToList();
            //}
            //dgvShift.DataSource = null;
            //dgvShift.DataSource = list;

        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadSalesWorkList();
                //cboFclts.SelectedIndex = 0;
                //cboShift.SelectedIndex = 0;
            }

        }

        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string uid = CheckedList();
                if (uid.Length < 1)
                    return;
                if (uid.Contains("@"))
                {
                    MessageBox.Show("수정할 품목 하나를 선택하세요.", "품목 선택", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                FrmSalesMasterPop frm = new FrmSalesMasterPop(InsertOrUpdate.update, uid);
                frm.ShowDialog();
                Reset(null, null);
            }

        }

        public void Delete(object sender, EventArgs e)
        {
            string lists = CheckedList();
            if (lists.Length > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //서비스 호출
                    SalesService service = new SalesService();
                    if (service.DeleteSalesWorkList(lists, "@"))
                    {
                        MessageBox.Show("삭제되었습니다.", "삭제 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("삭제 중 오류가 발생하였습니다. 다시 시도하여 주십시오.", "삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Reset(null, null);

        }

        public void Print(object sender, EventArgs e)
        {
            //미구현
        }

        #endregion

        #endregion

        #region 이벤트
        private void FrmSalesMaster_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadSalesWorkList();
        }

        #endregion

    }
}
