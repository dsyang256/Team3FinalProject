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
            DataGridViewColumnSet();
            GetFactoryInfo();
        }

        //그리드뷰에 DB에서 가져온 List 바인딩
        private void GetFactoryInfo()
        {
            FactoryService service = new FactoryService();
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
            if(((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        private void Insert(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {
                FrmFactoryPopUp frm = new FrmFactoryPopUp();
            }
        }

        private void Delete(object sender, EventArgs e)
        {
            if (((FrmMAIN)this.MdiParent).ActiveMdiChild == this)
            {

            }
        }
        #endregion
    }
}
