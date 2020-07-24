using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmFactoryManage : TEAM3FINAL.baseForm
    {
        public FrmFactoryManage()
        {
            InitializeComponent();
        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvFactoryList);
            ////데이터그리드뷰 체크박스, 컬럼 추가
            Util.DataGridViewCheckBoxSet(dgvFactoryList, "");
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설군", "FAC_FCLTY", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설구분", "FAC_TYP", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설코드", "FAC_CODE", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설명", "FAC_NAME", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "상위시설", "FAC_FCLTY_PARENT", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설설명", "FAC_DESC", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "유무상구분", "FAC_FREE_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "시설구분순서", "FAC_TYP_SORT", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "수요차감", "FAC_DEMAND_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "공정차감", "FAC_PROCS_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "자재차감여부", "FAC_MTRL_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "업체코드", "COM_CODE", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "사용유무", "FAC_USE_YN", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "최종수정자", "FAC_LAST_MDFR", true, 80);
            Util.AddNewColumnToDataGridView(dgvFactoryList, "최종수정시간", "FAC_LAST_MDFY", true, 80);
        }
                
        private void FrmFactoryManage_Load(object sender, EventArgs e)
        {
            btnset();
            DataGridViewColumnSet();
            GetFactoryInfo();
        }

        //그리드뷰에 DB에서 가져온 List 바인딩
        private void GetFactoryInfo()
        {
            FactoryService service = new FactoryService();
            dgvFactoryList.DataSource = null;
            dgvFactoryList.DataSource = service.GetFactoryInfo();
        }

        private void btnset()
        {
            // 버튼 이벤트 추가 메서드
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
        }

        #region ****메인 버튼 이벤트****
        private void Search(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        private void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmFactoryPopUp frm = new FrmFactoryPopUp();
                frm.ShowDialog();
                if(frm.DialogResult == DialogResult.OK)
                {
                    GetFactoryInfo();
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                //수정 시 여러개의 체크박스를 선택하는것을 막음
                dgvFactoryList.EndEdit();
                string sb = string.Empty;
                int cnt = 0;
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvFactoryList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        sb = item.Cells[3].Value.ToString();
                        cnt++;
                    }
                }
                if (cnt == 1 ) //하나일 경우 PopUp창 띄움
                {
                    FrmFactoryPopUp frm = new FrmFactoryPopUp();
                    frm.Update = true;
                    frm.FAC_CODE = dgvFactoryList.CurrentRow.Cells[3].Value.ToString();
                    frm.FAC_FCLTY = dgvFactoryList.CurrentRow.Cells[1].Value.ToString();
                    frm.FAC_FCLTY_PARENT = dgvFactoryList.CurrentRow.Cells[5].Value.ToString();
                    frm.FAC_NAME = dgvFactoryList.CurrentRow.Cells[4].Value.ToString();
                    frm.FAC_TYP = dgvFactoryList.CurrentRow.Cells[2].Value.ToString();
                    frm.FAC_FREE_YN = dgvFactoryList.CurrentRow.Cells[7].Value.ToString();
                    frm.FAC_TYP_SORT = Convert.ToInt32(dgvFactoryList.CurrentRow.Cells[8].Value);
                    frm.FAC_DEMAND_YN = dgvFactoryList.CurrentRow.Cells[9].Value.ToString();
                    frm.FAC_PROCS_YN = dgvFactoryList.CurrentRow.Cells[10].Value.ToString();
                    frm.FAC_MTRL_YN = dgvFactoryList.CurrentRow.Cells[11].Value.ToString();
                    frm.FAC_LAST_MDFR = dgvFactoryList.CurrentRow.Cells[14].Value.ToString();
                    frm.FAC_LAST_MDFY = dgvFactoryList.CurrentRow.Cells[15].Value.ToString();
                    frm.FAC_USE_YN = dgvFactoryList.CurrentRow.Cells[13].Value.ToString();
                    frm.FAC_DESC = dgvFactoryList.CurrentRow.Cells[6].Value.ToString();
                    frm.COM_CODE = dgvFactoryList.CurrentRow.Cells[12].Value.ToString();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("하나의 항목씩만 수정 가능");
                    return;
                }
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                dgvFactoryList.EndEdit();
                StringBuilder sb = new StringBuilder();
                int cnt = 0;
                //품목 선택후 List를 전달
                foreach (DataGridViewRow item in dgvFactoryList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
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
                    FactoryService service = new FactoryService();
                    if (service.DeleteFactory("FACTORY", "FAC_CODE", sb) == "C200")
                    {
                        MessageBox.Show("삭제 완료");
                        GetFactoryInfo();
                    }
                }          
            }
            
        }
        #endregion
    }
}
