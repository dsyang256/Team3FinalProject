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
    public partial class FrmMaterialCost : TEAM3FINAL.baseForm2, CommonBtn
    {

        #region 멤버변수
        List<MaterialCostList_VO> AllList;
        #endregion

        #region 생성자
        public FrmMaterialCost()
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
            Util.InitSettingGridView(dgvCost);
            Util.DataGridViewCheckBoxSet(dgvCost, "");
            Util.AddNewColumnToDataGridView(dgvCost, "자재코드", "MC_Code", false, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "업체", "COM_Code", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "업체명", "COM_NAME", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "품목", "ITEM_Code", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "품명", "ITEM_NAME", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "규격", "ITEM_STND", true, 150);
            Util.AddNewColumnToDataGridView(dgvCost, "단위", "ITEM_UNIT", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "현재단가", "MC_UNITPRICE_CUR", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "이전단가", "MC_UNITPRICE_EX", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "시작일", "MC_STARTDATE", true, 120);
            Util.AddNewColumnToDataGridView(dgvCost, "종료일", "MC_ENDDATE", true, 120);
            Util.AddNewColumnToDataGridView(dgvCost, "비고", "MC_REMARK", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "사용유무", "MC_USE_YN", true, 100);
        }

        /// <summary>
        /// 데이터그리드뷰의 체크된 품목의 코드에 해당하는 품목리스트를 가져오는 메서드
        /// </summary>
        private string CheckedList()
        {
            dgvCost.CommitEdit(DataGridViewDataErrorContexts.Commit);
            StringBuilder sb = new StringBuilder();
            //품목 선택후 List를 전달
            foreach (var item in dgvCost.Rows)
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

        private void LoadCostList()
        {
            //서비스 호출
            CostService service = new CostService();
            AllList = service.GetMaterialCostList();
            dgvCost.DataSource = null;
            dgvCost.DataSource = AllList;
        }

        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var ComList = service.GetCompanyCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboCompany, ComList, "COMMON_CODE", "COMMON_NAME", "");
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

        public void Delete(object sender, EventArgs e)
        {
            string lists = CheckedList();
            if (lists.Length > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //서비스 호출
                    CostService service = new CostService();
                    if (service.DeleteMaterialCostList(lists, "@"))
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

        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmMaterialCostPop frm = new FrmMaterialCostPop(InsertOrUpdate.insert);
                frm.ShowDialog();
                Reset(null, null);
            }
        }

        public void Print(object sender, EventArgs e)
        {
            //미구현
        }

        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                LoadCostList();
                txtItemName.Clear();
                cboCompany.SelectedIndex = 0;

            }
        }

        public void Search(object sender, EventArgs e)
        {
            List<MaterialCostList_VO> list = null;
            //기준날짜, 품목 조회
            if (AllList.Count > 0 && dtpDate.Checked)
            {
                list = (from item in AllList select item).Where
                    (p => Convert.ToDateTime(p.MC_STARTDATE) < dtpDate.Value && Convert.ToDateTime(p.MC_ENDDATE) > dtpDate.Value
                    && p.ITEM_Code.Contains(txtItemName.Text.Trim())).ToList();
            }
            else if (AllList.Count > 0 && !(dtpDate.Checked))
            {
                list = (from item in AllList select item).Where(p => p.ITEM_Code.Contains(txtItemName.Text.Trim())).ToList();
            }
            //업체명 조회
            if (cboCompany.Text.Length > 0)
            {
                list = (from item in list select item).Where(p => p.COM_NAME.Contains(cboCompany.Text)).ToList();
            }
            dgvCost.DataSource = null;
            dgvCost.DataSource = list;

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
                FrmMaterialCostPop frm = new FrmMaterialCostPop(InsertOrUpdate.update, uid);
                frm.ShowDialog();
                Reset(null, null);
            }
        }
        #endregion

        #endregion

        #region 이벤트
        private void FrmMaterialCost_Load(object sender, EventArgs e)
        {
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
            //데이터 조회
            LoadCostList();


        }


        /// <summary>
        /// 행 넘버 만드는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCost_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            { // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
        private void dgvCost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCost.SelectedRows.Count > 0)
            //{
            //    string str = dgvCost.Rows[e.RowIndex].Cells[3].Value.ToString();
            //}
        }
        #endregion

    }
}
