using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;
using System.Linq;
using Message = TEAM3FINALVO.Message;
using TEAM3FINAL.HHW;

namespace TEAM3FINAL
{
    public partial class FrmProductOUT : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;

        public FrmProductOUT()
        {
            InitializeComponent();
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvProductOUT);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvProductOUT, "");
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객주문번호", "SALES_WORK_ORDER_ID", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "납기일", "SALES_DUEDATE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객사코드", "COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "고객사", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "도착지코드", "SALES_COM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "품목", "ITEM_CODE", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "품명", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "주문수량", "WO_PLAN_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvProductOUT, "현재고량", "INS_QTY", true, 80);
            DataGridViewUtil.DataGridViewRowNumSet(dgvProductOUT);
            DataGridViewCheckBoxAllCheck();
        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvProductOUT.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvProductOUT.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvProductOUT.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvProductOUT.Rows)
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
            frm.ePrint += Print;
        }

        //콤보박스 바인딩
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            //var listCOMPANY_TYP = (from item in commonlist where item.COMMON_PARENT == "COMPANY_TYP" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(cboCategory, listCOMPANY_TYP, "COMMON_CODE", "COMMON_NAME", "");
        }

        private void FrmProductOUT_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetProductOUT();
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    

        private void GetProductOUT()
        {
            ProductOUTService service = new ProductOUTService();
            dgvProductOUT.DataSource = null;
            dgvProductOUT.DataSource = service.GetProductOUTList();
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            
        }

        public void Search(object sender, EventArgs e)
        {
            
        }

        public void Reset(object sender, EventArgs e)
        {
            
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

        private void btnMOVE_Click(object sender, EventArgs e)
        {
            dgvProductOUT.EndEdit();
            int cnt = 0;
            //체크가 되었는지 확인
            foreach (DataGridViewRow item in dgvProductOUT.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                {
                    cnt++;
                }
            }
            if (cnt == 1)
            {
                ProductOUT_VO vo = new ProductOUT_VO();
                vo.SALES_WORK_ORDER_ID = dgvProductOUT.CurrentRow.Cells[1].Value.ToString();
                vo.SALES_COM_CODE = dgvProductOUT.CurrentRow.Cells[5].Value.ToString();
                vo.ITEM_CODE = dgvProductOUT.CurrentRow.Cells[6].Value.ToString();
                vo.INS_QTY = Convert.ToInt32(dgvProductOUT.CurrentRow.Cells[9].Value); //현재 창고 안의 재고수량
                //if(vo.INS_QTY > )
            }
            else
            {
                MessageBox.Show("하나의 항목씩만 가능");
                return;
            }
        }

        private void dgvProductOUT_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }
    }
}
