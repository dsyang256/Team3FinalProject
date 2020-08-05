using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{ 

    public partial class FrmReleaseSearch : baseForm2
    {
        
        public FrmReleaseSearch()
        {
            InitializeComponent();
        }

        private void FrmReleaseSearch_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet();
        }
        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //발주창고
            var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");

            //입고유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "입고유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");

            //입고카테고리
            var listSTATE = (from item in Commonlist where item.COMMON_PARENT == "발주상태" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(STATE, listSTATE, "COMMON_CODE", "COMMON_NAME", "");

            //품목유형
            var listITEM_TYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listITEM_TYP, "COMMON_CODE", "COMMON_NAME", "");

            //관리등급
            var listITEM_MANAGER = (from item in Commonlist where item.COMMON_PARENT == "관리등급" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_MANAGER, listITEM_MANAGER, "COMMON_CODE", "COMMON_NAME", "");


        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입출고일", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "구분", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "카테고리", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "FROM창고", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "창고", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목형태", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "관리등급", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "수불량", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단가", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "금액", "", true, 100);


        }

        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;


        }

        #endregion

       

        
    }
}
