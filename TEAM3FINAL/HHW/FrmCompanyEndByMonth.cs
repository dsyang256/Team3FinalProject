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
    public partial class FrmCompanyEndByMonth : TEAM3FINAL.baseForm2, CommonBtn
    {
        CheckBox headerChk;

        public FrmCompanyEndByMonth()
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
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "업체코드", "SALES_COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "업체명", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "사업자등록번호", "COM_REG_NUM", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvCom, "매출액", "SALES_TTL", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvCom);
            DataGridViewCheckBoxAllCheck();


            //설비
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvComDetail);
            //데이터그리드뷰 체크박스 컬럼 추가
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "업체코드", "SALES_COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "업체명", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "마감일", "SALES_ENDDATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "판매수량", "SALES_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "단가", "unitprice", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvComDetail, "총판매액", "SALES_TTL", true, 80);            
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

        private void FrmCompanyEndByMonth_Load(object sender, EventArgs e)
        {
            btnset();
            ComboBinding();
            DataGridViewColumnSet();
            GetSalesCom();
            GetSalesComDetail();                                  
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

        private void GetSalesCom()
        {
            SalesComService service = new SalesComService();
            dgvCom.DataSource = null;
            dgvCom.DataSource = service.GetSalesCom();
        }
        
        private void GetSalesComDetail()
        {
            SalesComService service = new SalesComService();
            dgvComDetail.DataSource = null;
            dgvComDetail.DataSource = service.GetSalesComDetail();
        }

        private void FrmCompanyEndByMonth_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset;
            frm.ePrint -= Print;
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            
        }

        public void Search(object sender, EventArgs e)
        {
            string date = cboDate.Text + "-01";
            string company = (cboCOM.SelectedValue == null) ? "" : cboCOM.SelectedValue.ToString();
            SalesComService service = new SalesComService();
            dgvCom.DataSource = null;
            dgvComDetail.DataSource = null;
            dgvCom.DataSource = service.SearchSalesCom(date, company);
            dgvComDetail.DataSource = service.SearchSalesComDetail(date, company);
        }

        public void Reset(object sender, EventArgs e)
        {
            ComboBinding();
            GetSalesCom();
            GetSalesComDetail();
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

        private void dgvCom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string company = dgvCom.CurrentRow.Cells[1].Value.ToString();
                string date = dgvComDetail.Rows[1].Cells[2].Value.ToString();
                SalesComService service = new SalesComService();
                dgvComDetail.DataSource = null;
                dgvComDetail.DataSource = service.SearchSalesComDetail(date, company);
            }
            catch(Exception err)
            {
                return;
            }
        }
    }
}
