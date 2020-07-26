using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmGroupMenu : TEAM3FINAL.baseFormPopUP
    {
        public FrmGroupMenu()
        {
            InitializeComponent();
        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvGroups);
            ////데이터그리드뷰 체크박스, 컬럼 추가
            Util.AddNewColumnToDataGridView(dgvGroups, "그룹명", "FAC_FCLTY", true, 80);
            Util.AddNewColumnToDataGridView(dgvGroups, "그룹설명", "FAC_TYP", true, 80);

            //데이터그리드뷰 초기설정
            Util.InitSettingGridView(dgvMenus);
            ////데이터그리드뷰 체크박스, 컬럼 추가
            Util.DataGridViewCheckBoxSet(dgvMenus, "허용여부");
            Util.AddNewColumnToDataGridView(dgvMenus, "메뉴명", "FAC_FCLTY", true, 80);
            Util.AddNewColumnToDataGridView(dgvMenus, "메뉴설명", "FAC_TYP", true, 80);
        }
    }
}
