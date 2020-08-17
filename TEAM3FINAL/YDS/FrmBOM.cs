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
    public partial class FrmBOM : baseForm2, CommonBtn
    {
        /// <summary>
        /// 그리드뷰 체크 박스 
        /// </summary>
        CheckBox headerChk;
        public FrmBOM()
        {
            InitializeComponent();
        }
        private void FrmBOM_Load(object sender, EventArgs e)
        {
            BtnSet();
            DataGridViewColumnSet();
            DataGridViewBinding();
            ComboBinding();
        }
        /// <summary>
        /// 삭제 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvBOM.EndEdit();
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                //품목 선택후 List를 전달
                foreach (DataGridViewRow item in dgvBOM.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value))
                    {
                        sb.Append(item.Cells[2].Value.ToString() + "@");
                        cnt++;
                    }
                }
                if (sb.Length < 1)
                {
                    MessageBox.Show("미사용 항목을 선택하여 주십시오.");
                    return;
                }
                sb.Remove(sb.Length - 1, 1);
                if (MessageBox.Show($"총 {cnt}개의 항목을 미사용 하겠습니까?? 하위항목도 미사용됨니다. ", "미사용", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BOMService service = new BOMService();
                    if (service.DeleteBOM(sb))
                    {
                        MessageBox.Show("미사용 완료");
                        DataGridViewBinding();
                    }
                }
            }
        }
        /// <summary>
        /// 등록 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmBOMPopUp frm = new FrmBOMPopUp();
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewBinding();
                }
            }
        }
        /// <summary>
        /// 프린트 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Print(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        /// <summary>
        /// 리셋 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Reset(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                DataGridViewBinding();
            }
        }
        /// <summary>
        /// 조회 버튼 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                if(ITEM_NAEM.Text.Length <1)
                {
                    MessageBox.Show("검색하실 품목명을 입력해주세요");
                    return;
                }
                BOMService bom = new BOMService();
                dgvBOM.DataSource = bom.SearchBOM(day.Value.ToShortDateString(), ITEM_NAEM.Text, BOM_USE_YN.Text);
            }
        }
        /// <summary>
        /// 업데이트 버튼 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvBOM.EndEdit();
                int cnt = 0;
                int code = 0;
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvBOM.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[1].Value))
                    {
                        //MessageBox.Show(item.Cells[2].ToString());
                        code = Convert.ToInt32(item.Cells[2].Value);
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
                    FrmBOMPopUp frm = new FrmBOMPopUp(code);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Reset(null, null);
                    }
                }
            }
        }
        /// <summary>
        /// 버튼 이벤트 셋
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
            var listCOM_USE_YN = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_USE_YN, listCOM_USE_YN, "COMMON_CODE", "COMMON_NAME", "");



        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgvBOM);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvBOM, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "BOM_CODE", "BOM_CODE", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "품목유형", "ITEM_TYP", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "단위", "ITEM_UNIT", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "소요량", "BOM_QTY", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "BOM레벨", "Lvl", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "시작일", "BOM_STARTDATE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "종료일", "BOM_ENDDATE", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "사용여부", "BOM_USE_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "소요계획", "BOM_PLAN_YN", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "자동차감", "BOM_AUTOREDUCE_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "설비", "FCLTS_CODE", true, 140);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "설비명", "FCLTS_NAME", true, 140);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvBOM, "규격", "ITEM_STND", true, 140);
            DataGridViewCheckBoxAllCheck();

        }
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding()
        {
            dgvBOM.DataSource = null;
            BOMService bom = new BOMService();
            dgvBOM.DataSource = bom.SelectBOM();
        }
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvBOM.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvBOM.Controls.Add(headerChk);
        }
        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvBOM.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvBOM.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
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
        private void FrmBOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnUnSet();
        }
    }
}
