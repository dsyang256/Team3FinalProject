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
    public partial class FrmCompanyEndByMonth2 : TEAM3FINAL.baseForm2, CommonBtn
    {
        CheckBox headerChk;

        public FrmCompanyEndByMonth2()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //설비군
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvCom);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvCom, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "업체코드", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "업체명", "ITEM_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "사업자번호", "COM_REG_NUM", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "금액", "TTLPRICE", true, 110, DataGridViewContentAlignment.MiddleRight);
            dgvCom.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCom.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvCom);
            DataGridViewCheckBoxAllCheck();


            //설비
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvComDetail);
            //데이터그리드뷰 체크박스 컬럼 추가
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "업체명", "ITEM_COM_DLVR", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "납품업체명", "ITEM_COM_REORDER", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "입고일", "INS_DATE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "카테고리", "INS_TYP", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "창고", "FAC_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "수불량", "INS_QTY", true, 120, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "단가", "MC_UNITPRICE_CUR", true, 120, DataGridViewContentAlignment.MiddleRight);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "금액", "TTLPRICE", true, 120, DataGridViewContentAlignment.MiddleRight);
            dgvComDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvComDetail.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvComDetail);
        }

        //업체
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvCom.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvCom.Controls.Add(headerChk);
        }


        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvCom.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvCom.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        #endregion

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

        private void GetSalesCom2()
        {
            SalesComService service = new SalesComService();
            dgvCom.DataSource = null;
            dgvCom.DataSource = service.GetSalesCom2();
        }

        private void GetSalesComDetail2()
        {
            SalesComService service = new SalesComService();
            dgvComDetail.DataSource = null;
            dgvComDetail.DataSource = service.GetSalesComDetail2();
        }

        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listCOM = (from item in commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM, listCOM, "COMMON_CODE", "COMMON_NAME", "");

            string[] year = new string[36];

            for (int i = 0; i < 36; i++)
            {
                year[i] = DateTime.Now.AddMonths(-i).ToString("yyyy-MM");
            }

            cboDate.DataSource = year;
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            
        }

        public void Search(object sender, EventArgs e)
        {
            string date = cboDate.Text;
            string company = cboCOM.Text;
            SalesComService service = new SalesComService();
            dgvCom.DataSource = null;
            dgvComDetail.DataSource = null;
            dgvCom.DataSource = service.SearchSalesCom2(date, company);
            dgvComDetail.DataSource = service.SearchSalesComDetail2(date, company);
        }

        public void Reset(object sender, EventArgs e)
        {
            ComboBinding();
            GetSalesCom2();
            GetSalesComDetail2();
        }

        public void Update(object sender, EventArgs e)
        {
            
        }

        public void Delete(object sender, EventArgs e)
        {
            
        }

        public void Print(object sender, EventArgs e)
        {
            
        }

        #endregion

        private void FrmCompanyEndByMonth2_Load(object sender, EventArgs e)
        {
            btnset();
            ComboBinding();
            DataGridViewColumnSet();
            GetSalesComDetail2();
            GetSalesCom2();
        }

        private void FrmCompanyEndByMonth2_FormClosing(object sender, FormClosingEventArgs e)
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
