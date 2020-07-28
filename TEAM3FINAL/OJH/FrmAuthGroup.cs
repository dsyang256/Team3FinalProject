using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmAuthGroup : TEAM3FINAL.baseForm2
    {
        public FrmAuthGroup()
        {
            InitializeComponent();
        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvGroup);
            Util.AddNewColumnToDataGridView(dgvGroup, "관리자 ID", "FAC_FCLTY", true, 100);
            Util.AddNewColumnToDataGridView(dgvGroup, "이름", "FAC_TYP", true, 100);
            Util.AddNewColumnToDataGridView(dgvGroup, "부서", "FAC_CODE", true, 100);
            Util.AddNewColumnToDataGridView(dgvGroup, "그룹", "FAC_CODE", true, 100);
            //버튼 컬럼
            Util.DataGridViewBtnSet("그룹설정", dgvGroup, 0, 0);
            Util.DataGridViewBtnSet("권한설정", dgvGroup, 0, 0);
        }

        private void FrmAuthGroup_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();
        }
    }
}
