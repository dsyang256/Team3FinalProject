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
using DevExpress.XtraReports.UI;

namespace TEAM3FINAL
{
    public partial class FrmItem : TEAM3FINAL.baseForm2  ,CommonBtn
    {
        
        CheckBox headerChk;
        public FrmItem()
        {
            InitializeComponent();
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            BtnSet();
            ComboBinding();
            DataGridViewColumnSet();
            DataGridViewBinding();
            ((FrmMAIN)this.MdiParent).Readed += Readed_BarCode;

        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string msg = e.ReadMsg.Replace("%O","_").Trim();
                ((FrmMAIN)this.MdiParent).ClearStrings();
      
                string name = "";
                foreach (DataGridViewRow item in dgvitem.Rows)
                {
                    if (item.Cells[3].Value.ToString() == msg)
                    {
                        item.Cells[1].Value = true;
                        item.Selected = true;
                        name = item.Cells[4].Value.ToString();
                    }
                }
                if (name.Length < 1)
                {
                    MessageBox.Show("항목이 없습니다 다시 확인해주세요.");
                    return;
                }
                if (MessageBox.Show($"{name} - 품목을 수정하시겠습니까?", "수정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Update(null, null);
            }
        }


        /// <summary>
        /// 버튼 이벤트 델리게이트 추가
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

        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var listCOM_REORDER = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_REORDER, listCOM_REORDER, "COMMON_CODE", "COMMON_NAME", "");

            //납품유형
            var listCOM_DLVR = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_DLVR, listCOM_DLVR, "COMMON_CODE", "COMMON_NAME", "");

            //입고창고
            var listWRHS_IN = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_IN, listWRHS_IN, "COMMON_CODE", "COMMON_NAME", "");

            //출고창고
            var listWRHS_OUT = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_WRHS_OUT, listWRHS_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //담당자
            var listMANAGER = (from item in Commonlist where item.COMMON_PARENT == "담당자" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listMANAGER, "COMMON_CODE", "COMMON_NAME", "");

            //사용여부
            var listYN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_USE_YN, listYN, "COMMON_CODE", "COMMON_NAME", "");

            //품목유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");




        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgvitem);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvitem, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품목유형", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "규격", "ITEM_STND", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단위", "ITEM_UNIT", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단위수량", "ITEM_QTY_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "환산단위", "ITEM_UNIT_CNVR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "환산수량", "ITEM_QTY_CNVR", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "수입검사여부", "ITEM_INCOME_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "공정검사여부", "ITEM_PROCS_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "출하검사여부", "ITEM_XPORT_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "단종유무", "ITEM_DSCN_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "유무상구분", "ITEM_FREE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "납품업체", "ITEM_COM_DLVR", true, 140);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvitem, "발주업체", "ITEM_COM_REORDER", true, 140);
            DataGridViewCheckBoxAllCheck();
           

        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            ItemService item = new ItemService();
            dgvitem.DataSource = item.AllITEM();
        }

        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvitem.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvitem.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvitem.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvitem.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        /// <summary>
        /// 입력 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmItemPopUp frm = new FrmItemPopUp();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Search(null, null);
                }
            }
        }
        /// <summary>
        /// 조회 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                ITEM_VO vo = new ITEM_VO();
                vo.ITEM_NAME = ITEM_NAME.Text;
                vo.ITEM_STND = ITEM_STND.Text;
                vo.ITEM_COM_REORDER = ITEM_COM_REORDER.Text;
                vo.ITEM_COM_DLVR = ITEM_COM_DLVR.Text;
                vo.ITEM_WRHS_IN = ITEM_WRHS_IN.Text;
                vo.ITEM_WRHS_OUT = ITEM_WRHS_OUT.Text;
                vo.ITEM_MANAGER = ITEM_MANAGER.Text;
                vo.ITEM_TYP = ITEM_TYP.Text;
                vo.ITEM_USE_YN = ITEM_USE_YN.Text;

                dgvitem.DataSource = null;
                ItemService item = new ItemService();
                dgvitem.DataSource = item.GetSearchItem(vo);
            }
        }
        /// <summary>
        /// 리셋 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            ITEM_NAME.Text = "";
            ITEM_STND.Text = "";
            ITEM_COM_REORDER.SelectedIndex = -1;
            ITEM_COM_DLVR.SelectedIndex = -1;
            ITEM_WRHS_IN.SelectedIndex = -1;
            ITEM_WRHS_OUT.SelectedIndex = -1;
            ITEM_MANAGER.SelectedIndex = -1;
            ITEM_TYP.SelectedIndex = -1;
            ITEM_USE_YN.SelectedIndex = -1;
            DataGridViewBinding();
        }
        /// <summary>
        /// 업데이트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvitem.EndEdit();
                int cnt = 0;
                string code = "";
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvitem.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value))
                    {
                        code = item.Cells[3].Value.ToString();
                        cnt++;
                    }
                }
                if (cnt < 1)
                {
                    MessageBox.Show("수정할 항목을 선택해주세요.");
                    return;
                }
                if (cnt != 1)
                {
                    MessageBox.Show("하나의 항목씩만 수정 가능 합니다.");
                    return;
                }
                else if (cnt == 1)
                {
                    FrmItemPopUp frm = new FrmItemPopUp(code);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Search(null, null);
                    }
                }
            }
        }
        /// <summary>
        /// 삭제 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvitem.EndEdit();
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                //품목 선택후 List를 전달
                foreach (DataGridViewRow item in dgvitem.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value))
                    {
                        sb.Append(item.Cells[3].Value.ToString() + "@");
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
                    ItemService service = new ItemService();
                    if (service.DeleteItem(sb))
                    {
                        MessageBox.Show("삭제 완료");
                        DataGridViewBinding();
                    }
                }
            }
        }
        /// <summary>
        /// 프린트 버튼 이벤드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                string name = "";
                foreach (DataGridViewRow item in dgvitem.Rows)
                {
                    if (item.Cells[3].Value.ToString() == "CHAIR_01")
                    {
                        item.Cells[1].Value = true;
                        name = item.Cells[4].Value.ToString();
                    }
                }
                if (MessageBox.Show($"{name} - 품목을 수정하시겠습니까?", "수정확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Update(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> chkList = new List<string>();

            for (int i = 0; i < dgvitem.Rows.Count; i++)
            {
                bool isCellChecked = (bool)dgvitem.Rows[i].Cells[1].EditedFormattedValue;
                if (isCellChecked)
                {
                    chkList.Add("'"+dgvitem.Rows[i].Cells[3].Value.ToString()+ "'"); ;
                }
            }
            if (chkList.Count == 0)
            {
                MessageBox.Show("출력할 바코드를 선택해주세요.");
                return;
            }

            string strChkBarCodes = string.Join(",", chkList);
            
            ItemService service = new ItemService();
            XtraItemList rpt = new XtraItemList();
            DataTable dt = service.GetBaCodeItemList(strChkBarCodes);
            rpt.Parameters["uName"].Value = LoginInfo.UserInfo.LI_NAME;
            rpt.DataSource = dt;
            rpt.CreateDocument();
            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            { 
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void dgvitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
