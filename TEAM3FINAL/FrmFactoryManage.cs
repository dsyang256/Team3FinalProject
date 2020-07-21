using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmFactoryManage : TEAM3FINAL.baseForm
    {
        public FrmFactoryManage()
        {
            InitializeComponent();
        }

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
    }
}
