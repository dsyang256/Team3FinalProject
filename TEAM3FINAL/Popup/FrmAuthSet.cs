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
    public partial class FrmAuthSet : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        List<ComboItemVO> Commonlist = null;
        #endregion
        public FrmAuthSet()
        {
            InitializeComponent();
        }

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            Commonlist = service.GetCmCode();
            //콤보박스 바인딩 - 부서명
            var codelist = (from item in Commonlist where item.COMMON_PARENT == "DEP" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboDept, codelist, "COMMON_CODE", "COMMON_NAME");

        }

        //그리드뷰 컬럼 생성
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정

            //관리자 검색
            Util.InitSettingGridView(dgvUsers);
            Util.AddNewColumnToDataGridView(dgvUsers, "관리자 ID", "FAC_FCLTY", true, 100);
            Util.AddNewColumnToDataGridView(dgvUsers, "이름", "FAC_TYP", true, 100);
            //권한 설정
            Util.InitSettingGridView(dgvRight);
            Util.AddNewColumnToDataGridView(dgvRight, "메뉴ID", "FAC_FCLTY", false, 100);
            Util.AddNewColumnToDataGridView(dgvRight, "메뉴명", "FAC_FCLTY", true, 100);
            Util.DataGridViewCheckBoxSet(dgvRight, "등록");
            Util.DataGridViewCheckBoxSet(dgvRight, "읽기");
            Util.DataGridViewCheckBoxSet(dgvRight, "수정");
            Util.DataGridViewCheckBoxSet(dgvRight, "삭제");
            Util.DataGridViewCheckBoxSet(dgvRight, "인쇄");

            //그룹 설정
            Util.InitSettingGridView(dgvGroup);
            Util.DataGridViewCheckBoxSet(dgvGroup, "  ");
            Util.AddNewColumnToDataGridView(dgvGroup, "그룹코드", "FAC_FCLTY", false, 100);
            Util.AddNewColumnToDataGridView(dgvGroup, "그룹명", "FAC_TYP", true, 150);
            Util.AddNewColumnToDataGridView(dgvGroup, "상세설명", "FAC_TYP", true, 300);
        }

        #endregion

        private void FrmAuthSet_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();
        }
    }
}
